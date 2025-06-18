using System;
using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.MagicShot
{
    public class AttributeMagicShotFactory : IFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalMagicShot.Factory _normalMagicShotFactory;
        private readonly PoisonMagicShot.Factory _poisonMagicShotFactory;

        [Inject]
        public AttributeMagicShotFactory
        (
            NormalMagicShot.Factory normalMagicShotFactory,
            PoisonMagicShot.Factory poisonMagicShotFactory
        )
        {
            _normalMagicShotFactory = normalMagicShotFactory;
            _poisonMagicShotFactory = poisonMagicShotFactory;
        }


        public IAttackBehaviour Create
        (
            int skillId,
            Animator animator,
            Transform playerTransform,
            AbnormalCondition attribute,
            IAttackBehaviour attack
        )
        {
            if (attack == null && attribute == AbnormalCondition.None)
            {
                return _normalMagicShotFactory.Create(animator);
            }

            return attribute switch
            {
                AbnormalCondition.Poison => _poisonMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}