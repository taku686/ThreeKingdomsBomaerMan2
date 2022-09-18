using UnityEngine;
using State = StateMachine<UI.Title.Main.TitlePresenter>.State;

namespace UI.Title.Main
{
    public partial class TitlePresenter
    {
        public class CharacterDetailState : State
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
                Owner.mainView.CharacterDetailGameObject.SetActive(true);
            }
        }
    }
}