﻿using AttributeAttack;
using Common.Data;
using Manager.DataManager;
using Repository;
using UnityEngine;
using Zenject;

namespace Skill.MagicShot
{
    public class ConfusionMagicShot : MagicShotBase
    {
        private readonly IAttackBehaviour _attackBehaviour;
        private readonly Transform _playerTransform;
        private readonly int _skillId;

        public ConfusionMagicShot
        (
            SkillEffectRepository skillEffectRepository,
            SkillMasterDataRepository skillMasterDataRepository,
            IAttackBehaviour attackBehaviour,
            Animator animator,
            Transform playerTransform,
            int skillId
        ) : base(skillEffectRepository, skillMasterDataRepository)
        {
            _attackBehaviour = attackBehaviour;
            _playerTransform = playerTransform;
            _skillId = skillId;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            MagicShot(AbnormalCondition.Confusion, _skillId, _playerTransform);
        }

        public class Factory : PlaceholderFactory
        <
            int,
            Animator,
            Transform,
            IAttackBehaviour,
            ConfusionMagicShot
        >
        {
        }
    }
}