namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class CreateStageState : StateMachine<BattleCore>.State
        {
            private bool _isInitialize;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                OnInitialize();
            }

            protected override void OnUpdate()
            {
                if (_isInitialize)
                {
                    return;
                }

                Owner._stateMachine.Dispatch((int)State.PlayerCreate);
                _isInitialize = true;
            }

            private void OnInitialize()
            {
            }
        }
    }
}