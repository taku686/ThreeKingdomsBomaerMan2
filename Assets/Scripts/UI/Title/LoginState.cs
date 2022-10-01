using System;
using Common;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using  State = StateMachine<UI.Title.TitlePresenter>.State;

namespace UI.Title
{
    public partial class TitlePresenter
    {
        public class LoginState : State
        {
 [SerializeField] private TMP_InputField emailInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        private string customId;
        private string email;
        private string password = "password";

        protected override void OnEnter(State prevState)
        {
            OnInitialize();
        }

        private void OnInitialize()
        {
            Owner.DisableTitleGameObject();
            Owner.mainView.LoginGameObject.SetActive(true);
        }

        private async void Start()
        {
            email = GetEmail();
            PlayFabSettings.staticSettings.TitleId = "92AF5";
            customId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            var request = new LoginWithCustomIDRequest
            {
                CustomId = customId,
                CreateAccount = true
            };
            var result = await PlayFabClientAPI.LoginWithCustomIDAsync(request);

            var message = result.Error is null
                ? $"Login Success!! My PlayerID is {result.Result.PlayFabId}"
                : result.Error.GenerateErrorReport();

            Debug.Log(message);
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
            var request = new AddUsernamePasswordRequest
            {
                Username = customId,
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