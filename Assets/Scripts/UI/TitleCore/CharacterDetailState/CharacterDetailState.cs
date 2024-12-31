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
            private CharacterDetailView _View => (CharacterDetailView)Owner.GetView(State.CharacterDetail);
            private CommonView _CommonView => Owner._commonView;
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;
            private CharacterObjectRepository _CharacterObjectRepository => Owner._characterObjectRepository;
            private AnimationPlayBackUseCase _AnimationPlayBackUseCase => Owner._animationPlayBackUseCase;

            private CharacterDetailViewModelUseCase _CharacterDetailViewModelUseCase =>
                Owner._characterDetailViewModelUseCase;

            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private SortCharactersUseCase _SortCharactersUseCase => Owner._sortCharactersUseCase;
            private PlayFabUserDataManager _playFabUserDataManager;
            private PlayFabShopManager _playFabShopManager;
            private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
            private CharacterSelectRepository _characterSelectRepository;
            private UIAnimation _uiAnimation;

            private CancellationTokenSource _cts;
            private int _candidateIndex;
            private CharacterData[] _sortedCharacters;
            private readonly Subject<int> _onChangeViewModel = new();

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
                _playFabUserDataManager = Owner._playFabUserDataManager;
                _playFabShopManager = Owner._playFabShopManager;
                _playFabVirtualCurrencyManager = Owner._playFabVirtualCurrencyManager;
                _uiAnimation = Owner._uiAnimation;
                _characterSelectRepository = Owner._characterSelectRepository;
                GenerateCharacter();
                OnSubscribe();
                await Owner.SwitchUiObject(State.CharacterDetail, true);
                PlayBackAnimation();
            }

            private void OnSubscribe()
            {
                _onChangeViewModel
                    .Select(characterId => _CharacterDetailViewModelUseCase.InAsTask(characterId))
                    .Subscribe(viewModel => _View.ApplyViewModel(viewModel))
                    .AddTo(_cts.Token);

                _View.PurchaseErrorView.okButton.OnClickAsObservable()
                    .SelectMany(_ => OnClickClosePurchaseErrorView().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _View.BackButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickBackButton())
                    .AddTo(_cts.Token);

                _View.SelectButton.OnClickAsObservable()
                    .SelectMany(_ => OnClickDecideButton().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _View.LeftArrowButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickLeftArrow())
                    .AddTo(_cts.Token);

                _View.RightArrowButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickRightArrow())
                    .AddTo(_cts.Token);

                _View.UpgradeButton.OnClickAsObservable()
                    .SelectMany(_ => OnClickUpgrade().ToObservable())
                    .Subscribe()
                    .AddTo(_cts.Token);

                _View.VirtualCurrencyAddPopup.OnClickCancelButton
                    .Subscribe(_ =>
                    {
                        OnClickCloseVirtualCurrencyAddView(_View.VirtualCurrencyAddPopup
                            .CancelButton.gameObject);
                    })
                    .AddTo(_cts.Token);

                _View.VirtualCurrencyAddPopup.OnClickCloseButton
                    .Subscribe(_ => { OnClickCloseVirtualCurrencyAddView(_View.VirtualCurrencyAddPopup.CloseButton.gameObject); })
                    .AddTo(_cts.Token);

                _View.VirtualCurrencyAddPopup.OnClickAddButton
                    .Subscribe(_ => OnClickAddVirtualCurrency())
                    .AddTo(_cts.Token);

                _View.InventoryButton.OnClickAsObservable()
                    .Subscribe(_ => stateMachine.Dispatch((int)State.Inventory))
                    .AddTo(_cts.Token);

                _CommonView.errorView.okButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickCloseErrorView())
                    .AddTo(_cts.Token);

                var candidateCharacterId = _sortedCharacters[_candidateIndex].Id;
                _onChangeViewModel.OnNext(candidateCharacterId);
            }

            private void GenerateCharacter()
            {
                var selectedCharacterId = _characterSelectRepository.GetSelectedCharacterId();
                var orderType = _characterSelectRepository.GetOrderType();
                _sortedCharacters = _SortCharactersUseCase.InAsTask(orderType).ToArray();
                _candidateIndex = Array.FindIndex(_sortedCharacters, x => x.Id == selectedCharacterId);
                var selectedCharacter = _sortedCharacters[_candidateIndex];
                CreateCharacter(selectedCharacter);
            }

            private void OnClickBackButton()
            {
                Owner._stateMachine.Dispatch((int)State.CharacterSelect);
            }

            private void OnClickRightArrow()
            {
                var button = _View.RightArrowButton;
                button.interactable = false;
                Owner._uiAnimation.ClickScaleColor(button.gameObject).OnComplete(() =>
                {
                    var userData = _UserDataRepository.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        button.interactable = true;
                        return;
                    }

                    _candidateIndex++;
                    if (_candidateIndex >= _sortedCharacters.Length)
                    {
                        _candidateIndex = 0;
                    }

                    var candidateCharacter = _sortedCharacters[_candidateIndex];
                    _characterSelectRepository.SetSelectedCharacterId(candidateCharacter.Id);
                    CreateCharacter(candidateCharacter);
                    _onChangeViewModel.OnNext(candidateCharacter.Id);
                    PlayBackAnimation();
                    button.interactable = true;
                }).SetLink(button.gameObject);
            }

            private void OnClickLeftArrow()
            {
                var button = _View.LeftArrowButton;
                button.interactable = false;
                Owner._uiAnimation.ClickScaleColor(button.gameObject).OnComplete(() =>
                {
                    var userData = _UserDataRepository.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        button.interactable = true;
                        return;
                    }

                    _candidateIndex--;
                    if (_candidateIndex < 0)
                    {
                        _candidateIndex = _sortedCharacters.Length - 1;
                    }

                    var candidateCharacter = _sortedCharacters[_candidateIndex];
                    _characterSelectRepository.SetSelectedCharacterId(candidateCharacter.Id);
                    CreateCharacter(candidateCharacter);
                    _onChangeViewModel.OnNext(candidateCharacter.Id);
                    PlayBackAnimation();
                    button.interactable = true;
                }).SetLink(button.gameObject);
            }

            private async UniTask OnClickDecideButton()
            {
                _View.SelectButton.interactable = false;
                var userData = _UserDataRepository.GetUserData();
                userData.EquippedCharacterId = _sortedCharacters[_candidateIndex].Id;
                var result = await _playFabUserDataManager.TryUpdateUserDataAsync(userData);
                if (result)
                {
                    Owner._stateMachine.Dispatch((int)State.Main);
                }

                _View.SelectButton.interactable = true;
            }

            private async UniTask OnClickUpgrade()
            {
                _View.UpgradeButton.interactable = false;
                var selectedCharacterData = _sortedCharacters[_candidateIndex];
                var coin = await _playFabVirtualCurrencyManager.GetCoin();
                if (coin == GameCommonData.NetworkErrorCode)
                {
                    _View.UpgradeButton.interactable = true;
                    return;
                }


                var nextLevelData = _UserDataRepository.GetNextLevelData(selectedCharacterData.Id);
                var virtualCurrencyAddView = _View.VirtualCurrencyAddPopup;
                var purchaseErrorView = _View.PurchaseErrorView;
                if (coin < nextLevelData.NeedCoin)
                {
                    Debug.LogError("コイン足りない");
                    _View.UpgradeButton.interactable = true;
                    virtualCurrencyAddView.transform.localScale = Vector3.zero;
                    virtualCurrencyAddView.gameObject.SetActive(true);
                    await _uiAnimation.Open(virtualCurrencyAddView.transform, GameCommonData.OpenDuration);
                    return;
                }

                var result = await _playFabShopManager.TryPurchaseLevelUpItem(nextLevelData.Level,
                    GameCommonData.CoinKey, nextLevelData.NeedCoin, selectedCharacterData.Id, purchaseErrorView);

                if (!result)
                {
                    Debug.LogError("購入処理エラー");
                    purchaseErrorView.transform.localScale = Vector3.zero;
                    purchaseErrorView.gameObject.SetActive(true);
                    _View.UpgradeButton.interactable = true;
                    await _uiAnimation.Open(purchaseErrorView.transform, GameCommonData.OpenDuration);
                    return;
                }

                Owner.CheckMission(GameCommonData.LevelUpActionId);
                var userData = _UserDataRepository.GetUserData();
                await _UserDataRepository.UpdateUserData(userData);
                await Owner.SetCoinText();
                _onChangeViewModel.OnNext(selectedCharacterData.Id);
                if (nextLevelData.Level == GameCommonData.MaxCharacterLevel)
                {
                    CreateCharacter(selectedCharacterData);
                }

                _View.UpgradeButton.interactable = true;
            }

            private void OnClickCloseVirtualCurrencyAddView(GameObject button)
            {
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var virtualCurrencyAddView = _View.VirtualCurrencyAddPopup;
                        await _uiAnimation.Close(virtualCurrencyAddView.transform, GameCommonData.CloseDuration);
                        virtualCurrencyAddView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickAddVirtualCurrency()
            {
                var button = _View.VirtualCurrencyAddPopup.AddButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => { Owner._stateMachine.Dispatch((int)State.Shop); }).SetLink(button);
            }

            private async UniTask OnClickClosePurchaseErrorView()
            {
                var purchaseErrorView = _View.PurchaseErrorView;
                await _uiAnimation.Close(purchaseErrorView.transform, GameCommonData.CloseDuration);
                purchaseErrorView.gameObject.SetActive(false);
            }


            private void OnClickCloseErrorView()
            {
                var button = _CommonView.errorView.okButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var errorView = _CommonView.errorView.transform;
                        await _uiAnimation.Close(errorView, GameCommonData.CloseDuration);
                        errorView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }


            private void CreateCharacter(CharacterData characterData)
            {
                _CharacterCreateUseCase.CreateCharacter(characterData.Id);
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