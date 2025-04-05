using System;
using System.Collections.Generic;
using UnityEngine;
namespace FS_CombatSystem
{
    public enum AttackType { Single, Combo, Stealth, GroundAttack }

    [System.Serializable]
    public class AttackContainer : ISerializationCallbackReceiver
    {
        [Tooltip("The type of the attack")]
        [SerializeField] AttackType attackType;

        [Tooltip("The minimum distance required for this attack to be effective.")]
        [SerializeField] float minDistance = 0f;

        [Tooltip("The maximum distance at which this attack can be effective.")]
        [SerializeField] float maxDistance = 4f;

        [Tooltip("The attack will only be triggered if the character's health is below this threshold, expressed as a percentage.")]
        [Range(0, 100)]
        [SerializeField] float healthThreshold = 100f;

        [Tooltip("List of attack datas that can be used for this attack.")]
        [SerializeField] List<AttackSlot> attacks = new List<AttackSlot>();

        [Tooltip("Specific attack data used for this attack.")]
        [SerializeField] AttackSlot attack;

        [Tooltip("The distance taken by the animation rootmotion")]
        [SerializeField] float animationDistance;


        //public bool IsCombo => isCombo;
        public AttackType AttackType {
            get => attackType;
            set => attackType = value;
        }
        public float MinDistance => minDistance;
        public float MaxDistance => maxDistance;
        public float HealthThreshold => healthThreshold;
        public List<AttackSlot> AttackSlots
        {
            get
            {
                return attackType == AttackType.Combo ? attacks :
                    new List<AttackSlot>() { attack };
            }
        }



        [SerializeField, HideInInspector]
        private bool serialized = false;
        public void OnAfterDeserialize()
        {
            if (serialized == false)
            {
                maxDistance = 4f;
                healthThreshold = 100f;
            }
        }

        public void OnBeforeSerialize()
        {
            if (serialized)
                return;
            serialized = true;
        }
    }

    [System.Serializable]
    public class AttackSlot
    {
        [Tooltip("Data for the specific attack")]
        [SerializeField] AttackData attack;

        [Tooltip("Indicates if this attack can be charged")]
        [SerializeField] bool canBeCharged;

        [Tooltip("Data for the charged version of the attack")]
        [SerializeField] AttackData chargedAttack;

        public AttackData Attack {
            get => attack;
            set => attack = value;
        }
        public bool CanBeCharged => canBeCharged;
        public AttackData ChargedAttack => chargedAttack;
        
        [NonSerialized] public AttackContainer Container;
    }
}

