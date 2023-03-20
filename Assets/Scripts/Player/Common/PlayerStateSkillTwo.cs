using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using State = StateMachine<Player.Common.PLayerCore>.State;

namespace Player.Common
{
    public partial class PLayerCore
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
                Owner._animator.SetTrigger(GameCommonData.SkillTwoHashKey);
                Owner._animatorTrigger.OnStateExitAsObservable()
                    .Where(info => info.StateInfo.IsName(GameCommonData.SkillTwoKey)).Take(1).Subscribe(onStateInfo =>
                    {
                        Owner._stateMachine.Dispatch((int)PLayerState.Idle);
                    }).AddTo(Owner.GetCancellationTokenOnDestroy());
            }
        }
    }
}