using AttributeAttack;

namespace Skill.Attack.FlyingSlash
{
    public class FlyingSlashBase : IAttackBehaviour
    {
        public virtual void Attack()
        {
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}