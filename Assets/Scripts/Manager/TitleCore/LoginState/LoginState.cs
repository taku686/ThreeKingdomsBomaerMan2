using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class LoginState : State
        {
            private CancellationToken _token;
            private PlayFabUserDataManager _playFabUserDataManager;
            private LoginView _loginView;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            private void Initialize()
            {
                _token = Owner.GetCancellationTokenOnDestroy();
                _playFabUserDataManager = Owner._playFabUserDataManager;
                _loginView = Owner.loginView;
                Owner.DisableTitleGameObject();
                InitializeButton();
                InitializeObject();
                InitializeTitleImage();
                Owner.mainView.LoginGameObject.SetActive(true);
            }

            private void InitializeTitleImage()
            {
                var sprites = _loginView.TitleSprites;
                var backgroundImage = _loginView.BackgroundImage;
                var index = Random.Range(0, sprites.Count);
                var titleSprite = sprites[index];
                backgroundImage.sprite = titleSprite;
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
                    Owner._characterDataManager.Initialize(Owner._userDataManager, Owner._token);
                    Owner._mainManager.isInitialize = true;
                    Owner._stateMachine.Dispatch((int)Event.Main);
                }
            }

            private async UniTask OnClickDisplayName()
            {
                var displayName = Owner.loginView.DisplayNameView.InputField.text;
                var errorText = _loginView.DisplayNameView.ErrorText;
                var success = await _playFabUserDataManager.UpdateUserDisplayName(displayName, errorText);
                if (!success)
                {
                    return;
                }

                var createSuccess = await Owner._playFabLoginManager.CreateUserData();
                if (createSuccess)
                {
                    Owner._characterDataManager.Initialize(Owner._userDataManager, Owner._token);
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