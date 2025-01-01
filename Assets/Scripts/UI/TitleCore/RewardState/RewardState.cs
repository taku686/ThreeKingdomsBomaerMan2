using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using PUROPORO;
using Repository;
using UniRx;
using UnityEngine;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class RewardState : StateMachine<TitleCore>.State
        {
            private RewardView _View => (RewardView)Owner.GetView(State.Reward);
            private CommonView _CommonView => Owner._commonView;
            private RewardDataRepository _RewardDataRepository => Owner._rewardDataRepository;
            private RewardDataUseCase _RewardDataUseCase => Owner._rewardDataUseCase;
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
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
                var rewardIds = _RewardDataRepository.GetRewardIds().ToArray();
                var rewardDatum = _RewardDataUseCase.InAsTask(rewardIds).ToArray();
                Subscribe();
                Owner.SwitchUiObject(State.Reward, false, () => { _View._LootBoxSystem.Initialize(rewardDatum); }).Forget();
            }

            private void Subscribe()
            {
                _View._LootBoxSystem._OnClickAsObservable
                    .Where(state => state == LootBoxState.Ending)
                    .Subscribe(_ =>
                    {
                        var prevState = _StateMachine.PreviousState;
                        if (prevState < 0)
                        {
                            Debug.LogError("Invalid previous state");
                        }

                        _StateMachine.Dispatch(prevState);
                    })
                    .AddTo(_cts.Token);
            }

            private void Cancel()
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}