using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FS_CombatSystem
{
    public class CombatSettings : MonoBehaviour
    {
        [SerializeField] bool onlyCounterWhileBlocking = false;
        [SerializeField] bool onlyCounterFirstAttackOfCombo = true;
        [SerializeField] bool sameInputForAttackAndCounter = false;
        [SerializeField] float holdTimeForChargedAttacks = 0.2f;



        public static CombatSettings i { get; private set; }
        private void Awake()
        {
            i = this;
        }

        public bool OnlyCounterWhileBlocking => onlyCounterWhileBlocking;
        public bool OnlyCounterFirstAttackOfCombo => onlyCounterFirstAttackOfCombo;
        public bool SameInputForAttackAndCounter => sameInputForAttackAndCounter;
        public float HoldTimeForChargedAttacks => holdTimeForChargedAttacks;
    }
}
