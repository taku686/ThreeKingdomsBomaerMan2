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
            private SettingView View => (SettingView)Owner.GetView(State.Setting);

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
                Owner.SwitchUiObject(State.Setting, false).Forget();
            }

            private void InitializeButton()
            {
                View.BackToSignUpButton.onClick.RemoveAllListeners();
                View.SettingCloseButton.onClick.RemoveAllListeners();
                View.SignUpCloseButton.onClick.RemoveAllListeners();
                View.SignInCloseButton.onClick.RemoveAllListeners();
                View.AccountRegisterButton.onClick.RemoveAllListeners();
                View.AlreadySignInButton.onClick.RemoveAllListeners();
                View.SignInButton.onClick.RemoveAllListeners();
                View.SignUpButton.onClick.RemoveAllListeners();
                View.BackToSignUpButton.onClick.AddListener(OnClickBackToSignUpButton);
                View.SettingCloseButton.onClick.AddListener(OnClickCloseSetting);
                View.SignUpCloseButton.onClick.AddListener(OnClickCloseSignUp);
                View.SignInCloseButton.onClick.AddListener(OnClickCloseSignIn);
                View.AccountRegisterButton.onClick.AddListener(OnClickAccountButton);
                View.AlreadySignInButton.onClick.AddListener(OnClickAlreadySignInButton);
                View.SignInButton.onClick.AddListener(OnClickLogin);
                View.SignUpButton.onClick.AddListener(OnClickSetEmail);
            }

            private void InitializeObject()
            {
                View.SignUpGameObject.SetActive(false);
                View.SignInGameObject.SetActive(false);
            }

            private void OnClickCloseSetting()
            {
                Owner.uiAnimation.ClickScaleColor(View.SettingCloseButton.gameObject)
                    .OnComplete(() => { Owner.stateMachine.Dispatch((int)State.Main); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickCloseSignUp()
            {
                Owner.uiAnimation.ClickScaleColor(View.SignUpCloseButton.gameObject)
                    .OnComplete(() => { View.SignUpGameObject.SetActive(false); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickCloseSignIn()
            {
                Owner.uiAnimation.ClickScaleColor(View.SignInCloseButton.gameObject)
                    .OnComplete(() => { View.SignInGameObject.SetActive(false); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBackToSignUpButton()
            {
                Owner.uiAnimation.ClickScaleColor(View.BackToSignUpButton.gameObject)
                    .OnComplete(() =>
                    {
                        View.SignInGameObject.SetActive(false);
                        View.SignUpGameObject.SetActive(true);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickAccountButton()
            {
                Owner.uiAnimation.ClickScaleColor(View.AccountRegisterButton.gameObject)
                    .OnComplete(() => { View.SignUpGameObject.SetActive(true); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickAlreadySignInButton()
            {
                Owner.uiAnimation.ClickScaleColor(View.AlreadySignInButton.gameObject)
                    .OnComplete(() =>
                    {
                        View.SignInGameObject.SetActive(true);
                        View.SignUpGameObject.SetActive(false);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickSetEmail()
            {
                Owner.uiAnimation.ClickScaleColor(View.SignUpButton.gameObject)
                    .OnComplete(async () =>
                    {
                        await SetEmailAndPasswordAsync().AttachExternalCancellation(Owner.token);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickLogin()
            {
                Owner.uiAnimation.ClickScaleColor(View.SignInButton.gameObject)
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
                    Email = View.SignInUserNameInputField.text,
                    Password = View.SignInPasswordInputField.text
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
                    Email = View.SignUpEmailInputField.text,
                    Password = View.SignUpPasswordInputField.text,
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