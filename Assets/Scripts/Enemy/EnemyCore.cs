using System.Threading;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Facade.Skill;
using Manager.NetworkManager;
using Pathfinding;
using Photon.Pun;
using Player.Common;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Enemy
{
    public partial class EnemyCore : MonoBehaviourPunCallbacks
    {
        private EnemySearchPlayer.Factory _searchPlayerFactory;
        private EnemySkillTimer _enemySkillTimer;
        private PhotonNetworkManager _photonNetworkManager;
        [SerializeField] private BombProvider bombProvider;
        [SerializeField] private MapManager mapManager;

        private TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
        private PhotonView _photonView;
        private PutBomb _putBomb;
        private Seeker _seeker;
        private AIPath _aiPath;
        private EnemySearchPlayer _enemySearchPlayer;
        private Animator _animator;
        private PlayerConditionInfo _playerConditionInfo;
        private SkillAnimationFacade _skillAnimationFacade;
        private ObservableStateMachineTrigger _observableStateMachineTrigger;

        private Transform _target;
        private BoxCollider _boxCollider;
        private StateMachine<EnemyCore> _stateMachine;
        private CancellationTokenSource _cts;
        private int _playerKey;

        private enum EnemyState
        {
            Idle,
            Move,
            Escape,
            NormalSkill,
            SpecialSkill,
            WeaponSkill,
            PutBomb,
            Dead
        }

        private void Update()
        {
            _stateMachine?.Update();
        }

        public void Initialize
        (
            EnemySearchPlayer.Factory searchPlayerFactory,
            EnemySkillTimer.Factory enemySkillTimerFactory,
            PhotonNetworkManager photonNetworkManager,
            SkillAnimationFacade skillAnimationFacade
        )
        {
            _cts = new CancellationTokenSource();
            _searchPlayerFactory = searchPlayerFactory;
            _enemySkillTimer = enemySkillTimerFactory.Create();
            _photonNetworkManager = photonNetworkManager;
            _skillAnimationFacade = skillAnimationFacade;

            InitializeState();
            InitializeComponent();
            Subscribe();
        }

        private void InitializeComponent()
        {
            _animator = GetComponentInChildren<Animator>();
            _observableStateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
            _playerConditionInfo = GetComponent<PlayerConditionInfo>();
            _seeker = gameObject.AddComponent<Seeker>();
            _aiPath = gameObject.AddComponent<AIPath>();
            _photonView = GetComponent<PhotonView>();
            _enemySearchPlayer = _searchPlayerFactory.Create(gameObject);
            _playerKey = PhotonNetworkManager.GetPlayerKey(photonView.InstantiationId, 0);
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
            _stateMachine.AddTransition<EnemyMoveState, EnemyNormalSkillState>((int)EnemyState.NormalSkill);
            _stateMachine.AddTransition<EnemyMoveState, EnemySpecialSkillState>((int)EnemyState.SpecialSkill);
            _stateMachine.AddTransition<EnemyMoveState, EnemyWeaponSkillState>((int)EnemyState.WeaponSkill);
        }

        private void Subscribe()
        {
            SkillSubscribe();
            EventSubscribe();
        }

        private void SkillSubscribe()
        {
            var weaponData = _photonNetworkManager.GetWeaponData(_playerKey);
            var skillData = weaponData.NormalSkillMasterData;

            if (Mathf.Approximately(skillData.Interval, GameCommonData.InvalidNumber))
            {
                return;
            }

            if (Mathf.Approximately(skillData.Range, GameCommonData.InvalidNumber))
            {
                _enemySkillTimer
                    .TimerSubscribe(skillData)
                    .Where(activate => activate)
                    .Where(_ => IsStateEnableToSkill(_stateMachine._CurrentState))
                    .Subscribe(_ => { _stateMachine.Dispatch((int)EnemyState.WeaponSkill); })
                    .AddTo(_cts.Token);
            }
            else
            {
                _enemySkillTimer
                    .TimerSubscribe(skillData)
                    .Where(activate => activate)
                    .SelectMany(_ => _enemySearchPlayer.SearchObservable(skillData.Range))
                    .Where(_ => IsStateEnableToSkill(_stateMachine._CurrentState))
                    .Subscribe(target =>
                    {
                        _enemySkillTimer.ResetTimer();
                        transform.LookAt(target.transform);
                        _stateMachine.Dispatch((int)EnemyState.WeaponSkill);
                    })
                    .AddTo(_cts.Token);
            }
        }

        private static bool IsStateEnableToSkill(StateMachine<EnemyCore>.State currentState)
        {
            return currentState is EnemyIdleState or EnemyMoveState;
        }

        private void EventSubscribe()
        {
            gameObject
                .UpdateAsObservable()
                .Subscribe(_ => _stateMachine.Update())
                .AddTo(_cts.Token);
        }

        private bool IsMine(int instantiatedId)
        {
            return _photonView != null && _photonView.InstantiationId == instantiatedId;
        }

        private int GetPlayerKey()
        {
            return _playerKey;
        }

        private void OnDestroy()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }
    }
}