using System.Collections.Generic;
using System.Linq;
using Bomb;
using Common.Data;
using Manager.BattleManager.Camera;
using Manager.BattleManager.Environment;
using Manager.DataManager;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using Repository;
using Skill;
using UI.Battle;
using UI.BattleCore;
using UI.BattleCore.InBattle;
using UnityEngine;
using UseCase.Battle;
using Zenject;

namespace Manager.BattleManager
{
    public partial class BattleCore : MonoBehaviourPunCallbacks
    {
        //Repository
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private SkillMasterDataRepository _skillMasterDataRepository;
        [Inject] private BattleResultDataRepository _battleResultDataRepository;
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;
        [Inject] private AbnormalConditionSpriteRepository _abnormalConditionSpriteRepository;
        [Inject] private AnimatorControllerRepository _animatorControllerRepository;

        //UseCase
        [Inject] private PlayerGeneratorUseCase _playerGeneratorUseCase;
        [Inject] private StatusInBattleViewModelUseCase _statusInBattleViewModelUseCase;
        [Inject] private ApplyStatusSkillUseCase _applyStatusSkillUseCase;
        [Inject] private CharacterCreateUseCase _characterCreateUseCase;
        [Inject] private InputViewModelUseCase _inputViewModelUseCase;
        [Inject] private UnderAbnormalConditionsBySkillUseCase _underAbnormalConditionsBySkillUseCase;
        [Inject] private SetupAnimatorUseCase _setupAnimatorUseCase;
        [Inject] private SkillEffectActivateUseCase _skillEffectActivateUseCase;
        [Inject] private TranslateStatusInBattleUseCase.Factory _translateStatusInBattleUseCaseFactory;

        //Manager
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MissionManager _missionManager;
        [Inject] private ActiveSkillManager _activeSkillManager;
        [Inject] private PassiveSkillManager _passiveSkillManager;
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private StageManager stageManager;
        [SerializeField] private MapManager mapManager;

        //UI
        [SerializeField] private BattleViewBase[] _views;

        //Other
        [Inject] private BombProvider _bombProvider;
        [SerializeField] private Transform playerUIParent;
        [SerializeField] private GameObject playerUI;
        [SerializeField] private GameObject _arrowSkillIndicatorPrefab;
        [SerializeField] private GameObject _circleSkillIndicatorPrefab;
        [SerializeField] private StageCreate _stageCreate;
        [SerializeField] private PhysicMaterial _characterPhysicMaterial;
        private StateMachine<BattleCore> _stateMachine;
        private PlayerCore _playerCore;
        private readonly List<PlayerStatusUI> _playerStatusUiList = new();
        private Transform[] _startPositionArray;
        private PlayerConditionInfo _playerConditionInfo;
        private StartPointsRepository _startPointsRepository;
        private ArrowSkillIndicatorView _arrowSkillIndicatorView;
        private CircleSkillIndicatorView _circleSkillIndicatorView;

        public enum State
        {
            PlayerCreate,
            BattleStart,
            InBattle,
            Result,
        }

        // Start is called before the first frame update
        void Start()
        {
            _photonNetworkManager._isTitle = false;
            InitializeUI();
            InitializeState();
            InitializeComponent();
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void InitializeUI()
        {
            var battleStartView = GetView(State.BattleStart);
            foreach (Transform child in battleStartView.transform)
            {
                child.gameObject.SetActive(true);
            }

            var inBattleView = GetView(State.InBattle);
            inBattleView.gameObject.SetActive(false);
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

        private void SwitchUiObject(State state)
        {
            foreach (var view in _views)
            {
                view.gameObject.SetActive(view._State == state);
            }
        }

        private BattleViewBase GetView(State state)
        {
            return _views.FirstOrDefault(view => view._State == state);
        }

        private void SetPlayerCore(PlayerCore player)
        {
            _playerCore = player;
        }

        private void SetPlayerStatusInfo(PlayerConditionInfo playerConditionInfo)
        {
            _playerConditionInfo = playerConditionInfo;
        }

        private void SetArrowSkillIndicatorView(ArrowSkillIndicatorView arrowSkillIndicatorView)
        {
            _arrowSkillIndicatorView = arrowSkillIndicatorView;
        }

        private void SetCircleSkillIndicatorView(CircleSkillIndicatorView circleSkillIndicatorView)
        {
            _circleSkillIndicatorView = circleSkillIndicatorView;
        }

        private void SetStartPointsRepository(StartPointsRepository startPointsRepository)
        {
            _startPointsRepository = startPointsRepository;
        }
    }
}