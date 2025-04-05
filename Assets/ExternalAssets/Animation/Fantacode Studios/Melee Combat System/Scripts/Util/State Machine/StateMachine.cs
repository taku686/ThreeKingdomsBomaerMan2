namespace FS_CombatSystem
{

    public class StateMachine<T>
    {
        public State<T> CurrentState { get; private set; }

        T _owner;
        public StateMachine(T owner)
        {
            _owner = owner;
        }

        public void ChangeState(State<T> newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter(_owner);
        }

        public void Execute()
        {
            CurrentState?.Execute();
        }
    }
}