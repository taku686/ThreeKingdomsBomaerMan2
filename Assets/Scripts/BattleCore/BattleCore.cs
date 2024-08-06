using Bomb;
using Common.Data;
using Manager.BattleManager.Camera;
using Manager.BattleManager.Environment;
using Manager.NetworkManager;
using MoreMountains.Tools;
using Photon.Pun;
using Player.Common;
using UnityEngine;
using Zenject;

namespace Manager.BattleManager
{
    public partial class BattleCore : MonoBehaviourPunCallbacks
    {
        [Inject] private PhotonNetworkManager networkManager;
        [Inject] private PlayerGenerator playerGenerator;
        [Inject] private BombProvider bombProvider;
        [Inject] private UserDataManager userDataManager;
        [Inject] private MissionManager missionManager;
        [SerializeField] private Transform playerUIParent;
        [SerializeField] private GameObject playerUI;
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private StageManager stageManager;
        [SerializeField] private MapManager mapManager;
        [SerializeField] private BattleStartView battleStartView;
        [SerializeField] private BattleResultView battleResultView;
        private StateMachine<BattleCore> stateMachine;
        private PlayerCore playerCore;

        private enum State
        {
            PlayerCreate,
            BattleStart,
            InBattle,
            Result,
        }

        // Start is called before the first frame update
        void Start()
        {
            DisableUi();
            InitializeState();
            InitializeComponent();
        }

        private void Update()
        {
            stateMachine.Update();
        }

        private void InitializeState()
        {
            stateMachine = new StateMachine<BattleCore>(this);
            stateMachine.Start<CreateStageState>();
            stateMachine.AddTransition<CreateStageState, PlayerCreateState>((int)State.PlayerCreate);
            stateMachine.AddTransition<PlayerCreateState, BattleStartState>((int)State.BattleStart);
            stateMachine.AddTransition<BattleStartState, InBattleState>((int)State.InBattle);
            stateMachine.AddTransition<InBattleState, BattleResultState>((int)State.Result);
        }

        private void InitializeComponent()
        {
            gameObject.AddComponent<SynchronizedValue>();
        }

        private void CheckMission(int actionId)
        {
            switch (actionId)
            {
                case GameCommonData.LevelUpActionId:
                    missionManager.CheckMission(GameCommonData.LevelUpActionId);
                    break;
                case GameCommonData.BattleCountActionId:
                    missionManager.CheckMission(GameCommonData.BattleCountActionId);
                    break;
                case GameCommonData.CharacterBattleActionId:
                    var characterId = userDataManager.GetEquippedCharacterId();
                    missionManager.CheckMission(GameCommonData.CharacterBattleActionId, characterId);
                    break;
            }
        }

        private void SetPlayerCore(PlayerCore player)
        {
            playerCore = player;
        }

        private void DisableUi()
        {
            battleStartView.gameObject.SetActive(false);
            battleResultView.gameObject.SetActive(false);
        }
    }
}