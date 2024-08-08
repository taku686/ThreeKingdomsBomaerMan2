using State = StateMachine<Manager.BattleManager.BattleCore>.State;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class CreateStageState : StateMachine<BattleCore>.State
        {
            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                OnInitialize();
            }

            protected override void OnUpdate()
            {
                Owner.stateMachine.Dispatch((int)State.PlayerCreate);
            }

            private void OnInitialize()
            {
                Owner.stageManager.SetupBreakingBlocks();
            }
        }
    }
}