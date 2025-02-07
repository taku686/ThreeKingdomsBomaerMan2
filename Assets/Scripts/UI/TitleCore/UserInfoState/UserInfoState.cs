using System.Threading;
using Cysharp.Threading.Tasks;
using UI.TitleCore.UserInfoState;
using UniRx;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class UserInfoState : StateMachine<TitleCore>.State
        {
            private UserInfoView _View => (UserInfoView)Owner.GetView(State.UserInfo);
            private UserInfoViewModelUseCase _UserInfoViewModelUseCase => Owner._userInfoViewModelUseCase;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private CancellationTokenSource _cancellationTokenSource;

            protected override async void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
                Subscribe();
                await Owner.SwitchUiObject(State.UserInfo, false);
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            private void Initialize()
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _View.ApplyViewModel(_UserInfoViewModelUseCase.InAsTask());
            }

            private void Subscribe()
            {
                _View.OnClickCloseButtonAsObservable()
                    .Take(1)
                    .SelectMany(button => Owner.OnClickScaleColorAnimation(button).ToObservable())
                    .Subscribe(_ => _StateMachine.Dispatch((int)State.Main))
                    .AddTo(_cancellationTokenSource.Token);
            }

            private void Cancel()
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }
    }
}