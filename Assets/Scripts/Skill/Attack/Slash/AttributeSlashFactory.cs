using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class AttributeSlashFactory : IFactory<Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
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

        public IAttackBehaviour Create
        (
            Animator animator,
            Transform playerTransform,
            AbnormalCondition attribute,
            IAttackBehaviour attack
        )
        {
            if (attack == null && attribute == AbnormalCondition.None)
            {
                return _normalSlashBehaviourFactory.Create(animator);
            }

            return attribute switch
            {
                AbnormalCondition.None => _normalSlashBehaviourFactory.Create(animator),
                AbnormalCondition.Poison => _poisonSlashBehaviourFactory.Create(animator, playerTransform, attack),
                AbnormalCondition.Paralysis => _paralysisSlashBehaviourFactory.Create(animator, playerTransform, attack),
                _ => throw new System.NotImplementedException()
            };
        }

        public class SlashFactory : PlaceholderFactory<Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}