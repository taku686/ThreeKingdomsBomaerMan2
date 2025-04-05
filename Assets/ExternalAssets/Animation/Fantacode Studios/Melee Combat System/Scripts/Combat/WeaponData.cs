using FS_ThirdPerson;
using System.Collections.Generic;
using UnityEngine;
namespace FS_CombatSystem
{
    [CustomIcon(FolderPath.CombatIcons + "Weapon Icon.png")]
    [CreateAssetMenu(menuName = "Combat System/Create Weapon")]
    public class WeaponData : ScriptableObject
    {
        [Tooltip("Indicates if the weapon should be spawned.")]
        [SerializeField] bool spawnWeapon;

        [Tooltip("The bone where the weapon will be attached.")]
        [SerializeField] HumanBodyBones weaponHolder = HumanBodyBones.RightHand;

        [Tooltip("The local position of the weapon relative to the weapon holder.")]
        [SerializeField] Vector3 localPosition;

        [Tooltip("The local rotation of the weapon relative to the weapon holder.")]
        [SerializeField] Vector3 localRotation;

        [Tooltip("The model of the weapon to be spawned.")]
        [SerializeField] GameObject weaponModel;

        [Tooltip("List of attack datas, each containing details about an attack and its conditions.")]
        [SerializeField] List<AttackContainer> attacks;

        [Tooltip("List of attack data that is considered a heavy attack, each containing details about an attack and its conditions.")]
        [SerializeField] List<AttackContainer> heavyAttacks;

        [Tooltip("List of attack data that is considered a special attacks, each containing details about an attack and its conditions.")]
        [SerializeField] List<AttackContainer> specialAttacks;

        [Tooltip("Data for reactions associated with the weapon.")]
        [SerializeField] ReactionsData reactionData;

        [Tooltip("The animation clip for equipping the weapon.")]
        [SerializeField] AnimationClip weaponEquipAnimation;

        [Tooltip("The time taken to activate the weapon.")]
        [SerializeField] float weaponActivationTime;

        [Tooltip("The animation clip for unequipping the weapon.")]
        [SerializeField] AnimationClip weaponUnEquipAnimation;

        [Tooltip("The time taken to deactivate the weapon.")]
        [SerializeField] float weaponDeactivationTime;

        [Tooltip("Indicates if the weapon can block attacks.")]
        [SerializeField] bool canBlock;

        [Tooltip("The animation clip used for blocking with the attacks.")]
        [SerializeField] AnimationClip blocking;

        [Tooltip("The percentage of damage taken when getting hit while blocking.")]
        [Range(0, 100)]
        [SerializeField] float blockedDamage = 25f;

        [Tooltip("Data for reactions when blocking with the weapon.")]
        [SerializeField] ReactionsData blockReactionData;

        [Tooltip("Avatar mask to use during blocking.")]
        [SerializeField] AvatarMask blockMask;

        [Tooltip("Indicates if the weapon can perform counterattacks.")]
        [SerializeField] bool canCounter = true;

        [Tooltip("If true, the fighter will play a taunt action if the counter input is pressed while the enemy is not attacking. This can be used to prevent the misuse of the counter input.")]
        [SerializeField] bool playActionIfCounterMisused = false;
        [Tooltip("Animation clip of the action to play if the counter is pressed while the enemy is not attacking.")]
        [SerializeField] AnimationClip counterMisusedAction;

        [Tooltip("Animator override controller used to manage different movement animations specific to the weapon.")]
        [SerializeField] AnimatorOverrideController overrideController;

        [Tooltip("Indicates if root motion should be used for movement")]
        [SerializeField] bool useRootmotion;

        [Tooltip("Indicates if the locomotion movement speed should be overridden.")]
        [SerializeField] bool overrideMoveSpeed;

        [Tooltip("Speed of walking with the weapon.")]
        [SerializeField] float walkSpeed = 2f;

        [Tooltip("Speed of running with the weapon.")]
        [SerializeField] float runSpeed = 4.5f;

        [Tooltip("Speed of sprinting with the weapon.")]
        [SerializeField] float sprintSpeed = 6.5f;

        [Tooltip("Movement speed while the character is in combat mode(Locked into a target).")]
        [SerializeField] float combatMoveSpeed = 2f;

        [Tooltip("Indicates if the fighter can dodge.")]
        [SerializeField] bool overrideDodge;
        [SerializeField] DodgeData dodgeData;

        [Tooltip("Indicates if the fighter can roll.")]
        [SerializeField] bool overrideRoll;
        [SerializeField] DodgeData rollData;

        [Tooltip("If true, fighter will only be able to roll in combat mode.")]
        public bool OnlyRollInCombatMode = true;

        [Tooltip("Animation clip for the weapon holding pose, used to create a specific layer for the holding pose.")]
        [SerializeField] AnimationClip weaponHoldingClip;

        [Tooltip("Avatar mask used specifically for the weapon holding animation.")]
        [SerializeField] AvatarMask weaponHolderMask;

        [Tooltip("Sound played when equipping the weapon.")]
        [SerializeField] AudioClip weaponEquipSound;

        [Tooltip("Sound played when unequipping the weapon.")]
        [SerializeField] AudioClip weaponUnEquipSound;

        [Tooltip("The minimum distance required for the weapon to have an effective attack.")]
        [SerializeField] float minAttackDistance = 0;

        public void InIt()
        {
            foreach (var attack in attacks)
                attack.AttackSlots.ForEach(a => a.Container = attack);

            foreach (var attack in heavyAttacks)
                attack.AttackSlots.ForEach(a => a.Container = attack);

            foreach (var attack in specialAttacks)
                attack.AttackSlots.ForEach(a => a.Container = attack);
        }

        public bool SpawnWeapon => spawnWeapon;
        public HumanBodyBones WeaponHolder => weaponHolder;
        public Vector3 LocalPosition => localPosition;
        public Quaternion LocalRotation => Quaternion.Euler(localRotation);
        public GameObject WeaponModel => weaponModel;
        public AnimationClip WeaponEquipAnimation => weaponEquipAnimation;
        public float WeaponActivationTime => weaponActivationTime;
        public AnimationClip WeaponUnEquipAnimation => weaponUnEquipAnimation;
        public float WeaponDeactivationTime => weaponDeactivationTime;
        public List<AttackContainer> Attacks => attacks;
        public List<AttackContainer> HeavyAttacks => heavyAttacks;
        public List<AttackContainer> SpecialAttacks => specialAttacks;
        public ReactionsData ReactionData => reactionData;
        public bool CanBlock => canBlock;
        public AnimationClip Blocking => blocking;
        public float BlockedDamage => blockedDamage;
        public ReactionsData BlockReactionData => blockReactionData;
        public AvatarMask BlockMask => blockMask;
        public AnimatorOverrideController OverrideController => overrideController;
        public bool CanCounter => canCounter;
        public bool PlayActionIfCounterMisused => playActionIfCounterMisused;
        public AnimationClip CounterMisusedAction => counterMisusedAction;

        public bool UseRootmotion => useRootmotion;

        public bool OverrideMoveSpeed => overrideMoveSpeed;
        public float WalkSpeed => walkSpeed;
        public float RunSpeed => runSpeed;
        public float SprintSpeed => sprintSpeed;
        public float CombatModeSpeed => combatMoveSpeed;

        public bool OverrideDodge => overrideDodge;
        public DodgeData DodgeData => dodgeData;
        public bool OverrideRoll => overrideRoll;
        public DodgeData RollData => rollData;

        public AnimationClip WeaponHoldingClip => weaponHoldingClip;
        public AvatarMask WeaponHolderMask => weaponHolderMask;

        public AudioClip WeaponEquipSound => weaponEquipSound;
        public AudioClip WeaponUnEquipSound => weaponUnEquipSound;
        public float MinAttackDistance => minAttackDistance;

    }
}