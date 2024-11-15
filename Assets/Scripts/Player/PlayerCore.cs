using System;
using System.Threading;
using Bomb;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.BattleManager;
using Manager.NetworkManager;
using Pathfinding.Examples.RTS;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Player.Common
{
    public partial class PlayerCore : MonoBehaviourPunCallbacks
    {
        private ApplyStatusSkillUseCase applyStatusSkillUseCase;
        private PhotonNetworkManager photonNetworkManager;
        private InputManager inputManager;
        private PlayerMove playerMove;
        private PutBomb putBomb;
        private Animator animator;
        private ObservableStateMachineTrigger observableStateMachineTrigger;
        private TranslateStatusForBattleUseCase translateStatusForBattleUseCase;
        private const int DeadHp = 0;
        private const int InvincibleDuration = 2;
        private const float WaitDuration = 0.3f;
        private bool isDamage;
        private bool isInvincible;
        private Renderer playerRenderer;
        private BoxCollider boxCollider;
        private SkillBase skillOne;
        private SkillBase skillTwo;
        private string hpKey;
        private readonly Subject<Unit> deadSubject = new();
        private StateMachine<PlayerCore> stateMachine;
        private CancellationToken cancellationToken;
        private readonly Subject<(StatusType statusType, float value)> statusBuffSubject = new();
        private readonly Subject<(StatusType statusType, int speed, bool isBiff, bool isDebuff)> statusBuffUiSubject = new();
        public IObservable<Unit> DeadObservable => deadSubject;
        public IObservable<(StatusType statusType, int speed, bool isBuff, bool isDebuff)> StatusBuffUiObservable => statusBuffUiSubject;

        private enum PLayerState
        {
            Idle,
            Dead,
            NormalSkill,
            SpecialSkill,
        }


        public void Initialize
        (
            TranslateStatusForBattleUseCase forBattleUseCase,
            PhotonNetworkManager networkManager,
            ApplyStatusSkillUseCase applyStatusSkill,
            string key
        )
        {
            hpKey = key;
            translateStatusForBattleUseCase = forBattleUseCase;
            photonNetworkManager = networkManager;
            applyStatusSkillUseCase = applyStatusSkill;
            InitializeComponent();
            InitializeState();
        }

        private void InitializeComponent()
        {
            inputManager = gameObject.AddComponent<InputManager>();
            inputManager.Initialize(photonView, photonNetworkManager);
            putBomb = GetComponent<PutBomb>();
            animator = GetComponent<Animator>();
            observableStateMachineTrigger = animator.GetBehaviour<ObservableStateMachineTrigger>();
            playerMove = gameObject.AddComponent<PlayerMove>();
            playerMove.Initialize(statusBuffSubject, translateStatusForBattleUseCase.Speed);
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
            stateMachine.AddTransition<PlayerIdleState, PlayerNormalSkillState>((int)PLayerState.NormalSkill);
            stateMachine.AddTransition<PlayerIdleState, PlayerSpecialSkillState>((int)PLayerState.SpecialSkill);
        }

        private void Update()
        {
            if (!photonView.IsMine)
            {
                return;
            }

            stateMachine.Update();
            inputManager.UpdateSkillUI();
            OnInvincible();
        }

        private void OnTriggerEnter(Collider other)
        {
            OnDamage(other.gameObject).Forget();
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

        private async UniTaskVoid OnDamage(GameObject other)
        {
            if (!other.CompareTag(GameCommonData.BombEffectTag) || isDamage)
            {
                return;
            }

            var explosion = other.GetComponentInParent<Explosion>();
            translateStatusForBattleUseCase.CurrentHp -= explosion.damageAmount;
            var hpRate = translateStatusForBattleUseCase.CurrentHp / (float)translateStatusForBattleUseCase.MaxHp;
            SynchronizedValue.Instance.SetValue(hpKey, hpRate);
            if (translateStatusForBattleUseCase.CurrentHp <= DeadHp)
            {
                Dead().Forget();
                return;
            }

            isDamage = true;
            await UniTask.Delay(TimeSpan.FromSeconds(InvincibleDuration), cancellationToken: cancellationToken);
            isDamage = false;
            if (playerRenderer == null)
            {
                return;
            }

            playerRenderer.enabled = true;
        }

        private async UniTask Dead()
        {
            await UniTask.Delay(500, cancellationToken: cancellationToken);
            stateMachine.Dispatch((int)PLayerState.Dead);
        }

        private void OnDestroy()
        {
            translateStatusForBattleUseCase.Dispose();
            deadSubject.Dispose();
            statusBuffSubject.Dispose();
        }
    }
}