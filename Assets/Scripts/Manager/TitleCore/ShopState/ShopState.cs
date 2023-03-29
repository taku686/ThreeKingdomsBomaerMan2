using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using UI.Common;
using UI.Title.ShopState;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class ShopState : State
        {
            private UIAnimation _uiAnimation;
            private PlayFabShopManager _playFabShopManager;
            private ShopView _shopView;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _uiAnimation = Owner._uiAnimation;
                _playFabShopManager = Owner._playFabShopManager;
                _shopView = Owner.shopView;
                Owner.DisableTitleGameObject();
                InitializeButton();
                Owner.mainView.ShopGameObject.SetActive(true);
                Owner.shopView.RewardGetView.gameObject.SetActive(false);
                Owner.shopView.PurchaseErrorView.gameObject.SetActive(false);
                Owner.shopView.PurchaseErrorView.errorInfoText.text = "";
            }

            private void InitializeButton()
            {
                Owner.shopView.BackButton.onClick.RemoveAllListeners();
                Owner.shopView.ThousandCoinButton.onClick.RemoveAllListeners();
                Owner.shopView.FiveThousandCoinButton.onClick.RemoveAllListeners();
                Owner.shopView.TwelveThousandCoinButton.onClick.RemoveAllListeners();
                Owner.shopView.TwentyGemButton.onClick.RemoveAllListeners();
                Owner.shopView.HundredGemButton.onClick.RemoveAllListeners();
                Owner.shopView.TwoHundredGemButton.onClick.RemoveAllListeners();
                Owner.shopView.AdsButton.onClick.RemoveAllListeners();
                Owner.shopView.GachaButton.onClick.RemoveAllListeners();
                Owner.shopView.RewardGetView.okButton.onClick.RemoveAllListeners();
                Owner.shopView.PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                Owner.shopView.BackButton.onClick.AddListener(OnCLickBack);
                Owner.shopView.ThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.ThousandCoinItemKey, Owner.shopView.ThousandCoinButton.gameObject));
                Owner.shopView.FiveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.FiveThousandCoinItemKey,
                        Owner.shopView.FiveThousandCoinButton.gameObject));
                Owner.shopView.TwelveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwelveThousandCoinItemKey,
                        Owner.shopView.TwelveThousandCoinButton.gameObject));
                Owner.shopView.TwentyGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwentyGemItemKey,
                        Owner.shopView.TwentyGemButton.gameObject));
                Owner.shopView.HundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.HundredGemItemKey,
                        Owner.shopView.HundredGemButton.gameObject));
                Owner.shopView.TwoHundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwoHundredGemItemKey,
                        Owner.shopView.TwoHundredGemButton.gameObject));
                Owner.shopView.AdsButton.onClick.AddListener(OnClickAds);
                Owner.shopView.GachaButton.onClick.AddListener(OnClickCharacterGacha);
                Owner.shopView.RewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
                Owner.shopView.PurchaseErrorView.okButton.onClick.AddListener(OnClickCloseErrorView);
            }

            private void OnCLickBack()
            {
                var backButton = Owner.shopView.BackButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(backButton).OnComplete(() =>
                {
                    Owner._stateMachine.Dispatch((int)Event.Main);
                }).SetLink(backButton);
            }

            private void OnClickBuyItem(string itemKey, GameObject button)
            {
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    Owner._playFabShopManager.TryPurchaseItem(itemKey);
                })).SetLink(button);
            }

            private void OnClickAds()
            {
                var button = Owner.shopView.AdsButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    await Owner._playFabAdsManager.GetAdPlacementAsync(Owner.GetCancellationTokenOnDestroy());
                })).SetLink(button);
            }

            private void OnClickCharacterGacha()
            {
                var button = Owner.shopView.GachaButton.gameObject;
                var rewardView = Owner.shopView.RewardGetView.transform;
                var rewardImage = Owner.shopView.RewardGetView.rewardImage;
                var errorView = Owner.shopView.PurchaseErrorView.transform;
                var errorInfoText = Owner.shopView.PurchaseErrorView.errorInfoText;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var isSucceed = await Owner._playFabShopManager.TryPurchaseGacha(
                        GameCommonData.CharacterGachaItemKey, GameCommonData.GemKey, 100, GameCommonData.GachaShopKey,
                        rewardImage, errorInfoText);
                    if (isSucceed)
                    {
                        rewardView.localScale = Vector3.zero;
                        rewardView.gameObject.SetActive(true);
                        await _uiAnimation.Open(rewardView, GameCommonData.OpenDuration);
                    }
                    else
                    {
                        errorView.localScale = Vector3.zero;
                        errorView.gameObject.SetActive(true);
                        await _uiAnimation.Open(errorView, GameCommonData.OpenDuration);
                    }
                })).SetLink(button);
            }

            private void OnClickCloseRewardView()
            {
                var button = Owner.shopView.RewardGetView.okButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var rewardView = Owner.shopView.RewardGetView.transform;
                    await _uiAnimation.Close(rewardView, GameCommonData.CloseDuration);
                    rewardView.gameObject.SetActive(false);
                })).SetLink(button);
            }

            private void OnClickCloseErrorView()
            {
                var button = Owner.shopView.PurchaseErrorView.okButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var errorView = Owner.shopView.PurchaseErrorView.transform;
                    await _uiAnimation.Close(errorView, GameCommonData.CloseDuration);
                    errorView.gameObject.SetActive(false);
                })).SetLink(button);
            }
        }
    }
}