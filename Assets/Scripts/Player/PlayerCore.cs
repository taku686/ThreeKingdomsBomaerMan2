using System;
using System.Threading;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.BattleManager;
using Manager.NetworkManager;
using Pathfinding.Examples.RTS;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Player.Common
{
    public partial class PlayerCore : MonoBehaviourPunCallbacks
    {
        private ApplyStatusSkillUseCase _applyStatusSkillUseCase;
        private PhotonNetworkManager _photonNetworkManager;
        private InputManager _inputManager;
        private PlayerMove _playerMove;
        private PutBomb _putBomb;
        private Animator _animator;
        private ObservableStateMachineTrigger _observableStateMachineTrigger;
        private TranslateStatusForBattleUseCase _translateStatusForBattleUseCase;
        private const int DeadHp = 0;
        private const int InvincibleDuration = 2;
        private const float WaitDuration = 0.3f;
        private bool _isDamage;
        private bool _isInvincible;
        private Renderer _playerRenderer;
        private BoxCollider _boxCollider;
        private SkillBase _skillOne;
        private SkillBase _skillTwo;
        private string _hpKey;
        private readonly Subject<Unit> _deadSubject = new();
        private StateMachine<PlayerCore> _stateMachine;
        private CancellationToken _cancellationToken;
        private readonly Subject<(StatusType statusType, float value)> _statusBuffSubject = new();
        private readonly Subject<(StatusType statusType, int speed, bool isBiff, bool isDebuff)> _statusBuffUiSubject = new();
        public IObservable<Unit> _DeadObservable => _deadSubject;
        public IObservable<(StatusType statusType, int speed, bool isBuff, bool isDebuff)> _StatusBuffUiObservable => _statusBuffUiSubject;

        private enum PLayerState
        {
            Idle,
            Dead,
            NormalSkill,
            SpecialSkill,
            Dash
        }


        public void Initialize
        (
            TranslateStatusForBattleUseCase forBattleUseCase,
            PhotonNetworkManager networkManager,
            ApplyStatusSkillUseCase applyStatusSkill,
            string key
        )
        {
            _hpKey = key;
            _translateStatusForBattleUseCase = forBattleUseCase;
            _photonNetworkManager = networkManager;
            _applyStatusSkillUseCase = applyStatusSkill;
            InitializeComponent();
            InitializeState();
        }

        private void InitializeComponent()
        {
            _inputManager = gameObject.AddComponent<InputManager>();
            _putBomb = GetComponent<PutBomb>();
            _animator = GetComponent<Animator>();
            _playerMove = gameObject.AddComponent<PlayerMove>();
            _playerRenderer = GetComponentInChildren<Renderer>();
            _boxCollider = GetComponent<BoxCollider>();
            _observableStateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
            _inputManager.Initialize(photonView, _photonNetworkManager);
            _playerMove.Initialize(_statusBuffSubject, _translateStatusForBattleUseCase._Speed);
            _cancellationToken = gameObject.GetCancellationTokenOnDestroy();
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<PlayerCore>(this);
            _stateMachine.Start<PlayerIdleState>();
            _stateMachine.AddAnyTransition<PlayerDeadState>((int)PLayerState.Dead);
            _stateMachine.AddAnyTransition<PlayerIdleState>((int)PLayerState.Idle);
            _stateMachine.AddTransition<PlayerIdleState, PlayerNormalSkillState>((int)PLayerState.NormalSkill);
            _stateMachine.AddTransition<PlayerIdleState, PlayerSpecialSkillState>((int)PLayerState.SpecialSkill);
            _stateMachine.AddTransition<PlayerIdleState, PlayerStateDash>((int)PLayerState.Dash);
        }

        private void Update()
        {
            if (!photonView.IsMine)
            {
                return;
            }

            _stateMachine.Update();
            _inputManager.UpdateSkillUI();
            OnInvincible();
        }

        private void OnTriggerEnter(Collider other)
        {
            OnDamage(other.gameObject).Forget();
        }


        private async void OnInvincible()
        {
            if (_isInvincible)
            {
                return;
            }

            _isInvincible = true;
            while (_isDamage)
            {
                if (_playerRenderer == null)
                {
                    break;
                }

                _playerRenderer.enabled = false;
                await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration), cancellationToken: _cancellationToken);
                if (_playerRenderer == null)
                {
                    break;
                }

                _playerRenderer.enabled = true;
                await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration), cancellationToken: _cancellationToken);
            }

            _isInvincible = false;
        }

        private async UniTaskVoid OnDamage(GameObject other)
        {
            if (!other.CompareTag(GameCommonData.BombEffectTag) || _isDamage)
            {
                return;
            }

            var explosion = other.GetComponentInParent<Explosion>();
            _translateStatusForBattleUseCase._CurrentHp -= explosion.damageAmount;
            var hpRate = _translateStatusForBattleUseCase._CurrentHp / (float)_translateStatusForBattleUseCase._MaxHp;
            SynchronizedValue.Instance.SetValue(_hpKey, hpRate);
            if (_translateStatusForBattleUseCase._CurrentHp <= DeadHp)
            {
                Dead().Forget();
                return;
            }

            _isDamage = true;
            await UniTask.Delay(TimeSpan.FromSeconds(InvincibleDuration), cancellationToken: _cancellationToken);
            _isDamage = false;
            if (_playerRenderer == null)
            {
                return;
            }

            _playerRenderer.enabled = true;
        }

        private async UniTask Dead()
        {
            await UniTask.Delay(500, cancellationToken: _cancellationToken);
            _stateMachine.Dispatch((int)PLayerState.Dead);
        }

        private void OnDestroy()
        {
            _translateStatusForBattleUseCase.Dispose();
            _deadSubject.Dispose();
            _statusBuffSubject.Dispose();
        }
    }
}