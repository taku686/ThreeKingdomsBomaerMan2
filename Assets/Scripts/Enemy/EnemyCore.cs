using Bomb;
using Manager.DataManager;
using Pathfinding;
using Photon.Pun;
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

        private TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
        private PhotonView _photonView;
        private PutBomb _putBomb;
        private Seeker _seeker;
        private AILerp _aiLerp;
        private SearchPlayer _searchPlayer;

        private Transform _target;
        private BoxCollider _boxCollider;
        private StateMachine<EnemyCore> _stateMachine;

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

        private void Update()
        {
            _stateMachine?.Update();
        }

        public void Initialize()
        {
            InitializeState();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _seeker = GetComponent<Seeker>();
            _aiLerp = GetComponent<AILerp>();
            _searchPlayer = gameObject.AddComponent<SearchPlayer>();
            _photonView = GetComponent<PhotonView>();
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<EnemyCore>(this);
            _stateMachine.Start<EnemyIdleState>();
            _stateMachine.AddAnyTransition<EnemyIdleState>((int)EnemyState.Idle);
            _stateMachine.AddAnyTransition<EnemyDeadState>((int)EnemyState.Dead);
            _stateMachine.AddAnyTransition<EnemyMoveState>((int)EnemyState.Move);
            _stateMachine.AddTransition<EnemyMoveState, EnemyPutBombState>((int)EnemyState.PutBomb);
            _stateMachine.AddTransition<EnemyPutBombState, EnemyEscapeState>((int)EnemyState.Escape);
            _stateMachine.AddTransition<EnemyEscapeState, EnemyEscapeState>((int)EnemyState.Escape);
        }

        private bool IsMine(int instantiatedId)
        {
            return _photonView != null && _photonView.InstantiationId == instantiatedId;
        }
    }
}