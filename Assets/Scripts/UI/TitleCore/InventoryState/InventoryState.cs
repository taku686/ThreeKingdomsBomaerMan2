using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using Repository;
using UI.Common;
using UniRx;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class InventoryState : StateMachine<TitleCore>.State
        {
            private InventoryView _View => (InventoryView)Owner.GetView(State.Inventory);
            private InventoryViewModelUseCase _InventoryViewModelUseCase => Owner._inventoryViewModelUseCase;
            private TemporaryCharacterRepository _TemporaryCharacterRepository => Owner._temporaryCharacterRepository;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private SkillDetailViewModelUseCase _SkillDetailViewModelUseCase => Owner._skillDetailViewModelUseCase;
            private UIAnimation _UIAnimation => Owner._uiAnimation;
            private PlayFabShopManager _PlayFabShopManager => Owner._playFabShopManager;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private WeaponSortRepository _WeaponSortRepository => Owner._weaponSortRepository;
            private WeaponCautionRepository _WeaponCautionRepository => Owner._weaponCautionRepository;
            private WeaponMasterDataRepository _WeaponMasterDataRepository => Owner._weaponMasterDataRepository;
            private CancellationTokenSource _cts;
            private Subject<int> _onChangeSelectedWeaponSubject;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                _onChangeSelectedWeaponSubject.Dispose();
                Cancel();
            }

            private void Initialize()
            {
                _onChangeSelectedWeaponSubject = new Subject<int>();
                _cts = new CancellationTokenSource();
                _View.CloseSortView();
                Subscribe();
                Owner.SwitchUiObject(State.Inventory, true).Forget();
            }

            private void Subscribe()
            {
                _View._BackButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._BackButton).ToObservable())
                    .Subscribe(_ =>
                    {
                        var preState = StateMachine._PreviousState;
                        if (preState == GameCommonData.InvalidNumber)
                        {
                            StateMachine.Dispatch((int)State.CharacterDetail);
                            return;
                        }
                        
                        StateMachine.Dispatch(preState);
                    })
                    .AddTo(_cts.Token);

                _onChangeSelectedWeaponSubject
                    .Select(weaponId => _InventoryViewModelUseCase.InAsTask(weaponId))
                    .Subscribe(viewModel =>
                    {
                        _View.ApplyViewModel(viewModel, _UIAnimation, Owner.SetActiveBlockPanel);
                        foreach (var gridView in _View._WeaponGridViews)
                        {
                            gridView._OnClickObservable
                                .Subscribe(weaponId =>
                                {
                                    _WeaponCautionRepository.SetWeaponCautionData(weaponId, false);
                                    _onChangeSelectedWeaponSubject.OnNext(weaponId);
                                })
                                .AddTo(_cts.Token);
                        }
                    })
                    .AddTo(_cts.Token);

                _View._EquipButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._EquipButton).ToObservable())
                    .WithLatestFrom(_onChangeSelectedWeaponSubject, (_, weaponId) => weaponId)
                    .Select(selectedWeaponId => (selectedWeaponId, selectedCharacterId: _TemporaryCharacterRepository.GetSelectedCharacterId()))
                    .SelectMany(tuple => _UserDataRepository.SetEquippedWeapon(tuple.selectedCharacterId, tuple.selectedWeaponId).ToObservable())
                    .Subscribe(_ =>
                    {
                        var prevState = StateMachine._PreviousState;
                        if(prevState == GameCommonData.InvalidNumber)
                        {
                            StateMachine.Dispatch((int)State.CharacterDetail);
                            return;
                        }
                        stateMachine.Dispatch(prevState);
                    })
                    .AddTo(_cts.Token);

                DetailSkillSubscribe();
                SellWeaponSubscribe();
                SortViewSubscribe();
                OnNextSelectedWeapon();
            }

            private void OnNextSelectedWeapon()
            {
                var selectedCharacterId = _TemporaryCharacterRepository.GetSelectedCharacterId();
                var selectedWeaponId = _UserDataRepository.GetEquippedWeaponId(selectedCharacterId);
                _onChangeSelectedWeaponSubject.OnNext(selectedWeaponId);
            }

            private void DetailSkillSubscribe()
            {
                _View._OnClickNormalSkillDetailButtonAsObservable
                    .WithLatestFrom(_onChangeSelectedWeaponSubject, (_, weaponId) => weaponId)
                    .Select(weaponId => _WeaponMasterDataRepository.GetWeaponData(weaponId).NormalSkillMasterData.Id)
                    .Select(skillId => _SkillDetailViewModelUseCase.InAsTask(skillId))
                    .SelectMany(viewModel => _PopupGenerateUseCase.GenerateSkillDetailPopup(viewModel))
                    .Subscribe(_ => { Owner.SetActiveBlockPanel(false); })
                    .AddTo(_cts.Token);
            }

            private void SortViewSubscribe()
            {
                var sortTypes = _WeaponSortRepository.GetSortTypeDictionary();
                var filterTypes = _WeaponSortRepository.GetFilterTypeDictionary();
                var rarityFilters = _WeaponSortRepository.GetRarityFilterTypeDictionary();
                var isAscending = _WeaponSortRepository.GetAscendingSwitch();
                var sortToggleViews = _View._SortPopupView._SortToggleViews;
                var filterToggleViews = _View._SortPopupView._FilterToggleViews;
                var rareToggleViews = _View._SortPopupView._RareFilterToggleViews;

                _View._SortPopupView.ApplyAscendingSwitch(isAscending);

                foreach (var sortToggleView in sortToggleViews)
                {
                    foreach (var (sort, isDisable) in sortTypes)
                    {
                        sortToggleView.SetActive(sort, isDisable);
                    }

                    sortToggleView._OnClickSortButtonAsObservable
                        .Subscribe(sortType =>
                        {
                            _WeaponSortRepository.SetSortType(sortType);
                            foreach (var (sort, isDisable) in sortTypes)
                            {
                                foreach (var toggleView in sortToggleViews)
                                {
                                    toggleView.SetActive(sort, isDisable);
                                }
                            }
                        })
                        .AddTo(_cts.Token);
                }

                foreach (var filterToggleView in filterToggleViews)
                {
                    filterToggleView.Initialize();
                    foreach (var (filter, isDisable) in filterTypes)
                    {
                        filterToggleView.SetActive(filter, isDisable);
                    }

                    filterToggleView._OnChangedValueFilterToggleAsObservable
                        .Skip(1)
                        .Subscribe(filterType =>
                        {
                            _WeaponSortRepository.SetFilterType(filterType);
                            foreach (var (filter, isDisable) in filterTypes)
                            {
                                foreach (var toggleView in filterToggleViews)
                                {
                                    toggleView.SetActive(filter, isDisable);
                                }
                            }
                        })
                        .AddTo(_cts.Token);
                }

                foreach (var rareToggleView in rareToggleViews)
                {
                    rareToggleView.Initialize();
                    foreach (var (rarity, isDisable) in rarityFilters)
                    {
                        rareToggleView.SetActive(rarity, isDisable);
                    }

                    rareToggleView._OnChangedValueFilterToggleAsObservable
                        .Skip(1)
                        .Subscribe(rare =>
                        {
                            _WeaponSortRepository.SetRarity(rare);
                            foreach (var toggleView in rareToggleViews)
                            {
                                foreach (var (rarity, isDisable) in rarityFilters)
                                {
                                    toggleView.SetActive(rarity, isDisable);
                                }
                            }
                        })
                        .AddTo(_cts.Token);
                }

                _View._OnClickSortButtonAsObservable
                    .Subscribe(_ => { _View.ApplySortView(); })
                    .AddTo(_cts.Token);

                _View._OnClickSortOkButtonAsObservable
                    .Subscribe(_ =>
                    {
                        OnNextSelectedWeapon();
                        _View.CloseSortView();
                    })
                    .AddTo(_cts.Token);

                _View._OnClickAscendingSwitchAsObservable
                    .Subscribe(isOn =>
                    {
                        _View._SortPopupView.ApplyAscendingSwitch(isOn);
                        _WeaponSortRepository.SetAscending(isOn);
                    })
                    .AddTo(_cts.Token);
            }

            private void SellWeaponSubscribe()
            {
                var sellWeapon =
                    _View._OnClickSellButtonAsObservable
                        .WithLatestFrom(_onChangeSelectedWeaponSubject, (_, weaponId) => weaponId)
                        .SelectMany(weaponId => _PlayFabShopManager.SellWeaponAsync(weaponId, 1).ToObservable())
                        .Publish();

                sellWeapon
                    .Where(tuple => !tuple.Item1)
                    .Do(tuple => { _onChangeSelectedWeaponSubject.OnNext(tuple.Item3); })
                    .SelectMany(tuple => _PopupGenerateUseCase.GenerateErrorPopup(tuple.Item2))
                    .Subscribe()
                    .AddTo(_cts.Token);

                sellWeapon
                    .Where(result => result.Item1)
                    .Do(_ => SetVirtualCurrencyText().ToObservable())
                    .Subscribe(tuple => { _onChangeSelectedWeaponSubject.OnNext(tuple.Item3); })
                    .AddTo(_cts.Token);

                sellWeapon.Connect().AddTo(_cts.Token);
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