using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Skill
{
    public class AbnormalConditionEffectUseCase
    {
        private bool _canMove;
        private bool _canSkill;
        private bool _canChangeCharacter;
        private bool _randomMove;
        private List<int> _charmedCharacterIds = new();
        private const float CantMoveTime = 0.5f;

        /// <summary>
        /// 一時的に行動不能になる（2～4秒に1回発生する）
        /// </summary>
        /// <param name="cancellationToken"></param>
        public void Paralysis(CancellationToken cancellationToken)
        {
            Observable
                .EveryUpdate()
                .Where(_ => !_canMove)
                .SelectMany(_ => RandomMoveStop().ToObservable())
                .Subscribe()
                .AddTo(cancellationToken);
        }

        private async UniTask RandomMoveStop()
        {
            var randomTime = Random.Range(2f, 4f);
            await UniTask.Delay((int)(randomTime * 1000));
            _canMove = false;
            await UniTask.Delay((int)(CantMoveTime * 1000));
            _canMove = true;
        }
    }
}