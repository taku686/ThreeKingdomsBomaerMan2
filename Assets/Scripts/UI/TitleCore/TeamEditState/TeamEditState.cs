using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class TeamEditState : StateMachine<TitleCore>.State
        {
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private TeamEditViewModelUseCase _ViewModelUseCase => Owner._teamEditViewModelUseCase;
            private TeamEditView _View => (TeamEditView)Owner.GetView(State.TeamEdit);
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private CancellationTokenSource _cts;

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
                _cts = new CancellationTokenSource();
                Owner.SwitchUiObject(State.TeamEdit, true, () =>
                {
                    var viewModel = _ViewModelUseCase.InAsTask();
                    _View.ApplyViewModel(viewModel);
                    Subscribe();
                }).Forget();
            }

            private void Subscribe()
            {
                _View._BackButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._BackButton).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Main); })
                    .AddTo(_cts.Token);

                _View._DecideButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._DecideButton).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Main); })
                    .AddTo(_cts.Token);

                var teamGridViews = _View.GetTeamGridViews();
                foreach (var teamGridView in teamGridViews)
                {
                    teamGridView._ChangeButton
                        .Do(tuple => _UserDataRepository.SetCandidateTeamMemberIndex(tuple.Item1))
                        .SelectMany(tuple => Owner.OnClickScaleColorAnimation(tuple.Item2).ToObservable())
                        .Subscribe(_ => { _StateMachine.Dispatch((int)State.CharacterSelect, (int)State.TeamEdit); })
                        .AddTo(_cts.Token);

                    teamGridView._NoSelectButton
                        .Do(tuple => _UserDataRepository.SetCandidateTeamMemberIndex(tuple.Item1))
                        .SelectMany(tuple => Owner.OnClickScaleColorAnimation(tuple.Item2).ToObservable())
                        .Subscribe(_ => { _StateMachine.Dispatch((int)State.CharacterSelect, (int)State.TeamEdit); })
                        .AddTo(_cts.Token);
                }
            }


            private void Cancel()
            {
                _cts?.Cancel();
                _cts?.Dispose();
                _cts = null;
            }
        }
    }
}