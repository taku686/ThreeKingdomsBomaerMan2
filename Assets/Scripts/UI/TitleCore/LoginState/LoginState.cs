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
            private LoginView View => (LoginView)Owner.GetView(State.Login);
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
                commonView = Owner.commonView;

                InitializeButton();
                InitializeObject();
                InitializeTitleImage();
                Owner.SwitchUiObject(State.Login, false).Forget();
            }

            private void InitializeTitleImage()
            {
                var sprites = View.TitleSprites;
                var backgroundImage = View.BackgroundImage;
                var index = Random.Range(0, sprites.Count);
                var titleSprite = sprites[index];
                backgroundImage.sprite = titleSprite;
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
                    .AddTo(cts.Token);

                View.LoginButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(View.LoginButton).ToObservable())
                    .SelectMany(_ => OnClickLogin().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);

                View.DisplayNameView.OkButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(View.DisplayNameView.OkButton).ToObservable())
                    .SelectMany(_ => OnClickDisplayName().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);
            }

            private async UniTask OnClickLogin()
            {
                View.LoginButton.interactable = false;
                await Login().AttachExternalCancellation(cts.Token);
            }

            private async UniTask OnClickRetry()
            {
                View.RetryButton.interactable = false;
                View.ErrorGameObject.SetActive(false);
                await Login().AttachExternalCancellation(cts.Token);
            }

            private async UniTask Login()
            {
                commonView.waitPopup.SetActive(true);
                Owner.playFabLoginManager.Initialize(View.DisplayNameView, View.ErrorGameObject);
                var result = await Owner.playFabLoginManager.Login()
                    .AttachExternalCancellation(cts.Token);

                if (!result)
                {
                    commonView.waitPopup.SetActive(false);
                    View.RetryButton.interactable = true;
                    View.LoginButton.interactable = true;
                    return;
                }

                Owner.mainManager.isInitialize = true;
                Owner.stateMachine.Dispatch((int)State.Main);
                commonView.waitPopup.SetActive(false);
                View.RetryButton.interactable = true;
            }

            private async UniTask OnClickDisplayName()
            {
                View.DisplayNameView.OkButton.interactable = false;
                commonView.waitPopup.SetActive(true);
                var displayName = View.DisplayNameView.InputField.text;
                var errorText = View.DisplayNameView.ErrorText;
                var success = await playFabUserDataManager.UpdateUserDisplayName(displayName, errorText);
                if (!success)
                {
                    commonView.waitPopup.SetActive(false);
                    View.DisplayNameView.OkButton.interactable = true;
                    return;
                }

                var createSuccess = await Owner.playFabLoginManager.CreateUserData();
                if (createSuccess)
                {
                    View.DisplayNameView.gameObject.SetActive(false);
                    Owner.mainManager.isInitialize = true;
                    Owner.stateMachine.Dispatch((int)State.Main);
                    commonView.waitPopup.SetActive(false);
                }
            }
        }
    }
}