using UnityEngine;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class BattleReadyState : State
        {
            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.BattleReadyGameObject.SetActive(true);
            }
        }
    }
}