using System;
using System.Collections.Generic;
using System.Threading;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.BattleManager;
using Photon.Pun;
using UI.Battle;
using UniRx.Triggers;
using UnityEngine;

namespace Player.Common
{
    public partial class PLayerBase : MonoBehaviourPunCallbacks
    {
        private InputManager _inputManager;
        private PlayerMove _playerMove;
        private PlayerPutBomb _playerPutBomb;
        private CharacterData _characterData;
        private PhotonView _photonView;
        private Animator _animator;

        private PlayerDead _playerDead;

        //   private PlayerStatusUI _playerStatusUI;
        private ObservableStateMachineTrigger _animatorTrigger;
        private PlayerStatusManager _playerStatusManager;
        private const int DeadHp = 0;
        private const int InvincibleDuration = 2;
        private const float WaitDuration = 0.3f;
        private bool _isDamage;
        private bool _isInvincible;
        private Renderer _renderer;
        private BoxCollider _boxCollider;
        private CancellationToken _cancellationToken;
        private string _hpKey;

        //Todo仮の値
        private const float SkillOneIntervalTime = 3f;
        private const float SkillTwoIntervalTime = 5f;

        private enum PLayerState
        {
            Idle,
            Dead,
            Skill1,
            Skill2,
            Stop
        }

        private StateMachine<PLayerBase> _stateMachine;

        public void Initialize(CharacterData characterData, string hpKey)
        {
            InitializeComponent(characterData);
            InitializeState();
            _hpKey = hpKey;
        }

        private void InitializeComponent(CharacterData characterData)
        {
            _photonView = GetComponent<PhotonView>();
            _inputManager = gameObject.AddComponent<InputManager>();
            _inputManager.Initialize(_photonView, SkillOneIntervalTime, SkillTwoIntervalTime);
            _playerMove = gameObject.AddComponent<PlayerMove>();
            _playerMove.Initialize(characterData.Speed);
            _playerPutBomb = GetComponent<PlayerPutBomb>();
            _animator = GetComponent<Animator>();
            _animatorTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
            _playerDead = gameObject.AddComponent<PlayerDead>();
            _characterData = characterData;
            //   _playerStatusUI = playerStatusUI;
            _playerStatusManager = new PlayerStatusManager(characterData.Hp * 10);
            _renderer = GetComponentInChildren<Renderer>();
            _boxCollider = GetComponent<BoxCollider>();
            _cancellationToken = gameObject.GetCancellationTokenOnDestroy();
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<PLayerBase>(this);
            _stateMachine.Start<PlayerStateIdle>();
            _stateMachine.AddAnyTransition<PlayerStateDead>((int)PLayerState.Dead);
            _stateMachine.AddAnyTransition<PlayerStateIdle>((int)PLayerState.Idle);
            _stateMachine.AddTransition<PlayerStateIdle, PlayerStateSkillOne>((int)PLayerState.Skill1);
            _stateMachine.AddTransition<PlayerStateIdle, PlayerStateSkillTwo>((int)PLayerState.Skill2);
        }

        private void Update()
        {
            if (!_photonView.IsMine)
            {
                return;
            }

            _stateMachine.Update();
            _inputManager.UpdateSkillUI(SkillOneIntervalTime, SkillTwoIntervalTime);
            OnInvincible();
        }

        private void OnTriggerEnter(Collider other)
        {
            OnDamage(other);
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
                if (_renderer == null)
                {
                    break;
                }

                _renderer.enabled = false;
                await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration), cancellationToken: _cancellationToken);
                if (_renderer == null)
                {
                    break;
                }

                _renderer.enabled = true;
                await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration), cancellationToken: _cancellationToken);
            }

            _isInvincible = false;
        }

        private async void OnDamage(Collider other)
        {
            if (!other.CompareTag(GameSettingData.BombEffectTag) || _isDamage)
            {
                return;
            }

            _isDamage = true;
            var explosion = other.GetComponentInParent<Explosion>();
            _playerStatusManager.CurrentHp -= explosion.damageAmount;
            //var hpRate = _playerStatusManager.CurrentHp / (float)_playerStatusManager.MaxHp;
            //    await _playerStatusUI.OnDamage(hpRate);
            SynchronizedValue.SetValue(_hpKey, _playerStatusManager.CurrentHp);
            await UniTask.Delay(TimeSpan.FromSeconds(InvincibleDuration), cancellationToken: _cancellationToken);
            _isDamage = false;
            _renderer.enabled = true;
           // Debug.Log(_playerStatusManager.CurrentHp);
            if (_playerStatusManager.CurrentHp <= DeadHp)
            {
                Dead(explosion);
            }
        }

        private void Dead(Explosion explosion)
        {
            _playerDead.OnTouchExplosion(explosion);
            _stateMachine.Dispatch((int)PLayerState.Dead);
        }

        private void OnDestroy()
        {
            _playerStatusManager.Dispose();
        }
    }
}