using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleManager>.State;

namespace Manager.BattleManager
{
    public partial class BattleManager
    {
        public class EndSceneTransitionState : State
        {
            protected override void OnEnter(State prevState)
            {
                OnInitialize();
            }

            private void OnInitialize()
            {
                Debug.Log("EndSceneTransition");
                Owner._stateMachine.Dispatch((int)Event.PlayerCreate);
            }
        }
    }
}