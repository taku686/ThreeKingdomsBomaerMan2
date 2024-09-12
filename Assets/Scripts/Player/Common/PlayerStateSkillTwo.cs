using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerSpecialSkillState : State
        {
            protected override void OnEnter(State prevState)
            {
                base.OnEnter(prevState);
                PlayBackAnimation();
            }

            private void PlayBackAnimation()
            {
                Owner.animator.SetTrigger(GameCommonData.SpecialHashKey);
                Owner.observableStateMachineTrigger.OnStateExitAsObservable()
                    .Where(info => info.StateInfo.IsName(GameCommonData.SpecialKey)).Take(1).Subscribe(onStateInfo =>
                    {
                        Owner.stateMachine.Dispatch((int)PLayerState.Idle);
                    }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }
        }
    }
}