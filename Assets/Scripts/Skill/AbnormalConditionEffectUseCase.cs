using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Player.Common;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UseCase;
using Zenject;
using Random = UnityEngine.Random;

namespace Skill
{
    public class AbnormalConditionEffectUseCase : IDisposable
    {
        public bool _CanMove { get; private set; }
        private bool _canSkill;
        private bool _canChangeCharacter;
        public ReactiveProperty<bool> _CanPutBombReactiveProperty { get; } = new(true);
        public bool _RandomMove { get; private set; }

        private const float PoisonDamageInterval = 1f;
        private const float PoisonDamageRate = 0.02f; // 最大HPの2%

        private readonly List<int> _charmedCharacterIds = new();
        private readonly Dictionary<AbnormalCondition, bool> _abnormalConditionInProgress = new();

        [Inject]
        public AbnormalConditionEffectUseCase()
        {
            _CanMove = true;
        }

        private const float CantMoveTime = 0.5f;

        public void InAsTask
        (
            AbnormalCondition abnormalCondition,
            Animator animator,
            PlayerCore.PlayerStatusInfo playerStatusInfo,
            float effectTime
        )
        {
            switch (abnormalCondition)
            {
                case AbnormalCondition.Paralysis:
                    Paralysis(animator, effectTime);
                    break;
                case AbnormalCondition.Poison:
                    Poison(playerStatusInfo, effectTime);
                    break;
                case AbnormalCondition.Frozen:
                    Frozen(playerStatusInfo, effectTime);
                    break;
                case AbnormalCondition.Confusion:
                    Confusion(effectTime);
                    break;
                case AbnormalCondition.Charm:
                    break;
                case AbnormalCondition.Miasma:
                    Miasma(playerStatusInfo, effectTime);
                    break;
                case AbnormalCondition.Darkness:
                    break;
                case AbnormalCondition.LifeSteal:
                    break;
                case AbnormalCondition.HellFire:
                    break;
                case AbnormalCondition.TimeStop:
                    break;
                case AbnormalCondition.SoakingWet:
                    SoakingWet(effectTime);
                    break;
                case AbnormalCondition.Burning:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(abnormalCondition), abnormalCondition, null);
            }
        }

        /// <summary>
        /// 一時的に行動不能になる（2～4秒に1回発生する）
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="duration"></param>
        private void Paralysis(Animator animator, float duration)
        {
            var cts = new CancellationTokenSource();
            _abnormalConditionInProgress[AbnormalCondition.Paralysis] = false;

            Observable
                .EveryUpdate()
                .Where(_ => !_abnormalConditionInProgress[AbnormalCondition.Paralysis])
                .SelectMany(_ => RandomMoveStop(animator, cts.Token).ToObservable())
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
        private static void Poison(PlayerCore.PlayerStatusInfo playerStatusInfo, float effectTime)
        {
            var cts = new CancellationTokenSource();
            var maxHp = playerStatusInfo._Hp.Value.Item1;
            var damageAmount = Mathf.CeilToInt(maxHp * PoisonDamageRate);

            Observable
                .Interval(TimeSpan.FromSeconds(PoisonDamageInterval))
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


        /// <summary>
        /// 防御と耐性、移動速度が半分になる
        /// </summary>
        private static void Frozen(PlayerCore.PlayerStatusInfo playerStatusInfo, float effectTime)
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
        private static void Miasma(PlayerCore.PlayerStatusInfo playerStatusInfo, float effectTime)
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
            _CanPutBombReactiveProperty.Value = false;

            Observable
                .Timer(TimeSpan.FromSeconds(effectTime))
                .Subscribe(_ => { _CanPutBombReactiveProperty.Value = true; });
        }

        /// <summary>
        /// 毎秒10ダメージ貰い続ける
        /// ボムの爆破時間が短くなる
        /// </summary>
        private void Burning()
        {
        }

        /// <summary>
        /// ・スキルが使えなくなる
        ///・一時的に行動不能になる
        ///・全ステータスが半減される
        /// </summary>
        private void HellFire()
        {
        }

        /// <summary>
        /// ・スキルが使えなくなる
        ///・ボム設置ができなくなる
        ///・キャラクターの変更ができなくなる
        /// </summary>
        private void Stigmata()
        {
        }

        private async UniTask RandomMoveStop(Animator animator, CancellationToken cts)
        {
            _abnormalConditionInProgress[AbnormalCondition.Paralysis] = true;
            var randomTime = Random.Range(2f, 4f);
            await UniTask.Delay((int)(randomTime * 1000), cancellationToken: cts);
            _CanMove = false;
            animator.SetTrigger(GameCommonData.HitParameterName);
            await UniTask.Delay((int)(CantMoveTime * 1000), cancellationToken: cts);
            _CanMove = true;
            _abnormalConditionInProgress[AbnormalCondition.Paralysis] = false;
        }

        private static void HalvedStatus
        (
            StatusType statusType,
            PlayerCore.PlayerStatusInfo playerStatusInfo,
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

        public void Dispose()
        {
            _charmedCharacterIds.Clear();
        }
    }
}