using System;
using System.Linq;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Repository;
using UI.Common;
using UniRx;
using UnityEngine;
using UseCase;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterDetailState : StateMachine<TitleCore>.State
        {
            private CharacterDetailView _View => (CharacterDetailView)Owner.GetView(State.CharacterDetail);
            private CommonView _CommonView => Owner._commonView;
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;
            private CharacterObjectRepository _CharacterObjectRepository => Owner._characterObjectRepository;
            private AnimationPlayBackUseCase _AnimationPlayBackUseCase => Owner._animationPlayBackUseCase;
            private CharacterDetailViewModelUseCase _CharacterDetailViewModelUseCase => Owner._characterDetailViewModelUseCase;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private SortCharactersUseCase _SortCharactersUseCase => Owner._sortCharactersUseCase;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private SkillDetailViewModelUseCase _SkillDetailViewModelUseCase => Owner._skillDetailViewModelUseCase;
            private MissionManager _MissionManager => Owner._missionManager;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private PlayFabUserDataManager _playFabUserDataManager;
            private PlayFabShopManager _playFabShopManager;
            private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
            private TemporaryCharacterRepository _temporaryCharacterRepository;
            private UIAnimation _uiAnimation;

            private CancellationTokenSource _cts;
            private int _candidateIndex;
            private CharacterData[] _sortedCharacters;
            private readonly Subject<int> _onChangeViewModel = new();
            private const int SkillOne = 1;
            private const int SkillTwo = 2;
            private bool _isTeamEdit;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            private async UniTask Initialize()
            {
                await Owner.SwitchUiObject(State.CharacterDetail, true, () =>
                {
                    SetupCancellationToken();
                    _playFabUserDataManager = Owner._playFabUserDataManager;
                    _playFabShopManager = Owner._playFabShopManager;
                    _playFabVirtualCurrencyManager = Owner._playFabVirtualCurrencyManager;
                    _uiAnimation = Owner._uiAnimation;
                    _temporaryCharacterRepository = Owner._temporaryCharacterRepository;
                    _isTeamEdit = _StateMachine._PreviousState == (int)State.TeamEdit;
                    var userData = _UserDataRepository.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        _View._LeftArrowButton.gameObject.SetActive(false);
                        _View._RightArrowButton.gameObject.SetActive(false);
                    }
                    else
                    {
                        _View._LeftArrowButton.gameObject.SetActive(true);
                        _View._RightArrowButton.gameObject.SetActive(true);
                    }

                    GenerateCharacter();
                    Subscribe();
                });
                PlayBackAnimation();
            }

            private void Subscribe()
            {
                _onChangeViewModel
                    .Select(characterId => _CharacterDetailViewModelUseCase.InAsTask(characterId, _isTeamEdit))
                    .Subscribe(viewModel => _View.ApplyViewModel(viewModel))
                    .AddTo(_cts.Token);

                _View._PurchaseErrorView.okButton
                    .OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._PurchaseErrorView.okButton).ToObservable())
                    .SelectMany(_ => OnClickClosePurchaseErrorView().ToObservable())
                    .Subscribe(_ => { Owner.SetActiveBlockPanel(false); })
                    .AddTo(_cts.Token);

                _View._BackButton
                    .OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._BackButton).ToObservable())
                    .Subscribe(_ => OnClickBackButton())
                    .AddTo(_cts.Token);

                _View._TeamEditButton
                    .OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._TeamEditButton).ToObservable())
                    .SelectMany(_ => OnClickDecideButton().ToObservable())
                    .Subscribe(_ =>
                    {
                        ChangeState();
                        Owner.SetActiveBlockPanel(false);
                    })
                    .AddTo(_cts.Token);

                _View._LeftArrowButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._LeftArrowButton).ToObservable())
                    .Subscribe(_ => OnClickLeftArrow())
                    .AddTo(_cts.Token);

                _View._RightArrowButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._RightArrowButton).ToObservable())
                    .Subscribe(_ => OnClickRightArrow())
                    .AddTo(_cts.Token);

                _View._UpgradeButton
                    .OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._UpgradeButton).ToObservable())
                    .SelectMany(_ => OnClickUpgrade().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _View._VirtualCurrencyAddPopup.OnClickCancelButton
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._VirtualCurrencyAddPopup.CancelButton).ToObservable())
                    .SelectMany(_ => OnClickCloseVirtualCurrencyAddView().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _View._VirtualCurrencyAddPopup.OnClickCloseButton
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._VirtualCurrencyAddPopup.CloseButton).ToObservable())
                    .SelectMany(_ => OnClickCloseVirtualCurrencyAddView().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _View._VirtualCurrencyAddPopup.OnClickAddButton
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._VirtualCurrencyAddPopup.AddButton).ToObservable())
                    .Subscribe(_ => OnClickAddVirtualCurrency())
                    .AddTo(_cts.Token);

                _View._InventoryButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._InventoryButton).ToObservable())
                    .Subscribe(_ =>
                    {
                        stateMachine.Dispatch((int)State.Inventory, (int)State.CharacterDetail);
                        Owner.SetActiveBlockPanel(false);
                    })
                    .AddTo(_cts.Token);

                _CommonView.errorView.okButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_CommonView.errorView.okButton).ToObservable())
                    .SelectMany(_ => OnClickCloseErrorView().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _View._OnClickNormalSkillButtonAsObservable
                    .SelectMany(button => Owner.OnClickScaleColorAnimation(button).ToObservable())
                    .WithLatestFrom(_onChangeViewModel, (_, onChange) => onChange)
                    .Select(characterId => _CharacterDetailViewModelUseCase.InAsTask(characterId, _isTeamEdit))
                    .Select(viewModel => _SkillDetailViewModelUseCase.InAsTask(viewModel._CharacterData.NormalSkillId))
                    .SelectMany(viewModel => _PopupGenerateUseCase.GenerateSkillDetailPopup(viewModel))
                    .Subscribe(_ => { Owner.SetActiveBlockPanel(false); })
                    .AddTo(_cts.Token);

                _View._OnClickSpecialSkillButtonAsObservable
                    .SelectMany(button => Owner.OnClickScaleColorAnimation(button).ToObservable())
                    .WithLatestFrom(_onChangeViewModel, (_, onChange) => onChange)
                    .Select(characterId => _CharacterDetailViewModelUseCase.InAsTask(characterId, _isTeamEdit))
                    .Select(viewModel => _SkillDetailViewModelUseCase.InAsTask(viewModel._CharacterData.SpecialSkillId))
                    .SelectMany(viewModel => _PopupGenerateUseCase.GenerateSkillDetailPopup(viewModel))
                    .Subscribe(_ => { Owner.SetActiveBlockPanel(false); })
                    .AddTo(_cts.Token);

                _View._OnClickWeaponSkillButtonAsObservable
                    .SelectMany(button => Owner.OnClickScaleColorAnimation(button).ToObservable())
                    .WithLatestFrom(_onChangeViewModel, (_, onChange) => onChange)
                    .Select(characterId => _CharacterDetailViewModelUseCase.InAsTask(characterId, _isTeamEdit))
                    .Where(viewModel => viewModel._WeaponMasterData.NormalSkillMasterData != null)
                    .Select(viewModel => _SkillDetailViewModelUseCase.InAsTask(viewModel._WeaponMasterData.NormalSkillMasterData.Id))
                    .SelectMany(viewModel => _PopupGenerateUseCase.GenerateSkillDetailPopup(viewModel))
                    .Subscribe(_ => { Owner.SetActiveBlockPanel(false); })
                    .AddTo(_cts.Token);

                var candidateCharacterId = _sortedCharacters[_candidateIndex].Id;
                _onChangeViewModel.OnNext(candidateCharacterId);
            }

            private void GenerateCharacter()
            {
                var selectedCharacterId = _temporaryCharacterRepository.GetSelectedCharacterId();
                var orderType = _temporaryCharacterRepository.GetOrderType();
                _sortedCharacters = _SortCharactersUseCase.InAsTask(orderType).ToArray();
                _candidateIndex = Array.FindIndex(_sortedCharacters, x => x.Id == selectedCharacterId);
                var selectedCharacter = _sortedCharacters[_candidateIndex];
                CreateCharacter(selectedCharacter);
            }

            private void OnClickBackButton()
            {
                Owner._stateMachine.Dispatch((int)State.CharacterSelect);
                Owner.SetActiveBlockPanel(false);
            }

            private void OnClickRightArrow()
            {
                var userData = _UserDataRepository.GetUserData();
                if (userData.Characters.Count <= 1)
                {
                    Owner.SetActiveBlockPanel(false);
                    return;
                }

                _candidateIndex++;
                if (_candidateIndex >= _sortedCharacters.Length)
                {
                    _candidateIndex = 0;
                }

                var candidateCharacter = _sortedCharacters[_candidateIndex];
                _temporaryCharacterRepository.SetSelectedCharacterId(candidateCharacter.Id);
                CreateCharacter(candidateCharacter);
                _onChangeViewModel.OnNext(candidateCharacter.Id);
                PlayBackAnimation();
                Owner.SetActiveBlockPanel(false);
            }

            private void OnClickLeftArrow()
            {
                var userData = _UserDataRepository.GetUserData();
                if (userData.Characters.Count <= 1)
                {
                    Owner.SetActiveBlockPanel(false);
                    return;
                }

                _candidateIndex--;
                if (_candidateIndex < 0)
                {
                    _candidateIndex = _sortedCharacters.Length - 1;
                }

                var candidateCharacter = _sortedCharacters[_candidateIndex];
                _temporaryCharacterRepository.SetSelectedCharacterId(candidateCharacter.Id);
                CreateCharacter(candidateCharacter);
                _onChangeViewModel.OnNext(candidateCharacter.Id);
                PlayBackAnimation();
                Owner.SetActiveBlockPanel(false);
            }

            private async UniTask OnClickDecideButton()
            {
                if (_isTeamEdit)
                {
                    var userData = _UserDataRepository.GetUserData();
                    var characterId = _sortedCharacters[_candidateIndex].Id;
                    _UserDataRepository.SetTeamMember(characterId);
                    await _playFabUserDataManager.TryUpdateUserDataAsync(userData);
                }
            }

            private void ChangeState()
            {
                var prevState = _StateMachine._PreviousState;
                if (prevState >= 0)
                {
                    _StateMachine.Dispatch(prevState);
                }
                else
                {
                    _StateMachine.Dispatch((int)State.TeamEdit, (int)State.CharacterDetail);
                }
            }

            private async UniTask OnClickUpgrade()
            {
                var selectedCharacterData = _sortedCharacters[_candidateIndex];
                var coin = await _playFabVirtualCurrencyManager.GetCoin();
                if (coin == GameCommonData.NetworkErrorCode)
                {
                    Owner.SetActiveBlockPanel(false);
                    return;
                }


                var nextLevelData = _UserDataRepository.GetNextLevelData(selectedCharacterData.Id);
                var virtualCurrencyAddView = _View._VirtualCurrencyAddPopup;
                var purchaseErrorView = _View._PurchaseErrorView;
                if (coin < nextLevelData.NeedCoin)
                {
                    virtualCurrencyAddView.transform.localScale = Vector3.zero;
                    virtualCurrencyAddView.gameObject.SetActive(true);
                    await _uiAnimation.Open(virtualCurrencyAddView.transform, GameCommonData.OpenDuration);
                    Owner.SetActiveBlockPanel(false);
                    return;
                }

                var result = await _playFabShopManager.TryPurchaseLevelUpItem(nextLevelData.Level,
                    GameCommonData.CoinKey, nextLevelData.NeedCoin, selectedCharacterData.Id, purchaseErrorView);

                if (!result)
                {
                    Debug.LogError("購入処理エラー");
                    purchaseErrorView.transform.localScale = Vector3.zero;
                    purchaseErrorView.gameObject.SetActive(true);
                    await _uiAnimation.Open(purchaseErrorView.transform, GameCommonData.OpenDuration);
                    Owner.SetActiveBlockPanel(false);
                    return;
                }

                _MissionManager.CheckMission(GameCommonData.MissionActionId.LevelUp, 1);
                _MissionManager.CheckMission(GameCommonData.MissionActionId.CharacterLevelUp, 1, selectedCharacterData.Id);
                var userData = _UserDataRepository.GetUserData();
                await _UserDataRepository.UpdateUserData(userData);
                await Owner.SetCoinText();
                _onChangeViewModel.OnNext(selectedCharacterData.Id);
                if (nextLevelData.Level == GameCommonData.MaxCharacterLevel)
                {
                    CreateCharacter(selectedCharacterData);
                }

                Owner.SetActiveBlockPanel(false);
            }

            private async UniTask OnClickCloseVirtualCurrencyAddView()
            {
                var virtualCurrencyAddView = _View._VirtualCurrencyAddPopup;
                await _uiAnimation.Close(virtualCurrencyAddView.transform, GameCommonData.CloseDuration);
                virtualCurrencyAddView.gameObject.SetActive(false);
                Owner.SetActiveBlockPanel(false);
            }

            private void OnClickAddVirtualCurrency()
            {
                _StateMachine.Dispatch((int)State.Shop);
                Owner.SetActiveBlockPanel(false);
            }

            private async UniTask OnClickClosePurchaseErrorView()
            {
                var purchaseErrorView = _View._PurchaseErrorView;
                await _uiAnimation.Close(purchaseErrorView.transform, GameCommonData.CloseDuration);
                purchaseErrorView.gameObject.SetActive(false);
            }


            private async UniTask OnClickCloseErrorView()
            {
                var errorView = _CommonView.errorView.transform;
                await _uiAnimation.Close(errorView, GameCommonData.CloseDuration);
                errorView.gameObject.SetActive(false);
                Owner.SetActiveBlockPanel(false);
            }


            private void CreateCharacter(CharacterData characterData)
            {
                _CharacterCreateUseCase.CreateTeamMember(characterData.Id);
            }

            private void PlayBackAnimation()
            {
                var character = _CharacterObjectRepository.GetCharacterObject();
                var animator = character.GetComponent<Animator>();
                _AnimationPlayBackUseCase.RandomPlayBack(animator, AnimationStateType.Performance);
                _AnimationPlayBackUseCase.RandomPlayBack(animator, AnimationStateType.Idle);
            }

            private void SetupCancellationToken()
            {
                if (_cts != null)
                {
                    return;
                }

                _cts = new CancellationTokenSource();
                _cts.RegisterRaiseCancelOnDestroy(Owner);
            }

            private void Cancel()
            {
                if (_cts == null)
                {
                    return;
                }

                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}