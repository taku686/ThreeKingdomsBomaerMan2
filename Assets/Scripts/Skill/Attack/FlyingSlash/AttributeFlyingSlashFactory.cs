using System;
using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.Attack.FlyingSlash
{
    public class AttributeFlyingSlashFactory : IFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalFlyingSlash.Factory _normalFlyingSlashFactory;
        private readonly PoisonFlyingSlash.Factory _poisonFlyingSlashFactory;
        private readonly ParalysisFlyingSlash.Factory _paralysisFlyingSlashFactory;
        private readonly FrozenFlyingSlash.Factory _frozenFlyingSlashFactory;
        private readonly ConfusionFlyingSlash.Factory _confusionFlyingSlashFactory;
        private readonly CharmFlyingSlash.Factory _charmFlyingSlashFactory;
        private readonly MiasmaFlyingSlash.Factory _miasmaFlyingSlashFactory;
        private readonly DarknessFlyingSlash.Factory _darknessFlyingSlashFactory;
        private readonly LifeStealFlyingSlash.Factory _lifeStealFlyingSlashFactory;
        private readonly HellFireFlyingSlash.Factory _hellFireFlyingSlashFactory;
        private readonly StigmataFlyingSlash.Factory _stigmataFlyingSlashFactory;
        private readonly SoakingWetFlyingSlash.Factory _soakingWetFlyingSlashFactory;
        private readonly BurningFlyingSlash.Factory _burningFlyingSlashFactory;

        [Inject]
        public AttributeFlyingSlashFactory
        (
            NormalFlyingSlash.Factory normalFlyingSlashFactory,
            PoisonFlyingSlash.Factory poisonFlyingSlashFactory,
            ParalysisFlyingSlash.Factory paralysisFlyingSlashFactory,
            FrozenFlyingSlash.Factory frozenFlyingSlashFactory,
            ConfusionFlyingSlash.Factory confusionFlyingSlashFactory,
            CharmFlyingSlash.Factory charmFlyingSlashFactory,
            MiasmaFlyingSlash.Factory miasmaFlyingSlashFactory,
            DarknessFlyingSlash.Factory darknessFlyingSlashFactory,
            LifeStealFlyingSlash.Factory lifeStealFlyingSlashFactory,
            HellFireFlyingSlash.Factory hellFireFlyingSlashFactory,
            StigmataFlyingSlash.Factory stigmataFlyingSlashFactory,
            SoakingWetFlyingSlash.Factory soakingWetFlyingSlashFactory,
            BurningFlyingSlash.Factory burningFlyingSlashFactory
        )
        {
            _normalFlyingSlashFactory = normalFlyingSlashFactory;
            _poisonFlyingSlashFactory = poisonFlyingSlashFactory;
            _paralysisFlyingSlashFactory = paralysisFlyingSlashFactory;
            _frozenFlyingSlashFactory = frozenFlyingSlashFactory;
            _confusionFlyingSlashFactory = confusionFlyingSlashFactory;
            _charmFlyingSlashFactory = charmFlyingSlashFactory;
            _miasmaFlyingSlashFactory = miasmaFlyingSlashFactory;
            _darknessFlyingSlashFactory = darknessFlyingSlashFactory;
            _lifeStealFlyingSlashFactory = lifeStealFlyingSlashFactory;
            _hellFireFlyingSlashFactory = hellFireFlyingSlashFactory;
            _stigmataFlyingSlashFactory = stigmataFlyingSlashFactory;
            _soakingWetFlyingSlashFactory = soakingWetFlyingSlashFactory;
            _burningFlyingSlashFactory = burningFlyingSlashFactory;
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
                return _normalFlyingSlashFactory.Create(animator);
            }

            return attribute switch
            {
                AbnormalCondition.Poison => _poisonFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Paralysis => _paralysisFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Frozen => _frozenFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Confusion => _confusionFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Charm => _charmFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Miasma => _miasmaFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Darkness => _darknessFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.LifeSteal => _lifeStealFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.HellFire => _hellFireFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.TimeStop => _stigmataFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.SoakingWet => _soakingWetFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Burning => _burningFlyingSlashFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.NockBack => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null),
                AbnormalCondition.Sealed => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null),
                AbnormalCondition.Curse => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null),
                AbnormalCondition.Fear => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null),
                AbnormalCondition.Apraxia => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null),
                AbnormalCondition.ParalyzingThunder => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}