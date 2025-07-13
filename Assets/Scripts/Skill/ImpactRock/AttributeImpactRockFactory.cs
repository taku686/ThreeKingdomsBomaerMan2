using System;
using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.ImpactRock
{
    public class AttributeImpactRockFactory : IFactory<int, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalImpactRock.Factory _normalImpactRockFactory;
        private readonly PoisonImpactRock.Factory _poisonImpactRockFactory;
        private readonly ParalysisImpactRock.Factory _paralysisImpactRockFactory;
        private readonly SoakingWetImpactRock.Factory _soakingWetImpactRockFactory;
        private readonly BurningImpactRock.Factory _burningImpactRockFactory;
        private readonly FrozenImpactRock.Factory _frozenImpactRockFactory;
        private readonly CharmImpactRock.Factory _charmImpactRockFactory;
        private readonly ConfusionImpactRock.Factory _confusionImpactRockFactory;
        private readonly DarknessImpactRock.Factory _darknessImpactRockFactory;
        private readonly HellFireImpactRock.Factory _hellFireImpactRockFactory;
        private readonly MiasmaImpactRock.Factory _miasmaImpactRockFactory;
        private readonly StigmataImpactRock.Factory _stigmataImpactRockFactory;

        [Inject]
        public AttributeImpactRockFactory
        (
            NormalImpactRock.Factory normalImpactRockFactory,
            PoisonImpactRock.Factory poisonImpactRockFactory,
            ParalysisImpactRock.Factory paralysisImpactRockFactory,
            SoakingWetImpactRock.Factory soakingWetImpactRockFactory,
            BurningImpactRock.Factory burningImpactRockFactory,
            FrozenImpactRock.Factory frozenImpactRockFactory,
            CharmImpactRock.Factory charmImpactRockFactory,
            ConfusionImpactRock.Factory confusionImpactRockFactory,
            DarknessImpactRock.Factory darknessImpactRockFactory,
            HellFireImpactRock.Factory hellFireImpactRockFactory,
            MiasmaImpactRock.Factory miasmaImpactRockFactory,
            StigmataImpactRock.Factory stigmataImpactRockFactory
        )
        {
            _normalImpactRockFactory = normalImpactRockFactory;
            _poisonImpactRockFactory = poisonImpactRockFactory;
            _paralysisImpactRockFactory = paralysisImpactRockFactory;
            _soakingWetImpactRockFactory = soakingWetImpactRockFactory;
            _burningImpactRockFactory = burningImpactRockFactory;
            _frozenImpactRockFactory = frozenImpactRockFactory;
            _charmImpactRockFactory = charmImpactRockFactory;
            _confusionImpactRockFactory = confusionImpactRockFactory;
            _darknessImpactRockFactory = darknessImpactRockFactory;
            _hellFireImpactRockFactory = hellFireImpactRockFactory;
            _miasmaImpactRockFactory = miasmaImpactRockFactory;
            _stigmataImpactRockFactory = stigmataImpactRockFactory;
        }

        public IAttackBehaviour Create
        (
            int skillId,
            Transform playerTransform,
            AbnormalCondition attribute,
            IAttackBehaviour attack
        )
        {
            if (attack == null && attribute == AbnormalCondition.None)
            {
                return _normalImpactRockFactory.Create();
            }

            return attribute switch
            {
                AbnormalCondition.Paralysis => _paralysisImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Poison => _poisonImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Frozen => _frozenImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Confusion => _confusionImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Charm => _charmImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Miasma => _miasmaImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Darkness => _darknessImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.HellFire => _hellFireImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.TimeStop => _stigmataImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.SoakingWet => _soakingWetImpactRockFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Burning => _burningImpactRockFactory.Create(skillId, playerTransform, attack),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}