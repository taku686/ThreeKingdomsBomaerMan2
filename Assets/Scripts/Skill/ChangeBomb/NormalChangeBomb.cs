using AttributeAttack;
using Zenject;

namespace Skill.ChangeBomb
{
    public class NormalChangeBomb : IAttackBehaviour
    {
        public void Attack()
        {
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<NormalChangeBomb>
        {
        }
    }
}