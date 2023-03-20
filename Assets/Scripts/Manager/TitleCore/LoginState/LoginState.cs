using System.Threading;
using Common;
using Cysharp.Threading.Tasks;
using State = StateMachine<UI.Title.TitleBase>.State;

namespace UI.Title
{
    public partial class TitleBase
    {
        public class LoginState : State
        {
            private CancellationToken _token;

            protected override void OnEnter(State prevState)
            {
                OnInitialize();
            }

            private void OnInitialize()
            {
                _token = Owner.GetCancellationTokenOnDestroy();
                Owner.DisableTitleGameObject();
                InitializeButton();
                InitializeObject();
                Owner.mainView.LoginGameObject.SetActive(true);
            }

            private void InitializeObject()
            {
                Owner.loginView.ErrorGameObject.SetActive(false);
                Owner.loginView.DisplayNameView.gameObject.SetActive(false);
            }

            private void InitializeButton()
            {
                Owner.loginView.RetryButton.onClick.RemoveAllListeners();
                Owner.loginView.StartButton.onClick.RemoveAllListeners();
                Owner.loginView.DisplayNameView.OkButton.onClick.RemoveAllListeners();
                Owner.loginView.RetryButton.onClick.AddListener(OnClickRetry);
                Owner.loginView.StartButton.onClick.AddListener(() => UniTask.Void(async () =>
                    await Login().AttachExternalCancellation(_token)));
                Owner.loginView.DisplayNameView.OkButton.onClick.AddListener(() => UniTask.Void(async () =>
                {
                    await OnClickDisplayName();
                }));
            }

            private async UniTask Login()
            {
                Owner._playFabLoginManager.Initialize(Owner.loginView.DisplayNameView, Owner.loginView.ErrorGameObject);
                var result = await Owner._playFabLoginManager.Login()
                    .AttachExternalCancellation(_token);

                if (result)
                {
                    await Owner._characterDataManager.Initialize(Owner._userDataManager, Owner._token);
                    Owner._mainManager.isInitialize = true;
                    Owner._stateMachine.Dispatch((int)Event.Login);
                }
            }

            private async UniTask OnClickDisplayName()
            {
                var displayName = Owner.loginView.DisplayNameView.InputField.text;
                var success = await Owner._playFabLoginManager.SetDisplayName(displayName);
                if (!success)
                {
                    return;
                }

                var createSuccess = await Owner._playFabLoginManager.CreateUserData();
                if (createSuccess)
                {
                    await Owner._characterDataManager.Initialize(Owner._userDataManager, Owner._token);
                    Owner.loginView.DisplayNameView.gameObject.SetActive(false);
                    Owner._mainManager.isInitialize = true;
                    Owner._stateMachine.Dispatch((int)Event.Login);
                }
            }

            private async void OnClickRetry()
            {
                Owner.loginView.ErrorGameObject.SetActive(false);
                await Login().AttachExternalCancellation(_token);
            }
        }
    }
}