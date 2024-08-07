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
        public class SettingState : StateMachine<TitleCore>.State
        {
            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Owner.commonView.virtualCurrencyView.gameObject.SetActive(true);
            }

            private void Initialize()
            {
                InitializeButton();
                InitializeObject();
                Owner.SwitchUiObject(State.Setting, false);
            }

            private void InitializeButton()
            {
                Owner.setting.BackToSignUpButton.onClick.RemoveAllListeners();
                Owner.setting.SettingCloseButton.onClick.RemoveAllListeners();
                Owner.setting.SignUpCloseButton.onClick.RemoveAllListeners();
                Owner.setting.SignInCloseButton.onClick.RemoveAllListeners();
                Owner.setting.AccountRegisterButton.onClick.RemoveAllListeners();
                Owner.setting.AlreadySignInButton.onClick.RemoveAllListeners();
                Owner.setting.SignInButton.onClick.RemoveAllListeners();
                Owner.setting.SignUpButton.onClick.RemoveAllListeners();
                Owner.setting.BackToSignUpButton.onClick.AddListener(OnClickBackToSignUpButton);
                Owner.setting.SettingCloseButton.onClick.AddListener(OnClickCloseSetting);
                Owner.setting.SignUpCloseButton.onClick.AddListener(OnClickCloseSignUp);
                Owner.setting.SignInCloseButton.onClick.AddListener(OnClickCloseSignIn);
                Owner.setting.AccountRegisterButton.onClick.AddListener(OnClickAccountButton);
                Owner.setting.AlreadySignInButton.onClick.AddListener(OnClickAlreadySignInButton);
                Owner.setting.SignInButton.onClick.AddListener(OnClickLogin);
                Owner.setting.SignUpButton.onClick.AddListener(OnClickSetEmail);
            }

            private void InitializeObject()
            {
                Owner.setting.SignUpGameObject.SetActive(false);
                Owner.setting.SignInGameObject.SetActive(false);
            }

            private void OnClickCloseSetting()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.setting.SettingCloseButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Main); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickCloseSignUp()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.setting.SignUpCloseButton.gameObject)
                    .OnComplete(() => { Owner.setting.SignUpGameObject.SetActive(false); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickCloseSignIn()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.setting.SignInCloseButton.gameObject)
                    .OnComplete(() => { Owner.setting.SignInGameObject.SetActive(false); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBackToSignUpButton()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.setting.BackToSignUpButton.gameObject)
                    .OnComplete(() =>
                    {
                        Owner.setting.SignInGameObject.SetActive(false);
                        Owner.setting.SignUpGameObject.SetActive(true);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickAccountButton()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.setting.AccountRegisterButton.gameObject)
                    .OnComplete(() => { Owner.setting.SignUpGameObject.SetActive(true); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickAlreadySignInButton()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.setting.AlreadySignInButton.gameObject)
                    .OnComplete(() =>
                    {
                        Owner.setting.SignInGameObject.SetActive(true);
                        Owner.setting.SignUpGameObject.SetActive(false);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetEmail()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.setting.SignUpButton.gameObject)
                    .OnComplete(async () =>
                    {
                        await SetEmailAndPasswordAsync().AttachExternalCancellation(Owner.token);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickLogin()
            {
                Owner.uiAnimation.ClickScaleColor(Owner.setting.SignInButton.gameObject)
                    .OnComplete(async () =>
                    {
                        await LoginEmailAndPasswordAsync().AttachExternalCancellation(Owner.token);
                    })
                    .SetLink(Owner.gameObject);
            }

            private async UniTask SetEmailAndPasswordAsync()
            {
                var customID = PlayerPrefsManager.UserID;
                var request = new AddUsernamePasswordRequest
                {
                    Username = customID,
                    Email = Owner.setting.SignInUserNameInputField.text,
                    Password = Owner.setting.SignInPasswordInputField.text
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
                    Email = Owner.setting.SignUpEmailInputField.text,
                    Password = Owner.setting.SignUpPasswordInputField.text,
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