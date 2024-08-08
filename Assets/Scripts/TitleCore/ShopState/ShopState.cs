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
        public class ShopState : StateMachine<TitleCore>.State
        {
            private const int AddRewardValue = 5;
            private UIAnimation _uiAnimation;
            private PlayFabShopManager _playFabShopManager;
            private ShopView shopView;
            private Sprite _gemSprite;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            private async UniTaskVoid Initialize()
            {
                _uiAnimation = Owner.uiAnimation;
                _playFabShopManager = Owner.playFabShopManager;
                shopView = Owner.shopView;
                InitializeButton();
                shopView.RewardGetView.gameObject.SetActive(false);
                shopView.PurchaseErrorView.gameObject.SetActive(false);
                shopView.PurchaseErrorView.errorInfoText.text = "";
                var gemSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                _gemSprite = (Sprite)gemSprite;
                Owner.SwitchUiObject(State.Shop, true);
            }

            private void InitializeButton()
            {
                shopView.BackButton.onClick.RemoveAllListeners();
                shopView.ThousandCoinButton.onClick.RemoveAllListeners();
                shopView.FiveThousandCoinButton.onClick.RemoveAllListeners();
                shopView.TwelveThousandCoinButton.onClick.RemoveAllListeners();
                shopView.TwentyGemButton.onClick.RemoveAllListeners();
                shopView.HundredGemButton.onClick.RemoveAllListeners();
                shopView.TwoHundredGemButton.onClick.RemoveAllListeners();
                shopView.AdsButton.onClick.RemoveAllListeners();
                shopView.GachaButton.onClick.RemoveAllListeners();
                shopView.RewardGetView.okButton.onClick.RemoveAllListeners();
                shopView.PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                shopView.BackButton.onClick.AddListener(OnCLickBack);
                shopView.ThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.ThousandCoinItemKey, shopView.ThousandCoinButton.gameObject));
                shopView.FiveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.FiveThousandCoinItemKey,
                        shopView.FiveThousandCoinButton.gameObject));
                shopView.TwelveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwelveThousandCoinItemKey,
                        shopView.TwelveThousandCoinButton.gameObject));
                shopView.TwentyGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwentyGemItemKey,
                        shopView.TwentyGemButton.gameObject));
                shopView.HundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.HundredGemItemKey,
                        shopView.HundredGemButton.gameObject));
                shopView.TwoHundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwoHundredGemItemKey,
                        shopView.TwoHundredGemButton.gameObject));
                shopView.AdsButton.onClick.AddListener(OnClickAds);
                shopView.GachaButton.onClick.AddListener(OnClickCharacterGacha);
                shopView.RewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
                shopView.PurchaseErrorView.okButton.onClick.AddListener(OnClickCloseErrorView);
                Owner.SetupRewardOkButton();
            }

            private void OnCLickBack()
            {
                var backButton = shopView.BackButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(backButton).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)State.Main);
                }).SetLink(backButton);
            }

            private void OnClickBuyItem(string itemKey, GameObject button)
            {
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    await Owner.playFabShopManager.TryPurchaseItemByRealMoney(itemKey);
                    await SetVirtualCurrencyText();
                })).SetLink(button);
            }

            private void OnClickAds()
            {
                var button = Owner.shopView.AdsButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var result =
                        await Owner.playFabAdsManager.GetAdPlacementAsync(Owner.GetCancellationTokenOnDestroy());
                    if (!result)
                    {
                        return;
                    }

                    await SetVirtualCurrencyText();
                    await Owner.SetRewardUI(AddRewardValue, _gemSprite);
                })).SetLink(button);
            }

            private void OnClickCharacterGacha()
            {
                var button = Owner.shopView.GachaButton.gameObject;
                var rewardViewTransform = Owner.shopView.RewardGetView.transform;
                var rewardView = Owner.shopView.RewardGetView;
                var errorView = Owner.shopView.PurchaseErrorView.transform;
                var errorInfoText = Owner.shopView.PurchaseErrorView.errorInfoText;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var isSucceed = await Owner.playFabShopManager.TryPurchaseGacha(
                        GameCommonData.CharacterGachaItemKey, GameCommonData.GemKey, 100, GameCommonData.GachaShopKey,
                        rewardView, errorInfoText);
                    if (isSucceed)
                    {
                        rewardViewTransform.localScale = Vector3.zero;
                        rewardViewTransform.gameObject.SetActive(true);
                        await SetVirtualCurrencyText();
                        await _uiAnimation.Open(rewardViewTransform, GameCommonData.OpenDuration);
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
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var rewardView = Owner.shopView.RewardGetView.transform;
                    await _uiAnimation.Close(rewardView, GameCommonData.CloseDuration);
                    rewardView.gameObject.SetActive(false);
                })).SetLink(button);
            }

            private void OnClickCloseErrorView()
            {
                var button = Owner.shopView.PurchaseErrorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var errorView = Owner.shopView.PurchaseErrorView.transform;
                    await _uiAnimation.Close(errorView, GameCommonData.CloseDuration);
                    errorView.gameObject.SetActive(false);
                })).SetLink(button);
            }

            private async UniTask SetVirtualCurrencyText()
            {
                await Owner.SetCoinText();
                await Owner.SetGemText();
            }
        }
    }
}