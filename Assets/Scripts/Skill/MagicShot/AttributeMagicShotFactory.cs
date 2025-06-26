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
        private readonly ParalysisMagicShot.Factory _paralysisMagicShotFactory;
        private readonly FrozenMagicShot.Factory _frozenMagicShotFactory;
        private readonly ConfusionMagicShot.Factory _confusionMagicShotFactory;
        private readonly CharmMagicShot.Factory _charmMagicShotFactory;
        private readonly MiasmaMagicShot.Factory _miasmaMagicShotFactory;
        private readonly DarknessMagicShot.Factory _darknessMagicShotFactory;
        private readonly LifeStealMagicShot.Factory _lifeStealMagicShotFactory;
        private readonly HellFireMagicShot.Factory _hellFireMagicShotFactory;
        private readonly StigmataMagicShot.Factory _stigmataMagicShotFactory;
        private readonly SoakingWetMagicShot.Factory _soakingWetMagicShotFactory;
        private readonly BurningMagicShot.Factory _burningMagicShotFactory;

        [Inject]
        public AttributeMagicShotFactory
        (
            NormalMagicShot.Factory normalMagicShotFactory,
            PoisonMagicShot.Factory poisonMagicShotFactory,
            ParalysisMagicShot.Factory paralysisMagicShotFactory,
            FrozenMagicShot.Factory frozenMagicShotFactory,
            ConfusionMagicShot.Factory confusionMagicShotFactory,
            CharmMagicShot.Factory charmMagicShotFactory,
            MiasmaMagicShot.Factory miasmaMagicShotFactory,
            DarknessMagicShot.Factory darknessMagicShotFactory,
            LifeStealMagicShot.Factory lifeStealMagicShotFactory,
            HellFireMagicShot.Factory hellFireMagicShotFactory,
            StigmataMagicShot.Factory stigmataMagicShotFactory,
            SoakingWetMagicShot.Factory soakingWetMagicShotFactory,
            BurningMagicShot.Factory burningMagicShotFactory
        )
        {
            _normalMagicShotFactory = normalMagicShotFactory;
            _poisonMagicShotFactory = poisonMagicShotFactory;
            _paralysisMagicShotFactory = paralysisMagicShotFactory;
            _frozenMagicShotFactory = frozenMagicShotFactory;
            _confusionMagicShotFactory = confusionMagicShotFactory;
            _charmMagicShotFactory = charmMagicShotFactory;
            _miasmaMagicShotFactory = miasmaMagicShotFactory;
            _darknessMagicShotFactory = darknessMagicShotFactory;
            _lifeStealMagicShotFactory = lifeStealMagicShotFactory;
            _hellFireMagicShotFactory = hellFireMagicShotFactory;
            _stigmataMagicShotFactory = stigmataMagicShotFactory;
            _soakingWetMagicShotFactory = soakingWetMagicShotFactory;
            _burningMagicShotFactory = burningMagicShotFactory;
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
                AbnormalCondition.Paralysis => _paralysisMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Frozen => _frozenMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Confusion => _confusionMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Charm => _charmMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Miasma => _miasmaMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Darkness => _darknessMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.LifeSteal => _lifeStealMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.HellFire => _hellFireMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.TimeStop => _stigmataMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.SoakingWet => _soakingWetMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Burning => _burningMagicShotFactory.Create(skillId, animator, playerTransform, attack),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}