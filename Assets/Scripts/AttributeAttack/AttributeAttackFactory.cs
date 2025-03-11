using AttributeAttack.Sample;
using Zenject;

namespace AttributeAttack
{
    public  class AttributeAttackFactory : IFactory<PlayerInstaller.AttackAttribute, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalAttackBehaviour.Factory _normalAttackBehaviourFactory;
        private readonly PoisonAttackBehaviour.Factory _poisonAttackBehaviourFactory;
        private readonly WaterAttackBehaviour.Factory _waterAttackBehaviourFactory;

        public AttributeAttackFactory
        (
            NormalAttackBehaviour.Factory normalAttackBehaviourFactory,
            PoisonAttackBehaviour.Factory poisonAttackBehaviourFactory,
            WaterAttackBehaviour.Factory waterAttackBehaviourFactory
        )
        {
            _normalAttackBehaviourFactory = normalAttackBehaviourFactory;
            _poisonAttackBehaviourFactory = poisonAttackBehaviourFactory;
            _waterAttackBehaviourFactory = waterAttackBehaviourFactory;
        }

        public IAttackBehaviour Create(PlayerInstaller.AttackAttribute attribute, IAttackBehaviour attack)
        {
            if (attack == null && attribute == PlayerInstaller.AttackAttribute.Normal)
            {
                return _normalAttackBehaviourFactory.Create();
            }

            return attribute switch
            {
                PlayerInstaller.AttackAttribute.Normal => _normalAttackBehaviourFactory.Create(),
                PlayerInstaller.AttackAttribute.Poison => _poisonAttackBehaviourFactory.Create(attack),
                PlayerInstaller.AttackAttribute.Water => _waterAttackBehaviourFactory.Create(attack),
                _ => throw new System.NotImplementedException()
            };
        }
    }

    public class AttackFactory : PlaceholderFactory<PlayerInstaller.AttackAttribute, IAttackBehaviour, IAttackBehaviour>
    {
    }
}