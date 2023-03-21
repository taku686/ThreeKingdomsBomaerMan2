using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Newtonsoft.Json.Serialization;
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

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _uiAnimation = Owner._uiAnimation;
                Owner.DisableTitleGameObject();
                InitializeButton();
                Owner.mainView.ShopGameObject.SetActive(true);
                Owner.shopView.RewardGetView.gameObject.SetActive(false);
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
                Owner.shopView.BackButton.onClick.AddListener(OnCLickBack);
                Owner.shopView.ThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.ThousandCoinItemKey, GameCommonData.ThousandCoinItemPrice,
                        Owner.shopView.ThousandCoinButton.gameObject));
                Owner.shopView.FiveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.FiveThousandCoinItemKey, GameCommonData.FiveThousandCoinItemPrice,
                        Owner.shopView.FiveThousandCoinButton.gameObject));
                Owner.shopView.TwelveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwelveThousandCoinItemKey, GameCommonData.TwelveThousandCoinItemPrice,
                        Owner.shopView.TwelveThousandCoinButton.gameObject));
                Owner.shopView.TwentyGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwentyGemItemKey, GameCommonData.TwentyGemItemPrice,
                        Owner.shopView.TwentyGemButton.gameObject));
                Owner.shopView.HundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.HundredGemKey, GameCommonData.HundredGemItemPrice,
                        Owner.shopView.HundredGemButton.gameObject));
                Owner.shopView.TwoHundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwoHundredGemKey, GameCommonData.TwoHundredGemItemPrice,
                        Owner.shopView.TwoHundredGemButton.gameObject));
                Owner.shopView.AdsButton.onClick.AddListener(OnClickAds);
                Owner.shopView.GachaButton.onClick.AddListener(OnClickCharacterGacha);
                Owner.shopView.RewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
            }

            private void OnCLickBack()
            {
                var backButton = Owner.shopView.BackButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(backButton).OnComplete(() =>
                {
                    Owner._stateMachine.Dispatch((int)Event.Main);
                }).SetLink(backButton);
            }

            private void OnClickBuyItem(string itemKey, int price, GameObject button)
            {
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var isSucceed = await Owner._playFabShopManager.TryPurchaseItem(itemKey,
                        GameCommonData.RealMoneyKey, price, GameCommonData.MainShopKey);
                    if (isSucceed)
                    {
                        Owner.shopView.TextGameObject.SetActive(true);
                    }
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
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var isSucceed = await Owner._playFabShopManager.TryPurchaseGacha(
                        GameCommonData.CharacterGachaItemKey, GameCommonData.GemKey, 100, GameCommonData.GachaShopKey,
                        rewardImage);
                    if (isSucceed)
                    {
                        rewardView.localScale = Vector3.zero;
                        rewardView.gameObject.SetActive(true);
                        await _uiAnimation.Open(rewardView, GameCommonData.OpenDuration);
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
        }
    }
}