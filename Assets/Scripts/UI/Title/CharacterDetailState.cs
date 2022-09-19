using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class CharacterDetailState : State
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

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.CharacterDetailGameObject.SetActive(true);
                InitializeButton();
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
        }
    }
}