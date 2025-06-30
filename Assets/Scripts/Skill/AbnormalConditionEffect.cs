using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Skill
{
    public class AbnormalConditionEffect : IDisposable
    {
        public bool _CanMove;
        private bool _canSkill;
        private bool _canChangeCharacter;
        private bool _randomMove;
        private readonly List<int> _charmedCharacterIds = new();
        private readonly Dictionary<AbnormalCondition, bool> _abnormalConditionInProgress = new();

        [Inject]
        public AbnormalConditionEffect()
        {
            _CanMove = true;
        }

        private const float CantMoveTime = 0.5f;

        public void InAsTask
        (
            Animator animator,
            AbnormalCondition abnormalCondition,
            float effectTime
        )

        {
            switch (abnormalCondition)
            {
                case AbnormalCondition.Paralysis:
                    Paralysis(animator, effectTime);
                    break;
                case AbnormalCondition.Poison:
                    break;
                case AbnormalCondition.Frozen:
                    break;
                case AbnormalCondition.Confusion:
                    break;
                case AbnormalCondition.NockBack:
                    break;
                case AbnormalCondition.Charm:
                    break;
                case AbnormalCondition.Miasma:
                    break;
                case AbnormalCondition.Darkness:
                    break;
                case AbnormalCondition.Sealed:
                    break;
                case AbnormalCondition.LifeSteal:
                    break;
                case AbnormalCondition.Curse:
                    break;
                case AbnormalCondition.HellFire:
                    break;
                case AbnormalCondition.Fear:
                    break;
                case AbnormalCondition.TimeStop:
                    break;
                case AbnormalCondition.Apraxia:
                    break;
                case AbnormalCondition.SoakingWet:
                    break;
                case AbnormalCondition.Burning:
                    break;
                case AbnormalCondition.ParalyzingThunder:
                    break;
                case AbnormalCondition.All:
                    break;
                case AbnormalCondition.None:
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

        public void Dispose()
        {
            _charmedCharacterIds.Clear();
        }
    }
}