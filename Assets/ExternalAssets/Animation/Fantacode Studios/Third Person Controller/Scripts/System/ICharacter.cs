using System;
using System.Collections;
using UnityEngine;

namespace FS_ThirdPerson
{
    public interface ICharacter
    {
        /// <summary>
        /// Gravity for playing acitons
        /// </summary>
        public float Gravity { get; }

        /// <summary>
        /// Animator of the controller
        /// </summary>
        public Animator Animator { get; set; }

        /// <summary>
        /// While true, the root motion of the animation will be applied to the character
        /// </summary>
        public bool UseRootMotion { get; set; }

        /// <summary>
        /// Return the user's input direction in this property. This is used to determine the direction in which the player should jump/perform action. 
        /// </summary>
        public Vector3 MoveDir { get; }

        /// <summary>
        /// Return true in the property if the player's feet is touching the ground. The actions will only be performed if the player is grounded.
        /// </summary>
        public bool IsGrounded { get; }

        /// <summary>
        /// Return true if you want to prevent the character from performing actions.
        /// You can use this property when the character is performing some other actions like attacking, shooting, reloading, etc.
        /// </summary>
        public bool PreventAllSystems { get; set; }

        /// <summary>
        /// This function will be called while starting a Parkour/Climbing action. 
        /// From this function you can do things like disabling the collider of the player, resetting the walking or running animation paramater, etc.
        /// </summary>
        void OnStartSystem(SystemBase systemBase = null);

        /// <summary>
        /// This function will be called once an action is completed.
        /// From this function you can do things like enabling the collider of the player.
        /// </summary>
        void OnEndSystem(SystemBase systemBase = null);
    }

    public interface IDamagable
    {
        public float Health { get; set; }
        public float DamageMultiplier { get; }
        public Action<Vector3, float> OnHit { get; set; }
        public IDamagable Parent { get; }

    }
}
