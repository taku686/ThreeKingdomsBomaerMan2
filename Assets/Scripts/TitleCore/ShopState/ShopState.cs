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
            private const int AddRewardValue = 5;
            private UIAnimation _uiAnimation;
            private PlayFabShopManager _playFabShopManager;
            private ShopView _shopView;
            private Sprite _gemSprite;

            protected override void OnEnter(State prevState)
            {
                Initialize().Forget();
            }

            private async UniTaskVoid Initialize()
            {
                _uiAnimation = Owner._uiAnimation;
                _playFabShopManager = Owner._playFabShopManager;
                _shopView = Owner.shopView;
                Owner.DisableTitleGameObject();
                InitializeButton();
                Owner.mainView.ShopGameObject.SetActive(true);
                _shopView.RewardGetView.gameObject.SetActive(false);
                _shopView.PurchaseErrorView.gameObject.SetActive(false);
                _shopView.PurchaseErrorView.errorInfoText.text = "";
                var gemSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                _gemSprite = (Sprite)gemSprite;
            }

            private void InitializeButton()
            {
                _shopView.BackButton.onClick.RemoveAllListeners();
                _shopView.ThousandCoinButton.onClick.RemoveAllListeners();
                _shopView.FiveThousandCoinButton.onClick.RemoveAllListeners();
                _shopView.TwelveThousandCoinButton.onClick.RemoveAllListeners();
                _shopView.TwentyGemButton.onClick.RemoveAllListeners();
                _shopView.HundredGemButton.onClick.RemoveAllListeners();
                _shopView.TwoHundredGemButton.onClick.RemoveAllListeners();
                _shopView.AdsButton.onClick.RemoveAllListeners();
                _shopView.GachaButton.onClick.RemoveAllListeners();
                _shopView.RewardGetView.okButton.onClick.RemoveAllListeners();
                _shopView.PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                _shopView.BackButton.onClick.AddListener(OnCLickBack);
                _shopView.ThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.ThousandCoinItemKey, _shopView.ThousandCoinButton.gameObject));
                _shopView.FiveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.FiveThousandCoinItemKey,
                        _shopView.FiveThousandCoinButton.gameObject));
                _shopView.TwelveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwelveThousandCoinItemKey,
                        _shopView.TwelveThousandCoinButton.gameObject));
                _shopView.TwentyGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwentyGemItemKey,
                        _shopView.TwentyGemButton.gameObject));
                _shopView.HundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.HundredGemItemKey,
                        _shopView.HundredGemButton.gameObject));
                _shopView.TwoHundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwoHundredGemItemKey,
                        _shopView.TwoHundredGemButton.gameObject));
                _shopView.AdsButton.onClick.AddListener(OnClickAds);
                _shopView.GachaButton.onClick.AddListener(OnClickCharacterGacha);
                _shopView.RewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
                _shopView.PurchaseErrorView.okButton.onClick.AddListener(OnClickCloseErrorView);
                Owner.SetupRewardOkButton();
            }

            private void OnCLickBack()
            {
                var backButton = _shopView.BackButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(backButton).OnComplete(() =>
                {
                    Owner._stateMachine.Dispatch((int)Event.Main);
                }).SetLink(backButton);
            }

            private void OnClickBuyItem(string itemKey, GameObject button)
            {
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    await Owner._playFabShopManager.TryPurchaseItemByRealMoney(itemKey);
                    await SetVirtualCurrencyText();
                })).SetLink(button);
            }

            private void OnClickAds()
            {
                var button = Owner.shopView.AdsButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var result =
                        await Owner._playFabAdsManager.GetAdPlacementAsync(Owner.GetCancellationTokenOnDestroy());
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
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var isSucceed = await Owner._playFabShopManager.TryPurchaseGacha(
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

            private async UniTask SetVirtualCurrencyText()
            {
                await Owner.SetCoinText();
                await Owner.SetGemText();
            }
        }
    }
}