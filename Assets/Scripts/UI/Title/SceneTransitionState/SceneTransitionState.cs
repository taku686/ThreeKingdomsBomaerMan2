using Common.Data;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class SceneTransitionState : State
        {
            protected override void OnEnter(State prevState)
            {
                OnInitialize();
            }

            private void OnInitialize()
            {
                Owner.DisableTitleGameObject();
                Owner.mainView.SceneTransitionGameObject.SetActive(true);
                LoadScene().Forget();
            }

            private async UniTask LoadScene()
            {
                await SceneManager.LoadSceneAsync((int)SceneIndex.BattleScene).ToUniTask(Progress.Create<float>(x =>
                {
                    Owner.sceneTransitionView.LoadingText.text = "Loading..." + x + "%";
                    Owner.sceneTransitionView.LoadingBar.value = x;
                }),cancellationToken: Owner.gameObject.GetCancellationTokenOnDestroy());
            }
        }
    }
}