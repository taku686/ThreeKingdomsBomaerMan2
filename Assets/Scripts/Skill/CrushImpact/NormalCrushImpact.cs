using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.CrushImpact
{
    public class NormalCrushImpact : IAttackBehaviour
    {
        private readonly Animator _animator;

        [Inject]
        public NormalCrushImpact(Animator animator)
        {
            _animator = animator;
        }

        public void Attack()
        {
            _animator.SetTrigger(GameCommonData.ImpactHashKey);
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Animator, NormalCrushImpact>
        {
        }
    }
}