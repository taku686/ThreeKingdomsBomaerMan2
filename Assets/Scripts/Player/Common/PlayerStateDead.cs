using UnityEngine;
using State = StateMachine<Player.Common.PLayerCore>.State;

namespace Player.Common
{
    public partial class PLayerCore
    {
        public class PlayerStateDead : State
        {
            protected override void OnEnter(State prevState)
            {
                
            }

            private void Dead()
            {
                
            }
        }
    }
}