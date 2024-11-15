using Bomb;
using Common.Data;
using Manager.BattleManager.Camera;
using Manager.BattleManager.Environment;
using Manager.DataManager;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using UnityEngine;
using Zenject;

namespace Manager.BattleManager
{
    public partial class BattleCore : MonoBehaviourPunCallbacks
    {
        //Repository
        [Inject] private UserDataRepository userDataRepository;
        [Inject] private SkillMasterDataRepository skillMasterDataRepository;
        [SerializeField] private AnimatorControllerRepository animatorControllerRepository;

        //UseCase
        [Inject] private PlayerGeneratorUseCase playerGeneratorUseCase;
        [Inject] private WeaponCreateInBattleUseCase weaponCreateInBattleUseCase;
        [Inject] private StatusInBattleViewModelUseCase statusInBattleViewModelUseCase;
        [Inject] private ApplyStatusSkillUseCase applyStatusSkillUseCase;

        //Manager
        [Inject] private PhotonNetworkManager photonNetworkManager;
        [Inject] private MissionManager missionManager;
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private StageManager stageManager;
        [SerializeField] private MapManager mapManager;

        //UI
        [SerializeField] private BattleStartView battleStartView;
        [SerializeField] private BattleResultView battleResultView;
        [SerializeField] private InBattleView inBattleView;

        //Other
        [Inject] private BombProvider bombProvider;
        [SerializeField] private Transform playerUIParent;
        [SerializeField] private GameObject playerUI;
        [SerializeField] private EffectActivateUseCase effectActivator;

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
            InitializeUi();
            InitializeState();
            InitializeComponent();
        }

        private void Update()
        {
            stateMachine.Update();
        }

        private void InitializeUi()
        {
            inBattleView.UpdateTime(GameCommonData.BattleTime);
            InitializeStateUi();
        }

        private void InitializeStateUi()
        {
            var viewModel = statusInBattleViewModelUseCase.InAsTask();
            inBattleView.ApplyStatusViewModel(viewModel);
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
                    var characterId = userDataRepository.GetEquippedCharacterId();
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
            battleStartView.gameObject.SetActive(true);
            battleResultView.gameObject.SetActive(false);
        }
    }
}