using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.CrushImpact
{
    public class AttributeCrushImpactFactory : IFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalCrushImpact.Factory _normalCrushImpactFactory;

        [Inject]
        public AttributeCrushImpactFactory
        (
            NormalCrushImpact.Factory normalCrushImpactFactory
        )
        {
            _normalCrushImpactFactory = normalCrushImpactFactory;
        }

        public IAttackBehaviour Create
        (
            int skillId,
            Animator animator,
            Transform playerTransform,
            AbnormalCondition attribute,
            IAttackBehaviour attack
        )
        {
            if (attack == null && attribute == AbnormalCondition.None)
            {
                return _normalCrushImpactFactory.Create(animator);
            }

            return null;
        }

        public class Factory : PlaceholderFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}