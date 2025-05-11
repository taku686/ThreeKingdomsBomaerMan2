using AttributeAttack;
using Zenject;

namespace Skill.Attack
{
    public class SlashBase : IAttackBehaviour
    {
        protected readonly SkillEffectRepository _SkillEffectRepository;

        [Inject]
        public SlashBase(SkillEffectRepository skillEffectRepository)
        {
            _SkillEffectRepository = skillEffectRepository;
        }

        public virtual void Dispose()
        {
        }

        public virtual void Attack()
        {
        }
    }
}