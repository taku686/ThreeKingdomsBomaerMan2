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
            protected override async UniTask OnAsyncEnter(State prevState)
            {
                await Initialize();
                PhotonNetwork.LeaveRoom();
                
                Owner.deadSubject.OnNext(Unit.Default);
            }

            private async UniTask Initialize()
            {
                await Owner.playerDead.BigJump(Owner.transform);
            }
        }
    }
}