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
        public class CharacterDetailState : State
        {
            private const float MoveAmount = 50;
            private const int DefaultPage = 1;
            private const int UpgradeButtonIntervalDuration = 2;
            private const string LevelText = "LV <#94aed0><size=170%>";
            private CharacterDetailView _characterDetailView;
            private CommonView _commonView;
            private CharacterDataManager _characterDataManager;
            private CharacterLevelDataManager _characterLevelDataManager;
            private PlayFabUserDataManager _playFabUserDataManager;
            private PlayFabShopManager _playFabShopManager;
            private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
            private UserDataManager _userDataManager;
            private ChatGPTManager _chatGptManager;
            private CancellationTokenSource _cts;
            private UIAnimation _uiAnimation;
            private bool _isInitialize;
            private bool _canQuestion;
            private int _pageCount;
            private bool _isProcessing;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
                Cancel();
            }

            private async void Initialize()
            {
                SetupCancellationToken();
                _characterDataManager = Owner.characterDataManager;
                _characterLevelDataManager = Owner.characterLevelDataManager;
                _characterDetailView = Owner.characterDetailView;
                _commonView = Owner.commonView;
                _playFabUserDataManager = Owner.playFabUserDataManager;
                _playFabShopManager = Owner.playFabShopManager;
                _playFabVirtualCurrencyManager = Owner.playFabVirtualCurrencyManager;
                _userDataManager = Owner.userDataManager;
                _chatGptManager = Owner.chatGptManager;
                _uiAnimation = Owner.uiAnimation;
                _characterDetailView.PurchaseErrorView.gameObject.SetActive(false);
                _characterDetailView.VirtualCurrencyAddPopup.gameObject.SetActive(false);
                _characterDetailView.QuestionView.commentObj.SetActive(false);
                InitializeButton();
                SetupUIContent();
                InitializeUIAnimation();
                Owner.SwitchUiObject(TitleCoreEvent.CharacterDetail, true);
                _isInitialize = true;
                _canQuestion = true;
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                InitializeAnimation();
            }

            private void SetupUIContent()
            {
                var equippedCharacterDataId = _userDataManager.GetUserData().EquipCharacterId;
                var characterData = _characterDataManager.GetCharacterData(equippedCharacterDataId);
                var currentLevelData = _userDataManager.GetCurrentLevelData(equippedCharacterDataId);
                var nextLevelData = _userDataManager.GetNextLevelData(equippedCharacterDataId);
                SetStatusView(characterData, currentLevelData);
                SetSkillView(characterData, currentLevelData);
                SetLevelView(currentLevelData, nextLevelData);
                _chatGptManager.SetupCharacter(characterData.Name, characterData.Character);
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
                var skillsView = _characterDetailView.SkillsView;
                skillsView.skillOneImage.sprite = characterData.SkillOneSprite;
                skillsView.skillTwoImage.sprite = characterData.SkillTwoSprite;
                skillsView.skillOneLockImage.enabled = !currentLevelData.IsSkillOneActive;
                skillsView.skillTwoLockImage.enabled = !currentLevelData.IsSkillTwoActive;
            }

            private void SetLevelView(CharacterLevelData currentLevelData, CharacterLevelData nextLevelData)
            {
                if (currentLevelData.Level < GameCommonData.MaxCharacterLevel)
                {
                    _characterDetailView.LevelText.text = LevelText + currentLevelData.Level;
                    _characterDetailView.UpgradeInfoText.text = $"Lv{nextLevelData.Level} Upgrade";
                    _characterDetailView.UpgradeText.text = nextLevelData.NeedCoin.ToString("D");
                }
                else
                {
                    _characterDetailView.LevelText.text = LevelText + currentLevelData.Level;
                    _characterDetailView.UpgradeInfoText.text = "Max Level";
                    _characterDetailView.UpgradeText.text = "  ∞  ";
                }
            }

            private void InitializeButton()
            {
                Owner.characterDetailView.BackButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.SelectButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.LeftArrowButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.RightArrowButton.onClick.RemoveAllListeners();
                _characterDetailView.UpgradeButton.onClick.RemoveAllListeners();
                _characterDetailView.PurchaseErrorView.okButton.onClick.RemoveAllListeners();
                _characterDetailView.VirtualCurrencyAddPopup.CancelButton.onClick.RemoveAllListeners();
                _characterDetailView.VirtualCurrencyAddPopup.CloseButton.onClick.RemoveAllListeners();
                _characterDetailView.VirtualCurrencyAddPopup.AddButton.onClick.RemoveAllListeners();
                _characterDetailView.QuestionView.sendButton.onClick.RemoveAllListeners();
                _characterDetailView.QuestionView.closeButton.onClick.RemoveAllListeners();
                _commonView.errorView.okButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.BackButton.onClick.AddListener(OnClickBackButton);
                Owner.characterDetailView.SelectButton.onClick.AddListener(OnClickSelectButton);
                Owner.characterDetailView.LeftArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickLeftArrow()).AddTo(_cts.Token);
                Owner.characterDetailView.RightArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickRightArrow()).AddTo(_cts.Token);
                _characterDetailView.UpgradeButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(UpgradeButtonIntervalDuration))
                    .Subscribe(_ => OnClickUpgrade()).AddTo(_cts.Token);
                _characterDetailView.PurchaseErrorView.okButton.onClick.AddListener(OnClickClosePurchaseErrorView);
                _characterDetailView.VirtualCurrencyAddPopup.CancelButton.onClick.AddListener(() =>
                    OnClickCloseVirtualCurrencyAddView(_characterDetailView.VirtualCurrencyAddPopup.CancelButton
                        .gameObject));
                _characterDetailView.VirtualCurrencyAddPopup.CloseButton.onClick.AddListener(() =>
                    OnClickCloseVirtualCurrencyAddView(_characterDetailView.VirtualCurrencyAddPopup.CloseButton
                        .gameObject));
                _characterDetailView.VirtualCurrencyAddPopup.AddButton.onClick.AddListener(OnClickAddVirtualCurrency);
                _characterDetailView.QuestionView.sendButton.onClick.AddListener(OnClickSendQuestion);
                _characterDetailView.QuestionView.closeButton.onClick.AddListener(OnClickCloseComment);
                _commonView.errorView.okButton.onClick.AddListener(OnClickCloseErrorView);
            }

            private void InitializeUIAnimation()
            {
                if (_isInitialize)
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
                var button = _characterDetailView.BackButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    Owner.CreateCharacter(Owner.userDataManager.GetUserData().EquipCharacterId);
                    Owner.DisableTitleGameObject();
                    Owner.mainView.CharacterListGameObject.SetActive(true);
                    Owner.stateMachine.Dispatch((int)TitleCoreEvent.CharacterSelect);
                }).SetLink(button);
            }

            private void OnClickSelectButton()
            {
                var button = _characterDetailView.SelectButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var userData = _userDataManager.GetUserData();
                    var result = await _playFabUserDataManager.TryUpdateUserDataAsync(userData);
                    if (result)
                    {
                        Owner.stateMachine.Dispatch((int)TitleCoreEvent.Main);
                    }
                })).SetLink(button);
            }

            private void OnClickRightArrow()
            {
                var button = _characterDetailView.RightArrowButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    var userData = _userDataManager.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        return;
                    }

                    CharacterData nextCharacterData = null;
                    var orderCharacters = userData.Characters.OrderBy(x => x).ToList();
                    var characterData = _userDataManager.GetEquippedCharacterData();
                    foreach (var characterIndex in orderCharacters)
                    {
                        if (characterData.Id < characterIndex)
                        {
                            nextCharacterData = _characterDataManager.GetCharacterData(characterIndex);
                            break;
                        }
                    }

                    nextCharacterData ??= _characterDataManager.GetCharacterData(orderCharacters.First());
                    userData.EquipCharacterId = nextCharacterData.Id;
                    _userDataManager.SetUserData(userData);
                    CreateCharacter(nextCharacterData);
                    SetupUIContent();
                    InitializeAnimation();
                }).SetLink(button);
            }

            private void OnClickLeftArrow()
            {
                var button = _characterDetailView.LeftArrowButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    var userData = _userDataManager.GetUserData();
                    if (userData.Characters.Count <= 1)
                    {
                        return;
                    }

                    CharacterData prevCharacterData = null;
                    var characterData = _userDataManager.GetEquippedCharacterData();
                    var orderCharacters = userData.Characters.OrderByDescending(x => x).ToList();

                    foreach (var characterIndex in orderCharacters)
                    {
                        if (characterData.Id > characterIndex)
                        {
                            prevCharacterData = _characterDataManager.GetCharacterData(characterIndex);
                            break;
                        }
                    }

                    prevCharacterData ??= _characterDataManager.GetCharacterData(orderCharacters.First());
                    userData.EquipCharacterId = prevCharacterData.Id;
                    _userDataManager.SetUserData(userData);
                    CreateCharacter(prevCharacterData);
                    SetupUIContent();
                    InitializeAnimation();
                }).SetLink(button);
            }

            private void OnClickUpgrade()
            {
                if (_isProcessing)
                {
                    return;
                }

                _isProcessing = true;
                var characterData = _userDataManager.GetEquippedCharacterData();
                var currentLevelData = _userDataManager.GetCurrentLevelData(characterData.Id);
                if (currentLevelData.Level >= GameCommonData.MaxCharacterLevel)
                {
                    _isProcessing = false;
                    return;
                }

                var button = _characterDetailView.UpgradeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var coin = await _playFabVirtualCurrencyManager.GetCoin();
                    if (coin == GameCommonData.NetworkErrorCode)
                    {
                        _isProcessing = false;
                        return;
                    }


                    var nextLevelData = _userDataManager.GetNextLevelData(characterData.Id);
                    var virtualCurrencyAddView = _characterDetailView.VirtualCurrencyAddPopup;
                    var purchaseErrorView = _characterDetailView.PurchaseErrorView;
                    if (currentLevelData.Level >= GameCommonData.MaxCharacterLevel)
                    {
                        _isProcessing = false;
                        return;
                    }

                    if (coin < nextLevelData.NeedCoin)
                    {
                        virtualCurrencyAddView.transform.localScale = Vector3.zero;
                        virtualCurrencyAddView.gameObject.SetActive(true);
                        await _uiAnimation.Open(virtualCurrencyAddView.transform, GameCommonData.OpenDuration);
                        _isProcessing = false;
                        return;
                    }

                    var result = await _playFabShopManager.TryPurchaseLevelUpItem(nextLevelData.Level,
                        GameCommonData.CoinKey, nextLevelData.NeedCoin, characterData.Id, purchaseErrorView);

                    if (!result)
                    {
                        purchaseErrorView.transform.localScale = Vector3.zero;
                        purchaseErrorView.gameObject.SetActive(true);
                        await _uiAnimation.Open(purchaseErrorView.transform, GameCommonData.OpenDuration);
                        _isProcessing = false;
                        return;
                    }

                    Owner.CheckMission(GameCommonData.LevelUpActionId);
                    var userData = _userDataManager.GetUserData();
                    await _userDataManager.UpdateUserData(userData);
                    await Owner.SetCoinText();
                    SetupUIContent();
                    if (nextLevelData.Level == GameCommonData.MaxCharacterLevel)
                    {
                        CreateCharacter(characterData);
                    }

                    _isProcessing = false;
                })).SetLink(button);
            }

            private void OnClickCloseVirtualCurrencyAddView(GameObject button)
            {
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var virtualCurrencyAddView = _characterDetailView.VirtualCurrencyAddPopup;
                        await _uiAnimation.Close(virtualCurrencyAddView.transform, GameCommonData.CloseDuration);
                        virtualCurrencyAddView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickAddVirtualCurrency()
            {
                var button = _characterDetailView.VirtualCurrencyAddPopup.AddButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    Owner.stateMachine.Dispatch((int)TitleCoreEvent.Shop);
                }).SetLink(button);
            }

            private void OnClickClosePurchaseErrorView()
            {
                var button = _characterDetailView.PurchaseErrorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var purchaseErrorView = _characterDetailView.PurchaseErrorView;
                        await _uiAnimation.Close(purchaseErrorView.transform, GameCommonData.CloseDuration);
                        purchaseErrorView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickSendQuestion()
            {
                if (!_canQuestion)
                {
                    return;
                }

                _commonView.waitPopup.SetActive(true);
                _canQuestion = false;
                var button = _characterDetailView.QuestionView.sendButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var question = _characterDetailView.QuestionView.questionField.text;
                        var commentTransform = _characterDetailView.QuestionView.commentObj.transform;
                        var commentText = _characterDetailView.QuestionView.commentText;
                        var errorText = _commonView.errorView.errorInfoText;
                        if (question.Length > GameCommonData.CharacterLimit)
                        {
                            _commonView.waitPopup.SetActive(false);
                            _canQuestion = true;
                            var errorInfo = $"{GameCommonData.CharacterLimit}文字以内で質問してください。";
                            await OpenErrorView();
                            return;
                        }

                        var result = await _playFabShopManager.TryPurchaseItem(GameCommonData.QuestionItemKey,
                            GameCommonData.TicketKey, 1, errorText);
                        if (!result)
                        {
                            _commonView.waitPopup.SetActive(false);
                            _canQuestion = true;
                            await OpenErrorView();
                            return;
                        }

                        await _chatGptManager.Request(question, commentText);
                        _commonView.waitPopup.SetActive(false);
                        await Owner.SetTicketText();
                        commentText.pageToDisplay = DefaultPage;
                        commentTransform.localScale = Vector3.zero;
                        commentTransform.gameObject.SetActive(true);
                        await _uiAnimation.Open(commentTransform, GameCommonData.OpenDuration);

                        _canQuestion = true;
                    }
                )).SetLink(button);
            }

            private void OnClickCloseComment()
            {
                var button = _characterDetailView.QuestionView.closeButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var comment = _characterDetailView.QuestionView.commentObj.transform;
                        await _uiAnimation.Close(comment, GameCommonData.CloseDuration);
                        comment.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void OnClickCloseErrorView()
            {
                var button = _commonView.errorView.okButton.gameObject;
                Owner.uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var errorView = _commonView.errorView.transform;
                        await _uiAnimation.Close(errorView, GameCommonData.CloseDuration);
                        errorView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private async UniTask OpenErrorView(string errorText)
            {
                var errorView = _commonView.errorView;
                var errorViewObj = _commonView.errorView.gameObject;
                _commonView.errorView.errorInfoText.text = errorText;
                errorView.transform.localScale = Vector3.zero;
                errorViewObj.SetActive(true);
                await _uiAnimation.Open(errorView.transform, GameCommonData.OpenDuration);
            }

            private async UniTask OpenErrorView()
            {
                var errorView = _commonView.errorView;
                var errorViewObj = _commonView.errorView.gameObject;
                errorView.transform.localScale = Vector3.zero;
                errorViewObj.SetActive(true);
                await _uiAnimation.Open(errorView.transform, GameCommonData.OpenDuration);
            }

            private void CreateCharacter(CharacterData characterData)
            {
                _chatGptManager.SetupCharacter(characterData.Name, characterData.Character);
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