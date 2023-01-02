using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleBase>.State;

namespace Manager.BattleManager
{
    public partial class BattleBase
    {
        public class EndSceneTransitionState : State
        {
            protected override void OnEnter(State prevState)
            {
                OnInitialize();
            }

            private void OnInitialize()
            {
                Owner.stageManager.SetupBreakingBlocks();
                Owner._stateMachine.Dispatch((int)Event.PlayerCreate);
            }
        }
    }
}