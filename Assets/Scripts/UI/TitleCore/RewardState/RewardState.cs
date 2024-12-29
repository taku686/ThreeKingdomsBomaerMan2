using Cysharp.Threading.Tasks;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class RewardState : StateMachine<TitleCore>.State
        {
            private RewardView _View => (RewardView)Owner.GetView(State.Reward);

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _View._LootBoxSystem.Initialize();
                Owner.SwitchUiObject(State.Reward, false).Forget();
            }
        }
    }
}