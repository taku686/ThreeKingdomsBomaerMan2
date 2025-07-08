using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.PlayerLoop;
using State = StateMachine<Player.Common.PlayerCore>.State;

namespace Player.Common
{
    public partial class PlayerCore
    {
        public class PlayerStateDash : State
        {
            private Animator _Animator => Owner._animator;
            private PlayerDash _PlayerDash => Owner._playerDash;
            private ObservableStateMachineTrigger _ObservableStateMachineTrigger => Owner._observableStateMachineTrigger;
            private StateMachine<PlayerCore> _StateMachine => Owner._stateMachine;
            private CancellationTokenSource _cts;

            protected override void OnEnter(State prevState)
            {
                _cts = new CancellationTokenSource();
                _PlayerDash.Dash();
                PlayBackAnimation(GameCommonData.DashHashKey, GameCommonData.DashKey);
            }

            protected override void OnExit(State nextState)
            {
                Cancel();
            }

            private void PlayBackAnimation(int hashKey, string key)
            {
                _Animator.SetTrigger(hashKey);
                _ObservableStateMachineTrigger
                    .OnStateExitAsObservable()
                    .Where(info => info.StateInfo.IsName(key))
                    .Take(1)
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PlayerState.Idle); })
                    .AddTo(_cts.Token);
            }

            private void Cancel()
            {
                if (_cts == null)
                {
                    return;
                }

                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}