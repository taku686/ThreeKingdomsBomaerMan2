using System;
using System.Linq;
using System.Threading;
using Common.Data;
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
                Owner.SetActiveGlobalVolume(true);
                Cancel();
            }

            private void Initialize()
            {
                _cts = new CancellationTokenSource();
                Owner.SwitchUiObject(State.Reward, false, () =>
                {
                    Subscribe();
                    var rewardIds = _RewardDataRepository.GetRewardIds().ToArray();
                    var rewardDatum = _RewardDataUseCase.InAsTask(rewardIds).ToArray();
                    _View._LootBoxSystem.Initialize(rewardDatum);
                    Owner.SetActiveGlobalVolume(false);
                }).Forget();
            }

            private void Subscribe()
            {
                _View._LootBoxSystem._OnClickAsObservable
                    .Where(state => state == LootBoxState.Ending)
                    .Subscribe(_ =>
                    {
                        var prevState = _StateMachine._PreviousState;
                        _StateMachine._PreviousState = GameCommonData.InvalidNumber;
                        if (prevState < 0)
                        {
                            Debug.LogError("Invalid previous state");
                            _StateMachine.Dispatch((int)State.Main);
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