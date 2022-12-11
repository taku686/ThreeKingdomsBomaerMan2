using System.Xml.Serialization;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class ShopState : State
        {
            private const string ThousandCoinKey = "coin1000";

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
                Owner.shopView.ThousandCoinButton.onClick.RemoveAllListeners();
                Owner.shopView.BackButton.onClick.AddListener(OnCLickBack);
                Owner.shopView.ThousandCoinButton.onClick.AddListener(OnClickBuyThousandCoin);
            }

            private void OnCLickBack()
            {
                var backButton = Owner.shopView.BackButton.gameObject;
                Owner._uiAnimation.OnClickScaleColorAnimation(backButton).OnComplete(() =>
                {
                    Owner._stateMachine.Dispatch((int)Event.Main);
                }).SetLink(backButton);
            }

            private void OnClickBuyThousandCoin()
            {
                var button = Owner.shopView.ThousandCoinButton.gameObject;
                Owner._uiAnimation.OnClickScaleColorAnimation(button).OnComplete(() =>
                {
                    Owner._playFabShopManager.BuyItemInGooglePlayStore(ThousandCoinKey);
                }).SetLink(button);
            }
        }
    }
}