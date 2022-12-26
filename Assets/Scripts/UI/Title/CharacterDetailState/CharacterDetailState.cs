using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        private static readonly int Active = Animator.StringToHash("Active");

        public class CharacterDetailState : State
        {
            private CharacterData _characterData;
            private const float MoveAmount = 50;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private async void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterDetailGameObject.SetActive(true);
                _characterData = Owner._characterDataManager.GetCharacterData(Owner._currentCharacterId);
                InitializeButton();
                InitializeContent();
                InitializeUIAnimation();
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
                Owner.CreateCharacter(Owner._userManager.equipCharacterId.Value);
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterListGameObject.SetActive(true);
                Owner._stateMachine.Dispatch((int)Event.CharacterSelectBack);
            }

            private void OnClickSelectButton()
            {
                Owner._userManager.equipCharacterId.Value = Owner._currentCharacterId;
                Owner._stateMachine.Dispatch((int)Event.Main);
            }

            private void OnClickRightArrow()
            {
                if (Owner._userManager.GetUser().Characters.Count <= 1)
                {
                    return;
                }

                CharacterData nextCharacterData = null;
                var orderCharacters = Owner._userManager.GetUser().Characters.OrderBy(x => x.Key).ToList();

                foreach (var keyValuePair in orderCharacters)
                {
                    if (_characterData.ID < keyValuePair.Key)
                    {
                        nextCharacterData = keyValuePair.Value;
                        break;
                    }
                }

                nextCharacterData ??= orderCharacters.First().Value;
                _characterData = nextCharacterData;
                CreateCharacter(nextCharacterData);
                InitializeContent();
                //await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                InitializeAnimation();
            }

            private void OnClickLeftArrow()
            {
                if (Owner._userManager.GetUser().Characters.Count <= 1)
                {
                    return;
                }

                CharacterData prevCharacterData = null;
                var orderCharacters = Owner._userManager.GetUser().Characters.OrderByDescending(x => x.Key).ToList();

                foreach (var keyValuePair in orderCharacters)
                {
                    if (_characterData.ID > keyValuePair.Key)
                    {
                        prevCharacterData = keyValuePair.Value;
                        break;
                    }
                }

                prevCharacterData ??= orderCharacters.First().Value;
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
                    Owner._characterDataManager.GetCharacterGameObject(characterData.ID),
                    characterCreatePosition.position,
                    characterCreatePosition.rotation, characterCreatePosition);
                Owner._currentCharacterId = characterData.ID;
            }

            private void InitializeAnimation()
            {
                Owner._character.GetComponent<Animator>().SetTrigger(Active);
            }
        }
    }
}