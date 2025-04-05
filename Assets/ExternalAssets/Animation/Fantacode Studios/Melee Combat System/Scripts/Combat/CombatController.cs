using FS_ThirdPerson;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace FS_ThirdPerson
{
    public static partial class AnimatorParameters
    {
        public static int combatMode = Animator.StringToHash("combatMode");
        public static int strafeSpeed = Animator.StringToHash("strafeSpeed");
    }
}
namespace FS_CombatSystem
{

    public enum TargetSelectionCriteria { DirectionAndDistance, Direction, Distance }

    public class CombatController : SystemBase
    {
        [SerializeField] float moveSpeed = 2f;
        [SerializeField] float rotationSpeed = 500f;

        [Tooltip("Criteria used for selecting the target enemy the player should attack")]
        [SerializeField] TargetSelectionCriteria targetSelectionCriteria;

        [Tooltip("Increase this value if direction should be given more weight than distance for selecting the target. If distance should be given more weight, then decrease it.")]
        [HideInInspector] public float directionScaleFactor = 0.1f;

        public MeleeFighter meleeFighter { get; private set; }
        public Vector3 InputDir { get; private set; }

        Animator animator;
        AnimGraph animGraph;
        CharacterController characterController;
        CombatInputManager inputManager;
        LocomotionController locomotionController;
        ICharacter player;
        PlayerController playerController;
        EnemyController targetEnemy;

        List<Collider> colliders = new List<Collider>();
        bool isGrounded;
        float ySpeed;
        Quaternion targetRotation;
        bool combatMode;
        bool prevCombatMode;
        float _moveSpeed;

        public EnemyController TargetEnemy
        {
            get => targetEnemy;
            set
            {
                if (targetEnemy != value)
                {
                    targetEnemy?.OnRemovedAsTarget?.Invoke();
                    targetEnemy = value;
                    meleeFighter.Target = targetEnemy?.Fighter;
                    targetEnemy?.OnSelectedAsTarget?.Invoke();
                }

                if (targetEnemy == null)
                {
                    CombatMode = false;
                }
            }
        }

        public override SystemState State => SystemState.Combat;

        public bool CombatMode
        {
            get => combatMode;
            set
            {
                combatMode = value;
                if (TargetEnemy == null)
                    combatMode = false;
                if (prevCombatMode != combatMode)
                {
                    if (combatMode)
                    {
                        player.OnStartSystem(this);
                    }
                    else if (!meleeFighter.IsBusy)
                    {
                        player.OnEndSystem(this);
                    }
                    prevCombatMode = combatMode;
                }


                animator?.SetBool(AnimatorParameters.combatMode, combatMode);
            }
        }
        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            player = GetComponent<ICharacter>();
            characterController = GetComponent<CharacterController>();
            meleeFighter = GetComponent<MeleeFighter>();
            inputManager = GetComponent<CombatInputManager>();
            locomotionController = GetComponent<LocomotionController>();
            animGraph = GetComponent<AnimGraph>();

            _moveSpeed = moveSpeed;
        }
        private void Start()
        {
            animator = player.Animator;

            inputManager.OnAttackPressed += OnAttackPressed;

            meleeFighter.IsPlayerForDebug = true;

            meleeFighter.OnGotHit += (MeleeFighter attacker, Vector3 hitPoint, float hittingTime, bool isBlockedHit) =>
            {
                CombatMode = true;
                if (attacker != TargetEnemy.Fighter)
                    TargetEnemy = attacker.GetComponent<EnemyController>();
            };
            meleeFighter.OnAttack += (target) => { if (target != null) CombatMode = true; };

            locomotionController.OnStateExited += () =>
            {
                if (playerController.CurrentSystemState != SystemState.Combat)
                {
                    playerController.WaitToStartSystem = true;

                    meleeFighter.QuickSwitchWeapon();

                    StartCoroutine(AsyncUtil.RunAfterFrames(1, () => playerController.WaitToStartSystem = false));

                    locomotionController.HandleTurningAnimation(true);
                    locomotionController.ResetMoveSpeed();
                    meleeFighter.CanTakeHit = false;
                }
                meleeFighter.CanSwitchWeapon = false;
            };
            locomotionController.OnStateEntered += () =>
            {
                meleeFighter.CanTakeHit = true;
                meleeFighter.CanSwitchWeapon = true;
            };


            meleeFighter.OnDeath += Death;
            meleeFighter.OnWeaponEquipAction += (WeaponData weaponData, bool playSwitchingAnimation) =>
            {
                locomotionController.HandleTurningAnimation(false);

                if (weaponData.OverrideMoveSpeed)
                {
                    locomotionController.ChangeMoveSpeed(weaponData.WalkSpeed, weaponData.RunSpeed, weaponData.SprintSpeed);
                    moveSpeed = weaponData.CombatModeSpeed;
                }

            };
            meleeFighter.OnWeaponUnEquipAction += (WeaponData weaponData, bool playSwitchingAnimation) =>
            {
                locomotionController.HandleTurningAnimation(true);
                locomotionController.ResetMoveSpeed();
                moveSpeed = _moveSpeed;
            };

            meleeFighter.OnStartAction += () => { player.OnStartSystem(this); player.UseRootMotion = true; };
            meleeFighter.OnEndAction += () =>
            {
                if (!combatMode) player.OnEndSystem(this);
                player.UseRootMotion = false;
            };
            meleeFighter.OnResetFighter += () =>
            {
                player.PreventAllSystems = false;
                characterController.enabled = true;
                colliders.ForEach(c => c.enabled = true);
            };
        }

        void OnAttackPressed(float holdTime, bool isHeavyAttack, bool isCounter, bool isCharged, bool isSpecialAttack)
        {
            if (playerController.FocusedSystemState != SystemState.Locomotion && playerController.FocusedSystemState != SystemState.Combat) return;
            if (TargetEnemy == null && isCounter && !CombatSettings.i.SameInputForAttackAndCounter) return;

            if (isGrounded && !meleeFighter.IsDead)
            {
                var dirToAttack = player.MoveDir == Vector3.zero ? transform.forward : player.MoveDir;

                var enemyToAttack = EnemyManager.i?.GetEnemyToTarget(dirToAttack);
                if (enemyToAttack != null)
                    TargetEnemy = enemyToAttack;

                if (CombatSettings.i.SameInputForAttackAndCounter)
                {
                    if (meleeFighter.IsBeingAttacked && meleeFighter.CurrAttacker.AttackState == AttackStates.Windup)
                        isCounter = true;
                    else
                        isCounter = false;
                }

                meleeFighter.TryToAttack(enemyToAttack?.Fighter, isHeavyAttack: isHeavyAttack, isCounter: isCounter, isCharged: isCharged, isSpecialAttack: isSpecialAttack);
            }
        }

        void Death()
        {
            characterController.enabled = false;
            colliders = GetComponentsInChildren<Collider>().ToList().Where(c => c.enabled).ToList();
            foreach (var collider in colliders)
                collider.enabled = false;

            player.UseRootMotion = false;
            player.PreventAllSystems = true;
            player.OnEndSystem(this);
        }

        public Vector3 GetTargetingDir()
        {
            if (!CombatMode)
            {
                var vecFromCam = transform.position - Camera.main.transform.position;
                vecFromCam.y = 0f;
                return vecFromCam.normalized;
            }
            else
            {
                return transform.forward;
            }
        }


        public override void HandleUpdate()
        {
            if (IsInFocus)
                GroundCheck();
            else
                isGrounded = player.IsGrounded;

            if (isGrounded)
            {
                ySpeed = -0.5f;
            }
            else
            {
                ySpeed += Physics.gravity.y * Time.deltaTime;
            }


            if (meleeFighter.CurrentWeapon == null || meleeFighter.CurrentHealth <= 0)
            {
                CombatMode = false;
                return;
            }

            //if (CombatMode && !isInFocus)
            //    player.OnStartAction(this);
            //else if (!CombatMode && isInFocus && !meeleFighter.IsBusy)
            //    player.OnEndAction(this);

            if (inputManager.CombatMode && !meleeFighter.IsBusy)
                CombatMode = !combatMode;

            meleeFighter.IsBlocking = inputManager.Block && (!meleeFighter.IsBusy || meleeFighter.State == FighterState.TakingBlockedHit) && meleeFighter.CurrentWeapon.CanBlock;

            if (meleeFighter.IsBlocking && !CombatMode)
                CombatMode = true;

            if (meleeFighter.CanDodge && inputManager.Dodge && !meleeFighter.IsBusy)
            {
                if (meleeFighter.OnlyDodgeInCombatMode && !IsInFocus) return;

                StartCoroutine(meleeFighter.Dodge(player.MoveDir));
                return;
            }

            if (meleeFighter.CanRoll && inputManager.Roll && !meleeFighter.IsBusy)
            {
                if (meleeFighter.OnlyRollInCombatMode && !IsInFocus) return;

                StartCoroutine(meleeFighter.Roll(player.MoveDir));
                return;
            }

            if (!CombatMode)
            {
                ApplyAnimationGravity();
                return;
            }

            if (meleeFighter != null && (meleeFighter.InAction || meleeFighter.CurrentHealth <= 0))
            {
                targetRotation = transform.rotation;
                animator.SetFloat(AnimatorParameters.moveAmount, 0f);
                ApplyAnimationGravity();
                return;
            }

            float h = player.MoveDir.x;
            float v = player.MoveDir.z;

            float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

            var moveDir = player.MoveDir;
            InputDir = player.MoveDir;

            var velocity = moveDir * moveSpeed;

            // Rotate and face the target enemy
            Vector3 targetVec = transform.forward;
            if (TargetEnemy != null)
            {
                targetVec = TargetEnemy.transform.position - transform.position;
                targetVec.y = 0;
            }

            if (moveAmount > 0)
            {
                targetRotation = Quaternion.LookRotation(targetVec);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                    rotationSpeed * Time.deltaTime);
            }


            // Split the velocity into it's forward and sideward component and set it into the forwardSpeed and strafeSpeed
            float forwardSpeed = Vector3.Dot(velocity, transform.forward);
            animator.SetFloat(AnimatorParameters.moveAmount, forwardSpeed / moveSpeed, 0.2f, Time.deltaTime);

            float angle = Vector3.SignedAngle(transform.forward, velocity, Vector3.up);
            float strafeSpeed = Mathf.Sin(angle * Mathf.Deg2Rad);
            animator.SetFloat(AnimatorParameters.strafeSpeed, strafeSpeed, 0.2f, Time.deltaTime);


            if (meleeFighter.CurrentWeapon.UseRootmotion)
            {
                velocity = animator.deltaPosition;
                transform.rotation *= animator.deltaRotation;
            }
            else
                velocity = velocity * Time.deltaTime;

            velocity.y = ySpeed * Time.deltaTime;

            (moveDir, velocity) = locomotionController.LedgeMovement(moveDir, velocity);
            if (!meleeFighter.StopMovement)
                characterController.Move(velocity);
        }
        public void ApplyAnimationGravity()
        {
            if (animGraph.currentClipStateInfo.isPlayingAnimation && animGraph.currentClipStateInfo.currentClipInfo.useGravity && !meleeFighter.IsMatchingTarget)
            {
                ySpeed += Physics.gravity.y * Time.deltaTime;
                characterController.Move(ySpeed * Vector3.up * animGraph.currentClipInfo.gravityModifier.GetValue(animGraph.currentClipStateInfo.normalizedTime) * Time.deltaTime);
            }
        }

        public override void HandleOnAnimatorMove(Animator animator)
        {
            if (player.UseRootMotion && !meleeFighter.StopMovement)
            {
                //if (meleeFighter.IsDead)
                //    Debug.Log("Using root motion for death - Matching target - " + meleeFighter.IsMatchingTarget);
                transform.rotation *= animator.deltaRotation;

                var deltaPos = animator.deltaPosition;

                if (meleeFighter.IsMatchingTarget)
                    deltaPos = meleeFighter.MatchingTargetDeltaPos;
                var (newDeltaDir, newDelta) = locomotionController.LedgeMovement(deltaPos.normalized, deltaPos);
                if (locomotionController.isOnLedge) return;

                if (meleeFighter.IgnoreCollisions)
                    transform.position += newDelta;
                else
                    characterController.Move(newDelta);
            }
        }

        void GroundCheck()
        {
            isGrounded = Physics.CheckSphere(transform.TransformPoint(locomotionController.GroundCheckOffset), locomotionController.GroundCheckRadius, locomotionController.groundLayer);
            animator.SetBool(AnimatorParameters.IsGrounded, isGrounded);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0, 1, 0, 0.5f);
            //Gizmos.DrawSphere(transform.TransformPoint(locomotionController.GroundCheckOffset), locomotionController.GroundCheckRadius);
        }

        public override void EnterSystem()
        {
            meleeFighter.CanSwitchWeapon = true;
            playerController.WaitToStartSystem = true;
        }

        private void OnGUI()
        {
            //GUI.color = Color.black;
            //if (targetEnemy != null)
            //    GUI.Label(new Rect(0, 0, Screen.currentResolution.width, Screen.currentResolution.height),Vector3.Distance(transform.position, targetEnemy.transform.position).ToString());
        }

        public TargetSelectionCriteria TargetSelectionCriteria => targetSelectionCriteria;
    }
}