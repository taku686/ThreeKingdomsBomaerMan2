using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UseCase;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterSelectState : StateMachine<TitleCore>.State
        {
            private CharacterSelectView view;
            private CharacterSelectViewModelUseCase characterSelectViewModelUseCase;
            private CharacterSelectRepository characterSelectRepository;
            private PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager;
            private SortCharactersUseCase sortCharactersUseCase;
            private UserDataManager UserDataManager => Owner.userDataManager;

            private CancellationTokenSource cancellationTokenSource;
            private readonly Subject<Unit> onChangeViewModel = new();
            private readonly List<GameObject> gridGroupLists = new();

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
                view = Owner.characterSelectView;
                playFabVirtualCurrencyManager = Owner.playFabVirtualCurrencyManager;
                characterSelectViewModelUseCase = Owner.characterSelectViewModelUseCase;
                characterSelectRepository = Owner.characterSelectRepository;
                sortCharactersUseCase = Owner.sortCharactersUseCase;

                view.InitializeUiPosition();
                SetupCancellationToken();
                OnSubscribed();
                Owner.SwitchUiObject(State.CharacterSelect, true).Forget();
            }

            private void SetupCancellationToken()
            {
                if (cancellationTokenSource != null)
                {
                    return;
                }

                cancellationTokenSource = new CancellationTokenSource();
            }

            private void OnSubscribed()
            {
                SubscribeToggleView();

                onChangeViewModel
                    .Select(_ => characterSelectViewModelUseCase.InAsTask())
                    .Subscribe(viewModel =>
                    {
                        view.ApplyViewModel(viewModel);
                        CreateUIContents(viewModel.OrderType);
                    })
                    .AddTo(cancellationTokenSource.Token);

                view.ClickBackButton
                    .Subscribe(_ => OnClickBack())
                    .AddTo(cancellationTokenSource.Token);
                view.VirtualCurrencyAddPopup.OnClickCancelButton
                    .Subscribe(_ => OnClickCancelPurchase())
                    .AddTo(cancellationTokenSource.Token);
                view.VirtualCurrencyAddPopup.OnClickCloseButton
                    .Subscribe(_ => OnClickClosePopup())
                    .AddTo(cancellationTokenSource.Token);
                view.VirtualCurrencyAddPopup.OnClickAddButton
                    .Subscribe(_ => OnClickAddGem())
                    .AddTo(cancellationTokenSource.Token);

                onChangeViewModel.OnNext(Unit.Default);
            }

            private void SubscribeToggleView()
            {
                foreach (var element in view.ToggleElements)
                {
                    element.ClickOffButtonObservable
                        .Subscribe(type =>
                        {
                            view.ApplyToggleView(type);
                            characterSelectRepository.SetOrderType(type);
                            CreateUIContents(type);
                        })
                        .AddTo(cancellationTokenSource.Token);
                }
            }


            private void CreateUIContents(CharacterSelectRepository.OrderType orderType)
            {
                foreach (var gridGroupList in gridGroupLists)
                {
                    Destroy(gridGroupList);
                }

                gridGroupLists.Clear();
                GameObject gridGroup = null;
                var index = 0;
                var fixedCharacterDataArray = sortCharactersUseCase.InAsTask(orderType);
                foreach (var fixedCharacterData in fixedCharacterDataArray)
                {
                    if (index % 5 == 0)
                    {
                        gridGroup = Instantiate(Owner.characterSelectView.HorizontalGroupGameObject,
                            Owner.characterSelectView.ContentsTransform);
                        gridGroupLists.Add(gridGroup);
                    }

                    if (gridGroup != null)
                    {
                        CreateActiveGrid(fixedCharacterData, gridGroup.transform, orderType);
                    }

                    index++;
                }

                foreach (var characterData in UserDataManager.GetNotAvailableCharacters())
                {
                    if (index % 5 == 0)
                    {
                        gridGroup = Instantiate(Owner.characterSelectView.HorizontalGroupGameObject,
                            Owner.characterSelectView.ContentsTransform);
                        gridGroupLists.Add(gridGroup);
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
                var grid = Instantiate(Owner.characterSelectView.Grid, parent);
                var characterGrid = grid.GetComponentInChildren<CharacterGridView>();
                characterGrid.ApplyStatusGridViews(orderType, fixedCharacterData);
                characterGrid.gridButton.onClick.AddListener(() =>
                {
                    OnClickCharacterGrid(fixedCharacterData, characterGrid.gridButton);
                });
            }

            private void CreateDisableGrid(CharacterData characterData, Transform parent)
            {
                var disableGrid = Instantiate(Owner.characterSelectView.GridDisable, parent)
                    .GetComponent<CharacterDisableGrid>();
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
                var result = Owner.CreateCharacter(characterData.Id);
                if (!result)
                {
                    gridButton.interactable = true;
                    return;
                }

                Owner.uiAnimation.ClickScale(gridButton.gameObject).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)State.CharacterDetail);
                    gridButton.interactable = true;
                }).SetLink(Owner.gameObject);
            }

            private void OnClickBack()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.characterSelectView.BackButton.gameObject).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)State.Main);
                }).SetLink(Owner.gameObject);
            }

            private void OnClickPurchaseButton(Button disableGrid, CharacterData characterData,
                CancellationToken token)
            {
                disableGrid.interactable = false;
                Owner.uiAnimation.ClickScale(disableGrid.gameObject).OnComplete(() => UniTask.Void(async () =>
                {
                    var user = Owner.userDataManager.GetUserData();
                    var characterPrice = GameCommonData.CharacterPrice;
                    var gem = await playFabVirtualCurrencyManager.GetGem();
                    if (gem == GameCommonData.NetworkErrorCode)
                    {
                        disableGrid.interactable = true;
                        return;
                    }

                    if (gem < characterPrice)
                    {
                        Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject.SetActive(true);
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
                    var isSuccessPurchase = await Owner.playFabShopManager
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
                    onChangeViewModel.OnNext(Unit.Default);
                    disableGrid.interactable = true;
                })).SetLink(disableGrid.gameObject);
            }

            private void OnClickClosePopup()
            {
                var closeButton = Owner.characterSelectView.VirtualCurrencyAddPopup.CloseButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner.uiAnimation.ClickScaleColor(closeButton).OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickCancelPurchase()
            {
                var cancelButton = Owner.characterSelectView.VirtualCurrencyAddPopup.CancelButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner.uiAnimation.ClickScaleColor(cancelButton).OnComplete(() => { popup.SetActive(false); })
                    .SetLink(popup);
            }

            private void OnClickAddGem()
            {
                var addButton = Owner.characterSelectView.VirtualCurrencyAddPopup.AddButton.gameObject;
                var popup = Owner.characterSelectView.VirtualCurrencyAddPopup.gameObject;
                Owner.uiAnimation.ClickScaleColor(addButton)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Shop); }).SetLink(popup);
            }

            private void Cancel()
            {
                if (cancellationTokenSource == null)
                {
                    return;
                }

                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }
        }
    }
}