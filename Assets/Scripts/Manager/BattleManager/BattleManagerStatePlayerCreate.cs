using Cysharp.Threading.Tasks;
using UnityEngine;
using State = StateMachine<Manager.BattleManager.BattleManager>.State;

namespace Manager.BattleManager
{
    public partial class BattleManager
    {
        public class PlayerCreateState : State
        {
            protected override void OnEnter(State prevState)
            {
                CreatePlayer();
            }

            private void CreatePlayer()
            {
               // Owner._networkManager.OnStartConnectNetwork();
            }
        }
    }
}