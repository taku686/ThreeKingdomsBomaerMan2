using System.Threading;
using Common;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using PlayFab;
using PlayFab.ClientModels;
using UniRx;
using UnityEngine;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class SettingState : StateMachine<TitleCore>.State
        {
            private SettingView View => (SettingView)Owner.GetView(State.Setting);
            private CancellationTokenSource cts;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            private void Initialize()
            {
                cts = new CancellationTokenSource();
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
                
                View.BackToSignUpButton.onClick.AddListener(OnClickBackToSignUpButton);
                View.SettingCloseButton.onClick.AddListener(OnClickCloseSetting);
                View.SignUpCloseButton.onClick.AddListener(OnClickCloseSignUp);
                View.SignInCloseButton.onClick.AddListener(OnClickCloseSignIn);
                View.AccountRegisterButton.onClick.AddListener(OnClickAccountButton);
                View.AlreadySignInButton.onClick.AddListener(OnClickAlreadySignInButton);

                View.SignInButton.OnClickAsObservable()
                    .SelectMany(_ => OnClickLogin().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);

                View.SignUpButton.OnClickAsObservable()
                    .SelectMany(_ => OnClickSetEmail().ToObservable())
                    .Subscribe()
                    .AddTo(cts.Token);
            }

            private void InitializeObject()
            {
                View.SignUpGameObject.SetActive(false);
                View.SignInGameObject.SetActive(false);
            }

            private void OnClickCloseSetting()
            {
                Owner._uiAnimation.ClickScaleColor(View.SettingCloseButton.gameObject)
                    .OnComplete(() => { Owner._stateMachine.Dispatch((int)State.Main); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickCloseSignUp()
            {
                Owner._uiAnimation.ClickScaleColor(View.SignUpCloseButton.gameObject)
                    .OnComplete(() => { View.SignUpGameObject.SetActive(false); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickCloseSignIn()
            {
                Owner._uiAnimation.ClickScaleColor(View.SignInCloseButton.gameObject)
                    .OnComplete(() => { View.SignInGameObject.SetActive(false); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickBackToSignUpButton()
            {
                Owner._uiAnimation.ClickScaleColor(View.BackToSignUpButton.gameObject)
                    .OnComplete(() =>
                    {
                        View.SignInGameObject.SetActive(false);
                        View.SignUpGameObject.SetActive(true);
                    })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickAccountButton()
            {
                Owner._uiAnimation.ClickScaleColor(View.AccountRegisterButton.gameObject)
                    .OnComplete(() => { View.SignUpGameObject.SetActive(true); })
                    .SetLink(Owner.gameObject);
            }

            private void OnClickAlreadySignInButton()
            {
                Owner._uiAnimation.ClickScaleColor(View.AlreadySignInButton.gameObject)
                    .OnComplete(() =>
                    {
                        View.SignInGameObject.SetActive(true);
                        View.SignUpGameObject.SetActive(false);
                    })
                    .SetLink(Owner.gameObject);
            }

            private async UniTask OnClickSetEmail()
            {
                await SetEmailAndPasswordAsync();
            }

            private async UniTask OnClickLogin()
            {
                await LoginEmailAndPasswordAsync().AttachExternalCancellation(cts.Token);
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

            private void Cancel()
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
    }
}