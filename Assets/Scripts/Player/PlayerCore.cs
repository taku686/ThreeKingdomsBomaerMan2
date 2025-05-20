using System;
using System.Threading;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.BattleManager;
using Manager.NetworkManager;
using Photon.Pun;
using Skill;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Player.Common
{
    public partial class PlayerCore : MonoBehaviourPunCallbacks
    {
        private StateMachine<PlayerCore> _stateMachine;

        private bool _isDamage;
        private bool _isDead;
        private bool _isInvincible;

        private string _hpKey;

        private PhotonNetworkManager _photonNetworkManager;
        private ActiveSkillManager _activeSkillManager;
        private PassiveSkillManager _passiveSkillManager;

        private TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
        private SkillActivationConditionsUseCase _skillActivationConditionsUseCase;

        private PlayerMove _playerMove;
        private PutBomb _putBomb;
        private Animator _animator;
        private ObservableStateMachineTrigger _observableStateMachineTrigger;
        private Renderer _playerRenderer;
        private BoxCollider _boxCollider;
        private DC.Scanner.TargetScanner _targetScanner;
        private CancellationToken _cancellationToken;

        private readonly Subject<Unit> _deadSubject = new();
        private readonly Subject<(StatusType statusType, float value)> _statusBuffSubject = new();
        private readonly Subject<(StatusType statusType, int speed, bool isBiff, bool isDebuff)> _statusBuffUiSubject = new();

        private const int DeadHp = 0;
        private const int InvincibleDuration = 2;
        private const float WaitDuration = 0.3f;
        private const float HpMaxRate = 1f;

        public IObservable<Unit> _DeadObservable => _deadSubject;
        public IObservable<(StatusType statusType, int speed, bool isBuff, bool isDebuff)> _StatusBuffUiObservable => _statusBuffUiSubject;
        public Subject<Unit> _NormalSkillSubject { get; } = new();
        public Subject<Unit> _SpecialSkillSubject { get; } = new();
        public Subject<Unit> _DashSkillSubject { get; } = new();
        public Subject<Unit> _BombSkillSubject { get; } = new();
        public ReactiveProperty<int> _TeamMemberReactiveProperty { get; } = new();


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
            TranslateStatusInBattleUseCase inBattleUseCase,
            PhotonNetworkManager networkManager,
            ActiveSkillManager activeSkillManager,
            PassiveSkillManager passiveSkillManager,
            SkillActivationConditionsUseCase skillActivationConditionsUseCase,
            string key
        )
        {
            _hpKey = key;
            _translateStatusInBattleUseCase = inBattleUseCase;
            _photonNetworkManager = networkManager;
            _activeSkillManager = activeSkillManager;
            _passiveSkillManager = passiveSkillManager;
            _skillActivationConditionsUseCase = skillActivationConditionsUseCase;
            InitializeComponent();
            InitializeState();
        }

        private void InitializeComponent()
        {
            _targetScanner = gameObject.GetComponent<TargetScanner>()._targetScanner;
            _putBomb = GetComponent<PutBomb>();
            _animator = GetComponent<Animator>();
            _playerMove = gameObject.AddComponent<PlayerMove>();
            _playerRenderer = GetComponentInChildren<Renderer>();
            _boxCollider = GetComponent<BoxCollider>();
            _observableStateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
            _playerMove.Initialize(_statusBuffSubject, _translateStatusInBattleUseCase._Speed);
            _TeamMemberReactiveProperty.Value = PhotonNetworkManager.GetPlayerKey(photonView.InstantiationId, 0);
            var weaponData = _photonNetworkManager.GetWeaponData(_TeamMemberReactiveProperty.Value);
            var characterData = _photonNetworkManager.GetCharacterData(_TeamMemberReactiveProperty.Value);
            var characterId = characterData.Id;
            var statusSkillDatum = weaponData.StatusSkillMasterDatum;
            var normalSkillData = weaponData.NormalSkillMasterData;
            var specialSkillData = weaponData.SpecialSkillMasterData;
            _activeSkillManager.Initialize
            (
                _targetScanner,
                statusSkillDatum,
                transform,
                _animator,
                _statusBuffSubject,
                _statusBuffUiSubject,
                characterId,
                _translateStatusInBattleUseCase,
                CalculateHp
            );
            _passiveSkillManager.Initialize
            (
                normalSkillData,
                specialSkillData,
                statusSkillDatum,
                transform,
                _statusBuffSubject,
                _statusBuffUiSubject,
                characterId,
                _translateStatusInBattleUseCase
            );
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
            if (!other.CompareTag(GameCommonData.BombEffectTag) || _isDamage || _isDead)
            {
                return;
            }

            ActivatePassiveSkillOnDamage();
            var explosion = other.GetComponentInParent<Explosion>();
            var hp = CalculateHp(explosion.damageAmount);
            if (hp <= DeadHp　&& !_isDead)
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

        private int CalculateHp(int damage)
        {
            _translateStatusInBattleUseCase._CurrentHp -= damage;
            _translateStatusInBattleUseCase._CurrentHp = Mathf.Clamp(_translateStatusInBattleUseCase._CurrentHp, DeadHp, _translateStatusInBattleUseCase._MaxHp);
            var hpRate = _translateStatusInBattleUseCase._CurrentHp / (float)_translateStatusInBattleUseCase._MaxHp;
            SynchronizedValue.Instance.SetValue(_hpKey, hpRate);
            return _translateStatusInBattleUseCase._CurrentHp;
        }

        private void ActivatePassiveSkillOnDamage()
        {
            var index = photonView.OwnerActorNr;
            var weaponData = _photonNetworkManager.GetWeaponData(index);
            var normalSkillData = weaponData.NormalSkillMasterData;
            var specialSkillData = weaponData.SpecialSkillMasterData;
            _skillActivationConditionsUseCase.OnNextDamageSubject(normalSkillData);
            _skillActivationConditionsUseCase.OnNextDamageSubject(specialSkillData);
        }

        private async UniTask Dead()
        {
            _isDead = true;
            await UniTask.Delay(500, cancellationToken: _cancellationToken);
            _stateMachine.Dispatch((int)PLayerState.Dead);
        }

        public void ChangeTeamMember()
        {
            var teamMemberIndex = _TeamMemberReactiveProperty.Value - photonView.InstantiationId * 10;
            teamMemberIndex += 1;
            if (teamMemberIndex >= GameCommonData.MaxTeamMember)
            {
                teamMemberIndex = 0;
            }

            var playerKey = PhotonNetworkManager.GetPlayerKey(photonView.InstantiationId, teamMemberIndex);
            _TeamMemberReactiveProperty.Value = playerKey;
        }
        
        private int GetPlayerKey()
        {
            return _TeamMemberReactiveProperty.Value;
        }

        private void OnDestroy()
        {
            _translateStatusInBattleUseCase.Dispose();
            _deadSubject.Dispose();
            _statusBuffSubject.Dispose();
            _NormalSkillSubject.Dispose();
            _SpecialSkillSubject.Dispose();
            _DashSkillSubject.Dispose();
            _BombSkillSubject.Dispose();
            _TeamMemberReactiveProperty.Dispose();
        }
    }
}