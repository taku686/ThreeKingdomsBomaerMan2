using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        private static readonly int Active = Animator.StringToHash("Active");

        public class CharacterDetailState : State
        {
            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private async void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterDetailGameObject.SetActive(true);
                InitializeButton();
                InitializeContent();
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                InitializeAnimation();
            }

            private void InitializeContent()
            {
                Owner.characterDetailView.Name.text =
                    Owner._titleModel.GetCharacterData(Owner._currentCharacterId).Name;
            }

            private void InitializeButton()
            {
                Owner.characterDetailView.BackButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.SelectButton.onClick.RemoveAllListeners();
                Owner.characterDetailView.BackButton.onClick.AddListener(OnClickBackButton);
                Owner.characterDetailView.SelectButton.onClick.AddListener(OnClickSelectButton);
            }

            private void OnClickBackButton()
            {
                Owner.CreateCharacter(Owner._titleModel.UserData.currentCharacterID.Value);
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterListGameObject.SetActive(true);
                Owner._stateMachine.Dispatch((int)Event.CharacterSelectBack);
            }

            private void OnClickSelectButton()
            {
                Owner._titleModel.UserData.currentCharacterID.Value = Owner._currentCharacterId;
                Owner.DisableTitleGameObject();
                Owner.mainView.MainGameObject.SetActive(true);
                Owner._stateMachine.Dispatch((int)Event.Main);
            }

            private void InitializeAnimation()
            {
                Owner._character.GetComponent<Animator>().SetTrigger(Active);
            }
        }
    }
}