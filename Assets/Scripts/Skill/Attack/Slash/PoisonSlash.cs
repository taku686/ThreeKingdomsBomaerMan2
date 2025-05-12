using AttributeAttack;
using Common.Data;
using Repository;
using UnityEngine;
using Zenject;
using TargetScanner = DC.Scanner.TargetScanner;

namespace Skill.Attack
{
    public class PoisonSlash : SlashBase
    {
        private readonly int _skillId;
        private readonly TargetScanner _targetScanner;
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public PoisonSlash
        (
            int skillId,
            TargetScanner targetScanner,
            Animator animator,
            Transform playerTransform,
            IAttackBehaviour attackBehaviour,
            SkillEffectRepository skillEffectRepository
        ) : base(skillEffectRepository)
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
            var effect = _SkillEffectRepository.GetSkillEffect(AbnormalCondition.Poison);
            var effectClone = Object.Instantiate(effect, _playerTransform.position, Quaternion.identity);
        }

        public override void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }

        public class Factory : PlaceholderFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, PoisonSlash>
        {
        }
    }
}