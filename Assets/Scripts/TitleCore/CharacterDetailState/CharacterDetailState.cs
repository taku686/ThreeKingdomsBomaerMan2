using System;
using System.Linq;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.DataManager;
using Manager.NetworkManager;
using UI.Common;
using UniRx;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterDetailState : StateMachine<TitleCore>.State
        {
            private const int DefaultPage = 1;
            private CharacterDetailView view;
            private CommonView commonView;
            private CharacterDataManager characterDataManager;
            private PlayFabUserDataManager playFabUserDataManager;
            private PlayFabShopManager playFabShopManager;
            private PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager;
            private UserDataManager userDataManager;
            private ChatGPTManager chatGptManager;
            private CharacterSelectRepository characterSelectRepository;
            private UIAnimation uiAnimation;


            private CancellationTokenSource cts;
            private bool isInitialize;
            private bool canQuestion;
            private int index;
            private bool isProcessing;
            private CharacterData[] orderCharacters;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            private async void Initialize()
            {
                SetupCancellationToken();
                characterDataManager = Owner.characterDataManager;
                view = Owner.characterDetailView;
                commonView = Owner.commonView;
                playFabUserDataManager = Owner.playFabUserDataManager;
                playFabShopManager = Owner.playFabShopManager;
                playFabVirtualCurrencyManager = Owner.playFabVirtualCurrencyManager;
                userDataManager = Owner.userDataManager;
                chatGptManager = Owner.chatGptManager;
                uiAnimation = Owner.uiAnimation;
                characterSelectRepository = Owner.characterSelectRepository;

                InitializeIndex();
                InitializeButton();

                SetupUIContent();
                isInitialize = true;
                canQuestion = true;
                await Owner.SwitchUiObject(State.CharacterDetail, true);
                InitializeAnimation();
            }

            private void InitializeIndex()
            {
                var equippedCharacterId = userDataManager.GetUserData().EquippedCharacterId;
                var type = characterSelectRepository.GetOrderType();
                orderCharacters = userDataManager.GetAvailableCharactersByOrderType(type).ToArray();
                index = Array.FindIndex(orderCharacters, x => x.Id == equippedCharacterId);
            }

            private void SetupUIContent()
            {
                var candidateCharacterId = orderCharacters[index].Id;
                var characterData = characterDataManager.GetCharacterData(candidateCharacterId);
                var currentLevelData = userDataManager.GetCurrentLevelData(candidateCharacterId);
                var nextLevelData = userDataManager.GetNextLevelData(candidateCharacterId);
                view.ApplyViewModel(characterData, currentLevelData, nextLevelData);
                chatGptManager.SetupCharacter(characterData.Name, characterData.Character);
            }


            private void InitializeButton()
            {
                Owner.characterDetailView.BackButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.SelectButton.onClick.RemoveAllListeners();
                view.QuestionView.sendButton.onClick.RemoveAllListeners();
                view.QuestionView.closeButton.onClick.RemoveAllListeners();
                commonView.errorView.okButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.BackButton.onClick.AddListener(OnClickBackButton);
                Owner.characterDetailView.SelectButton.onClick.AddListener(OnClickSelectButton);
                view.PurchaseErrorView.okButton.onClick.AddListener(OnClickClosePurchaseErrorView);
                view.QuestionView.sendButton.onClick.AddListener(OnClickSendQuestion);
                view.QuestionView.closeButton.onClick.AddListener(OnClickCloseComment);
                commonView.errorView.okButton.onClick.AddListener(OnClickCloseErrorView);

                Owner.characterDetailView.LeftArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickLeftArrow()).AddTo(cts.Token);

                Owner.characterDetailView.RightArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickRightArrow()).AddTo(cts.Token);

                view.UpgradeButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickUpgrade()).AddTo(cts.Token);

                view.VirtualCurrencyAddPopup.OnClickCancelButton
                    .Subscribe(_ =>
                    {
                        OnClickCloseVirtualCurrencyAddView(view.VirtualCurrencyAddPopup
                            .CancelButton.gameObject);
                    }).AddTo(cts.Token);

                view.VirtualCurrencyAddPopup.OnClickCloseButton
                    .Subscribe(_ =>
                    {
                        OnClickCloseVirtualCurrencyAddView(view.VirtualCurrencyAddPopup.CloseButton
                            .gameObject);
                    }).AddTo(cts.Token);

                view.VirtualCurrencyAddPopup.OnClickAddButton
                    .Subscribe(_ => OnClickAddVirtualCurrency())
                    .AddTo(cts.Token);
            }

            private void OnClickBackButton()
            {
                var button = view.BackButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    Owner.CreateCharacter(Owner.userDataManager.GetUserData().EquippedCharacterId);
                    Owner.stateMachine.Dispatch((int)State.CharacterSelect);
                }).SetLink(button);
            }

            private void OnClickRightArrow()
            {
                var button = view.RightArrowButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    var userData = userDataManager.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        return;
                    }

                    index++;
                    if (index >= orderCharacters.Length)
                    {
                        index = 0;
                    }

                    var candidateCharacter = orderCharacters[index];
                    CreateCharacter(candidateCharacter);
                    SetupUIContent();
                    InitializeAnimation();
                }).SetLink(button);
            }

            private void OnClickLeftArrow()
            {
                var button = view.LeftArrowButton;
                button.interactable = false;
                Owner.uiAnimation.ClickScaleColor(button.gameObject).OnComplete(() =>
                {
                    var userData = userDataManager.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        button.interactable = true;
                        return;
                    }

                    index--;
                    if (index < 0)
                    {
                        index = orderCharacters.Length - 1;
                    }

                    var candidateCharacter = orderCharacters[index];
                    CreateCharacter(candidateCharacter);
                    SetupUIContent();
                    InitializeAnimation();
                    button.interactable = true;
                }).SetLink(button.gameObject);
            }

            private void OnClickSelectButton()
            {
                var button = view.SelectButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var userData = userDataManager.GetUserData();
                    userData.EquippedCharacterId = orderCharacters[index].Id;
                    var result = await playFabUserDataManager.TryUpdateUserDataAsync(userData);
                    if (result)
                    {
                        Owner.stateMachine.Dispatch((int)State.Main);
                    }
                })).SetLink(button);
            }

            private void OnClickUpgrade()
            {
                if (isProcessing)
                {
                    return;
                }

                isProcessing = true;
                view.UpgradeButton.interactable = false;
                var characterData = userDataManager.GetEquippedCharacterData();
                var button = view.UpgradeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var coin = await playFabVirtualCurrencyManager.GetCoin();
                    if (coin == GameCommonData.NetworkErrorCode)
                    {
                        isProcessing = false;
                        view.UpgradeButton.interactable = true;
                        return;
                    }


                    var nextLevelData = userDataManager.GetNextLevelData(characterData.Id);
                    var virtualCurrencyAddView = view.VirtualCurrencyAddPopup;
                    var purchaseErrorView = view.PurchaseErrorView;
                    if (coin < nextLevelData.NeedCoin)
                    {
                        view.UpgradeButton.interactable = true;
                        virtualCurrencyAddView.transform.localScale = Vector3.zero;
                        virtualCurrencyAddView.gameObject.SetActive(true);
                        await uiAnimation.Open(virtualCurrencyAddView.transform, GameCommonData.OpenDuration);
                        isProcessing = false;
                        return;
                    }

                    var result = await playFabShopManager.TryPurchaseLevelUpItem(nextLevelData.Level,
                        GameCommonData.CoinKey, nextLevelData.NeedCoin, characterData.Id, purchaseErrorView);

                    if (!result)
                    {
                        purchaseErrorView.transform.localScale = Vector3.zero;
                        purchaseErrorView.gameObject.SetActive(true);
                        view.UpgradeButton.interactable = true;
                        await uiAnimation.Open(purchaseErrorView.transform, GameCommonData.OpenDuration);
                        isProcessing = false;
                        return;
                    }

                    Owner.CheckMission(GameCommonData.LevelUpActionId);
                    var userData = userDataManager.GetUserData();
                    await userDataManager.UpdateUserData(userData);
                    await Owner.SetCoinText();
                    SetupUIContent();
                    if (nextLevelData.Level == GameCommonData.MaxCharacterLevel)
                    {
                        CreateCharacter(characterData);
                    }

                    isProcessing = false;
                    view.UpgradeButton.interactable = true;
                })).SetLink(button);
            }

            private void OnClickCloseVirtualCurrencyAddView(GameObject button)
            {
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var virtualCurrencyAddView = view.VirtualCurrencyAddPopup;
                        await uiAnimation.Close(virtualCurrencyAddView.transform, GameCommonData.CloseDuration);
                        virtualCurrencyAddView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickAddVirtualCurrency()
            {
                var button = view.VirtualCurrencyAddPopup.AddButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)State.Shop);
                }).SetLink(button);
            }

            private void OnClickClosePurchaseErrorView()
            {
                var button = view.PurchaseErrorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var purchaseErrorView = view.PurchaseErrorView;
                        await uiAnimation.Close(purchaseErrorView.transform, GameCommonData.CloseDuration);
                        purchaseErrorView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickSendQuestion()
            {
                if (!canQuestion)
                {
                    return;
                }

                commonView.waitPopup.SetActive(true);
                canQuestion = false;
                var button = view.QuestionView.sendButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var question = view.QuestionView.questionField.text;
                        var commentTransform = view.QuestionView.commentObj.transform;
                        var commentText = view.QuestionView.commentText;
                        var errorText = commonView.errorView.errorInfoText;
                        if (question.Length > GameCommonData.CharacterLimit)
                        {
                            commonView.waitPopup.SetActive(false);
                            canQuestion = true;
                            await OpenErrorView();
                            return;
                        }

                        var result = await playFabShopManager.TryPurchaseItem(GameCommonData.QuestionItemKey,
                            GameCommonData.TicketKey, 1, errorText);
                        if (!result)
                        {
                            commonView.waitPopup.SetActive(false);
                            canQuestion = true;
                            await OpenErrorView();
                            return;
                        }

                        await chatGptManager.Request(question, commentText);
                        commonView.waitPopup.SetActive(false);
                        await Owner.SetTicketText();
                        commentText.pageToDisplay = DefaultPage;
                        commentTransform.localScale = Vector3.zero;
                        commentTransform.gameObject.SetActive(true);
                        await uiAnimation.Open(commentTransform, GameCommonData.OpenDuration);

                        canQuestion = true;
                    }
                )).SetLink(button);
            }

            private void OnClickCloseComment()
            {
                var button = view.QuestionView.closeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var comment = view.QuestionView.commentObj.transform;
                        await uiAnimation.Close(comment, GameCommonData.CloseDuration);
                        comment.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickCloseErrorView()
            {
                var button = commonView.errorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var errorView = commonView.errorView.transform;
                        await uiAnimation.Close(errorView, GameCommonData.CloseDuration);
                        errorView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private async UniTask OpenErrorView()
            {
                var errorView = commonView.errorView;
                var errorViewObj = commonView.errorView.gameObject;
                errorView.transform.localScale = Vector3.zero;
                errorViewObj.SetActive(true);
                await uiAnimation.Open(errorView.transform, GameCommonData.OpenDuration);
            }

            private void CreateCharacter(CharacterData characterData)
            {
                chatGptManager.SetupCharacter(characterData.Name, characterData.Character);
                Owner.CreateCharacter(characterData.Id);
            }

            private void InitializeAnimation()
            {
                Owner.equippedCharacter.GetComponent<Animator>().SetTrigger(GameCommonData.ActiveHashKey);
            }

            private void SetupCancellationToken()
            {
                if (cts != null)
                {
                    return;
                }

                cts = new CancellationTokenSource();
                cts.RegisterRaiseCancelOnDestroy(Owner);
            }

            private void Cancel()
            {
                if (cts == null)
                {
                    return;
                }

                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
    }
}