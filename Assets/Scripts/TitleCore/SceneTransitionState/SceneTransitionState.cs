using Common.Data;
using MoreMountains.Tools;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class SceneTransitionState : StateMachine<TitleCore>.State
        {
            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
            }

            private void Initialize()
            {
                LoadScene();
                Owner.SwitchUiObject(State.SceneTransition, false);
            }

            private void LoadScene()
            {
                MMSceneLoadingManager.LoadScene(GameCommonData.BattleScene);
            }
        }
    }
}