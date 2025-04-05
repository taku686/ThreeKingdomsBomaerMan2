using FS_ThirdPerson;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FS_CombatSystem
{
    [CustomIcon(FolderPath.CombatIcons + "Attack Icon.png")]
    [CreateAssetMenu(menuName = "Combat System/Create Attack")]
    public class AttackData : ScriptableObject
    {
        [Tooltip("The animation clip associated with this attack.")]
        [SerializeField] AnimationClip clip;

        [Tooltip("The animation clip associated with this attack.")]
        [SerializeField] AnimGraphClipInfo clipInfo;

        [Tooltip("The speed at which the animation will play during the attack.")]
        [SerializeField] float animationSpeed = 1;

        [Tooltip("Indicates if this attack is a finishing move.")]
        [SerializeField] bool isFinisher;

        [Tooltip("Indicates whether the attack can hit multiple targets.")]
        [SerializeField] bool canHitMultipleTargets;

        [Tooltip("Indicates if the character should always look at the target during the attack.")]
        [SerializeField] bool rotateToTarget = true;

        [HideInInspectorEnum(0)]
        [Tooltip("The direction of the hit.")]
        [SerializeField] HitDirections hitDirection;

        [Tooltip("Tag used to identify the reaction to this attack.")]
        [SerializeField] string reactionTag;

        [Tooltip("Indicates if the reaction should be overridden.")]
        [SerializeField] bool overrideReaction;

        [Tooltip("The reaction associated with this attack.")]
        [SerializeField] Reaction reaction;

        [Tooltip("Indicates if the reaction should be synced.")]
        [SerializeField] bool isSyncedReaction;

        [Tooltip("The start time of the synced reaction, relative to the animation clip.")]
        [Range(0, 1)]
        [SerializeField] float syncStartTime;

        [Tooltip("Indicates if the target should be rotated during the reaction.")]
        [SerializeField] bool rotateTarget = true;

        [Tooltip("The rotation offset applied to the target during the reaction.")]
        [SerializeField] float rotationOffset = 0f;

        [Tooltip("Indicates if the blocked reaction should be overridden.")]
        [SerializeField] bool overrideBlockedReaction;

        [Tooltip("The blocked reaction associated with this attack.")]
        [SerializeField] Reaction blockedReaction;

        [Tooltip("Indicates if the blocked reaction should be synced.")]
        [SerializeField] bool isSyncedBlockedReaction;

        [Tooltip("The start time of the synced blocked reaction, relative to the animation clip.")]
        [Range(0, 1)]
        [SerializeField] float blockSyncStartTime;

        [Tooltip("Indicates if the target should be rotated during the blocked reaction.")]
        [SerializeField] bool rotateTargetInBlocked = true;

        [Tooltip("The rotation offset applied to the target during the blocked reaction.")]
        [SerializeField] float rotationOffsetInBlocked = 0f;

        [Tooltip("Indicates if this attack can be countered.")]
        [SerializeField] bool canBeCountered;

        [Tooltip("List of counterattacks that can be used against this attack.")]
        [SerializeField] List<CounterAttack> counterAttacks;

        [Tooltip("The hitbox to use for this attack.")]
        [SerializeField] AttackHitbox hitboxToUse;

        [Tooltip("Damage caused by this attack.")]
        [SerializeField] float damage = 5;

        [Tooltip("The start time of the impact, relative to the animation clip.")]
        [SerializeField] float impactStartTime;

        [Tooltip("The end time of the impact, relative to the animation clip.")]
        [SerializeField] float impactEndTime = 1;

        [Tooltip("Indicates if the next attack should wait before being triggered.")]
        [SerializeField] bool waitForNextAttack;

        [Tooltip("The time to wait before the next attack, relative to the animation clip.")]
        [Range(0, 1)]
        [SerializeField] float waitForAttackTime = 0f;

        [Tooltip("Indicates if the character should move to the target.")]
        [SerializeField] bool moveToTarget;

        [Tooltip("The distance from the target the character should move to.")]
        [SerializeField] float distanceFromTarget = 1f;

        [Tooltip("The local position offset from the target.")]
        [SerializeField] Vector3 localPositionFromTarget = Vector3.zero;

        [Tooltip("The start time of the movement, relative to the animation clip.")]
        [SerializeField] float moveStartTime = 0f;

        [Tooltip("The end time of the movement, relative to the animation clip.")]
        [SerializeField] float moveEndTime = 1f;

        [Tooltip("Indicates if collisions should be ignored during the movement.")]
        [SerializeField] bool ignoreCollisions = true;

        [Tooltip("The type of target matching movement.")]
        [SerializeField] TargetMatchType moveType;

        [Tooltip("The type of snapping to use for this attack.")]
        [SerializeField] SnapType snapType;

        [Tooltip("The target to snap to for this attack.")]
        [SerializeField] SnapTarget snapTarget;

        [Tooltip("The weight mask applied during the root motion.")]
        [SerializeField] Vector3 weightMask = new Vector3(1, 1, 1);

        [Tooltip("The root motion curves of this attack.")]
        [SerializeField] PositionCurves rootCurves;

        [Tooltip("Indicates if this attack is unblockable.")]
        [SerializeField] bool isUnblockableAttack;

        [Header("SFX")]
        [Tooltip("The sound played when the strike occurs.")]
        [SerializeField] AudioClip strikeSound;

        [Tooltip("The sound played when the attack hits.")]
        [SerializeField] AudioClip hitSound;

        [Tooltip("The sound played when the attack is blocked.")]
        [SerializeField] AudioClip blockedHitSound;

        [Tooltip("The sound played when the target gets hit and reacts to this attack.")]
        [SerializeField] AudioClip reactionSound;

        [Header("VFX")]
        [Tooltip("The visual effect played when the attack hits.")]
        [SerializeField] GameObject hitEffect;

        [Tooltip("The exact time during the attack animation when it will be hitting.")]
        [Range(0, 1)]
        [SerializeField] float hittingTime;

        [Tooltip("The visual effect played when the attack is blocked.")]
        [SerializeField] GameObject blockedHitEffect;

        [Tooltip("The exact time during the attack animation when it will be hitting.")]
        [Range(0, 1)]
        [SerializeField] float blockedHittingTime;

        [Tooltip("The intensity of the camera shake effect.")]
        [SerializeField] float cameraShakeAmount = .3f;

        [Tooltip("The duration for which the camera shake effect will last.")]
        [SerializeField] float cameraShakeDuration = .2f;

        public HitDirections HitDirection => hitDirection;
        public bool IsFinisher => isFinisher;
        public bool CanHitMultipleTargets => canHitMultipleTargets;
        public bool AlwaysLookAtTheTarget => rotateToTarget;
        public string ReactionTag => reactionTag;

        public bool OverrideReaction => overrideReaction;
        public bool IsSyncedReaction => isSyncedReaction;
        public float SyncStartTime => syncStartTime;
        public bool RotateTarget => rotateTarget;
        public float RotationOffset => rotationOffset;

        public bool OverrideBlockedReaction => overrideBlockedReaction;
        public Reaction BlockedReaction => blockedReaction;
        public bool IsSyncedBlockedReaction => isSyncedBlockedReaction;
        public float BlockSyncStartTime => blockSyncStartTime;
        public bool RotateTargetInBlocked => rotateTargetInBlocked;
        public float RotationOffsetInBlocked => rotationOffsetInBlocked;

        public bool CanBeCountered => canBeCountered;
        public List<CounterAttack> CounterAttacks => counterAttacks;

        public bool IsUnblockableAttack => isUnblockableAttack;

        public AudioClip StrikeSound => strikeSound;
        public AudioClip HitSound => hitSound;
        public AudioClip BlockedHitSound => blockedHitSound;
        public AudioClip ReactionSound => reactionSound;
        public GameObject HitEffect => hitEffect;
        public float HittingTime => hittingTime;
        public GameObject BlockedHitEffect => blockedHitEffect;
        public float BlockedHittingTime => blockedHittingTime;
        public float CameraShakeAmount => cameraShakeAmount;
        public float CameraShakeDuration => cameraShakeDuration;

        public bool WaitForNextAttack => waitForNextAttack;
        public float WaitForAttackTime => waitForAttackTime;

        //public float SyncStartTime => syncStartTime;
        //public float SyncEndTime => syncEndTime;

        //public WeaponData Weapon { get => weapon; private set => weapon = value; }
        public AnimGraphClipInfo Clip { get => clipInfo; private set => clipInfo = value; }
        public float AnimationSpeed => animationSpeed;
        public Reaction Reaction { get => reaction; private set => reaction = value; }
        public AttackHitbox HitboxToUse { get => hitboxToUse; private set => hitboxToUse = value; }
        public float Damage { get => damage; private set => damage = value; }
        //public float BlockedDamage { get => blockedDamage; private set => blockedDamage = value; }
        public float ImpactStartTime { get => impactStartTime; private set => impactStartTime = value; }
        public float ImpactEndTime { get => impactEndTime; private set => impactEndTime = value; }

        public bool MoveToTarget { get => moveToTarget; private set => moveToTarget = value; }
        public float DistanceFromTarget { get => distanceFromTarget; private set => distanceFromTarget = value; }
        public float MoveStartTime { get => moveStartTime; private set => moveStartTime = value; }
        public float MoveEndTime { get => moveEndTime; private set => moveEndTime = value; }
        public bool IgnoreCollisions => ignoreCollisions;

        public PositionCurves RootCurves { get => rootCurves; set => rootCurves = value; }
        public TargetMatchType MoveType => moveType;
        public SnapType SnapType => snapType;
        public SnapTarget SnapTarget => snapTarget;
        public Vector3 LocalPosFromTarget => localPositionFromTarget;

        public Vector3 WeightMask => weightMask;

        private void OnValidate()
        {
            if (clip != null && clipInfo.clip == null)
               clipInfo.clip = clip;

            if (reaction.animationClip != null && reaction.animationClipInfo.clip == null)
                reaction.animationClipInfo.clip = reaction.animationClip;

            if (blockedReaction.animationClip != null && blockedReaction.animationClipInfo.clip == null)
                blockedReaction.animationClipInfo.clip = blockedReaction.animationClip;
        }
    }
    public enum AttackHitbox { LeftHand, RightHand, LeftFoot, RightFoot, Weapon, LeftElbow, RightElbow, LeftKnee, RightKnee, Head }

    public enum TargetMatchType { Linear, ScaleRootMotion, Snap }
    public enum SnapType { LocalPosition, Distance }
    public enum SnapTarget { Attacker, Victim }

    [Serializable]
    public class CounterAttack : ISerializationCallbackReceiver
    {
        [SerializeField] AttackData counterAttack;
        [SerializeField] float counterStartTime;

        [Tooltip("Maximum distance below which the counter can be performed")]
        [SerializeField] float maxDistanceForCounter = 2f;

        [Tooltip("Health threshold below which the counter can be performed")]
        [Range(0, 100)]
        [SerializeField] float healthThresholdForCounter = 100;

        [SerializeField] bool foldOut = true;

        [SerializeField, HideInInspector]
        private bool serialized = false;
        public void OnAfterDeserialize()
        {
            if (serialized == false)
            {
                maxDistanceForCounter = 2f;
                healthThresholdForCounter = 100f;
            }
        }

        public void OnBeforeSerialize()
        {
            if (serialized)
                return;

            serialized = true;
        }

        public AttackData Attack => counterAttack;
        public float CounterStartTime => counterStartTime;
        public float MaxDistanceForCounter => maxDistanceForCounter;
        public float HealthThresholdForCounter => healthThresholdForCounter;
    }

    [Serializable]
    public class PositionCurves
    {
        public AnimationCurve CurveX;
        public AnimationCurve CurveY;
        public AnimationCurve CurveZ;

        public Vector3 GetPositionAtTime(float normalTime)
        {
            return new Vector3(CurveX.Evaluate(normalTime),
                CurveY.Evaluate(normalTime),
                CurveZ.Evaluate(normalTime));
        }
    }
}
