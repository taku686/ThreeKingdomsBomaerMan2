using System;
using Interface;
using Manager;
using UnityEngine;
using Zenject;

namespace Player.Common
{
    public partial class PLayerCore : MonoBehaviour
    {
        [Inject] private InputManager _inputManager;
        private IPlayerMove _playerMove;

        private CharacterData _characterData;

        private enum PLayerState
        {
            Idle,
            Dead,
            Skill1,
            Skill2,
            Stop
        }

        private StateMachine<PLayerCore> _stateMachine;

        private void Awake()
        {
        }

        private void Start()
        {
        }

        public void Initialize(CharacterData characterData)
        {
            InitializeComponent(characterData);
            InitializeState();
        }

        private void InitializeComponent(CharacterData characterData)
        {
            _playerMove = GetComponent<PlayerMove>();
            _playerMove.Initialize();
            _characterData = characterData;
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<PLayerCore>(this);
            _stateMachine.Start<PlayerStateIdle>();
        }
    }
}