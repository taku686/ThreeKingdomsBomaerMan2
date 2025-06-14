using AttributeAttack;
using Common.Data;
using Repository;
using UnityEngine;
using Zenject;

namespace Skill.DashAttack
{
    public class SoakingWetDashAttack : DashAttackBase
    {
        private readonly IAttackBehaviour _attackBehaviour;
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private readonly int _skillId;

        public SoakingWetDashAttack
        (
            SkillEffectRepository skillEffectRepository,
            IAttackBehaviour attackBehaviour,
            Animator animator,
            Transform playerTransform,
            int skillId
        ) : base(skillEffectRepository)
        {
            _attackBehaviour = attackBehaviour;
            _animator = animator;
            _playerTransform = playerTransform;
            _skillId = skillId;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            DashAttack(AbnormalCondition.SoakingWet, _animator, _skillId, _playerTransform);
        }

        public class Factory : PlaceholderFactory
        <
            int,
            Animator,
            Transform,
            IAttackBehaviour,
            SoakingWetDashAttack
        >
        {
        }
    }
}