using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerNormalSkillState : State
        {
            protected override void OnEnter(State prevState)
            {
                base.OnEnter(prevState);
                PlayAnimation();
            }

            private void PlayAnimation()
            {
                Owner.animator.SetTrigger(GameCommonData.NormalHashKey);
                Owner.observableStateMachineTrigger.OnStateExitAsObservable().Where(info =>
                    info.StateInfo.IsName(GameCommonData.NormalKey)).Take(1).Subscribe(onStateInfo =>
                {
                    Owner.stateMachine.Dispatch((int)PLayerState.Idle);
                }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }
        }
    }
}