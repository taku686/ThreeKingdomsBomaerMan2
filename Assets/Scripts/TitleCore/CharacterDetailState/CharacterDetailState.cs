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
using UseCase;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterDetailState : StateMachine<TitleCore>.State
        {
            private const int DefaultPage = 1;
            private CharacterDetail View => Owner.characterDetail;
            private CommonView CommonView => Owner.commonView;
            private CharacterSelectRepository CharacterSelectRepository => Owner.characterSelectRepository;
            private CharacterDataManager characterDataManager;
            private PlayFabUserDataManager playFabUserDataManager;
            private PlayFabShopManager playFabShopManager;
            private PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager;
            private UserDataManager userDataManager;
            private ChatGPTManager chatGptManager;
            private CharacterSelectRepository characterSelectRepository;
            private UIAnimation uiAnimation;
            private SortCharactersUseCase SortCharactersUseCase => Owner.sortCharactersUseCase;

            private CancellationTokenSource cts;
            private bool canQuestion;
            private int candidateIndex;
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
                playFabUserDataManager = Owner.playFabUserDataManager;
                playFabShopManager = Owner.playFabShopManager;
                playFabVirtualCurrencyManager = Owner.playFabVirtualCurrencyManager;
                userDataManager = Owner.userDataManager;
                chatGptManager = Owner.chatGptManager;
                uiAnimation = Owner.uiAnimation;
                characterSelectRepository = Owner.characterSelectRepository;

                InitializeOrderIndex();
                InitializeButton();

                SetupUIContent();
                canQuestion = true;
                await Owner.SwitchUiObject(State.CharacterDetail, true);
                InitializeAnimation();
            }

            private void InitializeOrderIndex()
            {
                var selectedCharacterId = characterSelectRepository.GetSelectedCharacterId();
                var orderType = characterSelectRepository.GetOrderType();
                orderCharacters = SortCharactersUseCase.InAsTask(orderType).ToArray();
                candidateIndex = Array.FindIndex(orderCharacters, x => x.Id == selectedCharacterId);
            }

            private void SetupUIContent()
            {
                var candidateCharacterId = orderCharacters[candidateIndex].Id;
                var characterData = characterDataManager.GetCharacterData(candidateCharacterId);
                var currentLevelData = userDataManager.GetCurrentLevelData(candidateCharacterId);
                var nextLevelData = userDataManager.GetNextLevelData(candidateCharacterId);
                View.ApplyViewModel(characterData, currentLevelData, nextLevelData);
                chatGptManager.SetupCharacter(characterData.Name, characterData.Character);
            }

            private void InitializeButton()
            {
                Owner.characterDetail.BackButton.onClick.RemoveAllListeners();
                Owner.characterDetail.SelectButton.onClick.RemoveAllListeners();
                View.QuestionView.sendButton.onClick.RemoveAllListeners();
                View.QuestionView.closeButton.onClick.RemoveAllListeners();
                CommonView.errorView.okButton.onClick.RemoveAllListeners();
                Owner.characterDetail.BackButton.onClick.AddListener(OnClickBackButton);
                Owner.characterDetail.SelectButton.onClick.AddListener(OnClickDecideButton);
                View.PurchaseErrorView.okButton.onClick.AddListener(OnClickClosePurchaseErrorView);
                View.QuestionView.sendButton.onClick.AddListener(OnClickSendQuestion);
                View.QuestionView.closeButton.onClick.AddListener(OnClickCloseComment);
                CommonView.errorView.okButton.onClick.AddListener(OnClickCloseErrorView);

                Owner.characterDetail.LeftArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickLeftArrow()).AddTo(cts.Token);

                Owner.characterDetail.RightArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickRightArrow()).AddTo(cts.Token);

                View.UpgradeButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickUpgrade()).AddTo(cts.Token);

                View.VirtualCurrencyAddPopup.OnClickCancelButton
                    .Subscribe(_ =>
                    {
                        OnClickCloseVirtualCurrencyAddView(View.VirtualCurrencyAddPopup
                            .CancelButton.gameObject);
                    }).AddTo(cts.Token);

                View.VirtualCurrencyAddPopup.OnClickCloseButton
                    .Subscribe(_ =>
                    {
                        OnClickCloseVirtualCurrencyAddView(View.VirtualCurrencyAddPopup.CloseButton
                            .gameObject);
                    }).AddTo(cts.Token);

                View.VirtualCurrencyAddPopup.OnClickAddButton
                    .Subscribe(_ => OnClickAddVirtualCurrency())
                    .AddTo(cts.Token);
            }

            private void OnClickBackButton()
            {
                var buttonObject = View.BackButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(buttonObject).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)State.CharacterSelect);
                }).SetLink(buttonObject);
            }

            private void OnClickRightArrow()
            {
                var buttonObject = View.RightArrowButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(buttonObject).OnComplete(() =>
                {
                    var userData = userDataManager.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        return;
                    }

                    candidateIndex++;
                    if (candidateIndex >= orderCharacters.Length)
                    {
                        candidateIndex = 0;
                    }

                    var candidateCharacter = orderCharacters[candidateIndex];
                    CreateCharacter(candidateCharacter);
                    SetupUIContent();
                    InitializeAnimation();
                }).SetLink(buttonObject);
            }

            private void OnClickLeftArrow()
            {
                var button = View.LeftArrowButton;
                button.interactable = false;
                Owner.uiAnimation.ClickScaleColor(button.gameObject).OnComplete(() =>
                {
                    var userData = userDataManager.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        button.interactable = true;
                        return;
                    }

                    candidateIndex--;
                    if (candidateIndex < 0)
                    {
                        candidateIndex = orderCharacters.Length - 1;
                    }

                    var candidateCharacter = orderCharacters[candidateIndex];
                    CreateCharacter(candidateCharacter);
                    SetupUIContent();
                    InitializeAnimation();
                    button.interactable = true;
                }).SetLink(button.gameObject);
            }

            private void OnClickDecideButton()
            {
                var button = View.SelectButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var userData = userDataManager.GetUserData();
                    userData.EquippedCharacterId = orderCharacters[candidateIndex].Id;
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
                View.UpgradeButton.interactable = false;
                var selectedCharacterData = orderCharacters[candidateIndex];
                var button = View.UpgradeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var coin = await playFabVirtualCurrencyManager.GetCoin();
                    if (coin == GameCommonData.NetworkErrorCode)
                    {
                        isProcessing = false;
                        View.UpgradeButton.interactable = true;
                        return;
                    }


                    var nextLevelData = userDataManager.GetNextLevelData(selectedCharacterData.Id);
                    var virtualCurrencyAddView = View.VirtualCurrencyAddPopup;
                    var purchaseErrorView = View.PurchaseErrorView;
                    if (coin < nextLevelData.NeedCoin)
                    {
                        Debug.LogError("コイン足りない");
                        View.UpgradeButton.interactable = true;
                        virtualCurrencyAddView.transform.localScale = Vector3.zero;
                        virtualCurrencyAddView.gameObject.SetActive(true);
                        await uiAnimation.Open(virtualCurrencyAddView.transform, GameCommonData.OpenDuration);
                        isProcessing = false;
                        return;
                    }

                    var result = await playFabShopManager.TryPurchaseLevelUpItem(nextLevelData.Level,
                        GameCommonData.CoinKey, nextLevelData.NeedCoin, selectedCharacterData.Id, purchaseErrorView);

                    if (!result)
                    {
                        Debug.LogError("購入処理エラー");
                        purchaseErrorView.transform.localScale = Vector3.zero;
                        purchaseErrorView.gameObject.SetActive(true);
                        View.UpgradeButton.interactable = true;
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
                        CreateCharacter(selectedCharacterData);
                    }

                    isProcessing = false;
                    View.UpgradeButton.interactable = true;
                })).SetLink(button);
            }

            private void OnClickCloseVirtualCurrencyAddView(GameObject button)
            {
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var virtualCurrencyAddView = View.VirtualCurrencyAddPopup;
                        await uiAnimation.Close(virtualCurrencyAddView.transform, GameCommonData.CloseDuration);
                        virtualCurrencyAddView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickAddVirtualCurrency()
            {
                var button = View.VirtualCurrencyAddPopup.AddButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)State.Shop);
                }).SetLink(button);
            }

            private void OnClickClosePurchaseErrorView()
            {
                var button = View.PurchaseErrorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var purchaseErrorView = View.PurchaseErrorView;
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

                CommonView.waitPopup.SetActive(true);
                canQuestion = false;
                var button = View.QuestionView.sendButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var question = View.QuestionView.questionField.text;
                        var commentTransform = View.QuestionView.commentObj.transform;
                        var commentText = View.QuestionView.commentText;
                        var errorText = CommonView.errorView.errorInfoText;
                        if (question.Length > GameCommonData.CharacterLimit)
                        {
                            CommonView.waitPopup.SetActive(false);
                            canQuestion = true;
                            await OpenErrorView();
                            return;
                        }

                        var result = await playFabShopManager.TryPurchaseItem(GameCommonData.QuestionItemKey,
                            GameCommonData.TicketKey, 1, errorText);
                        if (!result)
                        {
                            CommonView.waitPopup.SetActive(false);
                            canQuestion = true;
                            await OpenErrorView();
                            return;
                        }

                        await chatGptManager.Request(question, commentText);
                        CommonView.waitPopup.SetActive(false);
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
                var button = View.QuestionView.closeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var comment = View.QuestionView.commentObj.transform;
                        await uiAnimation.Close(comment, GameCommonData.CloseDuration);
                        comment.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickCloseErrorView()
            {
                var button = CommonView.errorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var errorView = CommonView.errorView.transform;
                        await uiAnimation.Close(errorView, GameCommonData.CloseDuration);
                        errorView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private async UniTask OpenErrorView()
            {
                var errorView = CommonView.errorView;
                var errorViewObj = CommonView.errorView.gameObject;
                errorView.transform.localScale = Vector3.zero;
                errorViewObj.SetActive(true);
                await uiAnimation.Open(errorView.transform, GameCommonData.OpenDuration);
            }

            private void CreateCharacter(CharacterData characterData)
            {
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