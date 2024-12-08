using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using Repository;
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

            private CharacterSelectViewModelUseCase _CharacterSelectViewModelUseCase =>
                Owner._characterSelectViewModelUseCase;

            private CharacterSelectRepository _CharacterSelectRepository => Owner._characterSelectRepository;

            private PlayFabVirtualCurrencyManager _PlayFabVirtualCurrencyManager =>
                Owner._playFabVirtualCurrencyManager;

            private SortCharactersUseCase _SortCharactersUseCase => Owner._sortCharactersUseCase;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;

            private CancellationTokenSource _cancellationTokenSource;
            private readonly Subject<Unit> _onChangeViewModel = new();
            private readonly List<GameObject> _gridGroupLists = new();

            private const string AddGemPopupTile = "ジェムの数が足りません";
            private const string AddGemPopupExplanation = "ジェムの数が足りません。\nジェムを追加しますか？";
            private const string AddGemPopupOk = "追加";
            private const string AddGemPopupCancel = "キャンセル";

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
                OnSubscribed();
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

            private void OnSubscribed()
            {
                SubscribeToggleView();

                _onChangeViewModel
                    .Select(_ => _CharacterSelectViewModelUseCase.InAsTask())
                    .Subscribe(viewModel =>
                    {
                        _View.ApplyViewModel(viewModel);
                        CreateUIContents(viewModel.OrderType);
                    })
                    .AddTo(_cancellationTokenSource.Token);

                _View._ClickBackButton
                    .Subscribe(_ => OnClickBack())
                    .AddTo(_cancellationTokenSource.Token);
                _onChangeViewModel.OnNext(Unit.Default);
            }

            private void SubscribeToggleView()
            {
                foreach (var element in _View._ToggleElements)
                {
                    element.ClickOffButtonObservable
                        .Subscribe(type =>
                        {
                            _View.ApplyToggleView(type);
                            _CharacterSelectRepository.SetOrderType(type);
                            CreateUIContents(type);
                        })
                        .AddTo(_cancellationTokenSource.Token);
                }
            }


            private void CreateUIContents(CharacterSelectRepository.OrderType orderType)
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
                        gridGroup = Instantiate(_View._HorizontalGroupGameObject,
                            _View._ContentsTransform);
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

            private void CreateActiveGrid(CharacterData fixedCharacterData, Transform parent,
                CharacterSelectRepository.OrderType orderType)
            {
                var grid = Instantiate(_View._Grid, parent);
                var characterGrid = grid.GetComponentInChildren<CharacterGridView>();
                characterGrid.ApplyStatusGridViews(orderType, fixedCharacterData);
                characterGrid.gridButton.onClick.AddListener(() =>
                {
                    OnClickCharacterGrid(fixedCharacterData, characterGrid.gridButton);
                });
            }

            private void CreateDisableGrid(CharacterData characterData, Transform parent)
            {
                var disableGrid = Instantiate(_View._GridDisable, parent).GetComponent<CharacterDisableGrid>();
                disableGrid.characterImage.color = Color.black;
                disableGrid.characterImage.sprite = characterData.SelfPortraitSprite;
                disableGrid.purchaseButton.OnClickAsObservable()
                    .Subscribe(_ =>
                    {
                        OnClickPurchaseButton(disableGrid.purchaseButton, characterData,
                            disableGrid.GetCancellationTokenOnDestroy());
                    })
                    .AddTo(disableGrid.GetCancellationTokenOnDestroy());
            }

            private void OnClickCharacterGrid(CharacterData characterData, Button gridButton)
            {
                gridButton.interactable = false;
                _CharacterCreateUseCase.CreateCharacter(characterData.Id);
                _CharacterSelectRepository.SetSelectedCharacterId(characterData.Id);
                Owner._uiAnimation.ClickScale(gridButton.gameObject).OnComplete(() =>
                {
                    Owner._stateMachine.Dispatch((int)State.CharacterDetail);
                    gridButton.interactable = true;
                }).SetLink(Owner.gameObject);
            }

            private void OnClickBack()
            {
                Owner._uiAnimation.ClickScaleColor(_View._BackButton.gameObject).OnComplete(() =>
                {
                    Owner._stateMachine.Dispatch((int)State.Main);
                }).SetLink(Owner.gameObject);
            }

            private void OnClickPurchaseButton(Button disableGrid, CharacterData characterData,
                CancellationToken token)
            {
                disableGrid.interactable = false;
                Owner._uiAnimation.ClickScale(disableGrid.gameObject).OnComplete(() => UniTask.Void(async () =>
                {
                    var user = Owner._userDataRepository.GetUserData();
                    var characterPrice = GameCommonData.CharacterPrice;
                    var gem = await _PlayFabVirtualCurrencyManager.GetGem();
                    if (gem == GameCommonData.NetworkErrorCode)
                    {
                        disableGrid.interactable = true;
                        return;
                    }

                    if (gem < characterPrice)
                    {
                        await _PopupGenerateUseCase.GenerateConfirmPopup
                        (AddGemPopupTile,
                            AddGemPopupExplanation,
                            AddGemPopupOk,
                            AddGemPopupCancel,
                            okAction: () => { Owner._stateMachine.Dispatch((int)State.Shop); }
                        );
                        disableGrid.interactable = true;
                        return;
                    }

                    if (user.Characters.Contains(characterData.Id))
                    {
                        disableGrid.interactable = true;
                        return;
                    }

                    var virtualCurrencyKey = GameCommonData.GemKey;
                    var price = characterPrice;
                    var isSuccessPurchase = await Owner._playFabShopManager
                        .TryPurchaseCharacter(characterData.Id, virtualCurrencyKey, price)
                        .AttachExternalCancellation(token);
                    if (!isSuccessPurchase)
                    {
                        //todo 購入に失敗したときの処理
                        disableGrid.interactable = true;
                        return;
                    }

                    await Owner.SetGemText();
                    await Owner.SetRewardUI(1, characterData.SelfPortraitSprite);
                    _onChangeViewModel.OnNext(Unit.Default);
                    disableGrid.interactable = true;
                })).SetLink(disableGrid.gameObject);
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