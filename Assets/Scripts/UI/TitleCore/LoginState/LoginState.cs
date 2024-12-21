using System.Threading;
using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using UniRx;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class LoginState : StateMachine<TitleCore>.State
        {
            private CancellationTokenSource _cancellationTokenSource;
            private PlayFabUserDataManager _playFabUserDataManager;
            private PlayFabLoginManager _PlayFabLoginManager => Owner._playFabLoginManager;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private LoginView _View => (LoginView)Owner.GetView(State.Login);
            private CommonView _commonView;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnLateExit(StateMachine<TitleCore>.State nextState)
            {
                Owner.Cancel(_cancellationTokenSource);
            }

            private void Initialize()
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _playFabUserDataManager = Owner._playFabUserDataManager;
                _commonView = Owner._commonView;

                InitializeButton();
                Owner.SwitchUiObject(State.Login, false).Forget();
            }

            private void InitializeButton()
            {
                _View._LoginButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickButtonAnimation(_View._LoginButton).ToObservable())
                    .SelectMany(_ => OnClickLogin().ToObservable())
                    .Subscribe()
                    .AddTo(_cancellationTokenSource.Token);
            }

            private async UniTask OnClickLogin()
            {
                _View._LoginButton.interactable = false;
                await Login().AttachExternalCancellation(_cancellationTokenSource.Token);
            }

            private async UniTask Login()
            {
                _commonView.waitPopup.SetActive(true);
                _PlayFabLoginManager.Initialize();
                var loginResult = await _PlayFabLoginManager.Login().AttachExternalCancellation(_cancellationTokenSource.Token);

                if (loginResult.Error != null)
                {
                    _commonView.waitPopup.SetActive(false);
                    _View._LoginButton.interactable = true;
                    return;
                }

                if (!loginResult.Result.InfoResultPayload.UserData.ContainsKey(GameCommonData.UserKey))
                {
                    var checkDisplayName = _PopupGenerateUseCase
                        .GenerateInputNamePopup("名前を入力してください", "")
                        .SelectMany(displayName => ValidationCheck(displayName).ToObservable())
                        .Publish();

                    checkDisplayName
                        .Where(tuple => !tuple.Item1)
                        .SelectMany(_ => _PopupGenerateUseCase.GenerateErrorPopup("名前が不正です", "OK"))
                        .Subscribe(_ =>
                        {
                            _View._LoginButton.interactable = true;
                            _commonView.waitPopup.SetActive(false);
                        });

                    checkDisplayName
                        .Where(tuple => tuple.Item1)
                        .SelectMany(_ => _PlayFabLoginManager.Login().ToObservable())
                        .SelectMany(response => _PlayFabLoginManager.CreateUserData(response).ToObservable())
                        .SelectMany(response => _PlayFabLoginManager.InitializeGameData(response).ToObservable())
                        .Subscribe(_ =>
                        {
                            Owner._mainManager.isInitialize = true;
                            Owner._stateMachine.Dispatch((int)State.Main);
                            _commonView.waitPopup.SetActive(false);
                        });

                    checkDisplayName.Connect().AddTo(_cancellationTokenSource.Token);
                }
                else
                {
                    await _PlayFabLoginManager.InitializeGameData(loginResult);
                    Owner._mainManager.isInitialize = true;
                    Owner._stateMachine.Dispatch((int)State.Main);
                    _commonView.waitPopup.SetActive(false);
                }
            }

            private async UniTask<(bool, string)> ValidationCheck(string displayName)
            {
                _commonView.waitPopup.SetActive(true);
                var result = await _playFabUserDataManager.UpdateUserDisplayNameAsync(displayName);
                return result;
            }
        }
    }
}