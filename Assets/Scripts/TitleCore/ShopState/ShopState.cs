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
            private Shop shop;
            private Sprite _gemSprite;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            private async UniTaskVoid Initialize()
            {
                _uiAnimation = Owner.uiAnimation;
                _playFabShopManager = Owner.playFabShopManager;
                shop = Owner.shop;
                InitializeButton();
                shop.RewardGetView.gameObject.SetActive(false);
                shop.PurchaseErrorView.gameObject.SetActive(false);
                shop.PurchaseErrorView.errorInfoText.text = "";
                var gemSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                _gemSprite = (Sprite)gemSprite;
                Owner.SwitchUiObject(State.Shop, true);
            }

            private void InitializeButton()
            {
                shop.BackButton.onClick.RemoveAllListeners();
                shop.ThousandCoinButton.onClick.RemoveAllListeners();
                shop.FiveThousandCoinButton.onClick.RemoveAllListeners();
                shop.TwelveThousandCoinButton.onClick.RemoveAllListeners();
                shop.TwentyGemButton.onClick.RemoveAllListeners();
                shop.HundredGemButton.onClick.RemoveAllListeners();
                shop.TwoHundredGemButton.onClick.RemoveAllListeners();
                shop.AdsButton.onClick.RemoveAllListeners();
                shop.GachaButton.onClick.RemoveAllListeners();
                shop.RewardGetView.okButton.onClick.RemoveAllListeners();
                shop.PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                shop.BackButton.onClick.AddListener(OnCLickBack);
                shop.ThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.ThousandCoinItemKey, shop.ThousandCoinButton.gameObject));
                shop.FiveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.FiveThousandCoinItemKey,
                        shop.FiveThousandCoinButton.gameObject));
                shop.TwelveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwelveThousandCoinItemKey,
                        shop.TwelveThousandCoinButton.gameObject));
                shop.TwentyGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwentyGemItemKey,
                        shop.TwentyGemButton.gameObject));
                shop.HundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.HundredGemItemKey,
                        shop.HundredGemButton.gameObject));
                shop.TwoHundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwoHundredGemItemKey,
                        shop.TwoHundredGemButton.gameObject));
                shop.AdsButton.onClick.AddListener(OnClickAds);
                shop.GachaButton.onClick.AddListener(OnClickCharacterGacha);
                shop.RewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
                shop.PurchaseErrorView.okButton.onClick.AddListener(OnClickCloseErrorView);
                Owner.SetupRewardOkButton();
            }

            private void OnCLickBack()
            {
                var backButton = shop.BackButton.gameObject;
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
                var button = Owner.shop.AdsButton.gameObject;
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
                var button = Owner.shop.GachaButton.gameObject;
                var rewardViewTransform = Owner.shop.RewardGetView.transform;
                var rewardView = Owner.shop.RewardGetView;
                var errorView = Owner.shop.PurchaseErrorView.transform;
                var errorInfoText = Owner.shop.PurchaseErrorView.errorInfoText;
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
                var button = Owner.shop.RewardGetView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var rewardView = Owner.shop.RewardGetView.transform;
                    await _uiAnimation.Close(rewardView, GameCommonData.CloseDuration);
                    rewardView.gameObject.SetActive(false);
                })).SetLink(button);
            }

            private void OnClickCloseErrorView()
            {
                var button = Owner.shop.PurchaseErrorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var errorView = Owner.shop.PurchaseErrorView.transform;
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