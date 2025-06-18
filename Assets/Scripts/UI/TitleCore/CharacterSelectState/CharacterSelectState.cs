using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager;
using Manager.NetworkManager;
using Repository;
using UI.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UseCase;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterSelectState : StateMachine<TitleCore>.State
        {
            private CharacterSelectView _View => (CharacterSelectView)Owner.GetView(State.CharacterSelect);
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;
            private CharacterSelectViewModelUseCase _CharacterSelectViewModelUseCase => Owner._characterSelectViewModelUseCase;
            private TemporaryCharacterRepository _TemporaryCharacterRepository => Owner._temporaryCharacterRepository;
            private PlayFabVirtualCurrencyManager _PlayFabVirtualCurrencyManager => Owner._playFabVirtualCurrencyManager;
            private SortCharactersUseCase _SortCharactersUseCase => Owner._sortCharactersUseCase;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private RewardDataRepository _RewardDataRepository => Owner._rewardDataRepository;
            private CharacterTypeSpriteRepository _CharacterTypeSpriteRepository => Owner._characterTypeSpriteRepository;
            private DataAcrossStates _DataAcrossStates => Owner._dataAcrossStates;

            private CancellationTokenSource _cancellationTokenSource;
            private readonly Subject<Unit> _onChangeViewModel = new();
            private readonly List<GameObject> _gridGroupLists = new();


            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            private void Initialize()
            {
                _View.InitializeUiPosition();
                SetupCancellationToken();
                Subscribe();
                Owner.SwitchUiObject(State.CharacterSelect, true).Forget();
            }

            private void SetupCancellationToken()
            {
                if (_cancellationTokenSource != null)
                {
                    return;
                }

                _cancellationTokenSource = new CancellationTokenSource();
            }

            private void Subscribe()
            {
                SubscribeSortToggleView();

                _onChangeViewModel
                    .Select(_ => _CharacterSelectViewModelUseCase.InAsTask())
                    .Subscribe(viewModel =>
                    {
                        _View.ApplyViewModel(viewModel);
                        CreateUIContents(viewModel._OrderType);
                    })
                    .AddTo(_cancellationTokenSource.Token);

                _View._BackButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._BackButton).ToObservable())
                    .Subscribe(_ =>
                    {
                        var prevState = _StateMachine._PreviousState;
                        if (prevState == GameCommonData.InvalidNumber)
                        {
                            _StateMachine.Dispatch(prevState);
                        }
                        else
                        {
                            _StateMachine.Dispatch((int)State.Main);
                        }
                    })
                    .AddTo(_cancellationTokenSource.Token);

                _onChangeViewModel.OnNext(Unit.Default);
            }

            private void SubscribeSortToggleView()
            {
                foreach (var element in _View._ToggleElements)
                {
                    element.ClickOffButtonObservable
                        .Subscribe(type =>
                        {
                            Owner.SetActiveBlockPanel(true);
                            _View.ApplyToggleView(type);
                            _TemporaryCharacterRepository.SetOrderType(type);
                            CreateUIContents(type);
                            Owner.SetActiveBlockPanel(false);
                        })
                        .AddTo(_cancellationTokenSource.Token);
                }
            }


            private void CreateUIContents(TemporaryCharacterRepository.OrderType orderType)
            {
                foreach (var gridGroupList in _gridGroupLists)
                {
                    Destroy(gridGroupList);
                }

                _gridGroupLists.Clear();
                GameObject gridGroup = null;
                var index = 0;
                var fixedCharacterDataArray = _SortCharactersUseCase.InAsTask(orderType);
                foreach (var fixedCharacterData in fixedCharacterDataArray)
                {
                    if (index % 5 == 0)
                    {
                        gridGroup = Instantiate(_View._HorizontalGroupGameObject, _View._ContentsTransform);
                        _gridGroupLists.Add(gridGroup);
                    }

                    if (gridGroup != null)
                    {
                        CreateActiveGrid(fixedCharacterData, gridGroup.transform, orderType);
                    }

                    index++;
                }

                foreach (var characterData in _UserDataRepository.GetNotAvailableCharacters())
                {
                    if (index % 5 == 0)
                    {
                        gridGroup = Instantiate(_View._HorizontalGroupGameObject, _View._ContentsTransform);
                        _gridGroupLists.Add(gridGroup);
                    }

                    if (gridGroup != null)
                    {
                        CreateDisableGrid(characterData, gridGroup.transform);
                    }

                    index++;
                }
            }

            private void CreateActiveGrid(CharacterData fixedCharacterData, Transform parent, TemporaryCharacterRepository.OrderType orderType)
            {
                var grid = Instantiate(_View._Grid, parent);
                var characterGrid = grid.GetComponentInChildren<CharacterGridView>();
                var (typeSprite, typeColor) = _CharacterTypeSpriteRepository.GetCharacterTypeData(fixedCharacterData.Type);
                characterGrid.ApplyStatusGridViews(orderType, fixedCharacterData, (typeSprite, typeColor));

                characterGrid.gridButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(characterGrid.gridButton).ToObservable())
                    .Subscribe(_ =>
                    {
                        OnClickCharacterGrid(fixedCharacterData);
                        Owner.SetActiveBlockPanel(false);
                    })
                    .AddTo(characterGrid.GetCancellationTokenOnDestroy());
            }

            private void CreateDisableGrid(CharacterData characterData, Transform parent)
            {
                var disableGrid = Instantiate(_View._GridDisable, parent).GetComponent<CharacterDisableGrid>();
                disableGrid.ApplyView
                (
                    characterData.Id,
                    characterData.SelfPortraitSprite,
                    () => Owner.OnClickScaleAnimation(disableGrid.purchaseButton)
                );

                var haveEnoughGem = disableGrid._OnClickPurchaseButton
                    .SelectMany(tuple => HaveEnoughGem(tuple).ToObservable())
                    .Publish();

                var addGem = haveEnoughGem
                    .Where(purchasedCharacterData => purchasedCharacterData.haveEnoughGem == false)
                    .SelectMany(_ => _PopupGenerateUseCase.GenerateConfirmPopup
                    (
                        GameCommonData.Terms.AddGemPopupTile,
                        GameCommonData.Terms.AddGemPopupExplanation,
                        GameCommonData.Terms.AddGemPopupOk,
                        GameCommonData.Terms.AddGemPopupCancel
                    ))
                    .Publish();

                addGem
                    .Where(isOk => !isOk)
                    .Subscribe(_ => Owner.SetActiveBlockPanel(false))
                    .AddTo(disableGrid.GetCancellationTokenOnDestroy());

                addGem
                    .Where(isOk => isOk)
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Shop, (int)State.CharacterSelect); })
                    .AddTo(disableGrid.GetCancellationTokenOnDestroy());

                var purchaseCharacter =
                    haveEnoughGem
                        .Where(purchasedCharacterData => purchasedCharacterData.haveEnoughGem)
                        .SelectMany(purchasedCharacterData => _PopupGenerateUseCase.GenerateConfirmPopup
                        (
                            GameCommonData.Terms.PurchaseCharacterPopupTitle,
                            GameCommonData.Terms.PurchaseCharacterPopupExplanation,
                            GameCommonData.Terms.PurchaseCharacterPopupOk,
                            GameCommonData.Terms.PurchaseCharacterPopupCancel
                        ).Select(isOk => (isOk, purchasedCharacterData)))
                        .Publish();

                purchaseCharacter
                    .Where(tuple => tuple.isOk)
                    .SelectMany(tuple => PurchaseCharacter(tuple.purchasedCharacterData.characterData).ToObservable())
                    .Subscribe(characterId =>
                    {
                        (int, GameCommonData.RewardType)[] characterIds = { (characterId, GameCommonData.RewardType.Character) };
                        _RewardDataRepository.SetRewardIds(characterIds);
                        _StateMachine.Dispatch((int)State.Reward, (int)State.CharacterSelect);
                        _onChangeViewModel.OnNext(Unit.Default);
                    })
                    .AddTo(disableGrid.GetCancellationTokenOnDestroy());

                purchaseCharacter
                    .Where(tuple => !tuple.isOk)
                    .Subscribe(_ => { Owner.SetActiveBlockPanel(false); })
                    .AddTo(disableGrid.GetCancellationTokenOnDestroy());

                haveEnoughGem.Connect().AddTo(disableGrid.GetCancellationTokenOnDestroy());
                addGem.Connect().AddTo(disableGrid.GetCancellationTokenOnDestroy());
                purchaseCharacter.Connect().AddTo(disableGrid.GetCancellationTokenOnDestroy());
            }

            private async UniTask<(bool haveEnoughGem, (int characterId, Sprite characterSprite) characterData)> HaveEnoughGem((int, Sprite) characterData)
            {
                var user = Owner._userDataRepository.GetUserData();
                var gem = await _PlayFabVirtualCurrencyManager.GetGem();
                const int characterPrice = GameCommonData.CharacterPrice;
                if (gem == GameCommonData.NetworkErrorCode)
                {
                    return (false, characterData);
                }

                if (user.Characters.Contains(characterData.Item1))
                {
                    return (false, characterData);
                }

                return gem >= characterPrice ? (true, tuple: characterData) : (false, tuple: characterData);
            }

            private async UniTask<int> PurchaseCharacter((int characterId, Sprite characterSprite) characterData)
            {
                const int characterPrice = GameCommonData.CharacterPrice;
                const string virtualCurrencyKey = GameCommonData.GemKey;
                const int price = characterPrice;
                var isSuccessPurchase = await Owner._playFabShopManager
                    .TryPurchaseCharacter(characterData.characterId, virtualCurrencyKey, price)
                    .AttachExternalCancellation(_cancellationTokenSource.Token);
                if (!isSuccessPurchase)
                {
                    //todo 購入に失敗したときの処理
                    return -1;
                }

                await Owner.SetGemText();
                return characterData.characterId;
            }

            private void OnClickCharacterGrid(CharacterData characterData)
            {
                _CharacterCreateUseCase.CreateTeamMember(characterData.Id);
                _TemporaryCharacterRepository.SetSelectedCharacterId(characterData.Id);
                if (_DataAcrossStates.GetCanEditTeam())
                {
                    _StateMachine.Dispatch((int)State.CharacterDetail, (int)State.TeamEdit);
                }
                else
                {
                    _StateMachine.Dispatch((int)State.CharacterDetail);
                }
            }


            private void Cancel()
            {
                if (_cancellationTokenSource == null)
                {
                    return;
                }

                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }
    }
}