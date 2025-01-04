using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using Repository;
using UI.Common;
using UI.Title.ShopState;
using UniRx;
using UnityEngine;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class ShopState : StateMachine<TitleCore>.State
        {
            private const int AddRewardValue = 5;
            private UIAnimation _UiAnimation => Owner._uiAnimation;
            private PlayFabVirtualCurrencyManager _PlayFabVirtualCurrencyManager => Owner._playFabVirtualCurrencyManager;
            private PlayFabShopManager _PlayFabShopManager => Owner._playFabShopManager;
            private RewardDataRepository _RewardDataRepository => Owner._rewardDataRepository;
            private ShopView _View => (ShopView)Owner.GetView(State.Shop);
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private Sprite _gemSprite;
            private CancellationTokenSource _cts;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            private async UniTaskVoid Initialize()
            {
                _cts = new CancellationTokenSource();
                _View._RewardGetView.gameObject.SetActive(false);
                _View._PurchaseErrorView.gameObject.SetActive(false);
                _View._PurchaseErrorView.errorInfoText.text = "";
                InitializeButton();
                _gemSprite = (Sprite)await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
                Owner.SwitchUiObject(State.Shop, true).Forget();
            }

            private void InitializeButton()
            {
                _View._BackButton.onClick.RemoveAllListeners();
                _View._FiveThousandCoinButton.onClick.RemoveAllListeners();
                _View._TwelveThousandCoinButton.onClick.RemoveAllListeners();
                _View._TwentyGemButton.onClick.RemoveAllListeners();
                _View._HundredGemButton.onClick.RemoveAllListeners();
                _View._TwoHundredGemButton.onClick.RemoveAllListeners();
                _View._AdsButton.onClick.RemoveAllListeners();
                _View._GachaButton.onClick.RemoveAllListeners();
                _View._RewardGetView.okButton.onClick.RemoveAllListeners();
                _View._PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                _View._BackButton.onClick.AddListener(OnCLickBack);
                _View._FiveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.FiveThousandCoinItemKey,
                        _View._FiveThousandCoinButton.gameObject));
                _View._TwelveThousandCoinButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwelveThousandCoinItemKey,
                        _View._TwelveThousandCoinButton.gameObject));
                _View._TwentyGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwentyGemItemKey,
                        _View._TwentyGemButton.gameObject));
                _View._HundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.HundredGemItemKey,
                        _View._HundredGemButton.gameObject));
                _View._TwoHundredGemButton.onClick.AddListener(() =>
                    OnClickBuyItem(GameCommonData.TwoHundredGemItemKey,
                        _View._TwoHundredGemButton.gameObject));
                _View._AdsButton.onClick.AddListener(OnClickAds);
                _View._GachaButton.onClick.AddListener(OnClickCharacterGacha);
                _View._RewardGetView.okButton.onClick.AddListener(OnClickCloseRewardView);
                _View._PurchaseErrorView.okButton.onClick.AddListener(OnClickCloseErrorView);
                _View._OnClickAddThousandCoin
                    .SelectMany(_ => _PlayFabVirtualCurrencyManager.Add1000CoinAsync().ToObservable())
                    .SelectMany(_ => SetVirtualCurrencyText().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _View._OnClickAddWeapon
                    .SelectMany(_ => _PlayFabShopManager.AddRandomWeaponAsync().ToObservable())
                    .Subscribe(ids =>
                    {
                        var rewards = new List<(int, RewardDataUseCase.RewardData.RewardType)>();
                        foreach (var id in ids)
                        {
                            rewards.Add((id, RewardDataUseCase.RewardData.RewardType.Weapon));
                        }

                        _RewardDataRepository.SetRewardIds(rewards.ToArray());
                        _StateMachine.Dispatch((int)State.Reward, (int)State.Shop);
                    })
                    .AddTo(_cts.Token);

                Owner.SubscribeRewardOkButton();
            }

            private void OnCLickBack()
            {
                var backButton = _View._BackButton.gameObject;
                _UiAnimation.ClickScaleColor(backButton).OnComplete(() => { Owner._stateMachine.Dispatch((int)State.Main); }).SetLink(backButton);
            }

            private void OnClickBuyItem(string itemKey, GameObject button)
            {
                _UiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    await Owner._playFabShopManager.TryPurchaseItemByRealMoney(itemKey);
                    await SetVirtualCurrencyText();
                })).SetLink(button);
            }

            private void OnClickAds()
            {
                var button = _View._AdsButton.gameObject;
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
                var button = _View._GachaButton.gameObject;
                var rewardViewTransform = _View._RewardGetView.transform;
                var rewardView = _View._RewardGetView;
                var errorView = _View._PurchaseErrorView.transform;
                var errorInfoText = _View._PurchaseErrorView.errorInfoText;
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
                        await _UiAnimation.Open(rewardViewTransform, GameCommonData.OpenDuration);
                    }
                    else
                    {
                        errorView.localScale = Vector3.zero;
                        errorView.gameObject.SetActive(true);
                        await _UiAnimation.Open(errorView, GameCommonData.OpenDuration);
                    }
                })).SetLink(button);
            }

            private void OnClickCloseRewardView()
            {
                var button = _View._RewardGetView.okButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var rewardView = _View._RewardGetView.transform;
                    await _UiAnimation.Close(rewardView, GameCommonData.CloseDuration);
                    rewardView.gameObject.SetActive(false);
                })).SetLink(button);
            }

            private void OnClickCloseErrorView()
            {
                var button = _View._PurchaseErrorView.okButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var errorView = _View._PurchaseErrorView.transform;
                    await _UiAnimation.Close(errorView, GameCommonData.CloseDuration);
                    errorView.gameObject.SetActive(false);
                })).SetLink(button);
            }

            private async UniTask SetVirtualCurrencyText()
            {
                await Owner.SetCoinText();
                await Owner.SetGemText();
            }

            private void Cancel()
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}