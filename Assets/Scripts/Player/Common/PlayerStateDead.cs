using State = StateMachine<Player.Common.PLayerBase>.State;

namespace Player.Common
{
    public partial class PLayerBase
    {
        public class PlayerStateDead : State
        {
            protected override void OnEnter(State prevState)
            {
                base.OnEnter(prevState);
                Initialize();
            }

            private void Initialize()
            {
                Owner._playerDead.BigJump(Owner.transform);
            }
        }
    }
}