using System;
using System.Linq;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
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
            private CharacterDetailView View => (CharacterDetailView)Owner.GetView(State.CharacterDetail);
            private CommonView CommonView => Owner.commonView;
            private CharacterCreateUseCase CharacterCreateUseCase => Owner.characterCreateUseCase;
            private CharacterObjectRepository CharacterObjectRepository => Owner.characterObjectRepository;
            private AnimationPlayBackUseCase AnimationPlayBackUseCase => Owner.animationPlayBackUseCase;

            private CharacterDetailViewModelUseCase CharacterDetailViewModelUseCase =>
                Owner.characterDetailViewModelUseCase;

            private UserDataRepository UserDataRepository => Owner.userDataRepository;
            private SortCharactersUseCase SortCharactersUseCase => Owner.sortCharactersUseCase;
            private PlayFabUserDataManager playFabUserDataManager;
            private PlayFabShopManager playFabShopManager;
            private PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager;
            private CharacterSelectRepository characterSelectRepository;
            private UIAnimation uiAnimation;

            private CancellationTokenSource cts;
            private int candidateIndex;
            private CharacterData[] sortedCharacters;
            private readonly Subject<int> onChangeViewModel = new();

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
                SetupCancellationToken();
                playFabUserDataManager = Owner.playFabUserDataManager;
                playFabShopManager = Owner.playFabShopManager;
                playFabVirtualCurrencyManager = Owner.playFabVirtualCurrencyManager;
                uiAnimation = Owner.uiAnimation;
                characterSelectRepository = Owner.characterSelectRepository;
                GenerateCharacter();
                OnSubscribe();
                await Owner.SwitchUiObject(State.CharacterDetail, true);
                PlayBackAnimation();
            }

            private void OnSubscribe()
            {
                onChangeViewModel
                    .Select(characterId => CharacterDetailViewModelUseCase.InAsTask(characterId))
                    .Subscribe(viewModel => View.ApplyViewModel(viewModel))
                    .AddTo(cts.Token);

                View.PurchaseErrorView.okButton.OnClickAsObservable()
                    .SelectMany(_ => OnClickClosePurchaseErrorView().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);

                View.BackButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickBackButton())
                    .AddTo(cts.Token);

                View.SelectButton.OnClickAsObservable()
                    .SelectMany(_ => OnClickDecideButton().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);

                View.LeftArrowButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickLeftArrow())
                    .AddTo(cts.Token);

                View.RightArrowButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickRightArrow())
                    .AddTo(cts.Token);

                View.UpgradeButton.OnClickAsObservable()
                    .SelectMany(_ => OnClickUpgrade().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);

                View.VirtualCurrencyAddPopup.OnClickCancelButton
                    .Subscribe(_ =>
                    {
                        OnClickCloseVirtualCurrencyAddView(View.VirtualCurrencyAddPopup
                            .CancelButton.gameObject);
                    })
                    .AddTo(cts.Token);

                View.VirtualCurrencyAddPopup.OnClickCloseButton
                    .Subscribe(_ =>
                    {
                        OnClickCloseVirtualCurrencyAddView(View.VirtualCurrencyAddPopup.CloseButton.gameObject);
                    })
                    .AddTo(cts.Token);

                View.VirtualCurrencyAddPopup.OnClickAddButton
                    .Subscribe(_ => OnClickAddVirtualCurrency())
                    .AddTo(cts.Token);

                View.InventoryButton.OnClickAsObservable()
                    .Subscribe(_ => stateMachine.Dispatch((int)State.Inventory))
                    .AddTo(cts.Token);

                CommonView.errorView.okButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickCloseErrorView())
                    .AddTo(cts.Token);

                var candidateCharacterId = sortedCharacters[candidateIndex].Id;
                onChangeViewModel.OnNext(candidateCharacterId);
            }

            private void GenerateCharacter()
            {
                var selectedCharacterId = characterSelectRepository.GetSelectedCharacterId();
                var orderType = characterSelectRepository.GetOrderType();
                sortedCharacters = SortCharactersUseCase.InAsTask(orderType).ToArray();
                candidateIndex = Array.FindIndex(sortedCharacters, x => x.Id == selectedCharacterId);
                var selectedCharacter = sortedCharacters[candidateIndex];
                CreateCharacter(selectedCharacter);
            }

            private void OnClickBackButton()
            {
                Owner.stateMachine.Dispatch((int)State.CharacterSelect);
            }

            private void OnClickRightArrow()
            {
                var button = View.RightArrowButton;
                button.interactable = false;
                Owner.uiAnimation.ClickScaleColor(button.gameObject).OnComplete(() =>
                {
                    var userData = UserDataRepository.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        button.interactable = true;
                        return;
                    }

                    candidateIndex++;
                    if (candidateIndex >= sortedCharacters.Length)
                    {
                        candidateIndex = 0;
                    }

                    var candidateCharacter = sortedCharacters[candidateIndex];
                    characterSelectRepository.SetSelectedCharacterId(candidateCharacter.Id);
                    CreateCharacter(candidateCharacter);
                    onChangeViewModel.OnNext(candidateCharacter.Id);
                    PlayBackAnimation();
                    button.interactable = true;
                }).SetLink(button.gameObject);
            }

            private void OnClickLeftArrow()
            {
                var button = View.LeftArrowButton;
                button.interactable = false;
                Owner.uiAnimation.ClickScaleColor(button.gameObject).OnComplete(() =>
                {
                    var userData = UserDataRepository.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        button.interactable = true;
                        return;
                    }

                    candidateIndex--;
                    if (candidateIndex < 0)
                    {
                        candidateIndex = sortedCharacters.Length - 1;
                    }

                    var candidateCharacter = sortedCharacters[candidateIndex];
                    characterSelectRepository.SetSelectedCharacterId(candidateCharacter.Id);
                    CreateCharacter(candidateCharacter);
                    onChangeViewModel.OnNext(candidateCharacter.Id);
                    PlayBackAnimation();
                    button.interactable = true;
                }).SetLink(button.gameObject);
            }

            private async UniTask OnClickDecideButton()
            {
                View.SelectButton.interactable = false;
                var userData = UserDataRepository.GetUserData();
                userData.EquippedCharacterId = sortedCharacters[candidateIndex].Id;
                var result = await playFabUserDataManager.TryUpdateUserDataAsync(userData);
                if (result)
                {
                    Owner.stateMachine.Dispatch((int)State.Main);
                }

                View.SelectButton.interactable = true;
            }

            private async UniTask OnClickUpgrade()
            {
                View.UpgradeButton.interactable = false;
                var selectedCharacterData = sortedCharacters[candidateIndex];
                var coin = await playFabVirtualCurrencyManager.GetCoin();
                if (coin == GameCommonData.NetworkErrorCode)
                {
                    View.UpgradeButton.interactable = true;
                    return;
                }


                var nextLevelData = UserDataRepository.GetNextLevelData(selectedCharacterData.Id);
                var virtualCurrencyAddView = View.VirtualCurrencyAddPopup;
                var purchaseErrorView = View.PurchaseErrorView;
                if (coin < nextLevelData.NeedCoin)
                {
                    Debug.LogError("コイン足りない");
                    View.UpgradeButton.interactable = true;
                    virtualCurrencyAddView.transform.localScale = Vector3.zero;
                    virtualCurrencyAddView.gameObject.SetActive(true);
                    await uiAnimation.Open(virtualCurrencyAddView.transform, GameCommonData.OpenDuration);
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
                    return;
                }

                Owner.CheckMission(GameCommonData.LevelUpActionId);
                var userData = UserDataRepository.GetUserData();
                await UserDataRepository.UpdateUserData(userData);
                await Owner.SetCoinText();
                onChangeViewModel.OnNext(selectedCharacterData.Id);
                if (nextLevelData.Level == GameCommonData.MaxCharacterLevel)
                {
                    CreateCharacter(selectedCharacterData);
                }

                View.UpgradeButton.interactable = true;
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

            private async UniTask OnClickClosePurchaseErrorView()
            {
                var purchaseErrorView = View.PurchaseErrorView;
                await uiAnimation.Close(purchaseErrorView.transform, GameCommonData.CloseDuration);
                purchaseErrorView.gameObject.SetActive(false);
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


            private void CreateCharacter(CharacterData characterData)
            {
                CharacterCreateUseCase.CreateCharacter(characterData.Id);
            }

            private void PlayBackAnimation()
            {
                var character = CharacterObjectRepository.GetCharacterObject();
                var animator = character.GetComponent<Animator>();
                AnimationPlayBackUseCase.RandomPlayBack(animator, AnimationStateType.Performance);
                AnimationPlayBackUseCase.RandomPlayBack(animator, AnimationStateType.Idle);
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

            #region chatGpt

/*private async UniTask OnClickSendQuestion()
            {
                View.QuestionView.sendButton.interactable = false;
                CommonView.waitPopup.SetActive(true);
                var question = View.QuestionView.questionField.text;
                var commentTransform = View.QuestionView.commentObj.transform;
                var commentText = View.QuestionView.commentText;
                var errorText = CommonView.errorView.errorInfoText;
                if (question.Length > GameCommonData.CharacterLimit)
                {
                    CommonView.waitPopup.SetActive(false);
                    View.QuestionView.sendButton.interactable = true;
                    await OpenErrorView();
                    return;
                }

                var result = await playFabShopManager.TryPurchaseItem(GameCommonData.QuestionItemKey,
                    GameCommonData.TicketKey, 1, errorText);
                if (!result)
                {
                    CommonView.waitPopup.SetActive(false);
                    View.QuestionView.sendButton.interactable = true;
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
                View.QuestionView.sendButton.interactable = true;
            }*/

            /*private void OnClickCloseComment()
            {
                var button = View.QuestionView.closeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var comment = View.QuestionView.commentObj.transform;
                        await uiAnimation.Close(comment, GameCommonData.CloseDuration);
                        comment.gameObject.SetActive(false);
                    }
                )).SetLink(button);

                 private async UniTask OpenErrorView()
            {
                var errorView = CommonView.errorView;
                var errorViewObj = CommonView.errorView.gameObject;
                errorView.transform.localScale = Vector3.zero;
                errorViewObj.SetActive(true);
                await uiAnimation.Open(errorView.transform, GameCommonData.OpenDuration);
            }
            }*/

            #endregion
        }
    }
}