using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Pathfinding.Examples.RTS;
using UniRx;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleCore>.State;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class BattleStartState : StateMachine<BattleCore>.State
        {
            private UserDataRepository _userDataRepository;
            private BattleStartView _BattleStartView => Owner.GetView(State.BattleStart) as BattleStartView;
            private CancellationTokenSource _cts;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                Initialize();
                OnSubscribe();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                Cancel();
                _BattleStartView.gameObject.SetActive(false);
            }

            private void Initialize()
            {
                _cts = new CancellationTokenSource();
                _userDataRepository = Owner._userDataRepository;
                _BattleStartView.gameObject.SetActive(true);
                _BattleStartView.Initialize();
                Owner.SwitchUiObject(State.BattleStart);
                CheckMission().Forget();
            }

            private async UniTask CheckMission()
            {
                Owner.CheckMission(GameCommonData.CharacterBattleActionId);
                Owner.CheckMission(GameCommonData.BattleCountActionId);
                var userData = _userDataRepository.GetUserData();
                await _userDataRepository.UpdateUserData(userData);
            }

            private void OnSubscribe()
            {
                _BattleStartView.Exit
                    .Subscribe(_ => { Owner._stateMachine.Dispatch((int)State.InBattle); })
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