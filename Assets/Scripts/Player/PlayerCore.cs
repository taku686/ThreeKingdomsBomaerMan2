using System;
using System.Collections.Generic;
using System.Threading;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.BattleManager;
using Manager.DataManager;
using Photon.Pun;
using Repository;
using UI.Battle;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Player.Common
{
    public partial class PlayerCore : MonoBehaviourPunCallbacks
    {
        private InputManager inputManager;
        private PlayerMove playerMove;

        private PutBomb putBomb;
        private PhotonView playerPhotonView;
        private Animator animator;
        private PlayerDead playerDead;
        private ObservableStateMachineTrigger animatorTrigger;
        private CharacterStatusManager characterStatusManager;
        private const int DeadHp = 0;
        private const int InvincibleDuration = 2;
        private const float WaitDuration = 0.3f;
        private bool isDamage;
        private bool isInvincible;
        private Renderer playerRenderer;
        private BoxCollider boxCollider;
        private CancellationToken cancellationToken;
        private SkillBase skillOne;
        private SkillBase skillTwo;
        private string hpKey;
        private readonly Subject<Unit> deadSubject = new();
        private StateMachine<PlayerCore> stateMachine;

        //Todo 仮の値
        private const float SkillOneIntervalTime = 3f;
        private const float SkillTwoIntervalTime = 5f;

        private enum PLayerState
        {
            Idle,
            Dead,
            NormalSkill,
            SpecialSkill,
        }

        public IObservable<Unit> DeadObservable => deadSubject;


        public void Initialize
        (
            CharacterStatusManager manager,
            string key,
            UserData userData,
            LevelMasterDataRepository levelMasterDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository
        )
        {
            hpKey = key;
            characterStatusManager = manager;
            InitializeComponent(userData, levelMasterDataRepository, weaponMasterDataRepository);
            InitializeState();
        }

        private void InitializeComponent
        (
            UserData userData,
            LevelMasterDataRepository levelMasterDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository
        )
        {
            playerPhotonView = GetComponent<PhotonView>();
            inputManager = gameObject.AddComponent<InputManager>();
            inputManager.Initialize
            (
                playerPhotonView,
                SkillOneIntervalTime,
                SkillTwoIntervalTime,
                userData,
                levelMasterDataRepository,
                weaponMasterDataRepository
            );
            putBomb = GetComponent<PutBomb>();
            animator = GetComponent<Animator>();
            animatorTrigger = animator.GetBehaviour<ObservableStateMachineTrigger>();
            playerDead = gameObject.AddComponent<PlayerDead>();
            playerMove = gameObject.AddComponent<PlayerMove>();
            playerMove.Initialize(characterStatusManager.Speed);
            playerRenderer = GetComponentInChildren<Renderer>();
            boxCollider = GetComponent<BoxCollider>();
            cancellationToken = gameObject.GetCancellationTokenOnDestroy();
        }

        private void InitializeState()
        {
            stateMachine = new StateMachine<PlayerCore>(this);
            stateMachine.Start<PlayerIdleState>();
            stateMachine.AddAnyTransition<PlayerDeadState>((int)PLayerState.Dead);
            stateMachine.AddAnyTransition<PlayerIdleState>((int)PLayerState.Idle);
            stateMachine.AddTransition<PlayerIdleState, PlayerSkillOneState>((int)PLayerState.NormalSkill);
            stateMachine.AddTransition<PlayerIdleState, PlayerSkillTwoState>((int)PLayerState.SpecialSkill);
        }

        private void Update()
        {
            if (!playerPhotonView.IsMine)
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
                if (playerRenderer == null)
                {
                    break;
                }

                playerRenderer.enabled = false;
                await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration), cancellationToken: cancellationToken);
                if (playerRenderer == null)
                {
                    break;
                }

                playerRenderer.enabled = true;
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
            playerRenderer.enabled = true;
        }

        private void Dead(Explosion explosion)
        {
            playerDead.OnTouchExplosion(explosion);
            stateMachine.Dispatch((int)PLayerState.Dead);
        }

        private void OnDestroy()
        {
            characterStatusManager.Dispose();
            deadSubject.Dispose();
        }
    }
}