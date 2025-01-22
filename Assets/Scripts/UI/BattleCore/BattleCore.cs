using System.Collections.Generic;
using Bomb;
using Common.Data;
using Manager.BattleManager.Camera;
using Manager.BattleManager.Environment;
using Manager.DataManager;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using UI.Battle;
using UnityEngine;
using Zenject;

namespace Manager.BattleManager
{
    public partial class BattleCore : MonoBehaviourPunCallbacks
    {
        //Repository
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private SkillMasterDataRepository _skillMasterDataRepository;
        [SerializeField] private AnimatorControllerRepository animatorControllerRepository;

        //UseCase
        [Inject] private PlayerGeneratorUseCase _playerGeneratorUseCase;
        [Inject] private WeaponCreateInBattleUseCase _weaponCreateInBattleUseCase;
        [Inject] private StatusInBattleViewModelUseCase _statusInBattleViewModelUseCase;
        [Inject] private ApplyStatusSkillUseCase _applyStatusSkillUseCase;

        //Manager
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MissionManager _missionManager;
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private StageManager stageManager;
        [SerializeField] private MapManager mapManager;

        //UI
        [SerializeField] private BattleStartView battleStartView;
        [SerializeField] private BattleResultView battleResultView;
        [SerializeField] private InBattleView inBattleView;

        //Other
        [Inject] private BombProvider _bombProvider;
        [SerializeField] private Transform playerUIParent;
        [SerializeField] private GameObject playerUI;
        [SerializeField] private EffectActivateUseCase effectActivator;

        private StateMachine<BattleCore> _stateMachine;
        private PlayerCore _playerCore;
        private List<PlayerStatusUI> _playerStatusUiList = new();

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
            _stateMachine.Update();
        }

        private void InitializeUi()
        {
            inBattleView.UpdateTime(GameCommonData.BattleTime);
            InitializeStateUi();
        }

        private void InitializeStateUi()
        {
            var viewModel = _statusInBattleViewModelUseCase.InAsTask();
            inBattleView.ApplyStatusViewModel(viewModel);
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<BattleCore>(this);
            _stateMachine.Start<CreateStageState>();
            _stateMachine.AddTransition<CreateStageState, PlayerCreateState>((int)State.PlayerCreate);
            _stateMachine.AddTransition<PlayerCreateState, BattleStartState>((int)State.BattleStart);
            _stateMachine.AddTransition<BattleStartState, InBattleState>((int)State.InBattle);
            _stateMachine.AddTransition<InBattleState, BattleResultState>((int)State.Result);
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
                    _missionManager.CheckMission(GameCommonData.LevelUpActionId);
                    break;
                case GameCommonData.BattleCountActionId:
                    _missionManager.CheckMission(GameCommonData.BattleCountActionId);
                    break;
                case GameCommonData.CharacterBattleActionId:
                    var characterId = _userDataRepository.GetEquippedCharacterId();
                    _missionManager.CheckMission(GameCommonData.CharacterBattleActionId, characterId);
                    break;
            }
        }

        private void SetPlayerCore(PlayerCore player)
        {
            _playerCore = player;
        }

        private void DisableUi()
        {
            battleStartView.gameObject.SetActive(true);
            battleResultView.gameObject.SetActive(false);
        }
    }
}