using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.DataManager;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        private static readonly int Active = Animator.StringToHash("Active");

        public class CharacterDetailState : State
        {
            private const float MoveAmount = 50;
            private CharacterData _characterData;
            private CharacterDataManager _characterDataManager;
            private CancellationTokenSource _cts;
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
                _characterData = Owner._characterDataManager.GetCharacterData(Owner._currentCharacterId);
                _characterDataManager = Owner._characterDataManager;
                InitializeButton();
                InitializeContent();
                InitializeUIAnimation();
                _isInitialize = true;
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                InitializeAnimation();
            }

            private void InitializeContent()
            {
                Owner.characterDetailView.NameText.text =
                    Owner._characterDataManager.GetCharacterData(Owner._currentCharacterId).Name;
                var characterStatusView = Owner.characterDetailView.CharacterStatusView;
                characterStatusView.HpText.text = _characterData.Hp.ToString();
                characterStatusView.DamageText.text = _characterData.Attack.ToString();
                characterStatusView.SpeedText.text = _characterData.Speed.ToString();
                characterStatusView.BombLimitText.text = _characterData.BombLimit.ToString();
                characterStatusView.FireRangeText.text = _characterData.FireRange.ToString();
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
                Owner.CreateCharacter(Owner._userDataManager.equipCharacterId.Value);
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterListGameObject.SetActive(true);
                Owner._stateMachine.Dispatch((int)Event.CharacterSelectBack);
            }

            private void OnClickSelectButton()
            {
                Owner._userDataManager.equipCharacterId.Value = Owner._currentCharacterId;
                Owner._stateMachine.Dispatch((int)Event.Main);
            }

            private void OnClickRightArrow()
            {
                if (Owner._userDataManager.GetUser().Characters.Count <= 1)
                {
                    return;
                }

                CharacterData nextCharacterData = null;
                var orderCharacters = Owner._userDataManager.GetUser().Characters.OrderBy(x => x).ToList();

                foreach (var characterIndex in orderCharacters)
                {
                    if (_characterData.ID < characterIndex)
                    {
                        nextCharacterData = _characterDataManager.GetCharacterData(characterIndex);
                        break;
                    }
                }

                nextCharacterData ??= _characterDataManager.GetCharacterData(orderCharacters.First());
                _characterData = nextCharacterData;
                CreateCharacter(nextCharacterData);
                InitializeContent();
                InitializeAnimation();
            }

            private void OnClickLeftArrow()
            {
                if (Owner._userDataManager.GetUser().Characters.Count <= 1)
                {
                    return;
                }

                CharacterData prevCharacterData = null;
                var orderCharacters =
                    Owner._userDataManager.GetUser().Characters.OrderByDescending(x => x).ToList();

                foreach (var characterIndex in orderCharacters)
                {
                    if (_characterData.ID > characterIndex)
                    {
                        prevCharacterData = _characterDataManager.GetCharacterData(characterIndex);
                        break;
                    }
                }

                prevCharacterData ??= _characterDataManager.GetCharacterData(orderCharacters.First());
                _characterData = prevCharacterData;
                CreateCharacter(prevCharacterData);
                InitializeContent();
                InitializeAnimation();
            }

            private void CreateCharacter(CharacterData characterData)
            {
                var characterCreatePosition = Owner.characterCreatePosition;
                var preCharacter = Owner._character;
                Destroy(preCharacter);
                Owner._character = Instantiate(
                    characterData.CharacterObject,
                    characterCreatePosition.position,
                    characterCreatePosition.rotation, characterCreatePosition);
                Owner._currentCharacterId = characterData.ID;
            }

            private void InitializeAnimation()
            {
                Owner._character.GetComponent<Animator>().SetTrigger(Active);
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