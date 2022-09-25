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

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.MainGameObject.SetActive(true);
                InitializeButton();
            }

            private void InitializeButton()
            {
                Owner.mainView.CharacterSelectButton.onClick.RemoveAllListeners();
                Owner.mainView.BattleReadyButton.onClick.RemoveAllListeners();
                Owner.mainView.CharacterSelectButton.onClick.AddListener(OnClickCharacterSelect);
                Owner.mainView.BattleReadyButton.onClick.AddListener(OnClickBattleReady);
            }


            private void OnClickCharacterSelect()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.mainView.CharacterSelectButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.CharacterSelect); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBattleReady()
            {
                Owner._uiAnimation.OnClickScaleColorAnimation(Owner.mainView.BattleReadyButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.ReadyBattle); })
                    .SetLink(Owner.gameObject);
            }
        }
    }
}