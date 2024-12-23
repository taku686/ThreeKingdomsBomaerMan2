using Cysharp.Threading.Tasks;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class RewardState : StateMachine<TitleCore>.State
        {
            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                Owner.SwitchUiObject(State.Login, false).Forget();
            }
        }
    }
}