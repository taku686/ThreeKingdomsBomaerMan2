using System;
using System.Collections.Generic;
using System.Threading;
using Character;
using Common.Data;
using Cysharp.Threading.Tasks;
using Player.Common;
using UniRx;
using UnityEngine;
using UseCase;
using Zenject;
using Random = UnityEngine.Random;

namespace Skill
{
    public class AbnormalConditionEffectUseCase : IDisposable
    {
        public bool _CanMove { get; private set; }
        public bool _IsBurning { get; private set; }
        public bool _RandomMove { get; private set; }
        public readonly ReactiveProperty<bool> _canPutBombReactiveProperty = new(true);
        public readonly ReactiveProperty<bool> _canSkillReactiveProperty = new(true);
        public readonly ReactiveProperty<bool> _canCharacterChangeReactiveProperty = new(true);

        private const float OneSecond = 1f;
        private const float PoisonDamageRate = 0.02f; // 最大HPの2%
        private const int BurningDamage = 3; // 毎秒3ダメージ

        public readonly List<int> _charmedCharacterIds = new();
        private readonly Dictionary<AbnormalCondition, bool> _abnormalConditionInProgress = new();

        [Inject]
        public AbnormalConditionEffectUseCase()
        {
            Initialize();
        }

        private const float CantMoveTime = 0.5f;

        public void InAsTask
        (
            AbnormalCondition abnormalCondition,
            Animator animator,
            PlayerStatusInfo myStatusInfo,
            PlayerConditionInfo hitPlayerConditionInfo,
            float effectTime
        )
        {
            switch (abnormalCondition)
            {
                case AbnormalCondition.Paralysis:
                    Paralysis(animator, effectTime);
                    break;
                case AbnormalCondition.Poison:
                    Poison(myStatusInfo, effectTime);
                    break;
                case AbnormalCondition.Frozen:
                    Frozen(myStatusInfo, effectTime);
                    break;
                case AbnormalCondition.Confusion:
                    Confusion(effectTime);
                    break;
                case AbnormalCondition.Charm:
                    Charm();
                    break;
                case AbnormalCondition.Miasma:
                    Miasma(myStatusInfo, effectTime);
                    break;
                case AbnormalCondition.Darkness:
                    Darkness();
                    break;
                case AbnormalCondition.LifeSteal:
                    LifeSteal();
                    break;
                case AbnormalCondition.HellFire:
                    HellFire(myStatusInfo, animator, effectTime);
                    break;
                case AbnormalCondition.TimeStop:
                    Stigmata(effectTime);
                    break;
                case AbnormalCondition.SoakingWet:
                    SoakingWet(effectTime);
                    break;
                case AbnormalCondition.Burning:
                    Burning(myStatusInfo, effectTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(abnormalCondition), abnormalCondition, null);
            }
        }

        #region AbnormalCondition Methods

        /// <summary>
        /// 一時的に行動不能になる（2～4秒に1回発生する）
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="duration"></param>
        private void Paralysis(Animator animator, float duration)
        {
            var cts = new CancellationTokenSource();

            Observable
                .EveryUpdate()
                .Where(_ => !_abnormalConditionInProgress[AbnormalCondition.Paralysis])
                .SelectMany(_ => RandomMoveStop(AbnormalCondition.Paralysis, animator, cts.Token).ToObservable())
                .Subscribe()
                .AddTo(cts.Token);

            Observable.Timer(TimeSpan.FromSeconds(duration))
                .Subscribe(_ =>
                {
                    _CanMove = true;
                    cts.Cancel();
                    cts.Dispose();
                    cts = null;
                })
                .AddTo(cts.Token);
        }

        /// <summary>
        /// 最大HPの２％のダメージを毎秒受け続ける
        /// </summary>
        private void Poison(PlayerStatusInfo playerStatusInfo, float effectTime)
        {
            var maxHp = playerStatusInfo._hp.Value.Item1;
            var damageAmount = Mathf.CeilToInt(maxHp * PoisonDamageRate);
            ContinuousDamage(playerStatusInfo, effectTime, damageAmount);
        }

        /// <summary>
        /// 防御と耐性、移動速度が半分になる
        /// </summary>
        private static void Frozen(PlayerStatusInfo playerStatusInfo, float effectTime)
        {
            HalvedStatus(StatusType.Defense, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.Resistance, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.Speed, playerStatusInfo, effectTime);
        }

        /// <summary>
        /// 行動が上下左右反対になる
        /// </summary>
        private void Confusion(float effectTime)
        {
            _RandomMove = true;
            Observable
                .Timer(TimeSpan.FromSeconds(effectTime))
                .Subscribe(_ => { _RandomMove = false; });
        }


        /// <summary>
        /// 魅了している敵のボムの爆風ダメージを無効にする
        /// </summary>
        private void Charm()
        {
        }

        /// <summary>
        /// 攻撃、ボム数、火力を半減にする
        /// </summary>
        private static void Miasma(PlayerStatusInfo playerStatusInfo, float effectTime)
        {
            HalvedStatus(StatusType.Attack, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.BombLimit, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.FireRange, playerStatusInfo, effectTime);
        }


        /// <summary>
        /// 視界が悪くなる
        /// </summary>
        private void Darkness()
        {
        }

        /// <summary>
        /// 与えたダメージの10％分回復する
        /// </summary>
        private void LifeSteal()
        {
        }

        /// <summary>
        /// ボム設置ができなくなる
        /// </summary>
        private void SoakingWet(float effectTime)
        {
            _canPutBombReactiveProperty.Value = false;

            Observable
                .Timer(TimeSpan.FromSeconds(effectTime))
                .Subscribe(_ => { _canPutBombReactiveProperty.Value = true; });
        }

        /// <summary>
        /// 毎秒10ダメージ貰い続ける
        /// ボムの爆破時間が短くなる
        /// </summary>
        private void Burning(PlayerStatusInfo playerStatusInfo, float effectTime)
        {
            ContinuousDamage
            (
                playerStatusInfo,
                effectTime,
                BurningDamage
            );

            _IsBurning = true;

            Observable
                .Timer(TimeSpan.FromSeconds(effectTime))
                .Subscribe(_ => { _IsBurning = false; });
        }

        /// <summary>
        /// ・スキルが使えなくなる
        ///・一時的に行動不能になる
        ///・全ステータスが半減される
        /// </summary>
        private void HellFire
        (
            PlayerStatusInfo playerStatusInfo,
            Animator animator,
            float effectTime
        )
        {
            var cts = new CancellationTokenSource();

            // スキルが使えなくなる
            _canSkillReactiveProperty.Value = false;

            // 一時的に行動不能になる
            Observable
                .EveryUpdate()
                .Where(_ => !_abnormalConditionInProgress[AbnormalCondition.HellFire])
                .SelectMany(_ => RandomMoveStop(AbnormalCondition.HellFire, animator, cts.Token).ToObservable())
                .Subscribe()
                .AddTo(cts.Token);

            // 全ステータスが半減される
            HalvedStatus(StatusType.Attack, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.Speed, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.BombLimit, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.FireRange, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.Defense, playerStatusInfo, effectTime);
            HalvedStatus(StatusType.Resistance, playerStatusInfo, effectTime);

            // スキルが使えるようになるまでの時間を設定
            Observable
                .Timer(TimeSpan.FromSeconds(effectTime))
                .Subscribe(_ =>
                {
                    _canSkillReactiveProperty.Value = true;
                    _CanMove = true;
                    cts.Cancel();
                    cts.Dispose();
                });
        }

        /// <summary>
        /// ・スキルが使えなくなる
        ///・ボム設置ができなくなる
        ///・キャラクターの変更ができなくなる
        /// </summary>
        private void Stigmata(float effectTime)
        {
            _canSkillReactiveProperty.Value = false;
            _canPutBombReactiveProperty.Value = false;
            _canCharacterChangeReactiveProperty.Value = false;

            Observable
                .Timer(TimeSpan.FromSeconds(effectTime))
                .Subscribe(_ =>
                {
                    _canSkillReactiveProperty.Value = true;
                    _canPutBombReactiveProperty.Value = true;
                    _canCharacterChangeReactiveProperty.Value = true;
                });
        }

        #endregion

        private void Initialize()
        {
            _abnormalConditionInProgress[AbnormalCondition.Paralysis] = false;
            _abnormalConditionInProgress[AbnormalCondition.Poison] = false;
            _abnormalConditionInProgress[AbnormalCondition.Frozen] = false;
            _abnormalConditionInProgress[AbnormalCondition.Confusion] = false;
            _abnormalConditionInProgress[AbnormalCondition.Charm] = false;
            _abnormalConditionInProgress[AbnormalCondition.Miasma] = false;
            _abnormalConditionInProgress[AbnormalCondition.Darkness] = false;
            _abnormalConditionInProgress[AbnormalCondition.LifeSteal] = false;
            _abnormalConditionInProgress[AbnormalCondition.HellFire] = false;
            _abnormalConditionInProgress[AbnormalCondition.TimeStop] = false;
            _abnormalConditionInProgress[AbnormalCondition.SoakingWet] = false;
            _abnormalConditionInProgress[AbnormalCondition.Burning] = false;

            _CanMove = true;
        }

        private async UniTask RandomMoveStop
        (
            AbnormalCondition abnormalCondition,
            Animator animator,
            CancellationToken cts
        )
        {
            _abnormalConditionInProgress[abnormalCondition] = true;
            var randomTime = Random.Range(2f, 4f);
            await UniTask.Delay((int)(randomTime * 1000), cancellationToken: cts);
            _CanMove = false;
            animator.SetTrigger(GameCommonData.HitParameterName);
            await UniTask.Delay((int)(CantMoveTime * 1000), cancellationToken: cts);
            _CanMove = true;
            _abnormalConditionInProgress[abnormalCondition] = false;
        }

        private static void HalvedStatus
        (
            StatusType statusType,
            PlayerStatusInfo playerStatusInfo,
            float effectTime
        )
        {
            var originValue = playerStatusInfo.GetStatusValue(statusType);
            var halfValue = Mathf.FloorToInt(originValue / 2f);
            playerStatusInfo.SetStatusValue(statusType, halfValue);
            Observable
                .Timer(TimeSpan.FromSeconds(effectTime))
                .Subscribe(_ => { playerStatusInfo.SetStatusValue(statusType, originValue); });
        }

        private void ContinuousDamage
        (
            PlayerStatusInfo playerStatusInfo,
            float effectTime,
            int damageAmount
        )
        {
            var cts = new CancellationTokenSource();

            Observable
                .Interval(TimeSpan.FromSeconds(OneSecond))
                .Subscribe(_ =>
                {
                    HpCalculateUseCase.InAsTask
                    (
                        playerStatusInfo,
                        damageAmount,
                        () =>
                        {
                            cts.Cancel();
                            cts.Dispose();
                        });
                })
                .AddTo(cts.Token);

            Observable
                .Timer(TimeSpan.FromSeconds(effectTime))
                .Subscribe(_ =>
                {
                    cts.Cancel();
                    cts.Dispose();
                })
                .AddTo(cts.Token);
        }

        public void Dispose()
        {
            _charmedCharacterIds.Clear();
        }
    }
}