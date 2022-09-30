using Manager.NetworkManager;
using UnityEngine;
using Zenject;

namespace Manager.BattleManager
{
    public partial class BattleManager : MonoBehaviour
    {
        [Inject] private PhotonNetworkManager _networkManager;
        private StateMachine<BattleManager> _stateMachine;

        private enum BattleState
        {
            EndSceneTransition,
            CreatePlayer,
            Staging,
            CountDown,
            BattleStart,
            InBattle,
            BattleEnd,
            Result,
            StartSceneTransition
        }

        // Start is called before the first frame update
        void Start()
        {
            InitializeState();
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<BattleManager>(this);
            _stateMachine.Start<BattleManagerStatePlayerCreate>();
        }
    }
}