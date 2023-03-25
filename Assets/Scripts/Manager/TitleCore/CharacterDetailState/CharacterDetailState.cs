using System;
using System.Linq;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.DataManager;
using Manager.NetworkManager;
using UI.Common;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class CharacterDetailState : State
        {
            private const float MoveAmount = 50;

            private CharacterDetailView _characterDetailView;
            private CharacterDataManager _characterDataManager;
            private PlayFabUserDataManager _playFabUserDataManager;
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
                Owner.mainView.CharacterDetailGameObject.SetActive(true);
                _characterDataManager = Owner._characterDataManager;
                _characterDetailView = Owner.characterDetailView;
                _playFabUserDataManager = Owner._playFabUserDataManager;
                _userDataManager = Owner._userDataManager;
                InitializeButton();
                InitializeUIContent();
                InitializeUIAnimation();
                _isInitialize = true;
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                InitializeAnimation();
            }

            private void InitializeUIContent()
            {
                var equippedCharacterDataId = _userDataManager.GetUserData().EquipCharacterId;
                var characterData = _characterDataManager.GetCharacterData(equippedCharacterDataId);
                Owner.characterDetailView.NameText.text = characterData.Name;
                var characterStatusView = Owner.characterDetailView.CharacterStatusView;
                characterStatusView.HpText.text = characterData.Hp.ToString();
                characterStatusView.DamageText.text = characterData.Attack.ToString();
                characterStatusView.SpeedText.text = characterData.Speed.ToString();
                characterStatusView.BombLimitText.text = characterData.BombLimit.ToString();
                characterStatusView.FireRangeText.text = characterData.FireRange.ToString();

                var skillsView = _characterDetailView.SkillsView;
                skillsView.skillOneImage.sprite = characterData.SkillOneSprite;
                skillsView.skillTwoImage.sprite = characterData.SkillTwoSprite;
            }

            private void InitializeButton()
            {
                Owner.characterDetailView.BackButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.SelectButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.LeftArrowButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.RightArrowButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.BackButton.onClick.AddListener(OnClickBackButton);
                Owner.characterDetailView.SelectButton.onClick.AddListener(OnClickSelectButton);
                Owner.characterDetailView.LeftArrowButton.onClick.AddListener(OnClickLeftArrow);
                Owner.characterDetailView.RightArrowButton.onClick.AddListener(OnClickRightArrow);
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
                    var result = await _playFabUserDataManager.TryUpdateUserDataAsync(GameCommonData.UserKey, userData);
                    if (result)
                    {
                        Owner._stateMachine.Dispatch((int)Event.Main);
                    }
                })).SetLink(button);
            }

            private void OnClickRightArrow()
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
                InitializeUIContent();
                InitializeAnimation();
            }

            private void OnClickLeftArrow()
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
                InitializeUIContent();
                InitializeAnimation();
            }

            private void CreateCharacter(CharacterData characterData)
            {
                Owner.CreateCharacter(characterData.ID);
            }

            private void InitializeAnimation()
            {
                Owner._character.GetComponent<Animator>().SetTrigger(GameCommonData.ActiveHashKey);
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