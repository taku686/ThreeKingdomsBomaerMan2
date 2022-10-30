using Common.Data;
using UnityEngine;
using Zenject;

namespace Manager
{
    public class AnimationManager
    {
        private Animator _animator;
        private static readonly string MoveKey = "speedv";

        public AnimationManager(Animator animator)
        {
            _animator = animator;
        }

        [Inject]
        private void Initialize(Animator animator)
        {
            _animator = animator;
        }

        public void Move(Direction direction)
        {
            var vec3Dir = DirectionToVector3(direction);
            var speed = Mathf.Max(Mathf.Abs(vec3Dir.x), Mathf.Abs(vec3Dir.z));
            _animator.SetFloat(MoveKey, speed);
        }

        private Vector3 DirectionToVector3(Direction direction)
        {
            switch (direction)
            {
                case Direction.Forward:
                    return Vector3.forward;
                case Direction.Back:
                    return Vector3.back;
                case Direction.Left:
                    return Vector3.left;
                case Direction.Right:
                    return Vector3.right;
                case Direction.None:
                    return Vector3.zero;
                default:
                    return Vector3.zero;
            }
        }
    }
}