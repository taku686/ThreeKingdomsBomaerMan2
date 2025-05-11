using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class AttributeSlashFactory : IFactory<Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalSlash.Factory _normalSlashBehaviourFactory;
        private readonly PoisonSlash.Factory _poisonSlashBehaviourFactory;
        private readonly ParalysisSlash.Factory _paralysisSlashBehaviourFactory;

        [Inject]
        public AttributeSlashFactory
        (
            NormalSlash.Factory normalSlashBehaviourFactory,
            PoisonSlash.Factory poisonSlashBehaviourFactory,
            ParalysisSlash.Factory paralysisSlashBehaviourFactory
        )
        {
            _normalSlashBehaviourFactory = normalSlashBehaviourFactory;
            _poisonSlashBehaviourFactory = poisonSlashBehaviourFactory;
            _paralysisSlashBehaviourFactory = paralysisSlashBehaviourFactory;
        }

        public IAttackBehaviour Create(Transform playerTransform, AbnormalCondition attribute, IAttackBehaviour attack)
        {
            if (attack == null && attribute == AbnormalCondition.None)
            {
                return _normalSlashBehaviourFactory.Create();
            }

            return attribute switch
            {
                AbnormalCondition.None => _normalSlashBehaviourFactory.Create(),
                AbnormalCondition.Poison => _poisonSlashBehaviourFactory.Create(attack),
                AbnormalCondition.Paralysis => _paralysisSlashBehaviourFactory.Create(attack),
                _ => throw new System.NotImplementedException()
            };
        }

        public class SlashFactory : PlaceholderFactory<Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}