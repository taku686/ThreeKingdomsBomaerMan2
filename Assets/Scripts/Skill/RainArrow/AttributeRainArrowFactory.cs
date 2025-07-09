using System;
using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.RainArrow
{
    public class AttributeRainArrowFactory : IFactory<int, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalRainArrow.Factory _normalRainArrowFactory;
        private readonly PoisonRainArrow.Factory _poisonRainArrowFactory;
        private readonly BurningRainArrow.Factory _burningRainArrowFactory;
        private readonly CharmRainArrow.Factory _charmRainArrowFactory;
        private readonly FrozenRainArrow.Factory _frozenRainArrowFactory;
        private readonly HellFireRainArrow.Factory _hellFireRainArrowFactory;
        private readonly LifeStealRainArrow.Factory _lifeStealRainArrowFactory;
        private readonly MiasmaRainArrow.Factory _miasmaRainArrowFactory;
        private readonly StigmataRainArrow.Factory _stigmataRainArrowFactory;
        private readonly SoakingWetRainArrow.Factory _soakingWetRainArrowFactory;
        private readonly ParalysisRainArrow.Factory _paralysisRainArrowFactory;
        private readonly ConfusionRainArrow.Factory _confusionRainArrowFactory;
        private readonly DarknessRainArrow.Factory _darknessRainArrowFactory;

        [Inject]
        public AttributeRainArrowFactory
        (
            NormalRainArrow.Factory normalRainArrowFactory,
            PoisonRainArrow.Factory poisonRainArrowFactory,
            BurningRainArrow.Factory burningRainArrowFactory,
            CharmRainArrow.Factory charmRainArrowFactory,
            FrozenRainArrow.Factory frozenRainArrowFactory,
            HellFireRainArrow.Factory hellFireRainArrowFactory,
            LifeStealRainArrow.Factory lifeStealRainArrowFactory,
            MiasmaRainArrow.Factory miasmaRainArrowFactory,
            StigmataRainArrow.Factory stigmataRainArrowFactory,
            SoakingWetRainArrow.Factory soakingWetRainArrowFactory,
            ParalysisRainArrow.Factory paralysisRainArrowFactory,
            ConfusionRainArrow.Factory confusionRainArrowFactory,
            DarknessRainArrow.Factory darknessRainArrowFactory
        )
        {
            _normalRainArrowFactory = normalRainArrowFactory;
            _poisonRainArrowFactory = poisonRainArrowFactory;
            _burningRainArrowFactory = burningRainArrowFactory;
            _charmRainArrowFactory = charmRainArrowFactory;
            _frozenRainArrowFactory = frozenRainArrowFactory;
            _hellFireRainArrowFactory = hellFireRainArrowFactory;
            _lifeStealRainArrowFactory = lifeStealRainArrowFactory;
            _miasmaRainArrowFactory = miasmaRainArrowFactory;
            _stigmataRainArrowFactory = stigmataRainArrowFactory;
            _soakingWetRainArrowFactory = soakingWetRainArrowFactory;
            _paralysisRainArrowFactory = paralysisRainArrowFactory;
            _confusionRainArrowFactory = confusionRainArrowFactory;
            _darknessRainArrowFactory = darknessRainArrowFactory;
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
                return _normalRainArrowFactory.Create();
            }

            return attribute switch
            {
                AbnormalCondition.Paralysis => _paralysisRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Poison => _poisonRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Frozen => _frozenRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Confusion => _confusionRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Charm => _charmRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Miasma => _miasmaRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Darkness => _darknessRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.LifeSteal => _lifeStealRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.HellFire => _hellFireRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.TimeStop => _stigmataRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.SoakingWet => _soakingWetRainArrowFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Burning => _burningRainArrowFactory.Create(skillId, playerTransform, attack),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}