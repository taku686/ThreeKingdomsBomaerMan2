using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UniRx;
using UnityEngine;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerDeadState : State
        {
            protected override void OnEnter(State prevState)
            {
                PlayBackAnimation();
            }

            private void PlayBackAnimation()
            {
                Owner.animator.SetTrigger(GameCommonData.DeadHashKey);
                Owner.observableStateMachineTrigger.OnStateEnterAsObservable()
                    .Where(info => info.StateInfo.IsName(GameCommonData.DeadKey))
                    .Take(1)
                    .SelectMany(_ => Dead().ToObservable())
                    .Subscribe()
                    .AddTo(Owner.GetCancellationTokenOnDestroy());
            }

            private async UniTask Dead()
            {
                await UniTask.Delay(2000);
                PhotonNetwork.LeaveRoom();
                Owner.deadSubject.OnNext(Unit.Default);
            }
        }
    }
}