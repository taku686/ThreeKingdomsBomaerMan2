using AttributeAttack;
using Common.Data;
using DC.Scanner;
using Repository;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class LifeStealSlash : SlashBase
    {
        private readonly int _skillId;
        private readonly TargetScanner _targetScanner;
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public LifeStealSlash
        (
            int skillId,
            TargetScanner targetScanner,
            Animator animator,
            Transform playerTransform,
            IAttackBehaviour attackBehaviour,
            SlashSkillEffectRepository slashSkillEffectRepository
        ) : base(slashSkillEffectRepository)
        {
            _skillId = skillId;
            _targetScanner = targetScanner;
            _animator = animator;
            _playerTransform = playerTransform;
            _attackBehaviour = attackBehaviour;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            Slash(AbnormalCondition.LifeSteal, _animator, _targetScanner, _skillId, _playerTransform);
        }

        public override void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, LifeStealSlash>
        {
        }
    }
}