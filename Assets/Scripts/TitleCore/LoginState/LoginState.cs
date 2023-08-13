using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager.NetworkManager;
using UI.Common;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class LoginState : State
        {
            private CancellationTokenSource _cts;
            private PlayFabUserDataManager _playFabUserDataManager;
            private LoginView _loginView;
            private CommonView _commonView;
            private UIAnimation _uiAnimation;
            private bool _isLoginProcessing;

            protected override void OnEnter(State prevState)
            {
                Initialize();
            }

            protected override void OnLateExit(State nextState)
            {
                Owner.Cancel(_cts);
            }

            private void Initialize()
            {
                _cts = new CancellationTokenSource();
                _playFabUserDataManager = Owner._playFabUserDataManager;
                _loginView = Owner.loginView;
                _uiAnimation = Owner._uiAnimation;
                _commonView = Owner.commonView;

                InitializeButton();
                InitializeObject();
                InitializeTitleImage();
                Owner.SwitchUiObject(TitleCoreEvent.Login, false);
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
                Owner.SetupButtonAsync(_loginView.RetryButton, OnClickRetry, _cts.Token);
                Owner.SetupButtonAsync(_loginView.LoginButton, OnClickLogin, _cts.Token);
                Owner.SetupButtonAsync(_loginView.DisplayNameView.OkButton, OnClickDisplayName, _cts.Token);
            }

            private async UniTask Login()
            {
                _isLoginProcessing = true;
                _commonView.waitPopup.SetActive(true);
                Owner._playFabLoginManager.Initialize(Owner.loginView.DisplayNameView, Owner.loginView.ErrorGameObject);
                var result = await Owner._playFabLoginManager.Login()
                    .AttachExternalCancellation(_cts.Token);

                if (!result)
                {
                    _commonView.waitPopup.SetActive(false);
                    _isLoginProcessing = false;
                    return;
                }

                Owner._characterDataManager.Initialize(Owner._userDataManager, Owner._token);
                Owner._mainManager.isInitialize = true;
                Owner._stateMachine.Dispatch((int)TitleCoreEvent.Main);
                _commonView.waitPopup.SetActive(false);
                _isLoginProcessing = false;
            }

            private async UniTask OnClickLogin()
            {
                if (_isLoginProcessing)
                {
                    return;
                }

                await Login();
            }

            private async UniTask OnClickDisplayName()
            {
                if (_isLoginProcessing)
                {
                    return;
                }

                _isLoginProcessing = true;
                _commonView.waitPopup.SetActive(true);
                var displayName = Owner.loginView.DisplayNameView.InputField.text;
                var errorText = _loginView.DisplayNameView.ErrorText;
                var success = await _playFabUserDataManager.UpdateUserDisplayName(displayName, errorText);
                if (!success)
                {
                    _commonView.waitPopup.SetActive(false);
                    _isLoginProcessing = false;
                    return;
                }

                var createSuccess = await Owner._playFabLoginManager.CreateUserData();
                if (createSuccess)
                {
                    Owner._characterDataManager.Initialize(Owner._userDataManager, Owner._token);
                    Owner.loginView.DisplayNameView.gameObject.SetActive(false);
                    Owner._mainManager.isInitialize = true;
                    Owner._stateMachine.Dispatch((int)TitleCoreEvent.Main);
                    _commonView.waitPopup.SetActive(false);
                    _isLoginProcessing = false;
                }
            }

            private async UniTask OnClickRetry()
            {
                Owner.loginView.ErrorGameObject.SetActive(false);
                await Login().AttachExternalCancellation(_cts.Token);
            }
        }
    }
}