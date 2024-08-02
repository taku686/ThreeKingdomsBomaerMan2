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
            private CancellationTokenSource cts;
            private PlayFabUserDataManager playFabUserDataManager;
            private LoginView loginView;
            private CommonView commonView;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnLateExit(StateMachine<TitleCore>.State nextState)
            {
                Owner.Cancel(cts);
            }

            private void Initialize()
            {
                cts = new CancellationTokenSource();
                playFabUserDataManager = Owner.playFabUserDataManager;
                loginView = Owner.loginView;
                commonView = Owner.commonView;

                InitializeButton();
                InitializeObject();
                InitializeTitleImage();
                Owner.SwitchUiObject(State.Login, false).Forget();
            }

            private void InitializeTitleImage()
            {
                var sprites = loginView.TitleSprites;
                var backgroundImage = loginView.BackgroundImage;
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
                loginView.RetryButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(loginView.RetryButton).ToObservable())
                    .SelectMany(_ => OnClickRetry().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);
                
                loginView.LoginButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(loginView.LoginButton).ToObservable())
                    .SelectMany(_ => OnClickLogin().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);
                
                loginView.DisplayNameView.OkButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(loginView.DisplayNameView.OkButton).ToObservable())
                    .SelectMany(_ => OnClickDisplayName().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);
            }

            private async UniTask OnClickLogin()
            {
                loginView.LoginButton.interactable = false;
                await Login().AttachExternalCancellation(cts.Token);
            }

            private async UniTask OnClickRetry()
            {
                loginView.RetryButton.interactable = false;
                Owner.loginView.ErrorGameObject.SetActive(false);
                await Login().AttachExternalCancellation(cts.Token);
            }

            private async UniTask Login()
            {
                commonView.waitPopup.SetActive(true);
                Owner.playFabLoginManager.Initialize(Owner.loginView.DisplayNameView, Owner.loginView.ErrorGameObject);
                var result = await Owner.playFabLoginManager.Login()
                    .AttachExternalCancellation(cts.Token);

                if (!result)
                {
                    commonView.waitPopup.SetActive(false);
                    loginView.RetryButton.interactable = true;
                    loginView.LoginButton.interactable = true;
                    return;
                }

                Owner.characterDataManager.Initialize(Owner.userDataManager, Owner.token);
                Owner.mainManager.isInitialize = true;
                Owner.stateMachine.Dispatch((int)State.Main);
                commonView.waitPopup.SetActive(false);
                loginView.RetryButton.interactable = true;
            }

            private async UniTask OnClickDisplayName()
            {
                loginView.DisplayNameView.OkButton.interactable = false;
                commonView.waitPopup.SetActive(true);
                var displayName = Owner.loginView.DisplayNameView.InputField.text;
                var errorText = loginView.DisplayNameView.ErrorText;
                var success = await playFabUserDataManager.UpdateUserDisplayName(displayName, errorText);
                if (!success)
                {
                    commonView.waitPopup.SetActive(false);
                    loginView.DisplayNameView.OkButton.interactable = true;
                    return;
                }

                var createSuccess = await Owner.playFabLoginManager.CreateUserData();
                if (createSuccess)
                {
                    Owner.characterDataManager.Initialize(Owner.userDataManager, Owner.token);
                    Owner.loginView.DisplayNameView.gameObject.SetActive(false);
                    Owner.mainManager.isInitialize = true;
                    Owner.stateMachine.Dispatch((int)State.Main);
                    commonView.waitPopup.SetActive(false);
                }
            }
        }
    }
}