using System.Threading;
using Common;
using Cysharp.Threading.Tasks;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class LoginState : State
        {
            private const string Email = "takunoshin123456789@gmail.com";
            private const string Password = "Passw0rd";
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
            }

            private void InitializeButton()
            {
                Owner.loginView.RetryButton.onClick.RemoveAllListeners();
                Owner.loginView.StartButton.onClick.RemoveAllListeners();
                Owner.loginView.RetryButton.onClick.AddListener(OnClickRetry);
                Owner.loginView.StartButton.onClick.AddListener(() => UniTask.Void(async () =>
                    await Login().AttachExternalCancellation(_token)));
            }

            private async UniTask Login()
            {
                bool result;
                Owner._playFabLoginManager.Initialize();
                if (!PlayerPrefsManager.IsLoginEmailAddress)
                {
                    result = await Owner._playFabLoginManager.LoginWithCustomId().AttachExternalCancellation(_token);
                }
                else
                {
                    result = await Owner._playFabLoginManager.LoginWithEmail(Email, Password)
                        .AttachExternalCancellation(_token);
                }

                if (result)
                {
                    await Owner._characterDataManager.Initialize(Owner._userManager, Owner._token);
                    Owner._mainManager.isInitialize = true;
                    Owner._stateMachine.Dispatch((int)Event.Login);
                }
                else
                {
                    Owner.loginView.ErrorGameObject.SetActive(true);
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