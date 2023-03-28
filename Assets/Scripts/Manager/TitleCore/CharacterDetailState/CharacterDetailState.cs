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
            private const string LevelText = "LV <#94aed0><size=170%>";
            private CharacterDetailView _characterDetailView;
            private CharacterDataManager _characterDataManager;
            private CharacterLevelDataManager _characterLevelDataManager;
            private PlayFabUserDataManager _playFabUserDataManager;
            private PlayFabShopManager _playFabShopManager;
            private UserDataManager _userDataManager;
            private CancellationTokenSource _cts;
            private UIAnimation _uiAnimation;
            private bool _isInitialize;

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
                Owner.DisableTitleGameObject();
                _characterDataManager = Owner._characterDataManager;
                _characterLevelDataManager = Owner._characterLevelDataManager;
                _characterDetailView = Owner.characterDetailView;
                _playFabUserDataManager = Owner._playFabUserDataManager;
                _playFabShopManager = Owner._playFabShopManager;
                _userDataManager = Owner._userDataManager;
                _uiAnimation = Owner._uiAnimation;
                _characterDetailView.PurchaseErrorView.gameObject.SetActive(false);
                _characterDetailView.VirtualCurrencyAddPopup.gameObject.SetActive(false);
                InitializeButton();
                SetupUIContent();
                InitializeUIAnimation();
                Owner.mainView.CharacterDetailGameObject.SetActive(true);
                _isInitialize = true;
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
            }

            private void SetStatusView(CharacterData characterData, CharacterLevelData currentLevelData)
            {
                Owner.characterDetailView.NameText.text = characterData.Name;
                var characterStatusView = Owner.characterDetailView.CharacterStatusView;
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
                skillsView.skillOneLockImage.enabled = currentLevelData.IsSkillOneActive;
                skillsView.skillTwoLockImage.enabled = currentLevelData.IsSkillTwoActive;
            }

            private void SetLevelView(CharacterLevelData currentLevelData, CharacterLevelData nextLevelData)
            {
                _characterDetailView.LevelText.text = LevelText + currentLevelData.Level;
                _characterDetailView.UpgradeInfoText.text = $"Lv{nextLevelData.Level} Upgrade";
                _characterDetailView.UpgradeText.text = nextLevelData.NeedCoin.ToString("D");
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
                Owner.characterDetailView.BackButton.onClick.AddListener(OnClickBackButton);
                Owner.characterDetailView.SelectButton.onClick.AddListener(OnClickSelectButton);

                Owner.characterDetailView.LeftArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickLeftArrow()).AddTo(_cts.Token);
                Owner.characterDetailView.RightArrowButton.OnClickAsObservable()
                    .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                    .Subscribe(_ => OnClickRightArrow()).AddTo(_cts.Token);
                _characterDetailView.UpgradeButton.onClick.AddListener(OnClickUpgrade);
                _characterDetailView.PurchaseErrorView.okButton.onClick.AddListener(OnClickClosePurchaseErrorView);
                _characterDetailView.VirtualCurrencyAddPopup.CancelButton.onClick.AddListener(() =>
                    OnClickCloseVirtualCurrencyAddView(_characterDetailView.VirtualCurrencyAddPopup.CancelButton
                        .gameObject));
                _characterDetailView.VirtualCurrencyAddPopup.CloseButton.onClick.AddListener(() =>
                    OnClickCloseVirtualCurrencyAddView(_characterDetailView.VirtualCurrencyAddPopup.CloseButton
                        .gameObject));
                _characterDetailView.VirtualCurrencyAddPopup.AddButton.onClick.AddListener(OnClickAddVirtualCurrency);
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
                        1f)
                    .SetLoops(-1, LoopType.Yoyo).SetLink(leftArrowTransform.gameObject);
                rightArrowTransform
                    .DOLocalMove(new Vector3(rightPosition.x - MoveAmount, rightPosition.y, rightPosition.z), 1f)
                    .SetLoops(-1, LoopType.Yoyo).SetLink(rightArrowTransform.gameObject);
            }

            private void OnClickBackButton()
            {
                var button = _characterDetailView.BackButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() =>
                {
                    Owner.CreateCharacter(Owner._userDataManager.GetUserData().EquipCharacterId);
                    Owner.DisableTitleGameObject();
                    Owner.mainView.CharacterListGameObject.SetActive(true);
                    Owner._stateMachine.Dispatch((int)Event.CharacterSelect);
                }).SetLink(button);
            }

            private void OnClickSelectButton()
            {
                var button = _characterDetailView.SelectButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var userData = _userDataManager.GetUserData();
                    var result = await _playFabUserDataManager.TryUpdateUserDataAsync(userData);
                    if (result)
                    {
                        Owner._stateMachine.Dispatch((int)Event.Main);
                    }
                })).SetLink(button);
            }

            private void OnClickRightArrow()
            {
                var button = _characterDetailView.RightArrowButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() =>
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
                        if (characterData.ID < characterIndex)
                        {
                            nextCharacterData = _characterDataManager.GetCharacterData(characterIndex);
                            break;
                        }
                    }

                    nextCharacterData ??= _characterDataManager.GetCharacterData(orderCharacters.First());
                    userData.EquipCharacterId = nextCharacterData.ID;
                    _userDataManager.SetUserData(userData);
                    CreateCharacter(nextCharacterData);
                    SetupUIContent();
                    InitializeAnimation();
                }).SetLink(button);
            }

            private void OnClickLeftArrow()
            {
                var button = _characterDetailView.LeftArrowButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() =>
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
                        if (characterData.ID > characterIndex)
                        {
                            prevCharacterData = _characterDataManager.GetCharacterData(characterIndex);
                            break;
                        }
                    }

                    prevCharacterData ??= _characterDataManager.GetCharacterData(orderCharacters.First());
                    userData.EquipCharacterId = prevCharacterData.ID;
                    _userDataManager.SetUserData(userData);
                    CreateCharacter(prevCharacterData);
                    SetupUIContent();
                    InitializeAnimation();
                }).SetLink(button);
            }

            private void OnClickUpgrade()
            {
                var button = _characterDetailView.UpgradeButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                {
                    var coin = _userDataManager.GetCoin();
                    var equippedCharacterData = _userDataManager.GetEquippedCharacterData();
                    var nextLevelData = _userDataManager.GetNextLevelData(equippedCharacterData.ID);
                    var currentLevelData = _userDataManager.GetCurrentLevelData(equippedCharacterData.ID);
                    var virtualCurrencyAddView = _characterDetailView.VirtualCurrencyAddPopup;
                    var purchaseErrorView = _characterDetailView.PurchaseErrorView;
                    if (currentLevelData.Level >= GameCommonData.MaxCharacterLevel)
                    {
                        return;
                    }

                    if (coin < nextLevelData.NeedCoin)
                    {
                        virtualCurrencyAddView.transform.localScale = Vector3.zero;
                        virtualCurrencyAddView.gameObject.SetActive(true);
                        await _uiAnimation.Open(virtualCurrencyAddView.transform, GameCommonData.OpenDuration);
                        return;
                    }

                    var result = await _playFabShopManager.TryPurchaseUpgradeItem(nextLevelData.Level,
                        GameCommonData.CoinKey, nextLevelData.NeedCoin, equippedCharacterData.ID, purchaseErrorView);

                    if (!result)
                    {
                        purchaseErrorView.transform.localScale = Vector3.zero;
                        purchaseErrorView.gameObject.SetActive(true);
                        await _uiAnimation.Open(purchaseErrorView.transform, GameCommonData.OpenDuration);
                        return;
                    }

                    SetupUIContent();
                })).SetLink(button);
            }

            private void OnClickCloseVirtualCurrencyAddView(GameObject button)
            {
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
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
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        Owner._stateMachine.Dispatch((int)Event.Shop);
                    }
                )).SetLink(button);
            }

            private void OnClickClosePurchaseErrorView()
            {
                var button = _characterDetailView.PurchaseErrorView.okButton.gameObject;
                Owner._uiAnimation.ClickScaleColor(button).OnComplete(() => UniTask.Void(async () =>
                    {
                        var purchaseErrorView = _characterDetailView.PurchaseErrorView;
                        await _uiAnimation.Close(purchaseErrorView.transform, GameCommonData.CloseDuration);
                        purchaseErrorView.gameObject.SetActive(false);
                    }
                )).SetLink(button);
            }

            private void CreateCharacter(CharacterData characterData)
            {
                Owner.CreateCharacter(characterData.ID);
            }

            private void InitializeAnimation()
            {
                Owner._character.GetComponent<Animator>().SetTrigger(GameCommonData.ActiveHashKey);
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