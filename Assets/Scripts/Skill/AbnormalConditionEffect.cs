using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;
using Random = UnityEngine.Random;

namespace Skill
{
    public class AbnormalConditionEffect : IDisposable
    {
        public bool _canMove;
        private bool _canSkill;
        private bool _canChangeCharacter;
        private bool _randomMove;
        private readonly List<int> _charmedCharacterIds = new();
        private readonly Dictionary<AbnormalCondition, bool> _abnormalConditionInProgress = new();

        [Inject]
        public AbnormalConditionEffect()
        {
            _canMove = true;
        }

        private const float CantMoveTime = 0.5f;

        public void InAsTask(AbnormalCondition abnormalCondition, float effectTime)
        {
            switch (abnormalCondition)
            {
                case AbnormalCondition.Paralysis:
                    Paralysis(effectTime);
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
        /// <param name="duration"></param>
        private void Paralysis(float duration)
        {
            var cts = new CancellationTokenSource();
            var updateObservable = Observable.EveryUpdate();
            _abnormalConditionInProgress[AbnormalCondition.Paralysis] = false;

            updateObservable
                .Where(_ => !_abnormalConditionInProgress[AbnormalCondition.Paralysis])
                .SelectMany(_ => RandomMoveStop().ToObservable())
                .Subscribe()
                .AddTo(cts.Token);

            Observable.Timer(TimeSpan.FromSeconds(duration))
                .Subscribe(_ =>
                {
                    cts.Cancel();
                    cts.Dispose();
                    cts = null;
                })
                .AddTo(cts.Token);
        }

        private async UniTask RandomMoveStop()
        {
            _abnormalConditionInProgress[AbnormalCondition.Paralysis] = true;
            var randomTime = Random.Range(2f, 4f);
            await UniTask.Delay((int)(randomTime * 1000));
            _canMove = false;
            await UniTask.Delay((int)(CantMoveTime * 1000));
            _canMove = true;
            _abnormalConditionInProgress[AbnormalCondition.Paralysis] = false;
        }

        public void Dispose()
        {
            _charmedCharacterIds.Clear();
        }
    }
}