using System;
using System.Threading;
using Common;
using Common.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class LoginState : State
        {
            private string email;
            private string password = "password";
            private CancellationToken token;

            protected override void OnEnter(State prevState)
            {
                OnInitialize();
            }

            private void OnInitialize()
            {
                token = Owner.GetCancellationTokenOnDestroy();
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
                    await Login().AttachExternalCancellation(token));
            }

            private async UniTask Login()
            {
                PlayFabSettings.staticSettings.TitleId = GameSettingData.TitleID;
                var customID = PlayerPrefsManager.UserID;
                var request = new LoginWithCustomIDRequest
                {
                    CustomId = customID,
                    CreateAccount = true
                };
                var result = await PlayFabClientAPI.LoginWithCustomIDAsync(request).AsUniTask()
                    .AttachExternalCancellation(token);
                var message = result.Error is null
                    ? $"Login Success!! My PlayerID is {result.Result.PlayFabId}"
                    : result.Error.GenerateErrorReport();
                var isSuccess = result.Error is null;
                Debug.Log(message);
                if (isSuccess)
                {
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
                await Login().AttachExternalCancellation(token);
            }
        }
    }
}