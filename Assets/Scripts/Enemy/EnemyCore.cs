using Bomb;
using Manager.DataManager;
using Pathfinding;
using Photon.Pun;
using Photon.Realtime;
using Player.Common;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public partial class EnemyCore : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterMasterDataRepository characterMasterDataRepository;
        [SerializeField] private BombProvider bombProvider;
        [SerializeField] private MapManager mapManager;
        private BoxCollider _boxCollider;
        private TranslateStatusForBattleUseCase translateStatusForBattleUseCase;
        private PhotonView _photonView;
        private PutBomb _putBomb;
        private StateMachine<EnemyCore> _stateMachine;
        private Seeker _seeker;
        private AILerp _aiLerp;
        private Transform _target;
        private static readonly Vector3 ColliderCenter = new(0, 0.6f, 0);
        private static readonly Vector3 ColliderSize = new(0.4f, 0.6f, 0.4f);

        private enum EnemyState
        {
            Idle,
            Move,
            Escape,
            Skill1,
            Skill2,
            PutBomb,
            Dead
        }

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void Initialize()
        {
            InitializeState();
            _seeker = GetComponent<Seeker>();
            _aiLerp = GetComponent<AILerp>();
            _photonView = GetComponent<PhotonView>();
            SetupBoxCollider();
            SetupCharacterStatusManager();
            SetupPutBomb();
            DebugSetting();
        }

        //todo あとでけす

        private bool joinedRoom;

        private void DebugSetting()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinOrCreateRoom("test", new RoomOptions(), TypedLobby.Default);
        }


        public override void OnJoinedRoom()
        {
            joinedRoom = true;
        }

        private void SetupBoxCollider()
        {
            _boxCollider = gameObject.AddComponent<BoxCollider>();
            _boxCollider.isTrigger = true;
            _boxCollider.center = ColliderCenter;
            _boxCollider.size = ColliderSize;
        }

        private void SetupCharacterStatusManager()
        {
            var characterData = characterMasterDataRepository.DebugGetCharacterData();
         //   _characterStatusManager = new CharacterStatusManager(characterData, PhotonNetwork.IsMasterClient);
        }

        private void SetupPutBomb()
        {
            _putBomb = gameObject.AddComponent<PutBomb>();
            _putBomb.Initialize(bombProvider, translateStatusForBattleUseCase, mapManager);
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<EnemyCore>(this);
            _stateMachine.Start<EnemyIdleState>();
            _stateMachine.AddAnyTransition<EnemyIdleState>((int)EnemyState.Idle);
            _stateMachine.AddAnyTransition<EnemyDeadState>((int)EnemyState.Dead);
            _stateMachine.AddTransition<EnemyIdleState, EnemyMoveState>((int)EnemyState.Move);
            _stateMachine.AddTransition<EnemyEscapeState, EnemyMoveState>((int)EnemyState.Move);
            _stateMachine.AddTransition<EnemyMoveState, EnemyPutBombState>((int)EnemyState.PutBomb);
            _stateMachine.AddTransition<EnemyPutBombState, EnemyEscapeState>((int)EnemyState.Escape);
            _stateMachine.AddTransition<EnemyEscapeState, EnemyEscapeState>((int)EnemyState.Escape);
        }
    }
}