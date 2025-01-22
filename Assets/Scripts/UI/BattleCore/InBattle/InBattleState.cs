using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Player.Common;
using UI.Battle;
using UniRx;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class InBattleState : StateMachine<BattleCore>.State
        {
            private InBattleView _View => Owner.inBattleView;
            private PlayerCore _PlayerCore => Owner._playerCore;
            private StateMachine<BattleCore> _StateMachine => Owner._stateMachine;
            private List<PlayerStatusUI> _PlayerStatusUiList => Owner._playerStatusUiList;
            private CancellationTokenSource _cts;
            private int _startTime;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                Initialize();
                OnSubscribe();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                DestroyPlayerListUi();
                Cancel();
            }


            private void Initialize()
            {
                _cts = new CancellationTokenSource();
                _startTime = PhotonNetwork.ServerTimestamp;
            }

            private void OnSubscribe()
            {
                _PlayerCore._DeadObservable
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Result); })
                    .AddTo(_cts.Token);

                _PlayerCore._StatusBuffUiObservable
                    .Subscribe(tuple => { _View.ApplyBuffState(tuple.statusType, tuple.speed, tuple.isBuff, tuple.isDebuff); })
                    .AddTo(_cts.Token);

                Observable.EveryUpdate()
                    .Subscribe(_ =>
                    {
                        var time = GameCommonData.BattleTime - unchecked(PhotonNetwork.ServerTimestamp - _startTime) / 1000;
                        if (time <= 0)
                        {
                            _StateMachine.Dispatch((int)State.Result);
                        }

                        _View.UpdateTime(time);
                    })
                    .AddTo(_cts.Token);
            }

            private void DestroyPlayerListUi()
            {
                foreach (var playerStatusUI in _PlayerStatusUiList)
                {
                    Destroy(playerStatusUI.gameObject);
                }

                _PlayerStatusUiList.Clear();
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