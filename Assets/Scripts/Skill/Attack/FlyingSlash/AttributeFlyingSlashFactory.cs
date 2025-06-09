using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.Attack.FlyingSlash
{
    public class AttributeFlyingSlashFactory : IFactory<Animator, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalFlyingSlash.Factory _normalFlyingSlashFactory;

        [Inject]
        public AttributeFlyingSlashFactory
        (
            NormalFlyingSlash.Factory normalFlyingSlashFactory
        )
        {
            _normalFlyingSlashFactory = normalFlyingSlashFactory;
        }

        public IAttackBehaviour Create
        (
            Animator animator,
            AbnormalCondition attribute,
            IAttackBehaviour attack
        )
        {
            if (attack == null && attribute == AbnormalCondition.None)
            {
                return _normalFlyingSlashFactory.Create(animator);
            }

            return null;
        }

        public class Factory : PlaceholderFactory<Animator, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}