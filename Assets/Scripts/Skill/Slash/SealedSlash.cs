﻿using AttributeAttack;
using Common.Data;
using DC.Scanner;
using Repository;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class SealedSlash : SlashBase
    {
        private readonly int _skillId;
        private readonly Transform _playerTransform;
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public SealedSlash
        (
            int skillId,
            Transform playerTransform,
            IAttackBehaviour attackBehaviour,
            SkillEffectRepository skillEffectRepository
        ) : base(skillEffectRepository)
        {
            _skillId = skillId;
            _playerTransform = playerTransform;
            _attackBehaviour = attackBehaviour;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            Slash(AbnormalCondition.Sealed, _skillId, _playerTransform);
        }

        public override void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<int, Transform, IAttackBehaviour, SealedSlash>
        {
        }
    }
}