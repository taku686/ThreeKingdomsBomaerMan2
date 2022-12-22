using System;
using Common.Data;
using Manager;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
        private ObservableStateMachineTrigger _animatorTrigger;

        //Todo仮の値
        private const float SkillOneIntervalTime = 3;
        private const float SkillTwoIntervalTime = 5;

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
            InitializeButton();
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
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<PLayerCore>(this);
            _stateMachine.Start<PlayerStateIdle>();
            _stateMachine.AddAnyTransition<PlayerStateDead>((int)PLayerState.Dead);
            _stateMachine.AddAnyTransition<PlayerStateIdle>((int)PLayerState.Idle);
            _stateMachine.AddTransition<PlayerStateIdle, PlayerStateSkillOne>((int)PLayerState.Skill1);
            _stateMachine.AddTransition<PlayerStateIdle, PlayerStateSkillTwo>((int)PLayerState.Skill2);
        }

        private void InitializeButton()
        {
            _inputManager.SetOnClickSkillOne(SkillOneIntervalTime, OnClickSkillOne);
            _inputManager.SetOnClickSkillTwo(SkillTwoIntervalTime, OnClickSkillTwo);
        }

        private void Update()
        {
            if (!_photonView.IsMine)
            {
                return;
            }

            _stateMachine.Update();
            _inputManager.UpdateSkillUI(SkillOneIntervalTime, SkillTwoIntervalTime);
        }

        private void OnClickSkillOne()
        {
            _stateMachine.Dispatch((int)PLayerState.Skill1);
        }

        private void OnClickSkillTwo()
        {
            _stateMachine.Dispatch((int)PLayerState.Skill2);
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

        private void OnDestroy()
        {
        }
    }
}