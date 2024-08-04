using System.Threading;
using Cysharp.Threading.Tasks;
using Player.Common;
using UniRx;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleCore>.State;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class InBattleState : StateMachine<BattleCore>.State
        {
            //todo カウントダウンの時間の処理
            private PlayerCore playerCore;
            private CancellationTokenSource cts;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                Initialize();
                OnSubscribe();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                Cancel();
            }

            private void Initialize()
            {
                cts = new CancellationTokenSource();
                playerCore = Owner.playerCore;
            }

            private void OnSubscribe()
            {
                playerCore.DeadObservable
                    .Subscribe(_ => { Owner.stateMachine.Dispatch((int)State.Result); })
                    .AddTo(cts.Token);
            }

            private void Cancel()
            {
                if (cts == null)
                {
                    return;
                }

                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
    }
}