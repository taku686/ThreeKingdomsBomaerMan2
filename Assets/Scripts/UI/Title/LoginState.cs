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

            private string GetEmail()
            {
                var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var resultString = "";
                // 処理はデバッグようなのである程度適当に。重複しなければ良い
                for (int i = 0; i < 8; i++)
                {
                    resultString += characters[Random.Range(0, characters.Length)];
                }

                // メールアドレスのフォーマットは必要なので、最後にドメインをつける
                resultString += "@gmail.com";
                return email = resultString;
            }

            public async void OnClickSetEmail()
            {
                await SetEmailAndPasswordAsync().AttachExternalCancellation(Owner._token);
            }

            public async void OnClickLogin()
            {
                await LoginEmailAndPasswordAsync().AttachExternalCancellation(Owner._token);
            }

            private async UniTask SetEmailAndPasswordAsync()
            {
                Debug.Log(email);
                Debug.Log(password);
                var customID = PlayerPrefsManager.UserID;
                var request = new AddUsernamePasswordRequest
                {
                    Username = customID,
                    Email = email,
                    Password = password
                };

                var response = await PlayFabClientAPI.AddUsernamePasswordAsync(request);
                if (response.Error != null)
                {
                    switch (response.Error.Error)
                    {
                        case PlayFabErrorCode.InvalidParams:
                            Debug.Log("有効なメールアドレスと6~100文字以内のパスワードを入力してください。");
                            break;
                        case PlayFabErrorCode.EmailAddressNotAvailable:
                            Debug.Log("このメールアドレスは使用できません");
                            break;
                        case PlayFabErrorCode.InvalidPassword:
                            Debug.Log("このパスワードは無効です。");
                            break;
                        default:
                            Debug.Log(response.Error.GenerateErrorReport());
                            break;
                    }
                }
            }

            private async UniTask LoginEmailAndPasswordAsync()
            {
                var request = new LoginWithEmailAddressRequest
                {
                    Email = email,
                    Password = password,
                    InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
                    {
                        GetUserAccountInfo = true,
                    }
                };

                var response = await PlayFabClientAPI.LoginWithEmailAddressAsync(request);
                if (response.Error != null)
                {
                    switch (response.Error.Error)
                    {
                        case PlayFabErrorCode.InvalidParams:
                        case PlayFabErrorCode.InvalidEmailOrPassword:
                        case PlayFabErrorCode.AccountNotFound:
                            Debug.Log("メールアドレスかパスワードが正しくありません。");
                            break;
                        default:
                            Debug.Log(response.Error.GenerateErrorReport());
                            break;
                    }
                }

                Debug.Log(response.Result);
                PlayerPrefs.DeleteAll();
                PlayerPrefsManager.UserID = response.Result.InfoResultPayload.AccountInfo.CustomIdInfo.CustomId;
                PlayerPrefsManager.IsLoginEmailAddress = true;
            }
        }
    }
}