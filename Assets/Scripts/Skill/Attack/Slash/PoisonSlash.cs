using AttributeAttack;
using Common.Data;
using Repository;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class PoisonSlash : SlashBase
    {
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public PoisonSlash
        (
            Animator animator,
            Transform playerTransform,
            IAttackBehaviour attackBehaviour,
            SkillEffectRepository skillEffectRepository
        ) : base(skillEffectRepository)
        {
            _animator = animator;
            _playerTransform = playerTransform;
            _attackBehaviour = attackBehaviour;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            var effect = _SkillEffectRepository.GetSkillEffect(AbnormalCondition.Poison);
            var effectClone = Object.Instantiate(effect, _playerTransform.position, Quaternion.identity);
            Debug.Log("Poison Attack");
        }

        public override void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }

        public class Factory : PlaceholderFactory<Animator, Transform, IAttackBehaviour, PoisonSlash>
        {
        }
    }
}