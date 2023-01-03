using System.Xml.Serialization;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using State = StateMachine<UI.Title.TitleBase>.State;

namespace UI.Title
{
    public partial class TitleBase
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
                Owner.shopView.AdsButton.onClick.RemoveAllListeners();
                Owner.shopView.BackButton.onClick.AddListener(OnCLickBack);
                Owner.shopView.ThousandCoinButton.onClick.AddListener(OnClickBuyThousandCoin);
                Owner.shopView.AdsButton.onClick.AddListener(OnClickAds);
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
                Owner._uiAnimation.OnClickScaleColorAnimation(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var isSucceed = await Owner._playFabShopManager.TryPurchaseItem(ThousandCoinKey,
                        GameSettingData.RealMoneyKey,
                        100);
                    if (isSucceed)
                    {
                        Owner.shopView.TextGameObject.SetActive(true);
                    }
                })).SetLink(button);
            }

            private void OnClickAds()
            {
                var button = Owner.shopView.AdsButton.gameObject;
                Owner._uiAnimation.OnClickScaleColorAnimation(button).OnComplete(() => UniTask.Void(async () =>
                {
                    await Owner._playFabAdsManager.GetAdPlacementAsync(Owner.GetCancellationTokenOnDestroy());
                })).SetLink(button);
            }
        }
    }
}