using Common.Data;
using Cysharp.Threading.Tasks;
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
                Owner._animator.SetTrigger(GameCommonData.DeadHashKey);
                Dead().Forget();
            }

            private async UniTask Dead()
            {
                await UniTask.Delay(2000);
                Owner._deadSubject.OnNext(Unit.Default);
            }
        }
    }
}