using Common.Data;
using UnityEngine;

namespace Manager
{
    public class AnimationManager : MonoBehaviour
    {
        private Animator _animator;

        private Transform _player;

        public void Initialize(Transform player, Animator animator)
        {
            _animator = animator;

            _player = player;
        }

        public void Move(float x, float z)
        {
            /*if (Mathf.Abs(x) > 0.001f)
            {
                z = 0;
                
            }*/

            var speed = Mathf.Max(Mathf.Abs(x), Mathf.Abs(z));
            _animator.SetFloat("speedv", speed);
        }
    }
}