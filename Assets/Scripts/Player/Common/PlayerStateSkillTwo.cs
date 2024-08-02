using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerStateSkillTwo : State
        {
            protected override void OnEnter(State prevState)
            {
                base.OnEnter(prevState);
                PlayAnimation();
            }

            private void PlayAnimation()
            {
                Owner.animator.SetTrigger(GameCommonData.SkillTwoHashKey);
                Owner.animatorTrigger.OnStateExitAsObservable()
                    .Where(info => info.StateInfo.IsName(GameCommonData.SkillTwoKey)).Take(1).Subscribe(onStateInfo =>
                    {
                        Owner.stateMachine.Dispatch((int)PLayerState.Idle);
                    }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }
        }
    }
}