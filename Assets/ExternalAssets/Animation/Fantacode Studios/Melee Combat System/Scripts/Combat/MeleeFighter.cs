using FS_ThirdPerson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
namespace FS_CombatSystem
{
    public enum AttackStates { Idle, Windup, Impact, Cooldown }
    public enum FighterState { None, Attacking, Blocking, Dodging, TakingHit, TakingBlockedHit, KnockedDown, GettingUp, SwitchingWeapon, Dead, Taunt, Other }

    public class MeleeFighter : MonoBehaviour
    {

        public bool StopMovement { get; set; } = false;

        [Tooltip("Default weapon of the fighter")]
        public WeaponData weapon;

        [field: SerializeField] public float MaxHealth { get; private set; } = 25f;

        [SerializeField] float rotationSpeedDuringAttack = 500f;
        [field: SerializeField] public float PreferredFightingRange { get; private set; } = 2f;

        [Header("Optional Parameters")]
        public DefaultReactions defaultAnimations = new DefaultReactions();

        [SerializeField] List<AttachedWeapon> attachedWeapons = new List<AttachedWeapon>();

        public float CurrentHealth { get; private set; }

        // Maximium range at which the fighter can perform an attack (Will be computed automatically)
        public float MaxAttackRange { get; private set; }

        // States
        public FighterState State { get; private set; }
        public AttackStates AttackState { get; private set; }
        public bool InAction => State != FighterState.None && State != FighterState.Blocking;
        public bool IsDead => State == FighterState.Dead;
        public bool IsBusy => InAction || IsDead;
        public bool IsKnockedDown => State == FighterState.KnockedDown || State == FighterState.TakingHit && prevState == FighterState.KnockedDown;
        public bool IsCounterable => AttackState == AttackStates.Windup && (!CombatSettings.i.OnlyCounterFirstAttackOfCombo || comboCount == 0);
        public bool IsMatchingTarget { get; private set; } = false;
        public bool IsInSyncedAnimation { get; private set; } = false;
        public AttackData CurrSyncedAction { get; private set; }    // To avoid on attack to prevent reseting IsInSyncedAnimation set by another attack

        public bool CanTakeHit { get; set; } = true;    // While false, AI won't try to hit player
        public bool IsInvinsible { get; set; } = false;  // While true, the AI will hit the player, but it won't have any effect

        bool isBlocking;
        public bool IsBlocking
        {
            get => isBlocking;
            set
            {
                bool wasPreviouslyBlocking = isBlocking;
                isBlocking = value;
                HandleBlockingChanged(wasPreviouslyBlocking);
            }
        }

        public MeleeFighter Target { get; set; }
        MeleeFighter attackingTarget;

        public bool IsBeingAttacked { get; private set; } = false;
        public MeleeFighter CurrAttacker { get; private set; }


        public WeaponData CurrentWeapon { get; set; }
        public GameObject CurrentWeaponObject { get; set; }
        public AttachedWeapon CurrentWeaponHandler { get; set; }
        public Vector3 MatchingTargetDeltaPos { get; private set; } = Vector3.zero;


        CapsuleCollider capsuleCollider;
        BoxCollider weaponCollider;
        BoxCollider leftHandCollider, rightHandCollider, leftFootCollider, rightFootCollider;
        BoxCollider leftElbowCollider, rightElbowCollider, leftKneeCollider, rightKneeCollider, headCollider;

        BoxCollider activeCollider;
        Vector3 prevColliderPos;
        GameObject prevGameObj;

        Animator animator;
        AnimGraph animGraph;
        AnimatorOverrideController defaultAnimatorController;
        CharacterController characterController;

        bool useGraph = true;
        bool doCombo;
        int comboCount = 0;
        int hitCount = 0;

        [Tooltip("Indicates if the fighter can dodge.")]
        [HideInInspector] public bool CanDodge;
        [HideInInspector] public DodgeData dodgeData;

        [Tooltip("If true, fighter will only be able to dodge in combat mode.")]
        [HideInInspector] public bool OnlyDodgeInCombatMode = true;

        [Tooltip("Indicates if the fighter can roll.")]
        [HideInInspector] public bool CanRoll;
        [HideInInspector] public DodgeData rollData;

        [Tooltip("If true, fighter will only be able to roll in combat mode.")]
        [HideInInspector] public bool OnlyRollInCombatMode = true;


        [Space(10)]

        [HideInInspector] public UnityEvent<WeaponData, bool> OnWeaponEquipEvent;
        [HideInInspector] public UnityEvent<WeaponData, bool> OnWeaponUnEquipEvent;

        public Action<WeaponData, bool> OnWeaponEquipAction;
        public Action<WeaponData, bool> OnWeaponUnEquipAction;


        public event Action<MeleeFighter, Vector3, float, bool> OnGotHit;
        [HideInInspector] public UnityEvent<MeleeFighter, Vector3, float> OnGotHitEvent;

        public event Action<MeleeFighter> OnAttack;
        [HideInInspector] public UnityEvent<MeleeFighter> OnAttackEvent;

        public event Action OnCounterMisused;
        [HideInInspector] public UnityEvent OnCounterMisusedEvent;

        public Action OnStartAction;
        public Action OnEndAction;

        public event Action OnHitComplete;

        public event Action OnDeath;
        [HideInInspector] public UnityEvent OnDeathEvent;

        public event Action OnKnockDown;
        [HideInInspector] public UnityEvent OnKnockDownEvent;

        public event Action OnGettingUp;
        [HideInInspector] public UnityEvent OnGettingUpEvent;


        public event Action OnResetFighter;

        public event Action<AttachedWeapon> OnEnableHit;

        public AttackData CurrAttack { get; private set; }
        public List<AttackSlot> CurrAttacksList { get; private set; }
        public AttackContainer CurrAttackContainer { get; private set; }
        public bool CanSwitchWeapon { get; set; } = true;

        public bool PlayingBlockAnimationEarlier { get; set; } = false;


        private void Awake()
        {
            animator = GetComponent<Animator>();
            animGraph = GetComponent<AnimGraph>();
            characterController = GetComponent<CharacterController>();
            defaultAnimatorController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            capsuleCollider = GetComponent<CapsuleCollider>();

            rigidbodies = GetComponentsInChildren<Rigidbody>().ToList();
            SetRagdollState(false);

            CurrentHealth = MaxHealth;
        }
        private void Start()
        {
            EquipDefaultWeapon(false);
            leftHandCollider = animator.GetBoneTransform(HumanBodyBones.LeftHand)?.GetComponentInChildren<BoxCollider>();
            rightHandCollider = animator.GetBoneTransform(HumanBodyBones.RightHand)?.GetComponentInChildren<BoxCollider>();
            leftFootCollider = animator.GetBoneTransform(HumanBodyBones.LeftFoot)?.GetComponentInChildren<BoxCollider>();
            rightFootCollider = animator.GetBoneTransform(HumanBodyBones.RightFoot)?.GetComponentInChildren<BoxCollider>();

            leftElbowCollider = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm)?.GetComponentsInChildren<BoxCollider>().FirstOrDefault(c => c.name == "LeftElbowCollider");
            rightElbowCollider = animator.GetBoneTransform(HumanBodyBones.RightLowerArm)?.GetComponentsInChildren<BoxCollider>().FirstOrDefault(c => c.name == "RightElbowCollider");
            leftKneeCollider = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg)?.GetComponentsInChildren<BoxCollider>().FirstOrDefault(c => c.name == "LeftKneeCollider");
            rightKneeCollider = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg)?.GetComponentsInChildren<BoxCollider>().FirstOrDefault(c => c.name == "RightKneeCollider");

            headCollider = animator.GetBoneTransform(HumanBodyBones.Head)?.GetComponentInChildren<BoxCollider>();

            OnDeath -= () => OnDeathEvent.Invoke();
            OnDeath += () => OnDeathEvent.Invoke();
        }

        // For testing, remove later
        public bool IsPlayerForDebug { get; set; }

        public void TryToAttack(MeleeFighter target = null, bool isHeavyAttack = false, bool isCounter = false, bool isCharged = false, bool isSpecialAttack = false)
        {
            // Taking Blocked Hit is a special case where counter can be peformed
            if (State != FighterState.TakingBlockedHit)
            {
                if (InAction && State != FighterState.Attacking) return;
                if (IsInSyncedAnimation || target != null && target.IsInSyncedAnimation) return;
            }
            else
                if (!isCounter || !CurrentWeapon.CanCounter) return;

            if (CurrentWeapon == null && weapon != null)
            {
                EquipWeapon(weapon,
                    onComplete: () => HandleAttack(target, isHeavyAttack, isCounter, isCharged, isSpecialAttack));
            }
            else if (CurrentWeapon != null)
            {
                HandleAttack(target, isHeavyAttack, isCounter, isCharged, isSpecialAttack);
            }
        }

        void HandleAttack(MeleeFighter target = null, bool isHeavyAttack = false, bool isCounter = false, bool isCharged = false, bool isSpecialAttack = false)
        {
            Target = target;

            if (!ChooseAttacks(target, comboCount, isHeavyAttack: isHeavyAttack, isCounter: isCounter, isSpecialAttack))
            {
                if (isCounter && CurrentWeapon.PlayActionIfCounterMisused && CurrentWeapon.CounterMisusedAction != null
                    && !InAction && Target != null)
                {
                    StartCoroutine(PlayTauntAction(CurrentWeapon.CounterMisusedAction));
                    OnCounterMisused?.Invoke();
                    OnCounterMisusedEvent?.Invoke();
                }

                return;
            }

            isChargedInput = isCharged;

            if (!InAction || State == FighterState.TakingBlockedHit)
            {
                StartCoroutine(Attack(Target));
            }
            else if (AttackState == AttackStates.Impact || AttackState == AttackStates.Cooldown)
            {
                if (!isCounter)
                    doCombo = true;
            }
        }


        public bool ChooseAttacks(MeleeFighter target = null, int comboCount = 0, bool isHeavyAttack = false, bool isCounter = false, bool isSpecialAttack = false)
        {
            if (CurrAttacksList == null)
                CurrAttacksList = new List<AttackSlot>();

            if (target != null && !target.CanTakeHit) return false;

            // Select Counters
            if (isCounter)
            {
                if (!CurrentWeapon.CanCounter) return false;

                bool counterPossible = ChooseCounterAttacks(target);
                if (!counterPossible)
                    CurrAttacksList = new List<AttackSlot>();

                return counterPossible;
            }

            if (CurrentWeapon.Attacks != null && CurrentWeapon.Attacks.Count > 0)
            {
                var possibleAttacks = CurrentWeapon.Attacks.ToList();
                if (isHeavyAttack) possibleAttacks = CurrentWeapon.HeavyAttacks.ToList();
                if (isSpecialAttack) possibleAttacks = CurrentWeapon.SpecialAttacks.ToList();

                var normalAttacks = possibleAttacks.Where(a => a.AttackType == AttackType.Single || a.AttackType == AttackType.Combo).OrderBy(a => a.MinDistance).ToList();
                var normalAttacksWithoutSyncedAndFinishers = normalAttacks.Where(a => a.AttackSlots.Any(s => !s.Attack.IsSyncedReaction && !s.Attack.IsFinisher)).ToList();

                bool inCombo = State == FighterState.Attacking && CurrAttacksList.Count > 0 && comboCount != CurrAttacksList.Count - 1;

                if (target != null && !target.IsDead)
                {
                    // If target is blocking, then avoid attacks with synced reaction
                    if (target.IsBlocking)
                        possibleAttacks.RemoveAll(a => a.AttackSlots.Any(s => s.Attack.IsSyncedReaction && !s.Attack.IsUnblockableAttack));

                    bool attackerUndetected = target.Target == null;

                    // Filter by attack type
                    if (attackerUndetected)
                        possibleAttacks = possibleAttacks.Where(a => a.AttackType == AttackType.Stealth).ToList();
                    else if (target.IsKnockedDown)
                        possibleAttacks = possibleAttacks.Where(a => a.AttackType == AttackType.GroundAttack).ToList();
                    else
                        possibleAttacks = normalAttacks;

                    // Filter distance & health threshold
                    float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
                    possibleAttacks = possibleAttacks.Where(c => distanceToTarget >= c.MinDistance && distanceToTarget <= c.MaxDistance
                        && (target.CurrentHealth / target.MaxHealth) * 100 <= c.HealthThreshold).ToList();
                    possibleAttacks = possibleAttacks.OrderBy(a => a.HealthThreshold).ToList();
                }
                else
                {
                    // If there is no target, choose closest attack and don't choose synced attacks
                    possibleAttacks = normalAttacksWithoutSyncedAndFinishers;
                }

                if (possibleAttacks.Count > 0)
                {
                    // If a finisher is possible then choose it
                    var possibleFinishers = possibleAttacks.Where(c => c.AttackSlots.Any(a => a.Attack.IsFinisher)).ToList();
                    if (possibleFinishers.Count > 0)
                    {
                        CurrAttacksList = possibleFinishers[Random.Range(0, possibleFinishers.Count)].AttackSlots;
                        return true;
                    }

                    // If it's not a combo or if the target went down in the middle of a combo then change the attack
                    if (!inCombo || (target != null && target.IsKnockedDown))
                    {
                        float lowestHealthTreshold = possibleAttacks.First().HealthThreshold;
                        possibleAttacks = possibleAttacks.Where(a => a.HealthThreshold == lowestHealthTreshold).ToList();

                        CurrAttacksList = possibleAttacks[Random.Range(0, possibleAttacks.Count)].AttackSlots;
                        return true;
                    }
                }
                else
                {
                    // If it's not a combo or if the target went down in the middle of a combo then, try to change the attack
                    if (!inCombo || (target != null && target.IsKnockedDown))
                    {
                        // No possible attacks, then just play the normal attacks if any
                        if (normalAttacksWithoutSyncedAndFinishers.Count > 0)
                        {
                            CurrAttacksList = normalAttacks.First().AttackSlots;
                            return true;
                        }
                        else
                        {
                            Debug.LogWarning("No possible attacks for the given range!");
                            CurrAttacksList = new List<AttackSlot>();
                            return false;
                        }
                    }
                }
            }

            return CurrAttacksList.Count > 0;
        }

        public bool ChooseCounterAttacks(MeleeFighter target)
        {
            if (target == null || target.IsDead) return false;

            if (IsBeingAttacked && CurrAttacker.IsCounterable && (!CombatSettings.i.OnlyCounterWhileBlocking || WillBlockAttack(CurrAttacker.CurrAttack)))
            {
                Target = CurrAttacker;

                var currAttack = CurrAttacker.CurrAttack;
                if (currAttack.CanBeCountered && currAttack.CounterAttacks.Count > 0)
                {
                    var possibleCounters = currAttack.CounterAttacks.Where(a => (target.CurrentHealth / target.MaxHealth) * 100 <= a.HealthThresholdForCounter).
                        OrderBy(a => a.HealthThresholdForCounter).ToList();
                    if (possibleCounters.Count == 0)
                        return false;

                    float lowestHealth = possibleCounters.First().HealthThresholdForCounter;
                    var counterAttack = possibleCounters.Where(a => a.HealthThresholdForCounter == lowestHealth).ToList().
                        GetRandom<CounterAttack>();

                    if (target.CheckIfAttackKills(counterAttack.Attack, this) && !counterAttack.Attack.IsFinisher && !counterAttack.Attack.Reaction.willBeKnockedDown)
                        return false;

                    var counterSlot = new AttackSlot()
                    {
                        Attack = counterAttack.Attack,
                        Container = new AttackContainer() { AttackType = AttackType.Single }
                    };

                    CurrAttacksList = new List<AttackSlot>() { counterSlot };
                    attackStartDelay = counterAttack.CounterStartTime;

                    return true;
                }
            }

            return false;
        }

        Vector3 moveToPos = Vector3.zero;
        bool isChargedInput = false;
        float attackStartDelay = 0f;
        public float AttackTimeNormalized { get; private set; }
        public bool IgnoreCollisions { get; private set; }
        IEnumerator Attack(MeleeFighter target = null)
        {
            StopMovement = false;
            OnStartAction?.Invoke();
            SetState(FighterState.Attacking);
            attackingTarget = target;
            AttackState = AttackStates.Windup;

            var attackSlot = CurrAttacksList[comboCount];
            var attack = attackSlot.Attack;
            if (isChargedInput && attackSlot.CanBeCharged && attackSlot.ChargedAttack != null)
                attack = attackSlot.ChargedAttack;

            bool wasChargedAttack = isChargedInput;
            isChargedInput = false;

            CurrAttack = attack;
            CurrAttackContainer = attackSlot.Container;

            if (attackStartDelay > 0f && target != null && target.CurrAttack != null)
            {
                yield return new WaitUntil(() => target.AttackTimeNormalized >= attackStartDelay);
                attackStartDelay = 0f;
            }

            OnAttack?.Invoke(target);
            var attackDir = transform.forward;
            Vector3 startPos = transform.position;
            Vector3 targetPos = Vector3.zero;
            Vector3 rootMotionScaleFactor = Vector3.one;

            bool willAttackBeBlocked = false;

            bool syncedReactionPlayed = false;
            bool shouldStartBlockingEarlier = false;

            if (target != null)
            {
                willAttackBeBlocked = target.WillBlockAttack(attack);

                target.BeingAttacked(this);

                var vecToTarget = target.transform.position - transform.position;
                vecToTarget.y = 0;

                attackDir = vecToTarget.normalized;
                float distance = vecToTarget.magnitude - attack.DistanceFromTarget;

                // Move to target
                if (attack.MoveToTarget)
                {
                    targetPos = target.transform.position - attackDir * attack.DistanceFromTarget;

                    if (attack.MoveType == TargetMatchType.ScaleRootMotion)
                    {
                        var endFramePos = attack.RootCurves.GetPositionAtTime(attack.MoveEndTime * attack.Clip.length);
                        var startFramePos = attack.RootCurves.GetPositionAtTime(attack.MoveStartTime * attack.Clip.length);

                        var destDisp = targetPos - transform.position;
                        var rootMotionDisp = Quaternion.LookRotation(destDisp) * (endFramePos - startFramePos);

                        // Having a zero value can casue problems when we find the ratio
                        if (rootMotionDisp.x == 0) rootMotionDisp.x = 1;
                        if (rootMotionDisp.y == 0) rootMotionDisp.y = 1;
                        if (rootMotionDisp.z == 0) rootMotionDisp.z = 1;

                        rootMotionScaleFactor = new Vector3(attack.WeightMask.x * destDisp.x / rootMotionDisp.x, attack.WeightMask.y * destDisp.y / rootMotionDisp.y, attack.WeightMask.z * destDisp.z / rootMotionDisp.z);
                    }
                    moveToPos = targetPos;
                    IgnoreCollisions = attack.IgnoreCollisions;

                    if (attack.IsSyncedReaction || attack.IsSyncedBlockedReaction)
                        target.IgnoreCollisions = attack.IgnoreCollisions;

                    if (attack.MoveType == TargetMatchType.Snap)
                    {
                        if (attack.SnapTarget == SnapTarget.Attacker)
                        {
                            if (attack.SnapType == SnapType.LocalPosition)
                                moveToPos = target.transform.TransformPoint(attack.LocalPosFromTarget);

                            transform.position = moveToPos;
                            yield return new WaitForFixedUpdate();
                        }
                        else if (attack.SnapTarget == SnapTarget.Victim)
                        {
                            if (attack.SnapType == SnapType.LocalPosition)
                                moveToPos = transform.TransformPoint(attack.LocalPosFromTarget);
                            else if (attack.SnapType == SnapType.Distance)
                                moveToPos = transform.position + attackDir * attack.DistanceFromTarget;

                            target.transform.position = moveToPos;
                        }
                    }

                }
                if (vecToTarget.magnitude < CurrentWeapon.MinAttackDistance && !attack.IsSyncedReaction && !attack.IsSyncedBlockedReaction && !attack.MoveToTarget)
                {
                    var moveDist = CurrentWeapon.MinAttackDistance - vecToTarget.magnitude;
                    StartCoroutine(target.PullBackCharacter(this, moveDist));
                }

                // Synced Reaction
                if (target.CheckIfAttackKills(attack, this) && !attack.IsFinisher && !attack.Reaction.willBeKnockedDown)
                {
                    IsInSyncedAnimation = target.IsInSyncedAnimation = false;
                }
                else
                {
                    if (willAttackBeBlocked && attack.OverrideBlockedReaction && attack.IsSyncedBlockedReaction)
                        shouldStartBlockingEarlier = true;

                    if (!willAttackBeBlocked && attack.OverrideReaction && attack.IsSyncedReaction)
                        IsInSyncedAnimation = target.IsInSyncedAnimation = true;

                    if (IsInSyncedAnimation)
                        CurrSyncedAction = target.CurrSyncedAction = attack;
                }
            }

            animGraph.CrossFade(attack.Clip, 0.2f, transitionOut: 0.4f, animationSpeed: attack.AnimationSpeed, clipInfo: attack.Clip);

            MatchingTargetDeltaPos = Vector3.zero;
            IsMatchingTarget = false;

            float timer = 0f;
            float attackLength = animGraph.currentClipStateInfo.clipLength;
            while (animGraph.currentClipStateInfo.timer <= attackLength)
            {
                if (State == FighterState.TakingHit || State == FighterState.Dead) break;

                timer = animGraph.currentClipStateInfo.timer;
                float normalizedTime = timer / attackLength;
                AttackTimeNormalized = normalizedTime;

                // Play Synced Reaction
                if (IsInSyncedAnimation && !syncedReactionPlayed)
                {
                    if (!willAttackBeBlocked && attack.OverrideReaction && attack.IsSyncedReaction)
                    {
                        var hittingTimer = Mathf.Clamp(attack.HittingTime * attackLength - timer, 0, attack.HittingTime * attackLength);
                        target.StopMovement = true;
                        if (normalizedTime >= attack.SyncStartTime)
                        {
                            syncedReactionPlayed = true;
                            target.TakeHit(this, reaction: attack.Reaction, willBeBlocked: false, hittingTime: hittingTimer);
                        }
                    }
                }

                if (shouldStartBlockingEarlier)
                {
                    var hittingTimer = Mathf.Clamp(attack.BlockedHittingTime * attackLength - timer, 0, attack.BlockedHittingTime * attackLength);
                    if (normalizedTime >= attack.BlockSyncStartTime)
                    {
                        shouldStartBlockingEarlier = false;
                        target.PlayingBlockAnimationEarlier = true;
                        target.TakeHit(this, reaction: attack.BlockedReaction, willBeBlocked: true, hittingTime: hittingTimer);
                    }
                }

                // Move the attacker towards the target while performing attack
                if (target != null && attack.MoveType != TargetMatchType.Snap
                    && attack.MoveToTarget && normalizedTime >= attack.MoveStartTime && normalizedTime <= attack.MoveEndTime)
                {
                    IsMatchingTarget = true;

                    float percTime = (normalizedTime - attack.MoveStartTime) / (attack.MoveEndTime - attack.MoveStartTime);

                    if (attack.MoveType == TargetMatchType.Linear)
                    {
                        MatchingTargetDeltaPos = (targetPos - startPos) * Time.deltaTime / ((attack.MoveEndTime - attack.MoveStartTime) * attackLength);
                    }
                    else
                    {
                        var disp = Vector3.Scale(animator.deltaPosition, rootMotionScaleFactor);
                        MatchingTargetDeltaPos = disp;
                    }

                }
                else
                {
                    IsMatchingTarget = false;
                }

                // Rotate to the attacking direction
                if (CurrAttack.AlwaysLookAtTheTarget && attackDir != Vector3.zero)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,
                        Quaternion.LookRotation(attackDir), rotationSpeedDuringAttack * Time.deltaTime);
                }
                Vector3 hitPoint = Vector3.zero;
                if (AttackState == AttackStates.Windup)
                {
                    if (normalizedTime >= attack.ImpactStartTime)
                    {
                        AttackState = AttackStates.Impact;
                        EnableActiveCollider(attack);
                        if (activeCollider)
                        {
                            prevColliderPos = activeCollider.transform.TransformPoint(activeCollider.center);
                            prevGameObj = null;
                        }
                    }
                }
                else if (AttackState == AttackStates.Impact)
                {
                    if (!IsInSyncedAnimation)
                        HandleColliderSweep(target);

                    if (normalizedTime >= attack.ImpactEndTime)
                    {
                        AttackState = AttackStates.Cooldown;
                        DisableActiveCollider();
                        prevGameObj = null;
                    }
                }
                else if (AttackState == AttackStates.Cooldown)
                {
                    if (doCombo && CurrAttacksList.Count > 0)
                    {
                        // Don't do combo till wait for attack time is reached
                        if (attack.WaitForNextAttack && normalizedTime < attack.WaitForAttackTime)
                        {
                            yield return null;
                            continue;
                        }

                        // Play next attack from combo
                        doCombo = false;
                        if (wasChargedAttack)
                            comboCount = 0;
                        else
                            comboCount = (comboCount + 1) % CurrAttacksList.Count;

                        if (target == null || !target.IsDead)
                        {
                            if (CurrSyncedAction == attack && (attack.IsSyncedReaction || attack.IsSyncedBlockedReaction))
                            {
                                target.IsInSyncedAnimation = IsInSyncedAnimation = false;
                            }
                            StartCoroutine(Attack(target));
                            yield break;
                        }
                    }
                }

                yield return null;
            }


            if (CurrSyncedAction == attack && (attack.IsSyncedReaction || attack.IsSyncedBlockedReaction))
            {
                target.IsInSyncedAnimation = IsInSyncedAnimation = false;
            }

            if (IgnoreCollisions && !IsInSyncedAnimation)
            {
                IgnoreCollisions = false;
                target.IgnoreCollisions = false;
            }

            if (IsMatchingTarget)
                IsMatchingTarget = false;
            MatchingTargetDeltaPos = Vector3.zero;

            if (target != null)
                target.AttackOver(this);


            AttackState = AttackStates.Idle;
            comboCount = 0;
            attackingTarget = null;
            CurrAttack = null;

            if (State == FighterState.Attacking)
                OnEndAction?.Invoke();

            ResetStateToNone(FighterState.Attacking);
        }

        public bool IsInCounterWindow() => AttackState == AttackStates.Cooldown && !doCombo;

        bool WillBlockAttack(AttackData attack) => IsBlocking && !attack.IsUnblockableAttack;

        void HandleBlockingChanged(bool wasPreviouslyBlocking)
        {
            if (isBlocking && !wasPreviouslyBlocking)
            {
                SetState(FighterState.Blocking);
                animGraph.CrossfadeAvatarMaskAnimation(CurrentWeapon.Blocking, Mask.Hand, mask: CurrentWeapon.BlockMask, transitionInTime: .1f);

            }
            else if (!isBlocking && wasPreviouslyBlocking)
            {
                ResetStateToNone(FighterState.Blocking);
                animGraph.RemoveAvatarMask();

            }
        }

        public IEnumerator Dodge(Vector3 dodgeDir)
        {
            if (CanDodge)
            {
                var dodge = CurrentWeapon != null && CurrentWeapon.OverrideDodge ? CurrentWeapon.DodgeData : dodgeData;

                if (dodgeDir == Vector3.zero)
                    dodgeDir = dodge.GetDodgeDirection(transform, Target?.transform);

                AnimGraphClipInfo dodgeClip = dodge.GetClip(transform, dodgeDir);

                OnStartAction?.Invoke();
                SetState(FighterState.Dodging);
                IsInvinsible = true;

                //animGraph.CrossFade(dodgeClip, 0.2f);

                yield return animGraph.CrossFadeAsync(dodgeClip, 0.2f, onAnimationUpdate: (float normalizedTime, float time) =>
                {
                    if (time <= dodgeClip.length * 0.8f && !dodge.useDifferentClipsForDirections)
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dodgeDir), 1000 * Time.deltaTime);
                }, clipInfo: dodgeClip);

                IsInvinsible = false;
                ResetStateToNone(FighterState.Dodging);
                if (!IsBusy)
                    OnEndAction?.Invoke();
            }
        }

        public IEnumerator Roll(Vector3 rollDir)
        {
            if (CanRoll)
            {
                var roll = CurrentWeapon != null && CurrentWeapon.OverrideRoll ? CurrentWeapon.RollData : rollData;

                if (rollDir == Vector3.zero)
                    rollDir = roll.GetDodgeDirection(transform, Target?.transform);

                AnimGraphClipInfo rollClip = roll.GetClip(transform, rollDir);

                OnStartAction?.Invoke();
                SetState(FighterState.Dodging);
                IsInvinsible = true;

                animGraph.CrossFade(rollClip, 0.2f,clipInfo: rollClip);
                yield return null;

                while (animGraph.currentClipStateInfo.normalizedTime <= 0.9f)
                {
                    if (!roll.useDifferentClipsForDirections)
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rollDir), 1000 * Time.deltaTime);
                    yield return null;
                }

                IsInvinsible = false;
                ResetStateToNone(FighterState.Dodging);
                if (!IsBusy)
                    OnEndAction?.Invoke();
            }
        }

        void HandleColliderSweep(MeleeFighter target)
        {
            var activeBoxCollider = activeCollider;
            Vector3 hitPoint = Vector3.zero;
            if (activeBoxCollider && target != null)
            {
                Vector3 endPoint = activeBoxCollider.transform.TransformPoint(activeBoxCollider.center);

                Vector3 direction = (endPoint - prevColliderPos).normalized;

                float distance = Vector3.Distance(prevColliderPos, endPoint);


                Vector3 halfExtents = Vector3.Scale(activeBoxCollider.size, activeBoxCollider.transform.localScale) * 0.5f;
                Quaternion orientation = activeBoxCollider.transform.rotation;

                RaycastHit hit;
                var checkCollision = Physics.OverlapBox(prevColliderPos, halfExtents, orientation, 1 << target.gameObject.layer, QueryTriggerInteraction.Collide);
                //GizmosExtend.drawBoxCastBox(prevColliderPos, halfExtents, orientation, direction, distance);

                if (checkCollision.Length > 0 && prevGameObj != checkCollision[0].gameObject)
                {
                    var collidedTarget = checkCollision[0].GetComponentInParent<MeleeFighter>();
                    collidedTarget.OnTriggerEnterAction(activeBoxCollider);
                    prevGameObj = checkCollision[0].gameObject;
                }
                else
                {
                    bool isHit = Physics.BoxCast(prevColliderPos, halfExtents, direction, out hit, orientation, distance, 1 << target.gameObject.layer, QueryTriggerInteraction.Collide);
                    //GizmosExtend.drawBoxCastBox(prevColliderPos, halfExtents, orientation, direction, distance);
                    if (isHit && prevGameObj != hit.transform.gameObject)
                    {
                        var collidedTarget = hit.transform.GetComponentInParent<MeleeFighter>();
                        collidedTarget.OnTriggerEnterAction(activeBoxCollider);
                        prevGameObj = hit.transform.gameObject;
                    }
                }
            }
            if (activeBoxCollider)
                prevColliderPos = activeBoxCollider.transform.TransformPoint(activeBoxCollider.center);
        }

        private void OnTriggerEnterAction(Collider other)
        {
            if (other.tag == "Hitbox" && CanTakeHit && !IsInvinsible)
            {
                var attacker = other.GetComponentInParent<MeleeFighter>();
                var currAttack = attacker.CurrAttack;
                var attackType = attacker.CurrAttackContainer.AttackType;

                // Don't take hit during synced animation, while getting up and while getting knocked down
                if (IsInSyncedAnimation || State == FighterState.GettingUp || (State == FighterState.TakingHit && currReaction != null && currReaction.willBeKnockedDown))
                    return;

                // Ground attacks should only be hit while knocked down & standing attacks should only hit while standing
                if ((IsKnockedDown && attackType != AttackType.GroundAttack) ||
                    (!IsKnockedDown && attackType == AttackType.GroundAttack))
                    return;

                // Dont' take hit if the victim was not the intented target of the attack
                if (attacker.attackingTarget != this && !attacker.CurrAttack.CanHitMultipleTargets)
                    return;

                bool willBeBlocked = WillBlockAttack(currAttack);

                if (willBeBlocked && PlayingBlockAnimationEarlier)
                    return;

                // If it's a synced block attack, then don't take allow late blocking
                //if (willBeBlocked && currAttack.OverrideBlockedReaction && currAttack.IsSyncedBlockedReaction && !CheckIfAttackKills(currAttack, attacker))
                //    willBeBlocked = false;

                other.enabled = true;
                var hitPoint = IsBlocking ? other.ClosestPoint(weaponCollider != null ? weaponCollider.transform.position : transform.position) : other.ClosestPoint(transform.position);
                other.enabled = false;
                TakeHit(attacker, hitPoint, willBeBlocked: willBeBlocked, reaction: null);
            }
        }

        Reaction currReaction;
        void TakeHit(MeleeFighter attacker, Vector3 hitPoint = new Vector3(), Reaction reaction = null, bool willBeBlocked = false,
            float hittingTime = 0)
        {
            StopMovement = false;
            if (State == FighterState.Dead || !CanTakeHit) return;
            AnimationClip getUpAnimation = null;

            if (!willBeBlocked)
            {
                if (attacker.CurrAttack.IsFinisher)
                    TakeDamage(CurrentHealth);
                else
                    TakeDamage(attacker.CurrAttack.Damage);


                if (attacker.CurrAttack.RotateTarget && (reaction != null || attacker.CurrAttack.OverrideReaction))
                    RotateToAttacker(attacker, attacker.CurrAttack.RotationOffset);

                // If no reaction clip has been passed, then find a suitable reaction
                if (reaction == null)
                {
                    if (attacker.CurrAttack.OverrideReaction)
                    {
                        reaction = attacker.CurrAttack.Reaction;
                    }
                    else
                    {
                        var weaponToUse = CurrentWeapon != null ? CurrentWeapon : weapon;
                        var reactionData = weapon != null ? weapon.ReactionData : defaultAnimations.hitReactionData;
                        reaction = ChooseHitReaction(hitPoint, attacker.CurrAttack, reactionData, attacker);
                    }

                    if (reaction != null)
                        getUpAnimation = (reaction.willBeKnockedDown) ? reaction.getUpAnimation : null;
                }
            }
            else
            {
                TakeDamage(Mathf.RoundToInt(attacker.CurrAttack.Damage * (attacker.CurrentWeapon.BlockedDamage / 100)));

                if (attacker.CurrAttack.RotateTargetInBlocked && (reaction != null || attacker.CurrAttack.OverrideReaction))
                    RotateToAttacker(attacker, attacker.CurrAttack.RotationOffsetInBlocked);

                if (reaction == null)
                {
                    if (attacker.CurrAttack.OverrideBlockedReaction)
                    {
                        reaction = attacker.CurrAttack.BlockedReaction;
                    }
                    else
                    {
                        var reactionData = CurrentWeapon != null ? CurrentWeapon.BlockReactionData : defaultAnimations.blockedReactionData;
                        reaction = ChooseHitReaction(hitPoint, attacker.CurrAttack, reactionData, attacker);
                    }
                }
            }
            // Go to combat mode
            animator.SetBool(AnimatorParameters.combatMode, true);

            OnGotHit?.Invoke(attacker, hitPoint, hittingTime, willBeBlocked);
            OnGotHitEvent?.Invoke(attacker, hitPoint, hittingTime);

            currReaction = reaction;
            if (CurrentHealth > 0 || (reaction != null && (reaction.willBeKnockedDown || attacker.CurrAttack.IsFinisher)))
            {
                StartCoroutine(PlayHitReaction(attacker, reaction, willBeBlocked));
            }
            else
            {
                StartCoroutine(PlayDeathAnimation(attacker, reaction?.animationClipInfo));
            }
        }

        IEnumerator PlayHitReaction(MeleeFighter attacker, Reaction reaction = null, bool isBlockedReaction = false,
            AnimationClip getUpAnimation = null)
        {
            SetState(isBlockedReaction ? FighterState.TakingBlockedHit : FighterState.TakingHit);

            OnStartAction?.Invoke();
            ++hitCount;

            bool willBeDead = false;
            if (CurrentHealth == 0 && ((reaction != null && reaction.willBeKnockedDown) || attacker.CurrAttack.IsFinisher))
            {
                SetState(FighterState.Dead);
                willBeDead = true;
            }

            var attack = attacker.CurrAttack;

            if (reaction?.animationClip == null && reaction?.animationClipInfo.clip == null)
            {
                Debug.LogError($"Reaction clips are not assigned. Attack - {attacker.CurrAttack.name}");
            }
            else
            {
                animGraph.CrossFade(reaction.animationClipInfo, 0.2f, transitionBack: CurrentHealth > 0, clipInfo: reaction.animationClipInfo);
                yield return null;
                float animLength = animGraph.currentClipStateInfo.clipLength;
                yield return new WaitUntil(() => animGraph.currentClipStateInfo.normalizedTime >= 0.8f);

                // If the character is knocked down, then play lying down and getting up animation
                if (!IsDead && reaction.willBeKnockedDown)
                {
                    StartCoroutine(GoToKnockedDownState(reaction));
                }
            }

            --hitCount;

            if (hitCount == 0)
            {
                OnHitComplete?.Invoke();

                // If hit was taken from the knocked down state, then go back to the knocked down state
                if (IsKnockedDown)
                    SetState(FighterState.KnockedDown);
                else
                {
                    if (isBlockedReaction && isBlocking)
                        SetState(FighterState.Blocking);
                    else
                        ResetStateToNone(isBlockedReaction ? FighterState.TakingBlockedHit : FighterState.TakingHit);
                }

                if (isBlockedReaction && PlayingBlockAnimationEarlier)
                    PlayingBlockAnimationEarlier = false;

                if (!IsBusy)
                    OnEndAction?.Invoke();
            }

            if (willBeDead)
                OnDeath?.Invoke();
        }

        public IEnumerator PlayDeathAnimation(MeleeFighter attacker, AnimGraphClipInfo clipInfo = null)
        {
            SetState(FighterState.Dead);

            OnStartAction?.Invoke();
            DisableActiveCollider();
            var dispVec = attacker.transform.position - transform.position;
            dispVec.y = 0;
            transform.rotation = Quaternion.LookRotation(dispVec);

            if (defaultAnimations.deathAnimationClipInfo.Count > 0)
                clipInfo = defaultAnimations.deathAnimationClipInfo[Random.Range(0, defaultAnimations.deathAnimationClipInfo.Count)];
            if (clipInfo.clip == null)
                OnDeath?.Invoke();

            yield return animGraph.CrossFadeAsync(clipInfo, 0.2f, transitionBack: false, OnComplete: OnDeath, clipInfo: clipInfo);

        }

        public IEnumerator PlayTauntAction(AnimationClip tauntClip)
        {
            SetState(FighterState.Taunt);
            OnStartAction?.Invoke();

            animGraph.CrossFade(tauntClip, 0.2f);
            yield return new WaitForSeconds(tauntClip.length);

            ResetStateToNone(FighterState.Taunt);
            if (!IsBusy)
                OnEndAction?.Invoke();
        }

        void RotateToAttacker(MeleeFighter attacker, float rotationOffset = 0f)
        {
            var dispVec = attacker.transform.position - transform.position;
            dispVec.y = 0;
            transform.rotation = Quaternion.LookRotation(dispVec) * Quaternion.Euler(new Vector3(0f, rotationOffset, 0f));
        }


        void TakeDamage(float damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, CurrentHealth);
        }

        bool CheckIfAttackKills(AttackData attack, MeleeFighter attacker)
        {
            var damage = WillBlockAttack(attack) ? attack.Damage * (attacker.CurrentWeapon.BlockedDamage / 100) : attack.Damage;

            return CurrentHealth - damage <= 0;
        }

        Reaction ChooseHitReaction(Vector3 hitPoint, AttackData currAttack, ReactionsData reactionData, MeleeFighter attacker = null)
        {
            if (reactionData == null) return null;

            var reactions = reactionData.reactions;
            var hitDirection = currAttack.HitDirection;

            if (reactionData.rotateToAttacker && attacker != null)
                RotateToAttacker(attacker);

            if (currAttack.HitDirection == HitDirections.FromCollision)
                hitDirection = GetHitDirection(hitPoint);

            // If attacked from behind
            bool attackedFromBehind = Vector3.Angle(transform.forward, attacker.transform.forward) <= 90;
            if (!reactionData.rotateToAttacker && attackedFromBehind)
            {
                var reactionsFromBehind = reactions.Where(r => r.attackedFromBehind);
                if (reactionsFromBehind.Count() > 0)
                    reactions = reactionsFromBehind.ToList();
            }

            //Debug.Log(hitDirection.ToString());

            // Match direction of the attack
            var reactionsWithSameDir = reactions.Where(c => c.direction == hitDirection);
            if (reactionsWithSameDir.Count() > 0)
                reactions = reactionsWithSameDir.ToList();
            else
                reactions = reactions.Where(c => c.direction == HitDirections.Any).ToList();

            // Tag match
            if (!String.IsNullOrEmpty(currAttack.ReactionTag))
            {
                var reactionsWithSameTag = reactions.Where(r => !String.IsNullOrEmpty(r.tag) && r.tag.ToLower() == currAttack.ReactionTag.ToLower());
                if (reactionsWithSameTag.Count() > 0)
                    reactions = reactionsWithSameTag.ToList();
                else
                {
                    var reactionsThatContainsTag = reactions.Where(r => !String.IsNullOrEmpty(r.tag)
                        && (r.tag.ToLower().Contains(currAttack.ReactionTag.ToLower()) || currAttack.ReactionTag.ToLower().Contains(r.tag.ToLower())));

                    if (reactionsThatContainsTag.Count() > 0)
                        reactions = reactionsThatContainsTag.ToList();
                }
            }

            var selectedReactionContainer = reactions.Count > 0 ? reactions.GetRandom() : null;

            return selectedReactionContainer?.reaction;
        }

        HitDirections GetHitDirection(Vector3 hitPoint)
        {
            var direction = (hitPoint - transform.position + Vector3.up * 0.5f).normalized;
            var right = Vector3.Dot(direction, transform.right);
            var up = Vector3.Dot(direction, transform.up);


            if (Mathf.Abs(right) > Mathf.Abs(up))
                return right > 0 ? HitDirections.Right : HitDirections.Left;
            else if (Mathf.Abs(up) > Mathf.Abs(right))
                return up > 0 ? HitDirections.Top : HitDirections.Bottom;

            return HitDirections.Any;
        }

        FighterState prevState;
        public void SetState(FighterState state)
        {
            if (State != state)
            {
                prevState = State;
                State = state;
            }
        }

        public void ResetStateToNone(FighterState stateToReset)
        {
            if (State == stateToReset)
            {
                prevState = State;
                State = FighterState.None;
            }
        }


        IEnumerator GoToKnockedDownState(Reaction reaction)
        {

            if (State != FighterState.Dead)
            {
                SetState(FighterState.KnockedDown);
                OnKnockDown?.Invoke();
                OnKnockDownEvent.Invoke();
            }

            AdjustColliderForKnockedDownState();

            AnimationClip lyingDownClip;
            AnimationClip getUpClip;

            if (reaction.overrideLyingDownAnimation)
            {
                lyingDownClip = reaction.lyingDownAnimation;
                getUpClip = reaction.getUpAnimation;
            }
            else
            {
                if (reaction.knockDownDirection == KnockDownDirection.LyingOnBack)
                {
                    lyingDownClip = defaultAnimations.lyingOnBackAnimation;
                    getUpClip = defaultAnimations.getUpFromBackAnimation;
                }
                else
                {
                    lyingDownClip = defaultAnimations.lyingOnFrontAnimation;
                    getUpClip = defaultAnimations.getUpFromFrontAnimation;
                }
            }


            if (lyingDownClip != null)
            {
                animGraph.CrossFadeAndLoop(lyingDownClip, 0.2f, transitionBack: false);
                yield return new WaitForSeconds(Random.Range(reaction.lyingDownTimeRange.x, reaction.lyingDownTimeRange.y));
                yield return new WaitUntil(() => State != FighterState.TakingHit);
            }

            // Don't Getup if dead
            if (CurrentHealth <= 0)
                yield break;

            ResetColliderAdjustments();
            animGraph.StopLoopingClip = true;

            if (getUpClip == null)
            {
                Debug.LogWarning("No Get Up Animations is provided to get up from the knocked down state");
                SetState(FighterState.None);
                yield break;
            }

            SetState(FighterState.GettingUp);
            OnGettingUp?.Invoke();
            OnGettingUpEvent.Invoke();
            yield return animGraph.CrossFadeAsync(getUpClip, 0.2f);
            ResetStateToNone(FighterState.GettingUp);

        }

        Vector3 colliderOriginalCenter;
        void AdjustColliderForKnockedDownState()
        {
            capsuleCollider.direction = 2;
            colliderOriginalCenter = capsuleCollider.center;
            capsuleCollider.center = new Vector3(capsuleCollider.center.x, 0, capsuleCollider.center.z);
        }

        void ResetColliderAdjustments()
        {
            capsuleCollider.direction = 1;
            capsuleCollider.center = colliderOriginalCenter;
        }

        void FindMaxAttackRange()
        {
            MaxAttackRange = 0f;
            if (CurrentWeapon.Attacks != null && CurrentWeapon.Attacks.Count > 0)
            {
                foreach (var combo in CurrentWeapon.Attacks)
                {
                    if (combo.MaxDistance > MaxAttackRange)
                        MaxAttackRange = combo.MaxDistance;
                }
            }
            else
            {
                MaxAttackRange = 3f;
            }
        }
        void EnableActiveCollider(AttackData attack)
        {
            switch (attack.HitboxToUse)
            {
                case AttackHitbox.LeftHand:
                    activeCollider = leftHandCollider;
                    CurrentWeaponHandler = leftHandCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.RightHand:
                    activeCollider = rightHandCollider;
                    CurrentWeaponHandler = rightHandCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.LeftFoot:
                    activeCollider = leftFootCollider;
                    CurrentWeaponHandler = leftFootCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.RightFoot:
                    activeCollider = rightFootCollider;
                    CurrentWeaponHandler = rightFootCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.Weapon:
                    activeCollider = weaponCollider;
                    CurrentWeaponHandler = CurrentWeaponObject.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.LeftElbow:
                    activeCollider = leftElbowCollider;
                    CurrentWeaponHandler = leftElbowCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.RightElbow:
                    activeCollider = rightElbowCollider;
                    CurrentWeaponHandler = rightElbowCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.LeftKnee:
                    activeCollider = leftKneeCollider;
                    CurrentWeaponHandler = leftKneeCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.RightKnee:
                    activeCollider = rightKneeCollider;
                    CurrentWeaponHandler = rightKneeCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                case AttackHitbox.Head:
                    activeCollider = headCollider;
                    CurrentWeaponHandler = headCollider.GetComponentInChildren<AttachedWeapon>();
                    break;
                default:
                    weaponCollider = null;
                    break;
            }
            OnEnableHit?.Invoke(CurrentWeaponHandler);
        }
        void DisableActiveCollider()
        {
            activeCollider = null;
        }

        #region Weapon Controller

        public void EquipWeapon(WeaponData weaponData, bool playSwitchingAnimation = true, Action onComplete = null)
        {
            if (IsBusy || !CanSwitchWeapon) return;
            StartCoroutine(EquipWeaponAsync(weaponData, playSwitchingAnimation, onComplete));

        }
        public IEnumerator EquipWeaponAsync(WeaponData weaponData, bool playSwitchingAnimation = true, Action onComplete = null)
        {
            var weaponChanged = (CurrentWeapon == null || CurrentWeapon != weaponData);
            if (weaponChanged)
            {
                if (weaponData != null)
                    weaponData.InIt();
                yield return UnEquipWeaponAsync(weaponData, playSwitchingAnimation);
                CurrentWeapon = weaponData;
                CurrAttacksList = new List<AttackSlot>();
                OnWeaponEquipAction?.Invoke(CurrentWeapon, playSwitchingAnimation);
                OnWeaponEquipEvent?.Invoke(CurrentWeapon, playSwitchingAnimation);

                StartCoroutine(SwitchingWeaponStateAnimation(CurrentWeapon.WeaponEquipAnimation, CurrentWeapon.WeaponActivationTime, playSwitchingAnimation, CurrentWeapon.OverrideController, CurrentWeapon, onComplete));
                FindMaxAttackRange();

                SetWeaponObject();

                if (CurrentWeaponObject != null)
                {
                    StartCoroutine(EnableAndDisableWeapon(true, playSwitchingAnimation ? CurrentWeapon.WeaponActivationTime : 0));
                    weaponCollider = CurrentWeaponObject.GetComponentInChildren<BoxCollider>();
                }
            }
        }
        public void EquipDefaultWeapon(bool playSwitchingAnimation = true, Action onComplete = null)
        {
            if (IsBusy) return;
            if (weapon != null)
            {
                //CurrentWeaponObject = attachedWeaponObject;
                EquipWeapon(weapon, playSwitchingAnimation, onComplete);
            }
        }
        void SetWeaponObject()
        {
            var weapon = attachedWeapons.FirstOrDefault(w => w.weapon == CurrentWeapon);
            CurrentWeaponObject = null;
            if (weapon == null && CurrentWeapon.SpawnWeapon && CurrentWeapon.WeaponModel != null)
            {
                var holder = animator.GetBoneTransform(CurrentWeapon.WeaponHolder);
                CurrentWeaponObject = Instantiate(CurrentWeapon.WeaponModel);
                CurrentWeaponObject.transform.SetParent(holder, true);
                CurrentWeaponObject.transform.localPosition = CurrentWeapon.LocalPosition;
                CurrentWeaponObject.transform.localRotation = CurrentWeapon.LocalRotation;

                SetWeaponLayer();
                CurrentWeaponHandler = this.CurrentWeaponObject.GetComponentInChildren<AttachedWeapon>();
                if (CurrentWeaponHandler == null)
                {
                    CurrentWeaponHandler = (AttachedWeapon)this.CurrentWeaponObject.AddComponent(typeof(AttachedWeapon));
                    CurrentWeaponHandler.weapon = CurrentWeapon;
                }
                attachedWeapons.Add(CurrentWeaponHandler);
            }
            else if (weapon != null)
                CurrentWeaponObject = weapon.gameObject;
        }


        public void QuickSwitchWeapon(WeaponData weaponData = null)
        {
            CurrAttacksList = new List<AttackSlot>();
            if (weaponData == null && CurrentWeapon != null)
            {
                OnWeaponUnEquipAction?.Invoke(CurrentWeapon, false);
                OnWeaponUnEquipEvent?.Invoke(CurrentWeapon, false);
                StartCoroutine(animGraph.CrosseFadeOverrideController(defaultAnimatorController, 0));
                if (CurrentWeaponObject != null)
                {
                    CurrentWeaponObject.SetActive(false);
                    CurrentWeaponObject = null;
                }
                CurrentWeapon = null;
                weaponCollider = null;
            }
            else if (weaponData != null)
            {
                weaponData.InIt();
                CurrentWeapon = weaponData;
                OnWeaponEquipAction?.Invoke(CurrentWeapon, false);
                OnWeaponEquipEvent?.Invoke(CurrentWeapon, false);
                FindMaxAttackRange();
                SetWeaponObject();
                if (CurrentWeaponObject != null)
                {
                    StartCoroutine(EnableAndDisableWeapon(true, 0));
                    weaponCollider = CurrentWeaponObject.GetComponentInChildren<BoxCollider>();
                }
            }
        }


        public void UnEquipWeapon(bool playSwitchingAnimation = true, Action onComplete = null)
        {
            if (IsBusy || !CanSwitchWeapon) return;
            StartCoroutine(UnEquipWeaponAsync(playSwitchingAnimation: playSwitchingAnimation, onComplete: onComplete));
        }
        public IEnumerator UnEquipWeaponAsync(WeaponData newWeapon = null, bool playSwitchingAnimation = true, Action onComplete = null)
        {
            if (CurrentWeapon == null) yield break;
            CurrAttacksList = new List<AttackSlot>();
            OnWeaponUnEquipAction?.Invoke(CurrentWeapon, playSwitchingAnimation);
            OnWeaponUnEquipEvent?.Invoke(CurrentWeapon, playSwitchingAnimation);
            StartCoroutine(EnableAndDisableWeapon(false, playSwitchingAnimation ? CurrentWeapon.WeaponDeactivationTime : 0));
            var overrideController = newWeapon != null && newWeapon.OverrideController != null ? newWeapon.OverrideController : defaultAnimatorController;
            yield return SwitchingWeaponStateAnimation(CurrentWeapon.WeaponUnEquipAnimation, CurrentWeapon.WeaponDeactivationTime, playSwitchingAnimation, overrideController, onComplete: onComplete);
            if (CurrentWeaponObject != null)
                CurrentWeaponObject = null;
            CurrentWeapon = null;
            if (!IsBusy)
                OnEndAction?.Invoke();
        }


        IEnumerator EnableAndDisableWeapon(bool enableWeapon, float time)
        {
            if (CurrentWeaponObject != null) yield return new WaitForSeconds(time);

            if (CurrentWeaponHandler != null && CurrentWeaponHandler.unEquipedWeaponModel != null)
                CurrentWeaponHandler.unEquipedWeaponModel.SetActive(!enableWeapon);
            CurrentWeaponObject?.SetActive(enableWeapon);
        }

        IEnumerator SwitchingWeaponStateAnimation(AnimationClip animation, float transitionOut, bool playSwitchingAnimation = true, AnimatorOverrideController overrideController = null, WeaponData weaponData = null, Action onComplete = null)
        {
            OnStartAction?.Invoke();
            SetState(FighterState.SwitchingWeapon);
            if (animation != null && playSwitchingAnimation)
                yield return animGraph.CrossFadeAsync(animation, .2f, transitionBack: false, transitionOut);
            var newController = overrideController == null ? defaultAnimatorController : overrideController;
            if (!IsDead)
                yield return animGraph.CrosseFadeOverrideController(newController, .2f);
            if (weaponData != null)
                animGraph.CrossfadeAvatarMaskAnimation(weaponData.WeaponHoldingClip, mask: weaponData.WeaponHolderMask, transitionInTime: 0.1f);
            else
                animGraph.RemoveAvatarMask();

            ResetStateToNone(FighterState.SwitchingWeapon);
            if (!IsBusy)
                OnEndAction?.Invoke();
            onComplete?.Invoke();
        }
        void SetWeaponLayer()
        {
            //if (transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            //    CurrentWeaponObject.layer = LayerMask.NameToLayer("EnemyHitbox");
            //else if (transform.gameObject.layer == LayerMask.NameToLayer("Player"))
            //    CurrentWeaponObject.layer = LayerMask.NameToLayer("PlayerHitbox");
            CurrentWeaponObject.tag = "Hitbox";
        }

        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if (moveToPos != Vector3.zero)
                Gizmos.DrawSphere(moveToPos, 0.3f);
        }

        public IEnumerator PullBackCharacter(MeleeFighter attacker, float moveDist = .75f)
        {
            float timer = 0;
            while (timer < moveDist)
            {

                characterController.Move((attacker.transform.forward * moveDist) * Time.deltaTime * 2);
                timer += Time.deltaTime * 2;
                yield return null;
            }
        }

        public Vector3 GetHitPoint(MeleeFighter attacker)
        {
            Vector3 hitPoint = Vector3.zero;
            attacker.EnableActiveCollider(attacker.CurrAttack);
            if (hitPoint == Vector3.zero)
            {
                attacker.activeCollider.enabled = true;
                hitPoint = IsBlocking ? attacker.activeCollider.ClosestPoint(weaponCollider != null ? weaponCollider.transform.position : transform.position) : attacker.activeCollider.ClosestPoint(transform.position);
                attacker.activeCollider.enabled = false;
            }
            attacker.DisableActiveCollider();
            return hitPoint;

        }

        public event Action<MeleeFighter> OnBeingAttacked;
        public void BeingAttacked(MeleeFighter attacker)
        {
            OnBeingAttacked?.Invoke(attacker);
            IsBeingAttacked = true;
            CurrAttacker = attacker;
        }

        public void AttackOver(MeleeFighter attacker)
        {
            if (CurrAttacker == attacker)
            {
                IsBeingAttacked = false;
                CurrAttacker = null;
            }
        }

        public void ResetFighter()
        {
            if (InAction) return;
            AttackState = AttackStates.Idle;
            CurrentHealth = MaxHealth;
            attackingTarget = null;
            UnEquipWeapon(false);
            OnResetFighter?.Invoke();
        }

        public List<Rigidbody> rigidbodies { get; set; }
        public void SetRagdollState(bool state)
        {
            //if (rigidbodies.Count > 0 && !state)
            //{
            //    var modelTransform = transform.GetComponentsInChildren<Animator>().ToList().FirstOrDefault(a => a != animator);
            //    if (modelTransform != null)
            //    {
            //        transform.position = modelTransform.transform.position;
            //        modelTransform.transform.localPosition = Vector3.zero;
            //    }
            //}
            //foreach (Rigidbody rb in rigidbodies)
            //{
            //    rb.isKinematic = !state;
            //    rb.GetComponent<Collider>().enabled = state;
            //}
            //if(rigidbodies.Count > 0)
            //animator.enabled = !state;
        }

        private void OnValidate()
        {
            for (int i = 0; i < defaultAnimations.deathAnimation.Count; i++)
            {
                if (defaultAnimations.deathAnimation[i] != null)
                {
                    if (defaultAnimations.deathAnimationClipInfo.Count <= i)
                        defaultAnimations.deathAnimationClipInfo.Add(new AnimGraphClipInfo());

                    if (defaultAnimations.deathAnimation[i] != null && defaultAnimations.deathAnimationClipInfo[i].clip == null)
                        defaultAnimations.deathAnimationClipInfo[i].clip = defaultAnimations.deathAnimation[i];
                }
            }
            SyncDodgeDataClips(rollData);
            SyncDodgeDataClips(dodgeData);

            void SyncDodgeDataClips(DodgeData dodgeData)
            {
                if (dodgeData.clip != null && dodgeData.clipInfo.clip == null)
                {
                    dodgeData.clipInfo.clip = dodgeData.clip;
                }

                if (dodgeData.useDifferentClipsForDirections)
                {
                    if (dodgeData.frontClip != null && dodgeData.frontClipInfo.clip == null)
                    {
                        dodgeData.frontClipInfo.clip = dodgeData.frontClip;
                    }

                    if (dodgeData.backClip != null && dodgeData.backClipInfo.clip == null)
                    {
                        dodgeData.backClipInfo.clip = dodgeData.backClip;
                    }

                    if (dodgeData.leftClip != null && dodgeData.leftClipInfo.clip == null)
                    {
                        dodgeData.leftClipInfo.clip = dodgeData.leftClip;
                    }

                    if (dodgeData.rightClip != null && dodgeData.rightClipInfo.clip == null)
                    {
                        dodgeData.rightClip = dodgeData.rightClipInfo.clip;
                    }
                }
            }
        }
    }

    [Serializable]
    public class DefaultReactions
    {
        public ReactionsData hitReactionData;
        public ReactionsData blockedReactionData;

        [Header("Lying down and Get up Animations")]
        public AnimationClip lyingOnBackAnimation;
        public AnimationClip getUpFromBackAnimation;
        public AnimationClip lyingOnFrontAnimation;
        public AnimationClip getUpFromFrontAnimation;

        [Space(10)]
        [HideInInspector]
        public List<AnimationClip> deathAnimation = new List<AnimationClip>();
        public List<AnimGraphClipInfo> deathAnimationClipInfo = new List<AnimGraphClipInfo>();

    }

    [Serializable]
    public class DodgeData
    {
        [HideInInspector]
        public AnimationClip clip;
        public AnimGraphClipInfo clipInfo;

        public DodgeDirection defaultDirection;
        public bool useDifferentClipsForDirections;

        [HideInInspector]
        public AnimationClip frontClip;
        [HideInInspector]
        public AnimationClip backClip;
        [HideInInspector]
        public AnimationClip leftClip;
        [HideInInspector]
        public AnimationClip rightClip;

        public AnimGraphClipInfo frontClipInfo;
        public AnimGraphClipInfo backClipInfo;
        public AnimGraphClipInfo leftClipInfo;
        public AnimGraphClipInfo rightClipInfo;

        public Vector3 GetDodgeDirection(Transform transform, Transform target)
        {
            if (defaultDirection == DodgeDirection.Forward || (defaultDirection == DodgeDirection.TowardsTarget && target == null))
                return transform.forward;
            else if (defaultDirection == DodgeDirection.Backward || (defaultDirection == DodgeDirection.AwayFromTarget && target == null))
                return -transform.forward;
            else if (defaultDirection == DodgeDirection.AwayFromTarget)
                return -(target.position - transform.position);
            else if (defaultDirection == DodgeDirection.TowardsTarget)
                return (target.position - transform.position);

            return -transform.forward;
        }

        public AnimGraphClipInfo GetClip(Transform transform, Vector3 direction)
        {
            if (!useDifferentClipsForDirections)
                return clipInfo;

            var dir = transform.InverseTransformDirection(direction);
            //Debug.Log(dir);

            float h = dir.x;
            float v = dir.z;

            if (Math.Abs(v) >= Math.Abs(h))
                return (v > 0) ? frontClipInfo : backClipInfo;
            else
                return (h > 0) ? rightClipInfo : leftClipInfo;
        }
    }

    public enum DodgeDirection { AwayFromTarget, TowardsTarget, Backward, Forward }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(DodgeData))]
    public class DodgeDataEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty clip = property.FindPropertyRelative("clipInfo");
            SerializedProperty defaultDirection = property.FindPropertyRelative("defaultDirection");
            SerializedProperty useDifferentClipsForDirections = property.FindPropertyRelative("useDifferentClipsForDirections");

            SerializedProperty frontClip = property.FindPropertyRelative("frontClipInfo");
            SerializedProperty backClip = property.FindPropertyRelative("backClipInfo");
            SerializedProperty leftClip = property.FindPropertyRelative("leftClipInfo");
            SerializedProperty rightClip = property.FindPropertyRelative("rightClipInfo");

            if (!useDifferentClipsForDirections.boolValue)
                EditorGUILayout.PropertyField(clip);

            EditorGUILayout.PropertyField(defaultDirection);
            EditorGUILayout.PropertyField(useDifferentClipsForDirections);
            if (useDifferentClipsForDirections.boolValue)
            {
                EditorGUILayout.PropertyField(frontClip);
                EditorGUILayout.PropertyField(backClip);
                EditorGUILayout.PropertyField(leftClip);
                EditorGUILayout.PropertyField(rightClip);
            }
        }
    }

#endif
}