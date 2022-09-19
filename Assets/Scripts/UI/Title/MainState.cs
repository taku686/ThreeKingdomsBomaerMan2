using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class MainState : State
        {
            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnExit(State nextState)
            {
            }

            protected override void OnUpdate()
            {
            }

            private async void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.MainGameObject.SetActive(true);
                InitializeButton();
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                InitializeAnimation();
            }

            private void InitializeAnimation()
            {
                Owner._character.GetComponent<Animator>().SetTrigger(Active);
            }

            private void InitializeButton()
            {
                Owner.mainView.CharacterSelectButton.onClick.RemoveAllListeners();
                Owner.mainView.CharacterSelectButton.onClick.AddListener(OnClickCharacterSelect);
            }


            private void OnClickCharacterSelect()
            {
                Owner._uiAnimation.OnClickAnimation(
                        Owner.mainView.CharacterSelectButton.GetComponent<RectTransform>())
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.CharacterSelect); })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}