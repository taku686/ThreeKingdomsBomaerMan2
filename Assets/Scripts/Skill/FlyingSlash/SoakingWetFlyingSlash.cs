﻿using AttributeAttack;
using Common.Data;
using Manager.DataManager;
using Repository;
using UnityEngine;
using Zenject;

namespace Skill.Attack.FlyingSlash
{
    public class SoakingWetFlyingSlash : FlyingSlashBase
    {
        private readonly IAttackBehaviour _attackBehaviour;
        private readonly Animator _animator;
        private readonly Transform _playerTransform;
        private readonly int _skillId;

        public SoakingWetFlyingSlash
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
            _animator = animator;
            _playerTransform = playerTransform;
            _skillId = skillId;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            FlyingSlash(AbnormalCondition.SoakingWet, _skillId, _playerTransform);
        }

        public class Factory : PlaceholderFactory
        <
            int,
            Animator,
            Transform,
            IAttackBehaviour,
            SoakingWetFlyingSlash
        >
        {
        }
    }
}