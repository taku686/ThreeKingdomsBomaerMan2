using System;
using System.Threading;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.BattleManager;
using Manager.NetworkManager;
using Photon.Pun;
using Repository;
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

        private TranslateStatusInBattleUseCase.Factory _translateStatusInBattleUseCaseFactory;
        private TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
        private UnderAbnormalConditionsBySkillUseCase _underAbnormalConditionsBySkillUseCase;
        private PlayerGeneratorUseCase _playerGeneratorUseCase;
        private CharacterCreateUseCase _characterCreateUseCase;

        private PlayerStatusInfo _playerStatusInfo;
        private PlayerMove _playerMove;
        private PlayerDash _playerDash;
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

        public IObservable<Unit> _DeadObservable => _deadSubject;
        public IObservable<(StatusType statusType, int speed, bool isBuff, bool isDebuff)> _StatusBuffUiObservable => _statusBuffUiSubject;
        public Subject<Unit> _WeaponSkillSubject { get; } = new();
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
            Dash,
            WeaponSkill
        }


        public void Initialize
        (
            TranslateStatusInBattleUseCase.Factory translateStatusInBattleUseCaseFactory,
            PhotonNetworkManager networkManager,
            ActiveSkillManager activeSkillManager,
            PassiveSkillManager passiveSkillManager,
            UnderAbnormalConditionsBySkillUseCase underAbnormalConditionsBySkillUseCase,
            PlayerGeneratorUseCase playerGeneratorUseCase,
            CharacterCreateUseCase characterCreateUseCase,
            string key
        )
        {
            _hpKey = key;
            _translateStatusInBattleUseCaseFactory = translateStatusInBattleUseCaseFactory;
            _photonNetworkManager = networkManager;
            _activeSkillManager = activeSkillManager;
            _passiveSkillManager = passiveSkillManager;
            _underAbnormalConditionsBySkillUseCase = underAbnormalConditionsBySkillUseCase;
            _playerGeneratorUseCase = playerGeneratorUseCase;
            _characterCreateUseCase = characterCreateUseCase;
            InitializeComponent();
            InitializeState();
            Subscribe();
        }

        private void InitializeComponent()
        {
            _playerDash = GetComponent<PlayerDash>();
            _playerMove = GetComponent<PlayerMove>();
            _targetScanner = gameObject.GetComponent<TargetScanner>()._targetScanner;
            _putBomb = GetComponent<PutBomb>();
            _animator = GetComponentInChildren<Animator>();
            _playerRenderer = GetComponentInChildren<Renderer>();
            _boxCollider = GetComponent<BoxCollider>();
            _TeamMemberReactiveProperty.Value = PhotonNetworkManager.GetPlayerKey(photonView.InstantiationId, 0);
            SetupTranslateStatusInBattleUseCase();
            _observableStateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
            _playerMove.Initialize(_animator, _statusBuffSubject);
            _playerDash.Initialize();
            _cancellationToken = gameObject.GetCancellationTokenOnDestroy();
        }

        private void InitializeSkillManager
        (
            WeaponMasterData weaponMasterData,
            int characterId
        )
        {
            var statusSkillDatum = weaponMasterData.StatusSkillMasterDatum;

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
                CalculateHp,
                _playerDash,
                _playerStatusInfo
            );

            _passiveSkillManager.Initialize
            (
                statusSkillDatum,
                transform,
                _statusBuffSubject,
                _statusBuffUiSubject,
                characterId,
                _translateStatusInBattleUseCase
            );
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<PlayerCore>(this);
            _stateMachine.Start<PlayerIdleState>();
            _stateMachine.AddAnyTransition<PlayerDeadState>((int)PLayerState.Dead);
            _stateMachine.AddAnyTransition<PlayerIdleState>((int)PLayerState.Idle);
            _stateMachine.AddTransition<PlayerIdleState, PlayerWeaponSkillState>((int)PLayerState.WeaponSkill);
            _stateMachine.AddTransition<PlayerIdleState, PlayerNormalSkillState>((int)PLayerState.NormalSkill);
            _stateMachine.AddTransition<PlayerIdleState, PlayerSpecialSkillState>((int)PLayerState.SpecialSkill);
            _stateMachine.AddTransition<PlayerIdleState, PlayerStateDash>((int)PLayerState.Dash);
        }

        private void Subscribe()
        {
            ChangeMemberSubscribe();
            PlayerStatusSubscribe();
        }

        private void ChangeMemberSubscribe()
        {
            _TeamMemberReactiveProperty
                .Skip(1)
                .Subscribe
                (playerKey =>
                    {
                        var characterData = _photonNetworkManager.GetCharacterData(playerKey);
                        var weaponData = _photonNetworkManager.GetWeaponData(playerKey);

                        DestroyWeaponObj(gameObject);
                        _playerGeneratorUseCase.DestroyPlayerObj();
                        var playerObj = _playerGeneratorUseCase.InstantiatePlayerObj(characterData, transform, weaponData.Id, false);
                        _characterCreateUseCase.CreateWeapon(playerObj, weaponData, true);
                        _animator = gameObject.GetComponentInChildren<Animator>();
                        _playerMove.SetAnimator(_animator);
                        _observableStateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
                        SetupTranslateStatusInBattleUseCase(playerKey);
                        PhotonNetwork.LocalPlayer.SetPlayerIndex(photonView.InstantiationId);
                    }
                ).AddTo(_cancellationToken);
        }

        private void PlayerStatusSubscribe()
        {
            _playerStatusInfo._CurrentHp
                .Subscribe(tuple =>
                {
                    if (_isDead)
                    {
                        return;
                    }

                    var maxHp = tuple.Item1;
                    var hp = tuple.Item2;
                    var hpRate = hp / maxHp;
                    hpRate = Mathf.Clamp(hpRate, 0, 1);
                    SynchronizedValue.Instance.SetValue(_hpKey, hpRate);

                    if (hp > DeadHp)
                    {
                        return;
                    }

                    Dead().Forget();
                }).AddTo(_cancellationToken);

            _playerStatusInfo._Speed
                .Subscribe(speed => { _playerMove.ChangeSpeed(speed); })
                .AddTo(_cancellationToken);
        }

        private void SetupTranslateStatusInBattleUseCase(int playerKey = GameCommonData.InvalidNumber)
        {
            if (playerKey == GameCommonData.InvalidNumber)
            {
                playerKey = _TeamMemberReactiveProperty.Value;
            }

            var weaponData = _photonNetworkManager.GetWeaponData(playerKey);
            var characterData = _photonNetworkManager.GetCharacterData(playerKey);
            var levelData = _photonNetworkManager.GetLevelMasterData(playerKey);
            _translateStatusInBattleUseCase = _translateStatusInBattleUseCaseFactory.Create(characterData, weaponData, levelData);
            var newPlayerStatusInfo = _translateStatusInBattleUseCase.InitializeStatus();
            SetupPlayerStatusInfo(newPlayerStatusInfo);
            _putBomb.SetupBombProvider(_translateStatusInBattleUseCase);
            InitializeSkillManager(weaponData, characterData.Id);
        }

        private void SetupPlayerStatusInfo(PlayerStatusInfo newPlayerStatusInfo)
        {
            _playerStatusInfo ??= newPlayerStatusInfo;
            var currentHp = _playerStatusInfo._CurrentHp.Value.Item2;
            var maxHp = newPlayerStatusInfo._CurrentHp.Value.Item1;
            _playerStatusInfo._CurrentHp.Value = (maxHp, currentHp);
            _playerStatusInfo._Speed.Value = newPlayerStatusInfo._Speed.Value;
            _playerStatusInfo._Attack.Value = newPlayerStatusInfo._Attack.Value;
            _playerStatusInfo._Defense.Value = newPlayerStatusInfo._Defense.Value;
            _playerStatusInfo._Resistance.Value = newPlayerStatusInfo._Resistance.Value;
            _playerStatusInfo._FireRange.Value = newPlayerStatusInfo._FireRange.Value;
            _playerStatusInfo._BombLimit.Value = newPlayerStatusInfo._BombLimit.Value;
        }

        private static void DestroyWeaponObj(GameObject playerObj)
        {
            var weapons = playerObj.GetComponentsInChildren<WeaponObject>();
            foreach (var weapon in weapons)
            {
                PhotonNetwork.Destroy(weapon.gameObject);
            }
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
            CalculateHp(explosion.damageAmount);

            _isDamage = true;
            await UniTask.Delay(TimeSpan.FromSeconds(InvincibleDuration), cancellationToken: _cancellationToken);
            _isDamage = false;

            if (_playerRenderer == null)
            {
                return;
            }

            _playerRenderer.enabled = true;
        }

        private void CalculateHp(int damage)
        {
            var tuple = _playerStatusInfo._CurrentHp.Value;
            var maxHp = tuple.Item1;
            var hp = tuple.Item2;
            hp -= damage;
            hp = Mathf.Clamp(hp, DeadHp, maxHp);
            _playerStatusInfo._CurrentHp.Value = (maxHp, hp);
        }

        private void ActivatePassiveSkillOnDamage()
        {
            var playerKey = _TeamMemberReactiveProperty.Value;
            var weaponData = _photonNetworkManager.GetWeaponData(playerKey);
            var normalSkillData = weaponData.NormalSkillMasterData;
            _underAbnormalConditionsBySkillUseCase.OnNextDamageSubject(normalSkillData);
            _underAbnormalConditionsBySkillUseCase.OnNextDamageSubject(null);
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
            _WeaponSkillSubject.Dispose();
            _NormalSkillSubject.Dispose();
            _SpecialSkillSubject.Dispose();
            _DashSkillSubject.Dispose();
            _BombSkillSubject.Dispose();
            _TeamMemberReactiveProperty.Dispose();
        }

        public class PlayerStatusInfo
        {
            public readonly ReactiveProperty<(float, float)> _CurrentHp;
            public readonly ReactiveProperty<float> _Speed;
            public readonly ReactiveProperty<int> _Attack;
            public readonly ReactiveProperty<int> _Defense;
            public readonly ReactiveProperty<int> _Resistance;
            public readonly ReactiveProperty<int> _FireRange;
            public readonly ReactiveProperty<int> _BombLimit;

            public PlayerStatusInfo
            (
                int currentHp,
                float speed,
                int maxHp,
                int attack,
                int defense,
                int resistance,
                int fireRange,
                int bombLimit
            )
            {
                _BombLimit = new ReactiveProperty<int>(bombLimit);
                _CurrentHp = new ReactiveProperty<(float, float)>((maxHp, currentHp));
                _Speed = new ReactiveProperty<float>(speed);
                _Attack = new ReactiveProperty<int>(attack);
                _Defense = new ReactiveProperty<int>(defense);
                _Resistance = new ReactiveProperty<int>(resistance);
                _FireRange = new ReactiveProperty<int>(fireRange);
            }
        }
    }
}