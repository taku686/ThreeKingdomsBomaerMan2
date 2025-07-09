using AttributeAttack;
using Zenject;

namespace Skill.RainArrow
{
    public class NormalRainArrow : IAttackBehaviour
    {
        public void Attack()
        {
    
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
        
        public class Factory : PlaceholderFactory<NormalRainArrow>
        {
        }
    }
}