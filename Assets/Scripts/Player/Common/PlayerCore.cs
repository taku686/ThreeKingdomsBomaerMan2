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
    public partial class PlayerCore : MonoBehaviourPunCallbacks
    {
        private InputManager inputManager;
        private PlayerMove playerMove;
        private PutBomb putBomb;
        private CharacterData characterData;
        private PhotonView photonView;
        private Animator animator;
        private PlayerDead playerDead;
        private ObservableStateMachineTrigger animatorTrigger;
        private CharacterStatusManager characterStatusManager;
        private const int DeadHp = 0;
        private const int InvincibleDuration = 2;
        private const float WaitDuration = 0.3f;
        private bool isDamage;
        private bool isInvincible;
        private Renderer renderer;
        private BoxCollider boxCollider;
        private CancellationToken cancellationToken;
        private SkillBase skillOne;
        private SkillBase skillTwo;
        private string hpKey;

        //Todo 仮の値
        private const float SkillOneIntervalTime = 3f;
        private const float SkillTwoIntervalTime = 5f;

        private enum PLayerState
        {
            Idle,
            Dead,
            Skill1,
            Skill2,
        }

        private StateMachine<PlayerCore> stateMachine;

        public void Initialize(CharacterStatusManager characterStatusManager, string hpKey, CharacterData characterData,
            UserDataManager userDataManager)
        {
            this.characterData = characterData;
            this.hpKey = hpKey;
            this.characterStatusManager = characterStatusManager;
            InitializeComponent(this.characterData, userDataManager);
            InitializeState();
        }

        private void InitializeComponent(CharacterData characterData, UserDataManager userDataManager)
        {
            photonView = GetComponent<PhotonView>();
            inputManager = gameObject.AddComponent<InputManager>();
            inputManager.Initialize(photonView, SkillOneIntervalTime, SkillTwoIntervalTime, characterData,
                userDataManager);
            putBomb = GetComponent<PutBomb>();
            animator = GetComponent<Animator>();
            animatorTrigger = animator.GetBehaviour<ObservableStateMachineTrigger>();
            playerDead = gameObject.AddComponent<PlayerDead>();
            playerMove = gameObject.AddComponent<PlayerMove>();
            playerMove.Initialize(characterStatusManager.Speed);
            renderer = GetComponentInChildren<Renderer>();
            boxCollider = GetComponent<BoxCollider>();
            cancellationToken = gameObject.GetCancellationTokenOnDestroy();
        }

        private void InitializeState()
        {
            stateMachine = new StateMachine<PlayerCore>(this);
            stateMachine.Start<PlayerStateIdle>();
            stateMachine.AddAnyTransition<PlayerStateDead>((int)PLayerState.Dead);
            stateMachine.AddAnyTransition<PlayerStateIdle>((int)PLayerState.Idle);
            stateMachine.AddTransition<PlayerStateIdle, PlayerStateSkillOne>((int)PLayerState.Skill1);
            stateMachine.AddTransition<PlayerStateIdle, PlayerStateSkillTwo>((int)PLayerState.Skill2);
        }

        private void Update()
        {
            if (!photonView.IsMine)
            {
                return;
            }

            stateMachine.Update();
            inputManager.UpdateSkillUI(SkillOneIntervalTime, SkillTwoIntervalTime);
            OnInvincible();
        }

        private void OnTriggerEnter(Collider other)
        {
            OnDamage(other.gameObject);
        }


        private async void OnInvincible()
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            while (isDamage)
            {
                if (renderer == null)
                {
                    break;
                }

                renderer.enabled = false;
                await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration), cancellationToken: cancellationToken);
                if (renderer == null)
                {
                    break;
                }

                renderer.enabled = true;
                await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration), cancellationToken: cancellationToken);
            }

            isInvincible = false;
        }

        private async void OnDamage(GameObject other)
        {
            if (!other.CompareTag(GameCommonData.BombEffectTag) || isDamage)
            {
                return;
            }

            isDamage = true;
            var explosion = other.GetComponentInParent<Explosion>();
            characterStatusManager.CurrentHp -= explosion.damageAmount;
            var hpRate = characterStatusManager.CurrentHp / (float)characterStatusManager.MaxHp;
            SynchronizedValue.Instance.SetValue(hpKey, hpRate);
            if (characterStatusManager.CurrentHp <= DeadHp)
            {
                Dead(explosion);
            }

            await UniTask.Delay(TimeSpan.FromSeconds(InvincibleDuration), cancellationToken: cancellationToken);
            isDamage = false;
            renderer.enabled = true;
        }

        private void Dead(Explosion explosion)
        {
            playerDead.OnTouchExplosion(explosion);
            stateMachine.Dispatch((int)PLayerState.Dead);
        }

        private void OnDestroy()
        {
            characterStatusManager.Dispose();
        }
    }
}