using System.Collections.Generic;
using System.Linq;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.BattleManager.Camera;
using Manager.BattleManager.Environment;
using Manager.DataManager;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using Repository;
using UI.Battle;
using UI.BattleCore;
using UnityEngine;
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
        [SerializeField] private AnimatorControllerRepository animatorControllerRepository;

        //UseCase
        [Inject] private PlayerGeneratorUseCase _playerGeneratorUseCase;
        [Inject] private WeaponCreateInBattleUseCase _weaponCreateInBattleUseCase;
        [Inject] private StatusInBattleViewModelUseCase _statusInBattleViewModelUseCase;
        [Inject] private ApplyStatusSkillUseCase _applyStatusSkillUseCase;
        [Inject] private CharacterCreateUseCase _characterCreateUseCase;

        //Manager
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MissionManager _missionManager;
        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private StageManager stageManager;
        [SerializeField] private MapManager mapManager;

        //UI
        [SerializeField] private BattleViewBase[] _views;

        //Other
        [Inject] private BombProvider _bombProvider;
        [SerializeField] private Transform playerUIParent;
        [SerializeField] private GameObject playerUI;
        [SerializeField] private EffectActivateUseCase effectActivator;

        private StateMachine<BattleCore> _stateMachine;
        private PlayerCore _playerCore;
        private readonly List<PlayerStatusUI> _playerStatusUiList = new();

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
            var inBattleView = _views.FirstOrDefault(view => view._State == State.InBattle) as InBattleView;
            if (inBattleView == null)
            {
                Debug.LogError("InBattleView is null");
                return;
            }

            inBattleView.UpdateTime(GameCommonData.BattleTime);
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
    }
}