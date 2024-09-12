using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UniRx;
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
                Owner.observableStateMachineTrigger.OnStateExitAsObservable()
                    .Where(info => info.StateInfo.IsName(GameCommonData.DeadKey)).Take(1).Subscribe(onStateInfo =>
                    {
                        PhotonNetwork.LeaveRoom();
                        Owner.deadSubject.OnNext(Unit.Default);
                    }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }
        }
    }
}