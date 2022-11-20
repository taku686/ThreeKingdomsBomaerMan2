using System;
using Bomb;
using Common.Data;
using Manager;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Player.Common
{
    public partial class PLayerCore : MonoBehaviourPunCallbacks
    {
        [Inject] private BombProvider _bombProvider;
        private InputManager _inputManager;
        private PlayerMove _playerMove;
        private PlayerPutBomb _playerPutBomb;
        private CharacterData _characterData;
        private PhotonView _photonView;

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
            _photonView = gameObject.GetComponent<PhotonView>();
            _inputManager = gameObject.AddComponent<InputManager>();
            _inputManager.Initialize(_photonView);
            _playerMove = gameObject.AddComponent<PlayerMove>();
            _playerMove.Initialize(characterData.Speed);
            _playerPutBomb = GetComponent<PlayerPutBomb>();
            _characterData = characterData;
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<PLayerCore>(this);
            _stateMachine.Start<PlayerStateIdle>();
        }
    }
}