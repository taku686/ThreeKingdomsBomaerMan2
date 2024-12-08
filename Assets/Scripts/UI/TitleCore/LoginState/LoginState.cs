using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using UniRx;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class LoginState : StateMachine<TitleCore>.State
        {
            private CancellationTokenSource _cancellationTokenSource;
            private PlayFabUserDataManager _playFabUserDataManager;
            private LoginView View => (LoginView)Owner.GetView(State.Login);
            private CommonView _commonView;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnLateExit(StateMachine<TitleCore>.State nextState)
            {
                Owner.Cancel(_cancellationTokenSource);
            }

            private void Initialize()
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _playFabUserDataManager = Owner._playFabUserDataManager;
                _commonView = Owner._commonView;

                InitializeButton();
                InitializeObject();
                Owner.SwitchUiObject(State.Login, false).Forget();
            }

            private void InitializeObject()
            {
                View.ErrorGameObject.SetActive(false);
                View.DisplayNameView.gameObject.SetActive(false);
            }

            private void InitializeButton()
            {
                View.RetryButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(View.RetryButton).ToObservable())
                    .SelectMany(_ => OnClickRetry().ToObservable())
                    .Subscribe()
                    .AddTo(_cancellationTokenSource.Token);

                View.LoginButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(View.LoginButton).ToObservable())
                    .SelectMany(_ => OnClickLogin().ToObservable())
                    .Subscribe()
                    .AddTo(_cancellationTokenSource.Token);

                View.DisplayNameView.OkButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(View.DisplayNameView.OkButton).ToObservable())
                    .SelectMany(_ => OnClickDisplayName().ToObservable())
                    .Subscribe()
                    .AddTo(_cancellationTokenSource.Token);
            }

            private async UniTask OnClickLogin()
            {
                View.LoginButton.interactable = false;
                await Login().AttachExternalCancellation(_cancellationTokenSource.Token);
            }

            private async UniTask OnClickRetry()
            {
                View.RetryButton.interactable = false;
                View.ErrorGameObject.SetActive(false);
                await Login().AttachExternalCancellation(_cancellationTokenSource.Token);
            }

            private async UniTask Login()
            {
                _commonView.waitPopup.SetActive(true);
                Owner._playFabLoginManager.Initialize(View.DisplayNameView, View.ErrorGameObject);
                var result = await Owner._playFabLoginManager.Login()
                    .AttachExternalCancellation(_cancellationTokenSource.Token);

                if (!result)
                {
                    _commonView.waitPopup.SetActive(false);
                    View.RetryButton.interactable = true;
                    View.LoginButton.interactable = true;
                    return;
                }

                Owner._mainManager.isInitialize = true;
                Owner._stateMachine.Dispatch((int)State.Main);
                _commonView.waitPopup.SetActive(false);
                View.RetryButton.interactable = true;
            }

            private async UniTask OnClickDisplayName()
            {
                View.DisplayNameView.OkButton.interactable = false;
                _commonView.waitPopup.SetActive(true);
                var displayName = View.DisplayNameView.InputField.text;
                var errorText = View.DisplayNameView.ErrorText;
                var success = await _playFabUserDataManager.UpdateUserDisplayName(displayName, errorText);
                if (!success)
                {
                    _commonView.waitPopup.SetActive(false);
                    View.DisplayNameView.OkButton.interactable = true;
                    return;
                }

                var createSuccess = await Owner._playFabLoginManager.CreateUserData();
                if (createSuccess)
                {
                    View.DisplayNameView.gameObject.SetActive(false);
                    Owner._mainManager.isInitialize = true;
                    Owner._stateMachine.Dispatch((int)State.Main);
                    _commonView.waitPopup.SetActive(false);
                }
            }
        }
    }
}