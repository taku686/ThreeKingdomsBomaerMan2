using Common.Data;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
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
                Owner.commonView.virtualCurrencyView.gameObject.SetActive(true);
            }

            private void Initialize()
            {
                Owner.DisableTitleGameObject();
                Owner.commonView.virtualCurrencyView.gameObject.SetActive(false);
                Owner.mainView.SceneTransitionGameObject.SetActive(true);
                LoadScene().Forget();
            }

            private async UniTask LoadScene()
            {
                await SceneManager.LoadSceneAsync((int)SceneIndex.BattleScene).ToUniTask(Progress.Create<float>(x =>
                {
                    Owner.sceneTransitionView.LoadingText.text = "Loading..." + x + "%";
                    Owner.sceneTransitionView.LoadingBar.value = x;
                }), cancellationToken: Owner.gameObject.GetCancellationTokenOnDestroy());
            }
        }
    }
}