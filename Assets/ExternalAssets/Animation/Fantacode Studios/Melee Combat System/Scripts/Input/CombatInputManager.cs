using System;
using UnityEngine;
namespace FS_CombatSystem
{
    public class CombatInputManager : MonoBehaviour
    {
        [Header("Keys")]
        [SerializeField] KeyCode attackKey = KeyCode.Mouse0;
        [SerializeField] KeyCode blockKey = KeyCode.Mouse1;
        [SerializeField] KeyCode dodgeKey = KeyCode.LeftAlt;
        [SerializeField] KeyCode rollKey = KeyCode.Space;
        [SerializeField] KeyCode combatModeKey = KeyCode.F;
        [SerializeField] KeyCode heavyAttackKey = KeyCode.R;
        [SerializeField] KeyCode specialAttackKey = KeyCode.X;
        [SerializeField] KeyCode counterKey = KeyCode.Q;


        [Header("Buttons")]
        [SerializeField] string attackButton;
        [SerializeField] string blockButton;
        [SerializeField] string dodgeButton;
        [SerializeField] string rollButton;
        [SerializeField] string combatModeButton;
        [SerializeField] string counterButton;
        [SerializeField] string heavyAttackButton;
        [SerializeField] string specialAttackButton;

        public event Action<float, bool, bool, bool, bool> OnAttackPressed;

        public bool Block { get; set; }
        public bool Dodge { get; set; }
        public bool Roll { get; set; }
        public bool CombatMode { get; set; }

        bool attackDown;
        bool heavyAttackDown;
        bool specialAttackDown;


        public float AttackHoldTime { get; private set; } = 0f;
        public float HeavyAttackHoldTime {get; private set;} = 0f;
        public float SpecialAttackHoldTime {get; private set;} = 0f;

        float chargeTime = 0f;
        bool useAttackInputForCounter = false;
        private void Start()
        {
            chargeTime = CombatSettings.i.HoldTimeForChargedAttacks;
            useAttackInputForCounter = CombatSettings.i.SameInputForAttackAndCounter;
        }

#if inputsystem
        CombatInputAction input;
        private void OnEnable()
        {
            input = new CombatInputAction();
            input.Enable();
        }
        private void OnDisable()
        {
            input.Disable();
        }
#endif

        private void Update()
        {

            //Attack
            HandleAttack();

            //HeavyAttack
            HandleHeavyAttack();

            //Special Attack
            HandleSpecialAttack();

            //Counter
            HandleCounter();

            //Block
            HandleBlock();

            HandleDodge();
            HandleRoll();

            //Combat Mode
            HandleCombatMode();
        }

        void HandleAttack()
        {
#if inputsystem

            if (input.Combat.Attack.WasPressedThisFrame())
            {
                attackDown = true;
            }
            if (attackDown)
            {
                if (AttackHoldTime >= chargeTime || input.Combat.Attack.WasReleasedThisFrame())
                {
                    OnAttackPressed?.Invoke(AttackHoldTime, false, useAttackInputForCounter, AttackHoldTime >= chargeTime, false);
                    attackDown = false;
                    AttackHoldTime = 0f;
                }
                AttackHoldTime += Time.deltaTime;
            }
#else


            if (Input.GetKeyDown(attackKey) || IsButtonDown(attackButton))
            {
                attackDown = true;
            }
            if (attackDown)
            {
                if (AttackHoldTime >= chargeTime || Input.GetKeyUp(attackKey) || IsButtonUp(attackButton))
                {
                    OnAttackPressed?.Invoke(AttackHoldTime, false, useAttackInputForCounter, AttackHoldTime >= chargeTime, false);
                    attackDown = false;
                    AttackHoldTime = 0f;
                }
                AttackHoldTime += Time.deltaTime;
            }
#endif
        }

        void HandleHeavyAttack()
        {
#if inputsystem
            if (input.Combat.HeavyAttack.WasPressedThisFrame())
            {
                heavyAttackDown = true;
            }

            if (heavyAttackDown)
            {
                if (HeavyAttackHoldTime >= chargeTime || input.Combat.HeavyAttack.WasReleasedThisFrame())
                {
                    OnAttackPressed?.Invoke(HeavyAttackHoldTime, true, false, HeavyAttackHoldTime >= chargeTime, false);
                    heavyAttackDown = false;
                    HeavyAttackHoldTime = 0f;
                }

                HeavyAttackHoldTime += Time.deltaTime;
            }
#else
            if (Input.GetKeyDown(heavyAttackKey) || IsButtonDown(heavyAttackButton))
            {
                heavyAttackDown = true;
            }

            if (heavyAttackDown)
            {
                if (HeavyAttackHoldTime >= chargeTime || Input.GetKeyUp(heavyAttackKey) || IsButtonUp(heavyAttackButton))
                {
                    OnAttackPressed?.Invoke(HeavyAttackHoldTime, true, false, HeavyAttackHoldTime >= chargeTime, false);
                    heavyAttackDown = false;
                    HeavyAttackHoldTime = 0f;
                }

                HeavyAttackHoldTime += Time.deltaTime;
            }
#endif
        }


        void HandleSpecialAttack()
        {
#if inputsystem
            if (input.Combat.SpecialAttack.WasPressedThisFrame())
            {
                specialAttackDown = true;
            }

            if (specialAttackDown)
            {
                if (SpecialAttackHoldTime >= chargeTime || input.Combat.SpecialAttack.WasReleasedThisFrame())
                {
                    OnAttackPressed?.Invoke(SpecialAttackHoldTime, false, false, SpecialAttackHoldTime >= chargeTime, true);
                    specialAttackDown = false;
                    SpecialAttackHoldTime = 0f;
                }

                SpecialAttackHoldTime += Time.deltaTime;
            }
#else
            if (Input.GetKeyDown(specialAttackKey) || IsButtonDown(specialAttackButton))
            {
                specialAttackDown = true;
            }

            if (specialAttackDown)
            {
                if (SpecialAttackHoldTime >= chargeTime || Input.GetKeyUp(specialAttackKey) || IsButtonUp(specialAttackButton))
                {
                    OnAttackPressed?.Invoke(SpecialAttackHoldTime, false, false, SpecialAttackHoldTime >= chargeTime, true);
                    specialAttackDown = false;
                    SpecialAttackHoldTime = 0f;
                }

                SpecialAttackHoldTime += Time.deltaTime;
            }
#endif
        }

        void HandleCounter()
        {
            if (!useAttackInputForCounter)
            {
#if inputsystem
                if (input.Combat.Counter.WasPressedThisFrame())
                {
                    OnAttackPressed?.Invoke(0f, false, true, false, false);
                }
#else
                if(Input.GetKeyDown(counterKey) || IsButtonDown(counterButton))
                {
                    OnAttackPressed?.Invoke(0f, false, true, false, false);
                }
#endif
            }
        }

        void HandleBlock()
        {
#if inputsystem
            Block = input.Combat.Block.inProgress;
#else
            Block = Input.GetKey(blockKey) || (!string.IsNullOrEmpty(blockButton) && Input.GetButton(blockButton));
#endif
        }

        void HandleDodge()
        {

#if inputsystem
                Dodge = input.Combat.Dodge.WasPressedThisFrame();
#else
                Dodge = Input.GetKeyDown(dodgeKey) || (!string.IsNullOrEmpty(dodgeButton) && Input.GetButtonDown(dodgeButton));
#endif
        }

        void HandleRoll()
        {
#if inputsystem
            Roll = input.Combat.Roll.WasPressedThisFrame();
#else
            Roll = Input.GetKeyDown(rollKey) || (!string.IsNullOrEmpty(rollButton) && Input.GetButtonDown(rollButton));
#endif
        }

        void HandleCombatMode()
        {
#if inputsystem
            CombatMode = input.Combat.CombatMode.WasPressedThisFrame();
#else
            CombatMode = Input.GetKeyDown(combatModeKey) || (!string.IsNullOrEmpty(combatModeButton) && Input.GetButtonDown(combatModeButton));
#endif
        }




        public bool IsButtonDown(string buttonName)
        {
            if (!String.IsNullOrEmpty(buttonName))
                return Input.GetButtonDown(buttonName);
            else
                return false;
        }

        public bool IsButtonUp(string buttonName)
        {
            if (!String.IsNullOrEmpty(buttonName))
                return Input.GetButtonUp(buttonName);
            else
                return false;
        }
    }
}