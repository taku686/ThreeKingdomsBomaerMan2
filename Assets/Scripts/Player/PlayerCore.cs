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
        private PassiveSkillManager _passiveSkillManager;
        private ActiveSkillManager _activeSkillManager;

        private TranslateStatusInBattleUseCase.Factory _translateStatusInBattleUseCaseFactory;
        private TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
        private UnderAbnormalConditionsBySkillUseCase _underAbnormalConditionsBySkillUseCase;
        private PlayerGeneratorUseCase _playerGeneratorUseCase;
        private CharacterCreateUseCase _characterCreateUseCase;
        private AbnormalConditionEffect _abnormalConditionEffect;

        private PlayerConditionInfo _playerConditionInfo;
        private PlayerMove _playerMove;
        private PlayerDash _playerDash;
        private PutBomb _putBomb;
        private Animator _animator;
        private ObservableStateMachineTrigger _observableStateMachineTrigger;
        private Renderer _playerRenderer;
        private BoxCollider _boxCollider;
        private CancellationToken _cancellationToken;

        private readonly Subject<Unit> _deadSubject = new();
        private const int DeadHp = 0;
        private const int InvincibleDuration = 2;
        private const float WaitDuration = 0.3f;

        public IObservable<Unit> _DeadObservable => _deadSubject;
        public Subject<Unit> _WeaponSkillSubject { get; } = new();
        public Subject<Unit> _NormalSkillSubject { get; } = new();
        public Subject<Unit> _SpecialSkillSubject { get; } = new();
        public Subject<Unit> _DashSkillSubject { get; } = new();
        public Subject<Unit> _BombSkillSubject { get; } = new();
        public ReactiveProperty<int> _TeamMemberReactiveProperty { get; } = new();
        public PlayerStatusInfo _PlayerStatusInfo { get; private set; }

        private enum PLayerState
        {
            Idle,
            Dead,
            NormalSkill,
            SpecialSkill,
            Dash,
            WeaponSkill
        }

        #region Initialize

        public void Initialize
        (
            TranslateStatusInBattleUseCase.Factory translateStatusInBattleUseCaseFactory,
            PhotonNetworkManager networkManager,
            ActiveSkillManager activeSkillManager,
            PassiveSkillManager passiveSkillManager,
            UnderAbnormalConditionsBySkillUseCase underAbnormalConditionsBySkillUseCase,
            PlayerGeneratorUseCase playerGeneratorUseCase,
            CharacterCreateUseCase characterCreateUseCase,
            AbnormalConditionEffect abnormalConditionEffect,
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
            _abnormalConditionEffect = abnormalConditionEffect;
            InitializeComponent();
            InitializeState();
            Subscribe();
        }

        private void InitializeComponent()
        {
            _playerDash = GetComponent<PlayerDash>();
            _playerMove = GetComponent<PlayerMove>();
            _playerConditionInfo = GetComponent<PlayerConditionInfo>();
            _putBomb = GetComponent<PutBomb>();
            _animator = GetComponentInChildren<Animator>();
            _playerRenderer = GetComponentInChildren<Renderer>();
            _boxCollider = GetComponent<BoxCollider>();
            _TeamMemberReactiveProperty.Value = PhotonNetworkManager.GetPlayerKey(photonView.InstantiationId, 0);
            SetupTranslateStatusInBattleUseCase();
            _observableStateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
            _playerMove.Initialize(_animator, _abnormalConditionEffect);
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
                statusSkillDatum,
                transform,
                characterId,
                _PlayerStatusInfo
            );

            _passiveSkillManager.Initialize
            (
                statusSkillDatum,
                transform,
                _PlayerStatusInfo,
                characterId
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

        #endregion

        #region Subscribe

        private void Subscribe()
        {
            EventSubscribe();
            ChangeMemberSubscribe();
            PlayerStatusSubscribe();
            PhotonNetWorkManagerSubscribe();
        }

        private void EventSubscribe()
        {
            gameObject
                .UpdateAsObservable()
                .Subscribe(_ =>
                {
                    _stateMachine.Update();
                    OnInvincible();
                })
                .AddTo(_cancellationToken);

            gameObject
                .OnTriggerEnterAsObservable()
                .Subscribe(other => { OnDamage(other.gameObject).Forget(); })
                .AddTo(_cancellationToken);
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
            _PlayerStatusInfo._Hp
                .Subscribe(tuple =>
                {
                    if (_isDead)
                    {
                        return;
                    }

                    var maxHp = tuple.Item1;
                    var hp = tuple.Item2;
                    var hpRate = hp / (float)maxHp;
                    hpRate = Mathf.Clamp(hpRate, 0, 1);
                    SynchronizedValue.Instance.SetValue(_hpKey, hpRate);

                    if (hp > DeadHp)
                    {
                        return;
                    }

                    Dead().Forget();
                }).AddTo(_cancellationToken);

            _PlayerStatusInfo._Speed
                .Subscribe(speed =>
                {
                    var translatedValue = TranslateStatusInBattleUseCase.Translate(StatusType.Speed, speed);
                    _playerMove.ChangeSpeed(translatedValue);
                })
                .AddTo(_cancellationToken);
        }

        private void PhotonNetWorkManagerSubscribe()
        {
            var actorNumber = photonView.InstantiationId;

            _photonNetworkManager
                ._ActivateSkillObservable
                .Where(tuple => tuple.Item1 == actorNumber)
                .Select(tuple => tuple.Item2)
                .Subscribe(skillData =>
                {
                    var abnormalConditions = skillData.InvalidAbnormalConditionEnum;
                    foreach (var abnormalCondition in abnormalConditions)
                    {
                        _abnormalConditionEffect.InAsTask(abnormalCondition, skillData.EffectTime);
                    }
                })
                .AddTo(_cancellationToken);
        }

        #endregion

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
            _PlayerStatusInfo ??= newPlayerStatusInfo;
            var currentHp = _PlayerStatusInfo._Hp.Value.Item2;
            var maxHp = newPlayerStatusInfo._Hp.Value.Item1;
            _PlayerStatusInfo._Hp.Value = (maxHp, currentHp);
            _PlayerStatusInfo._Speed.Value = newPlayerStatusInfo._Speed.Value;
            _PlayerStatusInfo._Attack.Value = newPlayerStatusInfo._Attack.Value;
            _PlayerStatusInfo._Defense.Value = newPlayerStatusInfo._Defense.Value;
            _PlayerStatusInfo._Resistance.Value = newPlayerStatusInfo._Resistance.Value;
            _PlayerStatusInfo._FireRange.Value = newPlayerStatusInfo._FireRange.Value;
            _PlayerStatusInfo._BombLimit.Value = newPlayerStatusInfo._BombLimit.Value;
        }

        private static void DestroyWeaponObj(GameObject playerObj)
        {
            var weapons = playerObj.GetComponentsInChildren<WeaponObject>();
            foreach (var weapon in weapons)
            {
                PhotonNetwork.Destroy(weapon.gameObject);
            }
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
            var tuple = _PlayerStatusInfo._Hp.Value;
            var maxHp = Mathf.FloorToInt(TranslateStatusInBattleUseCase.Translate(StatusType.Hp, tuple.Item1));
            var hp = Mathf.FloorToInt(TranslateStatusInBattleUseCase.Translate(StatusType.Hp, tuple.Item2));
            hp -= damage;
            hp = Mathf.Clamp(hp, DeadHp, maxHp);
            _PlayerStatusInfo._Hp.Value = (maxHp, hp);
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
            _WeaponSkillSubject.Dispose();
            _NormalSkillSubject.Dispose();
            _SpecialSkillSubject.Dispose();
            _DashSkillSubject.Dispose();
            _BombSkillSubject.Dispose();
            _TeamMemberReactiveProperty.Dispose();
        }

        public class PlayerStatusInfo
        {
            public readonly ReactiveProperty<(int, int)> _Hp;
            public readonly ReactiveProperty<int> _Speed;
            public readonly ReactiveProperty<int> _Attack;
            public readonly ReactiveProperty<int> _Defense;
            public readonly ReactiveProperty<int> _Resistance;
            public readonly ReactiveProperty<int> _FireRange;
            public readonly ReactiveProperty<int> _BombLimit;

            public PlayerStatusInfo
            (
                int currentHp,
                int speed,
                int maxHp,
                int attack,
                int defense,
                int resistance,
                int fireRange,
                int bombLimit
            )
            {
                _BombLimit = new ReactiveProperty<int>(bombLimit);
                _Hp = new ReactiveProperty<(int, int)>((maxHp, currentHp));
                _Speed = new ReactiveProperty<int>(speed);
                _Attack = new ReactiveProperty<int>(attack);
                _Defense = new ReactiveProperty<int>(defense);
                _Resistance = new ReactiveProperty<int>(resistance);
                _FireRange = new ReactiveProperty<int>(fireRange);
            }
        }
    }
}