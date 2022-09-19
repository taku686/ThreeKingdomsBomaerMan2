using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class MainState : State
        {
            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
            }

            protected override void OnUpdate()
            {
            }

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.MainGameObject.SetActive(true);
            }
        }
    }
}