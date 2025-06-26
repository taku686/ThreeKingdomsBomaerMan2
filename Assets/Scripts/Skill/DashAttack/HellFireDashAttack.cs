using AttributeAttack;
using Common.Data;
using Manager.DataManager;
using Repository;
using UnityEngine;
using Zenject;

namespace Skill.DashAttack
{
    public class HellFireDashAttack : DashAttackBase
    {
        private readonly IAttackBehaviour _attackBehaviour;
        private readonly Transform _playerTransform;
        private readonly int _skillId;

        public HellFireDashAttack
        (
            SkillMasterDataRepository skillMasterDataRepository,
            SkillEffectRepository skillEffectRepository,
            IAttackBehaviour attackBehaviour,
            Transform playerTransform,
            int skillId
        ) : base(skillEffectRepository,skillMasterDataRepository)
        {
            _attackBehaviour = attackBehaviour;
            _playerTransform = playerTransform;
            _skillId = skillId;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            DashAttack(AbnormalCondition.HellFire, _skillId, _playerTransform);
        }

        public class Factory : PlaceholderFactory
        <
            int,
            Transform,
            IAttackBehaviour,
            HellFireDashAttack
        >
        {
        }
    }
}