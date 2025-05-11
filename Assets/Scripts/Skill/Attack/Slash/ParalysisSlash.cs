using AttributeAttack;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class ParalysisSlash : SlashBase
    {
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public ParalysisSlash
        (
            IAttackBehaviour attackBehaviour,
            SkillEffectRepository skillEffectRepository
        ) : base(skillEffectRepository)
        {
            _attackBehaviour = attackBehaviour;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            Debug.Log("Paralysis Slash Attack");
        }

        public override void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<IAttackBehaviour, ParalysisSlash>
        {
        }
    }
}