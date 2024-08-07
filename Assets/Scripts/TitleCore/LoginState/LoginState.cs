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
            private Login login;
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
                login = Owner.login;
                commonView = Owner.commonView;

                InitializeButton();
                InitializeObject();
                InitializeTitleImage();
                Owner.SwitchUiObject(State.Login, false).Forget();
            }

            private void InitializeTitleImage()
            {
                var sprites = login.TitleSprites;
                var backgroundImage = login.BackgroundImage;
                var index = Random.Range(0, sprites.Count);
                var titleSprite = sprites[index];
                backgroundImage.sprite = titleSprite;
            }

            private void InitializeObject()
            {
                Owner.login.ErrorGameObject.SetActive(false);
                Owner.login.DisplayNameView.gameObject.SetActive(false);
            }

            private void InitializeButton()
            {
                login.RetryButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(login.RetryButton).ToObservable())
                    .SelectMany(_ => OnClickRetry().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);

                login.LoginButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(login.LoginButton).ToObservable())
                    .SelectMany(_ => OnClickLogin().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);

                login.DisplayNameView.OkButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(login.DisplayNameView.OkButton).ToObservable())
                    .SelectMany(_ => OnClickDisplayName().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);
            }

            private async UniTask OnClickLogin()
            {
                login.LoginButton.interactable = false;
                await Login().AttachExternalCancellation(cts.Token);
            }

            private async UniTask OnClickRetry()
            {
                login.RetryButton.interactable = false;
                Owner.login.ErrorGameObject.SetActive(false);
                await Login().AttachExternalCancellation(cts.Token);
            }

            private async UniTask Login()
            {
                commonView.waitPopup.SetActive(true);
                Owner.playFabLoginManager.Initialize(Owner.login.DisplayNameView, Owner.login.ErrorGameObject);
                var result = await Owner.playFabLoginManager.Login()
                    .AttachExternalCancellation(cts.Token);

                if (!result)
                {
                    commonView.waitPopup.SetActive(false);
                    login.RetryButton.interactable = true;
                    login.LoginButton.interactable = true;
                    return;
                }

                Owner.characterDataManager.Initialize(Owner.userDataManager);
                Owner.mainManager.isInitialize = true;
                Owner.stateMachine.Dispatch((int)State.Main);
                commonView.waitPopup.SetActive(false);
                login.RetryButton.interactable = true;
            }

            private async UniTask OnClickDisplayName()
            {
                login.DisplayNameView.OkButton.interactable = false;
                commonView.waitPopup.SetActive(true);
                var displayName = Owner.login.DisplayNameView.InputField.text;
                var errorText = login.DisplayNameView.ErrorText;
                var success = await playFabUserDataManager.UpdateUserDisplayName(displayName, errorText);
                if (!success)
                {
                    commonView.waitPopup.SetActive(false);
                    login.DisplayNameView.OkButton.interactable = true;
                    return;
                }

                var createSuccess = await Owner.playFabLoginManager.CreateUserData();
                if (createSuccess)
                {
                    Owner.characterDataManager.Initialize(Owner.userDataManager);
                    Owner.login.DisplayNameView.gameObject.SetActive(false);
                    Owner.mainManager.isInitialize = true;
                    Owner.stateMachine.Dispatch((int)State.Main);
                    commonView.waitPopup.SetActive(false);
                }
            }
        }
    }
}