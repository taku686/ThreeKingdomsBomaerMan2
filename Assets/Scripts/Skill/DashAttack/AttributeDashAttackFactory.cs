using System;
using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.DashAttack
{
    public class AttributeDashAttackFactory : IFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalDashAttack.Factory _normalDashAttackFactory;
        private readonly PoisonDashAttack.Factory _poisonDashAttackFactory;
        private readonly ParalysisDashAttack.Factory _paralysisDashAttackFactory;
        private readonly FrozenDashAttack.Factory _frozenDashAttackFactory;
        private readonly ConfusionDashAttack.Factory _confusionDashAttackFactory;
        private readonly CharmDashAttack.Factory _charmDashAttackFactory;
        private readonly MiasmaDashAttack.Factory _miasmaDashAttackFactory;
        private readonly DarknessDashAttack.Factory _darknessDashAttackFactory;
        private readonly LifeStealDashAttack.Factory _lifeStealDashAttackFactory;
        private readonly HellFireDashAttack.Factory _hellFireSlashFactory;
        private readonly StigmataDashAttack.Factory _stigmataDashAttackFactory;
        private readonly SoakingWetDashAttack.Factory _soakingWetDashAttackFactory;
        private readonly BurningDashAttack.Factory _burningDashAttackFactory;

        [Inject]
        public AttributeDashAttackFactory
        (
            NormalDashAttack.Factory normalDashAttackFactory,
            PoisonDashAttack.Factory poisonDashAttackFactory,
            ParalysisDashAttack.Factory paralysisDashAttackFactory,
            FrozenDashAttack.Factory frozenDashAttackFactory,
            ConfusionDashAttack.Factory confusionDashAttackFactory,
            CharmDashAttack.Factory charmDashAttackFactory,
            MiasmaDashAttack.Factory miasmaDashAttackFactory,
            DarknessDashAttack.Factory darknessDashAttackFactory,
            LifeStealDashAttack.Factory lifeStealDashAttackFactory,
            HellFireDashAttack.Factory hellFireSlashFactory,
            StigmataDashAttack.Factory stigmataDashAttackFactory,
            SoakingWetDashAttack.Factory soakingWetDashAttackFactory,
            BurningDashAttack.Factory burningDashAttackFactory
        )
        {
            _normalDashAttackFactory = normalDashAttackFactory;
            _poisonDashAttackFactory = poisonDashAttackFactory;
            _paralysisDashAttackFactory = paralysisDashAttackFactory;
            _frozenDashAttackFactory = frozenDashAttackFactory;
            _confusionDashAttackFactory = confusionDashAttackFactory;
            _charmDashAttackFactory = charmDashAttackFactory;
            _miasmaDashAttackFactory = miasmaDashAttackFactory;
            _darknessDashAttackFactory = darknessDashAttackFactory;
            _lifeStealDashAttackFactory = lifeStealDashAttackFactory;
            _hellFireSlashFactory = hellFireSlashFactory;
            _stigmataDashAttackFactory = stigmataDashAttackFactory;
            _soakingWetDashAttackFactory = soakingWetDashAttackFactory;
            _burningDashAttackFactory = burningDashAttackFactory;
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
            if (attack == null || attribute == AbnormalCondition.None)
            {
                return _normalDashAttackFactory.Create(animator);
            }

            return attribute switch
            {
                AbnormalCondition.Poison => _poisonDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Paralysis => _paralysisDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Frozen => _frozenDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Confusion => _confusionDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Charm => _charmDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Miasma => _miasmaDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Darkness => _darknessDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.LifeSteal => _lifeStealDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.HellFire => _hellFireSlashFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.TimeStop => _stigmataDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.SoakingWet => _soakingWetDashAttackFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Burning => _burningDashAttackFactory.Create(skillId, playerTransform, attack),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}