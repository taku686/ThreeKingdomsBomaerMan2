using DG.Tweening;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class ShopState : State
        {
            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                InitializeButton();
                Owner.mainView.ShopGameObject.SetActive(true);
            }

            private void InitializeButton()
            {
                Owner.shopView.BackButton.onClick.RemoveAllListeners();
                Owner.shopView.BackButton.onClick.AddListener(OnCLickBack);
            }

            private void OnCLickBack()
            {
                var backButton = Owner.shopView.BackButton.gameObject;
                Owner._uiAnimation.OnClickScaleColorAnimation(backButton).OnComplete(() =>
                {
                    Owner._stateMachine.Dispatch((int)Event.Main);
                }).SetLink(backButton);
            }
        }
    }
}