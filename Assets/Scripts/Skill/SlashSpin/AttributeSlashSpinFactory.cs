using System;
using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.SlashSpin
{
    public class AttributeSlashSpinFactory : IFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalSlashSpin.Factory _normalSlashSpinFactory;
        private readonly PoisonSlashSpin.Factory _poisonSlashSpinFactory;
        private readonly ParalysisSlashSpin.Factory _paralysisSlashSpinFactory;
        private readonly FrozenSlashSpin.Factory _frozenSlashSpinFactory;
        private readonly ConfusionSlashSpin.Factory _confusionSlashSpinFactory;
        private readonly CharmSlashSpin.Factory _charmSlashSpinFactory;
        private readonly MiasmaSlashSpin.Factory _miasmaSlashSpinFactory;
        private readonly DarknessSlashSpin.Factory _darknessSlashSpinFactory;
        private readonly LifeStealSlashSpin.Factory _lifeStealSlashSpinFactory;
        private readonly HellFireSlashSpin.Factory _hellFireSlashSpinFactory;
        private readonly StigmataSlashSpin.Factory _stigmataSlashSpinFactory;
        private readonly SoakingWetSlashSpin.Factory _soakingWetSlashSpinFactory;
        private readonly BurningSlashSpin.Factory _burningSlashSpinFactory;

        [Inject]
        public AttributeSlashSpinFactory
        (
            NormalSlashSpin.Factory normalSlashSpinFactory,
            PoisonSlashSpin.Factory poisonSlashSpinFactory,
            ParalysisSlashSpin.Factory paralysisSlashSpinFactory,
            FrozenSlashSpin.Factory frozenSlashSpinFactory,
            ConfusionSlashSpin.Factory confusionSlashSpinFactory,
            CharmSlashSpin.Factory charmSlashSpinFactory,
            MiasmaSlashSpin.Factory miasmaSlashSpinFactory,
            DarknessSlashSpin.Factory darknessSlashSpinFactory,
            LifeStealSlashSpin.Factory lifeStealSlashSpinFactory,
            HellFireSlashSpin.Factory hellFireSlashSpinFactory,
            StigmataSlashSpin.Factory stigmataSlashSpinFactory,
            SoakingWetSlashSpin.Factory soakingWetSlashSpinFactory,
            BurningSlashSpin.Factory burningSlashSpinFactory
        )
        {
            _normalSlashSpinFactory = normalSlashSpinFactory;
            _poisonSlashSpinFactory = poisonSlashSpinFactory;
            _paralysisSlashSpinFactory = paralysisSlashSpinFactory;
            _frozenSlashSpinFactory = frozenSlashSpinFactory;
            _confusionSlashSpinFactory = confusionSlashSpinFactory;
            _charmSlashSpinFactory = charmSlashSpinFactory;
            _miasmaSlashSpinFactory = miasmaSlashSpinFactory;
            _darknessSlashSpinFactory = darknessSlashSpinFactory;
            _lifeStealSlashSpinFactory = lifeStealSlashSpinFactory;
            _hellFireSlashSpinFactory = hellFireSlashSpinFactory;
            _stigmataSlashSpinFactory = stigmataSlashSpinFactory;
            _soakingWetSlashSpinFactory = soakingWetSlashSpinFactory;
            _burningSlashSpinFactory = burningSlashSpinFactory;
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
                return _normalSlashSpinFactory.Create(animator);
            }

            return attribute switch
            {
                AbnormalCondition.Poison => _poisonSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Paralysis => _paralysisSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Frozen => _frozenSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Confusion => _confusionSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Charm => _charmSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Miasma => _miasmaSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Darkness => _darknessSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.LifeSteal => _lifeStealSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.HellFire => _hellFireSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.TimeStop => _stigmataSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.SoakingWet => _soakingWetSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Burning => _burningSlashSpinFactory.Create(skillId, animator, playerTransform, attack),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}