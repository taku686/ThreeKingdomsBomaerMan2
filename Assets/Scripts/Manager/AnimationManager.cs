using System;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Manager
{
    public class AnimationManager : IDisposable
    {
        private Animator animator;
        private static readonly string MoveKey = "speedv";

        public AnimationManager(Animator animator)
        {
            this.animator = animator;
        }

        [Inject]
        private void Initialize(Animator animator)
        {
            this.animator = animator;
        }

        public void Move(MoveDirection moveDirection)
        {
            var vec3Dir = DirectionToVector3(moveDirection);
            var speed = Mathf.Max(Mathf.Abs(vec3Dir.x), Mathf.Abs(vec3Dir.z));
            animator.SetFloat(MoveKey, speed);
        }

        private Vector3 DirectionToVector3(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.Forward:
                    return Vector3.forward;
                case MoveDirection.Back:
                    return Vector3.back;
                case MoveDirection.Left:
                    return Vector3.left;
                case MoveDirection.Right:
                    return Vector3.right;
                case MoveDirection.None:
                    return Vector3.zero;
                default:
                    return Vector3.zero;
            }
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}