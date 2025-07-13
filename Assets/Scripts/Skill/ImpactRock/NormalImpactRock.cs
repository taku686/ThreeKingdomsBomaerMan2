using AttributeAttack;
using Zenject;

namespace Skill.ImpactRock
{
    public class NormalImpactRock : IAttackBehaviour
    {
        public void Attack()
        {
        }

        public void Dispose()
        {
        }
        
        public class Factory : PlaceholderFactory<NormalImpactRock>
        {
            // Factory class for creating instances of NormalImpactRock
            // This can be used with Zenject for dependency injection
        }
    }
}