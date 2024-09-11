using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Player.Common;
using UniRx;
using State = StateMachine<Manager.BattleManager.BattleCore>.State;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class InBattleState : StateMachine<BattleCore>.State
        {
            private InBattleView View => Owner.inBattleView;
            private PlayerCore playerCore;
            private CancellationTokenSource cts;
            private int startTime;

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
                startTime = PhotonNetwork.ServerTimestamp;
            }

            private void OnSubscribe()
            {
                playerCore.DeadObservable
                    .Subscribe(_ => { Owner.stateMachine.Dispatch((int)State.Result); })
                    .AddTo(cts.Token);

                Observable.EveryUpdate()
                    .Subscribe(_ =>
                    {
                        var time =
                            GameCommonData.BattleTime - unchecked(PhotonNetwork.ServerTimestamp - startTime) / 1000;
                        View.UpdateTime(time);
                    })
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