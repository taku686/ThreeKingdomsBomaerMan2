using System;
using System.Linq;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager;
using Manager.NetworkManager;
using Repository;
using UI.Common;
using UI.Title.ShopState;
using UniRx;
using UseCase;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class ShopState : StateMachine<TitleCore>.State
        {
            private UIAnimation _UiAnimation => Owner._uiAnimation;
            private PlayFabVirtualCurrencyManager _PlayFabVirtualCurrencyManager => Owner._playFabVirtualCurrencyManager;
            private RewardDataRepository _RewardDataRepository => Owner._rewardDataRepository;
            private ShopView _View => (ShopView)Owner.GetView(State.Shop);
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private WeaponCautionRepository _WeaponCautionRepository => Owner._weaponCautionRepository;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private GetRewardUseCase _GetRewardUseCase => Owner._getRewardUseCase;
            private PlayStoreShopManager _PlayStoreShopManager => Owner._playStoreShopManager;
            private MissionSpriteDataRepository _MissionSpriteDataRepository => Owner._missionSpriteDataRepository;
            private AdMobManager _AdMobManager => Owner._adMobManager;

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
                _View._PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                _View._BackButton.onClick.AddListener(OnCLickBack);
                _View._PurchaseErrorView.okButton.onClick.AddListener(OnClickCloseErrorView);

                PurchaseInPlayStoreSubscribe(_View._OnClickAddThousandCoin, GameCommonData.Item1000CoinKey);
                PurchaseInPlayStoreSubscribe(_View._FiveThousandCoinButton, GameCommonData.Item5000CoinKey);
                PurchaseInPlayStoreSubscribe(_View._TwelveThousandCoinButton, GameCommonData.Item12000CoinKey);
                PurchaseInPlayStoreSubscribe(_View._TwentyGemButton, GameCommonData.Item20GemKey);
                PurchaseInPlayStoreSubscribe(_View._HundredGemButton, GameCommonData.Item100GemKey);
                PurchaseInPlayStoreSubscribe(_View._TwoHundredGemButton, GameCommonData.Item200GemKey);
                CharacterSubscribe();
                WeaponSubscribe();
                ErrorSubscribe();
                AdMobSubscribe();
            }

            #region Subscribe Methods

            private void AdMobSubscribe()
            {
                _View._AdsButton
                    .Do(_ => Owner.SetActiveBlockPanel(true))
                    .Do(_ => OnClickAds())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _AdMobManager
                    ._RewardSubject
                    .Select(tuple => (tuple.Item1, GetRewardKey(tuple.Item2)))
                    .SelectMany(tuple => _PlayFabVirtualCurrencyManager.AddVirtualCurrency(tuple.Item2, tuple.Item1).ToObservable())
                    .SelectMany(_ => SetVirtualCurrencyText().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _AdMobManager
                    ._RewardSubject
                    .Select(tuple => GetRewardPopupViewModel(amount: tuple.Item1, rewardType: tuple.Item2))
                    .SelectMany(popupViewModel => _PopupGenerateUseCase.GenerateRewardPopup(popupViewModel))
                    .Subscribe(_ => Owner.SetActiveBlockPanel(false))
                    .AddTo(_cts.Token);
            }

            private void PurchaseInPlayStoreSubscribe(IObservable<Unit> onClickObservable, string itemId)
            {
                onClickObservable
                    .Do(_ => Owner.SetActiveBlockPanel(true))
                    .Do(_ => _PlayStoreShopManager.BuyItem(itemId))
                    .Subscribe()
                    .AddTo(_cts.Token);

                _PlayStoreShopManager
                    ._OnSuccessPurchase
                    .Where(tuple => tuple.Item4 == itemId)
                    .SelectMany(tuple => _PlayFabVirtualCurrencyManager.AddVirtualCurrency(tuple.Item1, tuple.Item2).ToObservable())
                    .SelectMany(_ => SetVirtualCurrencyText().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _PlayStoreShopManager
                    ._OnSuccessPurchase
                    .Where(tuple => tuple.Item4 == itemId)
                    .Select(tuple => GetRewardPopupViewModel(amount: tuple.Item2, rewardType: tuple.Item3))
                    .SelectMany(popupViewModel => _PopupGenerateUseCase.GenerateRewardPopup(popupViewModel))
                    .Subscribe(_ => Owner.SetActiveBlockPanel(false))
                    .AddTo(_cts.Token);
            }

            private void ErrorSubscribe()
            {
                _PlayStoreShopManager
                    ._OnFailedPurchase
                    .SelectMany(message => _PopupGenerateUseCase.GenerateErrorPopup(message))
                    .Subscribe(_ => Owner.SetActiveBlockPanel(false))
                    .AddTo(_cts.Token);

                _AdMobManager
                    ._ErrorSubject
                    .SelectMany(message => _PopupGenerateUseCase.GenerateErrorPopup(message))
                    .Subscribe(_ => Owner.SetActiveBlockPanel(false))
                    .AddTo(_cts.Token);
            }

            private void CharacterSubscribe()
            {
                var addCharacter =
                    _View._GachaButton
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
                var addWeapon =
                    _View._ShopWeaponGridView._WeaponButton
                        .OnClickAsObservable()
                        .Do(_ => Owner.SetActiveBlockPanel(true))
                        .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._ShopWeaponGridView._WeaponButton).ToObservable())
                        .Select(_ => EnoughVirtualCurrency(WeaponRewardAmount, GameCommonData.GemKey))
                        .Publish();

                addWeapon
                    .Where(enoughGem => !enoughGem)
                    .SelectMany(_ => _PopupGenerateUseCase.GenerateErrorPopup(GameCommonData.Terms.AddGemPopupTile))
                    .Subscribe(_ => Owner.SetActiveBlockPanel(false))
                    .AddTo(_cts.Token);

                addWeapon
                    .Where(enoughGem => enoughGem)
                    .SelectMany(_ => GetRewardAsync(WeaponRewardAmount, GameCommonData.RewardType.Weapon, GameCommonData.WeaponBuyPrice * WeaponRewardAmount, GameCommonData.GemKey).ToObservable())
                    .Subscribe(_ =>
                    {
                        Owner.SetActiveBlockPanel(false);
                        _StateMachine.Dispatch((int)State.Reward, (int)State.Shop);
                    })
                    .AddTo(_cts.Token);

                addWeapon.Connect().AddTo(_cts.Token);
            }

            #endregion


            private string GetRewardKey(GameCommonData.RewardType rewardType)
            {
                return rewardType switch
                {
                    GameCommonData.RewardType.Gem => GameCommonData.GemKey,
                    GameCommonData.RewardType.Coin => GameCommonData.CoinKey,
                    _ => throw new ArgumentOutOfRangeException(nameof(rewardType), rewardType, null)
                };
            }

            private RewardPopup.ViewModel GetRewardPopupViewModel
            (
                int amount,
                GameCommonData.RewardType rewardType
            )
            {
                var rewardSprite = _MissionSpriteDataRepository.GetRewardSprite(rewardType);
                var popupViewModel = new RewardPopup.ViewModel
                (
                    "購入完了",
                    $"{amount}コインを獲得しました。",
                    rewardSprite,
                    amount
                );

                return popupViewModel;
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

            private void OnClickAds()
            {
                _AdMobManager.ShowRewardedAd();
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