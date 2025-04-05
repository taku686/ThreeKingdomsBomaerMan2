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
            private PlayerMove _PlayerMove => Owner._playerMove;
            private ObservableStateMachineTrigger _ObservableStateMachineTrigger => Owner._observableStateMachineTrigger;
            private StateMachine<PlayerCore> _StateMachine => Owner._stateMachine;

            protected override void OnEnter(State prevState)
            {
                PlayBackAnimation(GameCommonData.DashHashKey, GameCommonData.DashKey);
            }

            protected override void OnUpdate()
            {
                _PlayerMove.Dodge();
            }

            private void PlayBackAnimation(int hashKey, string key)
            {
                _Animator.SetTrigger(hashKey);
                _ObservableStateMachineTrigger
                    .OnStateExitAsObservable()
                    .Where(info => info.StateInfo.IsName(key))
                    .Take(1)
                    .Subscribe(_ => { _StateMachine.Dispatch((int)PLayerState.Idle); })
                    .AddTo(Owner.GetCancellationTokenOnDestroy());
            }
        }
    }
}