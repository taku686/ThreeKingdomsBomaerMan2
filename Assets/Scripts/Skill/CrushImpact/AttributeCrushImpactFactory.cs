using System;
using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.CrushImpact
{
    public class AttributeCrushImpactFactory : IFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalCrushImpact.Factory _normalCrushImpactFactory;
        private readonly PoisonCrushImpact.Factory _poisonCrushImpactFactory;
        private readonly ParalysisCrushImpact.Factory _paralysisCrushImpactFactory;
        private readonly FrozenCrushImpact.Factory _frozenCrushImpactFactory;
        private readonly ConfusionCrushImpact.Factory _confusionCrushImpactFactory;
        private readonly CharmCrushImpact.Factory _charmCrushImpactFactory;
        private readonly MiasmaCrushImpact.Factory _miasmaCrushImpactFactory;
        private readonly DarknessCrushImpact.Factory _darknessCrushImpactFactory;
        private readonly LifeStealCrushImpact.Factory _lifeStealCrushImpactFactory;
        private readonly HellFireCrushImpact.Factory _hellFireCrushImpactFactory;
        private readonly StigmataCrushImpact.Factory _stigmataCrushImpactFactory;
        private readonly SoakingWetCrushImpact.Factory _soakingWetCrushImpactFactory;
        private readonly BurningCrushImpact.Factory _burningCrushImpactFactory;

        [Inject]
        public AttributeCrushImpactFactory
        (
            NormalCrushImpact.Factory normalCrushImpactFactory,
            PoisonCrushImpact.Factory poisonCrushImpactFactory,
            ParalysisCrushImpact.Factory paralysisCrushImpactFactory,
            FrozenCrushImpact.Factory frozenCrushImpactFactory,
            ConfusionCrushImpact.Factory confusionCrushImpactFactory,
            CharmCrushImpact.Factory charmCrushImpactFactory,
            MiasmaCrushImpact.Factory miasmaCrushImpactFactory,
            DarknessCrushImpact.Factory darknessCrushImpactFactory,
            LifeStealCrushImpact.Factory lifeStealCrushImpactFactory,
            HellFireCrushImpact.Factory hellFireCrushImpactFactory,
            StigmataCrushImpact.Factory stigmataCrushImpactFactory,
            SoakingWetCrushImpact.Factory soakingWetCrushImpactFactory,
            BurningCrushImpact.Factory burningCrushImpactFactory
        )
        {
            _normalCrushImpactFactory = normalCrushImpactFactory;
            _poisonCrushImpactFactory = poisonCrushImpactFactory;
            _paralysisCrushImpactFactory = paralysisCrushImpactFactory;
            _frozenCrushImpactFactory = frozenCrushImpactFactory;
            _confusionCrushImpactFactory = confusionCrushImpactFactory;
            _charmCrushImpactFactory = charmCrushImpactFactory;
            _miasmaCrushImpactFactory = miasmaCrushImpactFactory;
            _darknessCrushImpactFactory = darknessCrushImpactFactory;
            _lifeStealCrushImpactFactory = lifeStealCrushImpactFactory;
            _hellFireCrushImpactFactory = hellFireCrushImpactFactory;
            _stigmataCrushImpactFactory = stigmataCrushImpactFactory;
            _soakingWetCrushImpactFactory = soakingWetCrushImpactFactory;
            _burningCrushImpactFactory = burningCrushImpactFactory;
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
                return _normalCrushImpactFactory.Create(playerTransform);
            }

            return attribute switch
            {
                AbnormalCondition.Poison => _poisonCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Paralysis => _paralysisCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Frozen => _frozenCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Confusion => _confusionCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Charm => _charmCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Miasma => _miasmaCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Darkness => _darknessCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.LifeSteal => _lifeStealCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.HellFire => _hellFireCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.TimeStop => _stigmataCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.SoakingWet => _soakingWetCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                AbnormalCondition.Burning => _burningCrushImpactFactory.Create(skillId, animator, playerTransform, attack),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}