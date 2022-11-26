using System;
using Common.Data;
using Manager;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Player.Common
{
    public partial class PLayerCore : MonoBehaviourPunCallbacks
    {
        private InputManager _inputManager;
        private PlayerMove _playerMove;
        private PlayerPutBomb _playerPutBomb;
        private CharacterData _characterData;
        private PhotonView _photonView;
        private Animator _animator;
        private PlayerDead _playerDead;

        private enum PLayerState
        {
            Idle,
            Dead,
            Skill1,
            Skill2,
            Stop
        }

        private StateMachine<PLayerCore> _stateMachine;

        public void Initialize(CharacterData characterData)
        {
            InitializeComponent(characterData);
            InitializeState();
        }

        private void InitializeComponent(CharacterData characterData)
        {
            _photonView = GetComponent<PhotonView>();
            _inputManager = gameObject.AddComponent<InputManager>();
            _inputManager.Initialize(_photonView);
            _playerMove = gameObject.AddComponent<PlayerMove>();
            _playerMove.Initialize(characterData.Speed);
            _playerPutBomb = GetComponent<PlayerPutBomb>();
            _animator = GetComponent<Animator>();
            _playerDead = gameObject.AddComponent<PlayerDead>();
            _characterData = characterData;
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<PLayerCore>(this);
            _stateMachine.Start<PlayerStateIdle>();
            _stateMachine.AddAnyTransition<PlayerStateDead>((int)PLayerState.Dead);
        }

        private void OnTriggerEnter(Collider other)
        {
            Dead(other);
        }

        private void Dead(Collider other)
        {
            if (!other.CompareTag(GameSettingData.BombEffectTag))
            {
                return;
            }

            _playerDead.OnTouchExplosion(other);
            _stateMachine.Dispatch((int)PLayerState.Dead);
        }
    }
}