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
                Owner._stateMachine.Dispatch((int)State.PlayerCreate);
            }

            private void OnInitialize()
            {
            }
        }
    }
}