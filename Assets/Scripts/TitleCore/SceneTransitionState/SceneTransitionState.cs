using Common.Data;
using MoreMountains.Tools;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class SceneTransitionState : State
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
                LoadScene();
                Owner.SwitchUiObject(TitleCoreEvent.SceneTransition, false);
            }

            private void LoadScene()
            {
                MMSceneLoadingManager.LoadScene(GameCommonData.BattleScene);
            }
        }
    }
}