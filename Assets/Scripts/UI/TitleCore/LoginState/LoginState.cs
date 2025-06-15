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

            // private PlayFabLoginManager _PlayFabLoginManager => Owner._playFabLoginManager;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private LoginView _View => (LoginView)Owner.GetView(State.Login);
            private CommonView _commonView;

            /*protected override void OnEnter(StateMachine<TitleCore>.State prevState)
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
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._LoginButton).ToObservable())
                    .SelectMany(_ => Login().ToObservable())
                    .Subscribe()
                    .AddTo(_cancellationTokenSource.Token);
            }
            */

            /*private async UniTask Login()
            {
                _commonView.waitPopup.SetActive(true);
                _PlayFabLoginManager.Initialize();
                var result = await _PlayFabLoginManager.Login().AttachExternalCancellation(_cancellationTokenSource.Token);
                var loginResult = result.Item1;
                if (loginResult.Error != null)
                {
                    _commonView.waitPopup.SetActive(false);
                    Owner.SetActiveBlockPanel(false);
                    return;
                }

                if (!loginResult.Result.InfoResultPayload.UserData.ContainsKey(GameCommonData.UserKey))
                {
                    var checkDisplayName =
                        _PopupGenerateUseCase
                            .GenerateInputNamePopup("名前を入力してください", "")
                            .SelectMany(displayName => ValidationCheck(displayName).ToObservable())
                            .Publish();

                    checkDisplayName
                        .Where(tuple => !tuple.Item1)
                        .SelectMany(_ => _PopupGenerateUseCase.GenerateErrorPopup("適切な名前を入力してください", "OK"))
                        .Subscribe(_ =>
                        {
                            Owner.SetActiveBlockPanel(false);
                            _commonView.waitPopup.SetActive(false);
                        })
                        .AddTo(_cancellationTokenSource.Token);

                    checkDisplayName
                        .Where(tuple => tuple.Item1)
                        .SelectMany(tuple => _PlayFabLoginManager.Login(tuple.Item2).ToObservable())
                        .SelectMany(tuple => _PlayFabLoginManager.CreateUserData(tuple).ToObservable())
                        .SelectMany(response => _PlayFabLoginManager.InitializeGameData(response).ToObservable())
                        .Subscribe(_ =>
                        {
                            Owner._mainManager._isInitialize = true;
                            Owner.SetActiveBlockPanel(false);
                            Owner._stateMachine.Dispatch((int)State.Main);
                            _commonView.waitPopup.SetActive(false);
                        })
                        .AddTo(_cancellationTokenSource.Token);

                    checkDisplayName.Connect().AddTo(_cancellationTokenSource.Token);
                }
                else
                {
                    await _PlayFabLoginManager.InitializeGameData(loginResult);
                    Owner._mainManager._isInitialize = true;
                    Owner.SetActiveBlockPanel(false);
                    Owner._stateMachine.Dispatch((int)State.Main);
                    _commonView.waitPopup.SetActive(false);
                }
            }

            private async UniTask<(bool, string)> ValidationCheck(string displayName)
            {
                _commonView.waitPopup.SetActive(true);
                var result = await _playFabUserDataManager.UpdateUserDisplayNameAsync(displayName);
                return result;
            }*/
        }
    }
}