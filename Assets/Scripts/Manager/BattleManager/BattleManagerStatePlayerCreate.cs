using Cysharp.Threading.Tasks;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleManager>.State;

namespace Manager.BattleManager
{
    public partial class BattleManager
    {
        public class BattleManagerStatePlayerCreate : State
        {
            protected override void OnEnter(State prevState)
            {
                CreatePlayer();
            }

            protected override void OnExit(State nextState)
            {
            }

            protected override void OnUpdate()
            {
            }

            private void CreatePlayer()
            {
                Owner._networkManager.OnStartConnectNetwork();
            }
        }
    }
}