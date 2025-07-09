using AttributeAttack;
using Common.Data;
using Manager.DataManager;
using Repository;
using UnityEngine;
using Zenject;

namespace Skill.RainArrow
{
    public class DarknessRainArrow : RainArrowBase
    {
        private readonly int _skillId;
        private readonly Transform _playerTransform;
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public DarknessRainArrow
        (
            int skillId,
            Transform playerTransform,
            IAttackBehaviour attackBehaviour,
            SkillEffectRepository skillEffectRepository,
            SkillMasterDataRepository skillMasterDataRepository
        ) : base(skillEffectRepository, skillMasterDataRepository)
        {
            _skillId = skillId;
            _playerTransform = playerTransform;
            _attackBehaviour = attackBehaviour;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            RainArrow(AbnormalCondition.Darkness, _skillId, _playerTransform);
        }

        public class Factory : PlaceholderFactory<int, Transform, IAttackBehaviour, DarknessRainArrow>
        {
        }
    }
}