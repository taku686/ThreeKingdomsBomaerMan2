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
            private const float MoveAmount = 50;
            private const int DefaultPage = 1;
            private const int UpgradeButtonIntervalDuration = 2;
            private const string LevelText = "LV <#94aed0><size=170%>";
            private CharacterDetailView characterDetailView;
            private CommonView commonView;
            private CharacterDataManager characterDataManager;
            private CharacterLevelDataManager characterLevelDataManager;
            private PlayFabUserDataManager playFabUserDataManager;
            private PlayFabShopManager playFabShopManager;
            private PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager;
            private UserDataManager userDataManager;
            private ChatGPTManager chatGptManager;
            private CancellationTokenSource cts;
            private UIAnimation uiAnimation;
            private bool isInitialize;
            private bool canQuestion;
            private int pageCount;
            private bool isProcessing;

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
                characterLevelDataManager = Owner.characterLevelDataManager;
                characterDetailView = Owner.characterDetailView;
                commonView = Owner.commonView;
                playFabUserDataManager = Owner.playFabUserDataManager;
                playFabShopManager = Owner.playFabShopManager;
                playFabVirtualCurrencyManager = Owner.playFabVirtualCurrencyManager;
                userDataManager = Owner.userDataManager;
                chatGptManager = Owner.chatGptManager;
                uiAnimation = Owner.uiAnimation;
                characterDetailView.PurchaseErrorView.gameObject.SetActive(false);
                characterDetailView.VirtualCurrencyAddPopup.gameObject.SetActive(false);
                characterDetailView.QuestionView.commentObj.SetActive(false);
                InitializeButton();
                SetupUIContent();
                InitializeUIAnimation();
                Owner.SwitchUiObject(State.CharacterDetail, true).Forget();
                isInitialize = true;
                canQuestion = true;
                await UniTask.Delay(TimeSpan.FromSeconds(1f));
                InitializeAnimation();
            }

            private void SetupUIContent()
            {
                var equippedCharacterDataId = userDataManager.GetUserData().EquipCharacterId;
                var characterData = characterDataManager.GetCharacterData(equippedCharacterDataId);
                var currentLevelData = userDataManager.GetCurrentLevelData(equippedCharacterDataId);
                var nextLevelData = userDataManager.GetNextLevelData(equippedCharacterDataId);
                SetStatusView(characterData, currentLevelData);
                SetSkillView(characterData, currentLevelData);
                SetLevelView(currentLevelData, nextLevelData);
                chatGptManager.SetupCharacter(characterData.Name, characterData.Character);
            }

            private void SetStatusView(CharacterData characterData, CharacterLevelData currentLevelData)
            {
                Owner.characterDetailView.NameText.text = characterData.Name;
                var characterStatusView = Owner.characterDetailView.StatusView;
                characterStatusView.HpText.text = GetModifiedStatus(currentLevelData, characterData.Hp).ToString();
                characterStatusView.DamageText.text =
                    GetModifiedStatus(currentLevelData, characterData.Attack).ToString();
                characterStatusView.SpeedText.text =
                    GetModifiedStatus(currentLevelData, characterData.Speed).ToString();
                characterStatusView.BombLimitText.text =
                    GetModifiedStatus(currentLevelData, characterData.BombLimit).ToString();
                characterStatusView.FireRangeText.text =
                    GetModifiedStatus(currentLevelData, characterData.FireRange).ToString();
            }

            private void SetSkillView(CharacterData characterData, CharacterLevelData currentLevelData)
            {
                var skillsView = characterDetailView.SkillsView;
                skillsView.skillOneImage.sprite = characterData.SkillOneSprite;
                skillsView.skillTwoImage.sprite = characterData.SkillTwoSprite;
                skillsView.skillOneLockImage.enabled = !currentLevelData.IsSkillOneActive;
                skillsView.skillTwoLockImage.enabled = !currentLevelData.IsSkillTwoActive;
            }

            private void SetLevelView(CharacterLevelData currentLevelData, CharacterLevelData nextLevelData)
            {
                if (currentLevelData.Level < GameCommonData.MaxCharacterLevel)
                {
                    characterDetailView.UpgradeButton.gameObject.SetActive(true);
                    characterDetailView.UpgradeInfoGameObject.gameObject.SetActive(true);
                    characterDetailView.LevelText.text = LevelText + currentLevelData.Level;
                    characterDetailView.UpgradeInfoText.text = $"Lv{nextLevelData.Level} Upgrade";
                    characterDetailView.UpgradeText.text = nextLevelData.NeedCoin.ToString("D");
                }
                else
                {
                    characterDetailView.LevelText.text = LevelText + currentLevelData.Level;
                    characterDetailView.UpgradeButton.gameObject.SetActive(false);
                    characterDetailView.UpgradeInfoGameObject.gameObject.SetActive(false);
                }
            }

            private void InitializeButton()
            {
                Owner.characterDetailView.BackButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.SelectButton.onClick.RemoveAllListeners();
                characterDetailView.PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                characterDetailView.VirtualCurrencyAddPopup.CancelButton.onClick.RemoveAllListeners();
                characterDetailView.VirtualCurrencyAddPopup.CloseButton.onClick.RemoveAllListeners();
                characterDetailView.VirtualCurrencyAddPopup.AddButton.onClick.RemoveAllListeners();
                characterDetailView.QuestionView.sendButton.onClick.RemoveAllListeners();
                characterDetailView.QuestionView.closeButton.onClick.RemoveAllListeners();
                commonView.errorView.okButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.BackButton.onClick.AddListener(OnClickBackButton);
                Owner.characterDetailView.SelectButton.onClick.AddListener(OnClickSelectButton);
                
                Owner.characterDetailView.LeftArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickLeftArrow()).AddTo(cts.Token);
                
                Owner.characterDetailView.RightArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickRightArrow()).AddTo(cts.Token);
                
                characterDetailView.UpgradeButton.OnClickAsObservable()
                    .Subscribe(_ => OnClickUpgrade()).AddTo(cts.Token);
                
                characterDetailView.PurchaseErrorView.okButton.onClick.AddListener(OnClickClosePurchaseErrorView);
                characterDetailView.VirtualCurrencyAddPopup.CancelButton.onClick.AddListener(() =>
                    OnClickCloseVirtualCurrencyAddView(characterDetailView.VirtualCurrencyAddPopup.CancelButton
                        .gameObject));
                characterDetailView.VirtualCurrencyAddPopup.CloseButton.onClick.AddListener(() =>
                    OnClickCloseVirtualCurrencyAddView(characterDetailView.VirtualCurrencyAddPopup.CloseButton
                        .gameObject));
                characterDetailView.VirtualCurrencyAddPopup.AddButton.onClick.AddListener(OnClickAddVirtualCurrency);
                characterDetailView.QuestionView.sendButton.onClick.AddListener(OnClickSendQuestion);
                characterDetailView.QuestionView.closeButton.onClick.AddListener(OnClickCloseComment);
                commonView.errorView.okButton.onClick.AddListener(OnClickCloseErrorView);
            }

            private void InitializeUIAnimation()
            {
                if (isInitialize)
                {
                    return;
                }

                var leftArrowTransform = Owner.characterDetailView.LeftArrowRect;
                var rightArrowTransform = Owner.characterDetailView.RightArrowRect;
                var leftPosition = leftArrowTransform.anchoredPosition3D;
                var rightPosition = rightArrowTransform.anchoredPosition3D;
                leftArrowTransform.DOLocalMove(new Vector3(leftPosition.x + MoveAmount, leftPosition.y, leftPosition.z),
                    1f).SetLoops(-1, LoopType.Yoyo).SetLink(leftArrowTransform.gameObject);
                rightArrowTransform
                    .DOLocalMove(new Vector3(rightPosition.x - MoveAmount, rightPosition.y, rightPosition.z), 1f)
                    .SetLoops(-1, LoopType.Yoyo).SetLink(rightArrowTransform.gameObject);
            }

            private void OnClickBackButton()
            {
                var button = characterDetailView.BackButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    Owner.CreateCharacter(Owner.userDataManager.GetUserData().EquipCharacterId);
                    Owner.stateMachine.Dispatch((int)State.CharacterSelect);
                }).SetLink(button);
            }

            private void OnClickSelectButton()
            {
                var button = characterDetailView.SelectButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var userData = userDataManager.GetUserData();
                    var result = await playFabUserDataManager.TryUpdateUserDataAsync(userData);
                    if (result)
                    {
                        Owner.stateMachine.Dispatch((int)State.Main);
                    }
                })).SetLink(button);
            }

            private void OnClickRightArrow()
            {
                var button = characterDetailView.RightArrowButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    var userData = userDataManager.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        return;
                    }

                    CharacterData nextCharacterData = null;
                    var orderCharacters = userData.Characters.OrderBy(x => x).ToList();
                    var characterData = userDataManager.GetEquippedCharacterData();
                    foreach (var characterIndex in orderCharacters)
                    {
                        if (characterData.Id < characterIndex)
                        {
                            nextCharacterData = characterDataManager.GetCharacterData(characterIndex);
                            break;
                        }
                    }

                    nextCharacterData ??= characterDataManager.GetCharacterData(orderCharacters.First());
                    userData.EquipCharacterId = nextCharacterData.Id;
                    userDataManager.SetUserData(userData);
                    CreateCharacter(nextCharacterData);
                    SetupUIContent();
                    InitializeAnimation();
                }).SetLink(button);
            }

            private void OnClickLeftArrow()
            {
                var button = characterDetailView.LeftArrowButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    var userData = userDataManager.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        return;
                    }

                    CharacterData prevCharacterData = null;
                    var characterData = userDataManager.GetEquippedCharacterData();
                    var orderCharacters = userData.Characters.OrderByDescending(x => x).ToList();

                    foreach (var characterIndex in orderCharacters)
                    {
                        if (characterData.Id > characterIndex)
                        {
                            prevCharacterData = characterDataManager.GetCharacterData(characterIndex);
                            break;
                        }
                    }

                    prevCharacterData ??= characterDataManager.GetCharacterData(orderCharacters.First());
                    userData.EquipCharacterId = prevCharacterData.Id;
                    userDataManager.SetUserData(userData);
                    CreateCharacter(prevCharacterData);
                    SetupUIContent();
                    InitializeAnimation();
                }).SetLink(button);
            }

            private void OnClickUpgrade()
            {
                if (isProcessing)
                {
                    return;
                }

                isProcessing = true;
                characterDetailView.UpgradeButton.interactable = false;
                var characterData = userDataManager.GetEquippedCharacterData();
                var currentLevelData = userDataManager.GetCurrentLevelData(characterData.Id);
                var button = characterDetailView.UpgradeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var coin = await playFabVirtualCurrencyManager.GetCoin();
                    if (coin == GameCommonData.NetworkErrorCode)
                    {
                        isProcessing = false;
                        characterDetailView.UpgradeButton.interactable = true;
                        return;
                    }


                    var nextLevelData = userDataManager.GetNextLevelData(characterData.Id);
                    var virtualCurrencyAddView = characterDetailView.VirtualCurrencyAddPopup;
                    var purchaseErrorView = characterDetailView.PurchaseErrorView;
                    if (coin < nextLevelData.NeedCoin)
                    {
                        characterDetailView.UpgradeButton.interactable = true;
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
                        characterDetailView.UpgradeButton.interactable = true;
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
                    characterDetailView.UpgradeButton.interactable = true;
                })).SetLink(button);
            }

            private void OnClickCloseVirtualCurrencyAddView(GameObject button)
            {
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var virtualCurrencyAddView = characterDetailView.VirtualCurrencyAddPopup;
                        await uiAnimation.Close(virtualCurrencyAddView.transform, GameCommonData.CloseDuration);
                        virtualCurrencyAddView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickAddVirtualCurrency()
            {
                var button = characterDetailView.VirtualCurrencyAddPopup.AddButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)State.Shop);
                }).SetLink(button);
            }

            private void OnClickClosePurchaseErrorView()
            {
                var button = characterDetailView.PurchaseErrorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var purchaseErrorView = characterDetailView.PurchaseErrorView;
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
                var button = characterDetailView.QuestionView.sendButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var question = characterDetailView.QuestionView.questionField.text;
                        var commentTransform = characterDetailView.QuestionView.commentObj.transform;
                        var commentText = characterDetailView.QuestionView.commentText;
                        var errorText = commonView.errorView.errorInfoText;
                        if (question.Length > GameCommonData.CharacterLimit)
                        {
                            commonView.waitPopup.SetActive(false);
                            canQuestion = true;
                            var errorInfo = $"{GameCommonData.CharacterLimit}文字以内で質問してください。";
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
                var button = characterDetailView.QuestionView.closeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var comment = characterDetailView.QuestionView.commentObj.transform;
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
                Owner.character.GetComponent<Animator>().SetTrigger(GameCommonData.ActiveHashKey);
            }

            private int GetModifiedStatus(CharacterLevelData currentLevelData, int value)
            {
                return Mathf.FloorToInt(currentLevelData.StatusRate * value);
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