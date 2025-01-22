using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleCore>.State;

namespace Manager.BattleManager
{
    public partial class BattleCore
    {
        public class BattleStartState : StateMachine<BattleCore>.State
        {
            private UserDataRepository userDataRepository;
            private BattleStartView battleStartView;
            private CancellationTokenSource cts;

            protected override void OnEnter(StateMachine<BattleCore>.State prevState)
            {
                Initialize();
                OnSubscribe();
            }

            protected override void OnExit(StateMachine<BattleCore>.State nextState)
            {
                Cancel();
                battleStartView.gameObject.SetActive(false);
            }

            private void Initialize()
            {
                cts = new CancellationTokenSource();
                userDataRepository = Owner._userDataRepository;
                battleStartView = Owner.battleStartView;
                battleStartView.gameObject.SetActive(true);
                battleStartView.Initialize();
                CheckMission().Forget();
            }

            private async UniTask CheckMission()
            {
                Owner.CheckMission(GameCommonData.CharacterBattleActionId);
                Owner.CheckMission(GameCommonData.BattleCountActionId);
                var userData = userDataRepository.GetUserData();
                await userDataRepository.UpdateUserData(userData);
            }

            private void OnSubscribe()
            {
                battleStartView.Exit
                    .Subscribe(_ => { Owner._stateMachine.Dispatch((int)State.InBattle); })
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