using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerStateDead : State
        {
            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                Owner.playerDead.BigJump(Owner.transform);
            }
        }
    }
}