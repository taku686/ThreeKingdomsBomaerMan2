using System;
using System.Threading;
using Common;
using Common.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class LoginState : State
        {
            private const string Email = "test9@gmail.com";
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
                Owner.loginView.StartButton.onClick.AddListener(async () =>
                    await Login().AttachExternalCancellation(_token));
            }

            private async UniTask Login()
            {
                bool result;
                Owner._playFabManager.Initialize();
                if (!PlayerPrefsManager.IsLoginEmailAddress)
                {
                    result = await Owner._playFabManager.LoginWithCustomId().AttachExternalCancellation(_token);
                }
                else
                {
                    result = await Owner._playFabManager.LoginWithEmail(Email, Password)
                        .AttachExternalCancellation(_token);
                }

                if (result)
                {
                    await Owner._characterDataModel.Initialize(Owner._userManager, Owner._token);
                    /*Owner._userManager.equipCharacterId
                        .Subscribe(index => { Owner.CreateCharacter(index); }).AddTo(Owner._token);*/
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