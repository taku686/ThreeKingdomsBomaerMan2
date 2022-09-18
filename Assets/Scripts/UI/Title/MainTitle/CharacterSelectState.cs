using UnityEngine;
using State = StateMachine<UI.Title.MainTitle.TitlePresenter>.State;

namespace UI.Title.MainTitle
{
    public partial class TitlePresenter
    {
        public class CharacterSelectState : State
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
                Owner._titleView.CharacterListGameObject.SetActive(true);
            }
        }
    }
}