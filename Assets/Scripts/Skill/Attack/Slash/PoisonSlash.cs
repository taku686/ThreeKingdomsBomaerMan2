using AttributeAttack;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class PoisonSlash : SlashBase
    {
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public PoisonSlash
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
            Debug.Log("Poison Attack");
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }

        public class Factory : PlaceholderFactory<IAttackBehaviour, PoisonSlash>
        {
        }
    }
}