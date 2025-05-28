using System.Linq;
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
using UseCase;

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
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private WeaponCautionRepository _WeaponCautionRepository => Owner._weaponCautionRepository;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private GetRewardUseCase _GetRewardUseCase => Owner._getRewardUseCase;

            private CancellationTokenSource _cts;
            private const int WeaponRewardAmount = 10;
            private const int CharacterRewardAmount = 1;

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
                _View._PurchaseErrorView.gameObject.SetActive(false);
                _View._PurchaseErrorView.errorInfoText.text = "";
                _View._ShopWeaponGridView.ApplyView(WeaponRewardAmount, GameCommonData.WeaponBuyPrice);
                InitializeButton();
                await SetVirtualCurrencyText();
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
                _View._PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                _View._BackButton.onClick.AddListener(OnCLickBack);
                _View._FiveThousandCoinButton.onClick.AddListener(() => OnClickBuyItem(GameCommonData.FiveThousandCoinItemKey, _View._FiveThousandCoinButton.gameObject));
                _View._TwelveThousandCoinButton.onClick.AddListener(() => OnClickBuyItem(GameCommonData.TwelveThousandCoinItemKey, _View._TwelveThousandCoinButton.gameObject));
                _View._TwentyGemButton.onClick.AddListener(() => OnClickBuyItem(GameCommonData.TwentyGemItemKey, _View._TwentyGemButton.gameObject));
                _View._HundredGemButton.onClick.AddListener(() => OnClickBuyItem(GameCommonData.HundredGemItemKey, _View._HundredGemButton.gameObject));
                _View._TwoHundredGemButton.onClick.AddListener(() => OnClickBuyItem(GameCommonData.TwoHundredGemItemKey, _View._TwoHundredGemButton.gameObject));
                _View._AdsButton.onClick.AddListener(OnClickAds);
                _View._PurchaseErrorView.okButton.onClick.AddListener(OnClickCloseErrorView);
                _View._OnClickAddThousandCoin
                    .SelectMany(_ => _PlayFabVirtualCurrencyManager.Add1000CoinAsync().ToObservable())
                    .SelectMany(_ => SetVirtualCurrencyText().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                CharacterSubscribe();
                WeaponSubscribe();
            }

            private void CharacterSubscribe()
            {
                var addCharacter = _View._GachaButton
                    .OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._GachaButton).ToObservable())
                    .Select(_ => EnoughVirtualCurrency(WeaponRewardAmount, GameCommonData.GemKey))
                    .Publish();

                addCharacter
                    .Where(enoughGem => !enoughGem)
                    .SelectMany(_ => _PopupGenerateUseCase.GenerateErrorPopup(GameCommonData.Terms.AddGemPopupTile))
                    .Subscribe()
                    .AddTo(_cts.Token);

                addCharacter
                    .Where(enoughGem => enoughGem)
                    .SelectMany(_ => GetRewardAsync(CharacterRewardAmount, GameCommonData.RewardType.Character, GameCommonData.CharacterPrice * CharacterRewardAmount, GameCommonData.GemKey).ToObservable())
                    .Subscribe(_ => { stateMachine.Dispatch((int)State.Reward, (int)State.Shop); })
                    .AddTo(_cts.Token);

                addCharacter.Connect().AddTo(_cts.Token);
            }

            private void WeaponSubscribe()
            {
                var addWeapon = _View._ShopWeaponGridView._OnClickWeaponButton
                    .Select(_ => EnoughVirtualCurrency(WeaponRewardAmount, GameCommonData.GemKey))
                    .Publish();

                addWeapon
                    .Where(enoughGem => !enoughGem)
                    .SelectMany(_ => _PopupGenerateUseCase.GenerateErrorPopup(GameCommonData.Terms.AddGemPopupTile))
                    .Subscribe()
                    .AddTo(_cts.Token);

                addWeapon
                    .Where(enoughGem => enoughGem)
                    .SelectMany(_ => GetRewardAsync(WeaponRewardAmount, GameCommonData.RewardType.Weapon, GameCommonData.WeaponBuyPrice * WeaponRewardAmount, GameCommonData.GemKey).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Reward, (int)State.Shop); })
                    .AddTo(_cts.Token);

                addWeapon.Connect().AddTo(_cts.Token);
            }

            private async UniTask GetRewardAsync
            (
                int rewardAmount,
                GameCommonData.RewardType rewardType,
                int cost,
                string currencyKey
            )
            {
                if (rewardType == GameCommonData.RewardType.Weapon)
                {
                    var rewards = _RewardDataRepository.GetRandomWeaponReward(rewardAmount).ToArray();
                    await _GetRewardUseCase.InAsTask(rewards, cost, currencyKey);
                    var weaponIds = rewards.Select(reward => reward.Item1).ToArray();
                    _WeaponCautionRepository.AddWeaponCautionData(weaponIds);
                }

                if (rewardType == GameCommonData.RewardType.Character)
                {
                    var reward = _RewardDataRepository.GetRandomCharacterReward(rewardAmount).ToArray();
                    await _GetRewardUseCase.InAsTask(reward, cost, currencyKey);
                }
                
                await SetVirtualCurrencyText();
            }

            private bool EnoughVirtualCurrency(int buyCount, string key)
            {
                var cost = GameCommonData.WeaponBuyPrice * buyCount;
                var userData = _UserDataRepository.GetUserData();
                if (GameCommonData.CoinKey == key)
                {
                    var coin = userData.Coin;
                    return coin >= cost;
                }

                if (GameCommonData.GemKey == key)
                {
                    var gem = userData.Gem;
                    return gem >= cost;
                }

                return false;
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
                    await _PlayFabShopManager.TryPurchaseItemByRealMoney(itemKey);
                    await SetVirtualCurrencyText();
                })).SetLink(button);
            }

            private void OnClickAds()
            {
                var button = _View._AdsButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var result = await Owner._playFabAdsManager.GetAdPlacementAsync(Owner.GetCancellationTokenOnDestroy());
                    if (!result)
                    {
                        return;
                    }

                    await SetVirtualCurrencyText();
                    //await Owner.SetRewardUI(AddRewardValue, _gemSprite);
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