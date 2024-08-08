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
            private UIAnimation uiAnimation;
            private ShopView View => (ShopView)Owner.GetView(State.Shop);
            private Sprite gemSprite;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            private async UniTaskVoid Initialize()
            {
                uiAnimation = Owner.uiAnimation;
                InitializeButton();
                View.RewardGetView.gameObject.SetActive(false);
                View.PurchaseErrorView.gameObject.SetActive(false);
                View.PurchaseErrorView.errorInfoText.text = "";
                gemSprite = (Sprite)await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                Owner.SwitchUiObject(State.Shop, true).Forget();
            }

            private void InitializeButton()
            {
                View.BackButton.onClick.RemoveAllListeners();
                View.ThousandCoinButton.onClick.RemoveAllListeners();
                View.FiveThousandCoinButton.onClick.RemoveAllListeners();
                View.TwelveThousandCoinButton.onClick.RemoveAllListeners();
                View.TwentyGemButton.onClick.RemoveAllListeners();
                View.HundredGemButton.onClick.RemoveAllListeners();
                View.TwoHundredGemButton.onClick.RemoveAllListeners();
                View.AdsButton.onClick.RemoveAllListeners();
                View.GachaButton.onClick.RemoveAllListeners();
                View.RewardGetView.okButton.onClick.RemoveAllListeners();
                View.PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                View.BackButton.onClick.AddListener(OnCLickBack);
                View.ThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.ThousandCoinItemKey, View.ThousandCoinButton.gameObject));
                View.FiveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.FiveThousandCoinItemKey,
                        View.FiveThousandCoinButton.gameObject));
                View.TwelveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwelveThousandCoinItemKey,
                        View.TwelveThousandCoinButton.gameObject));
                View.TwentyGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwentyGemItemKey,
                        View.TwentyGemButton.gameObject));
                View.HundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.HundredGemItemKey,
                        View.HundredGemButton.gameObject));
                View.TwoHundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwoHundredGemItemKey,
                        View.TwoHundredGemButton.gameObject));
                View.AdsButton.onClick.AddListener(OnClickAds);
                View.GachaButton.onClick.AddListener(OnClickCharacterGacha);
                View.RewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
                View.PurchaseErrorView.okButton.onClick.AddListener(OnClickCloseErrorView);
                Owner.SetupRewardOkButton();
            }

            private void OnCLickBack()
            {
                var backButton = View.BackButton.gameObject;
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
                var button = View.AdsButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var result =
                        await Owner.playFabAdsManager.GetAdPlacementAsync(Owner.GetCancellationTokenOnDestroy());
                    if (!result)
                    {
                        return;
                    }

                    await SetVirtualCurrencyText();
                    await Owner.SetRewardUI(AddRewardValue, gemSprite);
                })).SetLink(button);
            }

            private void OnClickCharacterGacha()
            {
                var button = View.GachaButton.gameObject;
                var rewardViewTransform = View.RewardGetView.transform;
                var rewardView = View.RewardGetView;
                var errorView = View.PurchaseErrorView.transform;
                var errorInfoText = View.PurchaseErrorView.errorInfoText;
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
                        await uiAnimation.Open(rewardViewTransform, GameCommonData.OpenDuration);
                    }
                    else
                    {
                        errorView.localScale = Vector3.zero;
                        errorView.gameObject.SetActive(true);
                        await uiAnimation.Open(errorView, GameCommonData.OpenDuration);
                    }
                })).SetLink(button);
            }

            private void OnClickCloseRewardView()
            {
                var button = View.RewardGetView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var rewardView = View.RewardGetView.transform;
                    await uiAnimation.Close(rewardView, GameCommonData.CloseDuration);
                    rewardView.gameObject.SetActive(false);
                })).SetLink(button);
            }

            private void OnClickCloseErrorView()
            {
                var button = View.PurchaseErrorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var errorView = View.PurchaseErrorView.transform;
                    await uiAnimation.Close(errorView, GameCommonData.CloseDuration);
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