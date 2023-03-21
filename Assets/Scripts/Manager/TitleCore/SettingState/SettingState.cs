using Common;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using State = StateMachine<UI.Title.TitleCore>.State;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class SettingState : State
        {
            protected override void OnEnter(State prevState)
            {
                OnInitialize();
            }

            private void OnInitialize()
            {
                InitializeButton();
                InitializeObject();
                Owner.DisableTitleGameObject();
                Owner.mainView.SettingGameObject.SetActive(true);
            }

            private void InitializeButton()
            {
                Owner.settingView.BackToSignUpButton.onClick.RemoveAllListeners();
                Owner.settingView.SettingCloseButton.onClick.RemoveAllListeners();
                Owner.settingView.SignUpCloseButton.onClick.RemoveAllListeners();
                Owner.settingView.SignInCloseButton.onClick.RemoveAllListeners();
                Owner.settingView.AccountRegisterButton.onClick.RemoveAllListeners();
                Owner.settingView.AlreadySignInButton.onClick.RemoveAllListeners();
                Owner.settingView.SignInButton.onClick.RemoveAllListeners();
                Owner.settingView.SignUpButton.onClick.RemoveAllListeners();
                Owner.settingView.BackToSignUpButton.onClick.AddListener(OnClickBackToSignUpButton);
                Owner.settingView.SettingCloseButton.onClick.AddListener(OnClickCloseSetting);
                Owner.settingView.SignUpCloseButton.onClick.AddListener(OnClickCloseSignUp);
                Owner.settingView.SignInCloseButton.onClick.AddListener(OnClickCloseSignIn);
                Owner.settingView.AccountRegisterButton.onClick.AddListener(OnClickAccountButton);
                Owner.settingView.AlreadySignInButton.onClick.AddListener(OnClickAlreadySignInButton);
                Owner.settingView.SignInButton.onClick.AddListener(OnClickLogin);
                Owner.settingView.SignUpButton.onClick.AddListener(OnClickSetEmail);
            }

            private void InitializeObject()
            {
                Owner.settingView.SignUpGameObject.SetActive(false);
                Owner.settingView.SignInGameObject.SetActive(false);
            }

            private void OnClickCloseSetting()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.settingView.SettingCloseButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)Event.Main); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickCloseSignUp()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.settingView.SignUpCloseButton.gameObject)
                    .OnComplete(() => { Owner.settingView.SignUpGameObject.SetActive(false); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickCloseSignIn()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.settingView.SignInCloseButton.gameObject)
                    .OnComplete(() => { Owner.settingView.SignInGameObject.SetActive(false); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBackToSignUpButton()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.settingView.BackToSignUpButton.gameObject)
                    .OnComplete(() =>
                    {
                        Owner.settingView.SignInGameObject.SetActive(false);
                        Owner.settingView.SignUpGameObject.SetActive(true);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickAccountButton()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.settingView.AccountRegisterButton.gameObject)
                    .OnComplete(() => { Owner.settingView.SignUpGameObject.SetActive(true); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickAlreadySignInButton()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.settingView.AlreadySignInButton.gameObject)
                    .OnComplete(() =>
                    {
                        Owner.settingView.SignInGameObject.SetActive(true);
                        Owner.settingView.SignUpGameObject.SetActive(false);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetEmail()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.settingView.SignUpButton.gameObject)
                    .OnComplete(async () =>
                    {
                        await SetEmailAndPasswordAsync().AttachExternalCancellation(Owner._token);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickLogin()
            {
                Owner._uiAnimation.ClickScaleColor(Owner.settingView.SignInButton.gameObject)
                    .OnComplete(async () =>
                    {
                        await LoginEmailAndPasswordAsync().AttachExternalCancellation(Owner._token);
                    })
                    .SetLink(Owner.gameObject);
            }

            private async UniTask SetEmailAndPasswordAsync()
            {
                var customID = PlayerPrefsManager.UserID;
                var request = new AddUsernamePasswordRequest
                {
                    Username = customID,
                    Email = Owner.settingView.SignInUserNameInputField.text,
                    Password = Owner.settingView.SignInPasswordInputField.text
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
                else
                {
                    PlayerPrefsManager.IsLoginEmailAddress = true;
                }
            }

            private async UniTask LoginEmailAndPasswordAsync()
            {
                var request = new LoginWithEmailAddressRequest
                {
                    Email = Owner.settingView.SignUpEmailInputField.text,
                    Password = Owner.settingView.SignUpPasswordInputField.text,
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

        //ToDo 後で消す
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
            return resultString;
        }
    }
}