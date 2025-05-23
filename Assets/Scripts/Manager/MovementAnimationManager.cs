using System;
using Common.Data;
using UnityEngine;

namespace Manager
{
    public class MovementAnimationManager : IDisposable
    {
        private Animator _animator;
        private const string MoveKey = "speedv";

        public void SetAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void Move(MoveDirection moveDirection)
        {
            var vec3Dir = DirectionToVector3(moveDirection);
            var speed = Mathf.Max(Mathf.Abs(vec3Dir.x), Mathf.Abs(vec3Dir.z));
            if (_animator == null)
            {
                return;
            }

            _animator.SetFloat(MoveKey, speed);
        }

        private static Vector3 DirectionToVector3(MoveDirection moveDirection)
        {
            return moveDirection switch
            {
                MoveDirection.Forward => Vector3.forward,
                MoveDirection.Back => Vector3.back,
                MoveDirection.Left => Vector3.left,
                MoveDirection.Right => Vector3.right,
                MoveDirection.None => Vector3.zero,
                _ => Vector3.zero
            };
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}