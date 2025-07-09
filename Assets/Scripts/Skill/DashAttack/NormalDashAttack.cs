using AttributeAttack;
using UnityEngine;
using Zenject;

namespace Skill.DashAttack
{
    public class NormalDashAttack : IAttackBehaviour
    {
        private readonly Animator _animator;

        [Inject]
        public NormalDashAttack
        (
            Animator animator
        )
        {
            _animator = animator;
        }

        public void Attack()
        {
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Animator, NormalDashAttack>
        {
        }
    }
}