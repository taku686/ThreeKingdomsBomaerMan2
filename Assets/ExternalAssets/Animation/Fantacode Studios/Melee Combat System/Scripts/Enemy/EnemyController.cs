using FS_ThirdPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
namespace FS_CombatSystem
{

    public enum EnemyStates { Idle, CombatMovement, Attack, RetreatAfterAttack, Dead, GettingHit }

    public class EnemyController : MonoBehaviour
    {
        [field: SerializeField] public float Fov { get; private set; } = 180f;
        [field: SerializeField] public float AlertRange { get; private set; } = 20f;
        [field: SerializeField] public float WalkSpeed { get; private set; } = 2f;
        [field: SerializeField] public float RunSpeed { get; private set; } = 4.5f;
        [field: SerializeField] public float CombatModeSpeed { get; private set; } = 2f;

        [Range(0, 100f)]
        [SerializeField] float chanceForBlockingAttack = 0f;


        public List<MeleeFighter> TargetsInRange { get; set; } = new List<MeleeFighter>();

        public float CombatMovementTimer { get; set; } = 0f;

        public StateMachine<EnemyController> StateMachine { get; private set; }

        Dictionary<EnemyStates, State<EnemyController>> stateDict;

        public event Action<EnemyStates> OnStateChanged;

        public NavMeshAgent NavAgent { get; private set; }
        public CharacterController CharacterController { get; private set; }
        public Animator Animator { get; private set; }
        public MeleeFighter Fighter { get; private set; }
        public VisionSensor VisionSensor { get; set; }

        public LayerMask obstacleMask = 1;

        public Action OnSelectedAsTarget;
        public Action OnRemovedAsTarget;

        float blockingTimer = 0f;

        private void Start()
        {
            NavAgent = GetComponent<NavMeshAgent>();
            CharacterController = GetComponent<CharacterController>();
            Animator = GetComponent<Animator>();
            Animator.fireEvents = false;
            Fighter = GetComponent<MeleeFighter>();

            stateDict = new Dictionary<EnemyStates, State<EnemyController>>();
            stateDict[EnemyStates.Idle] = GetComponent<IdleState>();
            stateDict[EnemyStates.CombatMovement] = GetComponent<CombatMovementState>();
            stateDict[EnemyStates.Attack] = GetComponent<AttackState>();
            stateDict[EnemyStates.RetreatAfterAttack] = GetComponent<RetreatAfterAttackState>();
            stateDict[EnemyStates.Dead] = GetComponent<DeadState>();
            stateDict[EnemyStates.GettingHit] = GetComponent<GettingHitState>();

            StateMachine = new StateMachine<EnemyController>(this);
            StateMachine.ChangeState(stateDict[EnemyStates.Idle]);

            Fighter.OnBeingAttacked += (MeleeFighter attacker) =>
            {
                if (Fighter.CurrentWeapon != null && Fighter.CurrentWeapon.CanBlock && !Fighter.IsBlocking && !Fighter.IsBusy && Fighter.Target != null)
                {
                    if (UnityEngine.Random.Range(0, 100) <= chanceForBlockingAttack)
                    {
                        Fighter.IsBlocking = true;
                        blockingTimer = UnityEngine.Random.Range(1f, 2f);
                    }
                }
            };

            Fighter.OnGotHit += (MeleeFighter attacker, Vector3 hitPoint, float hittingTime, bool isBlockedHit) =>
            {
                if (Fighter.CurrentHealth > 0)
                {
                    if (Fighter.Target == null)
                    {
                        Fighter.Target = attacker;
                        AlertNearbyEnemies();
                    }

                    if (!isBlockedHit)
                        ChangeState(EnemyStates.GettingHit);
                }
                else
                    ChangeState(EnemyStates.Dead);
            };

            Fighter.OnWeaponEquipAction += (WeaponData weaponData, bool playSwitchingAnimation) =>
            {
                if (weaponData.OverrideMoveSpeed)
                {
                    WalkSpeed = weaponData.WalkSpeed;
                    RunSpeed = weaponData.RunSpeed;
                    CombatModeSpeed = weaponData.CombatModeSpeed;
                }
            };

            Fighter.OnResetFighter += () =>
            {
                CharacterController.enabled = true;
                colliders.ForEach(c => c.enabled = true);
                Fighter.StopMovement = false;
            };
            // Fighter.EquipDefaultWeapon(false);
            Fighter.OnDeath += Death;

            prevPos = transform.position;
        }
        List<Collider> colliders = new List<Collider>();
        public void Death()
        {
            CharacterController.enabled = false;
            colliders = GetComponentsInChildren<Collider>().ToList().Where(c => c.enabled).ToList();
            colliders.ForEach(c => c.enabled = false);
            Fighter.StopMovement = true;

            Fighter.SetRagdollState(true);

        }

        public EnemyStates currState;
        public void ChangeState(EnemyStates state)
        {
            currState = state;
            OnStateChanged?.Invoke(state);
            StateMachine.ChangeState(stateDict[state]);
        }

        public bool IsInState(EnemyStates state)
        {
            return StateMachine.CurrentState == stateDict[state];
        }

        Vector3 prevPos;
        private void Update()
        {
            if (Fighter.IsBlocking)
            {
                if (blockingTimer > 0f)
                    blockingTimer -= Time.deltaTime;

                if (blockingTimer <= 0f || (Fighter.State != FighterState.TakingBlockedHit && Fighter.State != FighterState.Blocking))
                    Fighter.IsBlocking = false;
            }

            if (Fighter.InAction)
            {
                prevPos = transform.position;
                Animator.SetFloat(AnimatorParameters.moveAmount, 0f, 0.2f, Time.deltaTime);
                Animator.SetFloat(AnimatorParameters.strafeSpeed, 0f, 0.2f, Time.deltaTime);

                return;
            }

            StateMachine.Execute();

            // v = dx / dt
            var deltaPos = transform.position - prevPos;
            var velocity = deltaPos / Time.deltaTime;

            float forwardSpeed = Vector3.Dot(velocity, transform.forward);
            Animator.SetFloat(AnimatorParameters.moveAmount, forwardSpeed / NavAgent.speed, 0.2f, Time.deltaTime);

            float angle = Vector3.SignedAngle(transform.forward, velocity, Vector3.up);
            float strafeSpeed = Mathf.Sin(angle * Mathf.Deg2Rad);
            Animator.SetFloat(AnimatorParameters.strafeSpeed, strafeSpeed, 0.2f, Time.deltaTime);

            if (Fighter.Target?.CurrentHealth <= 0)
            {
                TargetsInRange.Remove(Fighter.Target);
                EnemyManager.i.RemoveEnemyInRange(this);
            }

            prevPos = transform.position;
        }

        private void OnAnimatorMove()
        {
            if (Fighter.InAction && !Fighter.StopMovement)
            {
                transform.rotation *= Animator.deltaRotation;
                var deltaPos = Animator.deltaPosition;

                if (Fighter.IsMatchingTarget)
                    deltaPos = Fighter.MatchingTargetDeltaPos;

                if (LedgeMovement(deltaPos.normalized, deltaPos)) return;

                if (Fighter.IgnoreCollisions)
                    transform.position += deltaPos;
                else if(CharacterController.enabled)
                    CharacterController.Move(deltaPos);

            }
        }

        public bool LedgeMovement(Vector3 currMoveDir, Vector3 currVelocity)
        {
            if (currMoveDir == Vector3.zero) return false;

            float yOffset = 1f;
            float xOffset = 0.7f;

            var radius = 0.2f; // can control moveAngle here
            float maxAngle = 60f;

            RaycastHit  newHit;
            var positionOffset = transform.position + currMoveDir * xOffset;

            var ledgeHeightThreshold = 1.4f;

            if (!(Physics.SphereCast(positionOffset + Vector3.up * yOffset /* + Vector3.up * radius */, radius, Vector3.down, out newHit, yOffset + ledgeHeightThreshold, obstacleMask)) || ((newHit.distance - yOffset) > ledgeHeightThreshold && Vector3.Angle(Vector3.up, newHit.normal) > maxAngle))
            {
                return true;

            }

            return false;
        }

        public MeleeFighter FindTarget()
        {
            foreach (var target in TargetsInRange)
            {
                var vecToTarget = target.transform.position - transform.position;
                float angle = Vector3.Angle(transform.forward, vecToTarget);

                if (angle <= Fov / 2 && LineOfSightCheck(target))
                {
                    return target;
                }
            }
            return null;
        }

        public bool LineOfSightCheck(MeleeFighter target)
        {
            var headPos = Animator.GetBoneTransform(HumanBodyBones.Neck).position;
            var targetPos = target.transform.position + Vector3.up * 0.7f;


            //var dir = (transform.position - target.transform.position).normalized;

            //var navAgentRaycast = NavAgent.Raycast(target.transform.position + dir * 0.3f,out NavMeshHit navMeshHit);
            return !NavAgent.isOnOffMeshLink && !Physics.SphereCast(headPos, 0.2f, (targetPos - headPos), out RaycastHit info, (targetPos - headPos).magnitude, obstacleMask);
        }

        public void AlertNearbyEnemies()
        {
            var colliders = Physics.OverlapBox(transform.position, new Vector3(AlertRange / 2f, 1f, AlertRange / 2f),
                Quaternion.identity, 1 << gameObject.layer);

            foreach (var collider in colliders)
            {
                if (collider.gameObject == gameObject) continue;

                var nearbyEnemy = collider.GetComponent<EnemyController>();
                if (nearbyEnemy != null && nearbyEnemy.Fighter.Target == null)
                {
                    StartCoroutine(AsyncUtil.RunAfterDelay(0.5f, () =>
                    {
                        nearbyEnemy.Fighter.Target = Fighter.Target;
                        nearbyEnemy.ChangeState(EnemyStates.CombatMovement);
                    }));
                }
            }
        }

        public float DistanceToTarget { get; private set; }
        public float CalculateDistanceToTarget()
        {
            if (Fighter.Target == null) return 999;

            DistanceToTarget = Vector3.Distance(transform.position, Fighter.Target.transform.position);
            return DistanceToTarget;
        }

        private void OnDisable()
        {
            EnemyManager.i.RemoveEnemyInRange(this);
        }
    }
}