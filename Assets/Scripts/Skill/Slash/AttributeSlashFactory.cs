using AttributeAttack;
using Common.Data;
using UnityEngine;
using Zenject;

namespace Skill.Attack
{
    public class AttributeSlashFactory : IFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalSlash.Factory _normalSlashBehaviourFactory;
        private readonly PoisonSlash.Factory _poisonSlashBehaviourFactory;
        private readonly ParalysisSlash.Factory _paralysisSlashBehaviourFactory;
        private readonly FrozenSlash.Factory _frozenSlashBehaviourFactory;
        private readonly ConfusionSlash.Factory _confusionSlashBehaviourFactory;
        private readonly NockBackSlash.Factory _nockBackSlashBehaviourFactory;
        private readonly CharmSlash.Factory _charmSlashBehaviourFactory;
        private readonly MiasmaSlash.Factory _miasmaSlashBehaviourFactory;
        private readonly DarknessSlash.Factory _darknessSlashBehaviourFactory;
        private readonly SealedSlash.Factory _sealedSlashBehaviourFactory;
        private readonly LifeStealSlash.Factory _lifeStealSlashBehaviourFactory;
        private readonly CurseSlash.Factory _curseSlashBehaviourFactory;
        private readonly HellFireSlash.Factory _hellFireSlashBehaviourFactory;
        private readonly FearSlash.Factory _fearSlashBehaviourFactory;
        private readonly TimeStopSlash.Factory _timeStopSlashBehaviourFactory;
        private readonly ApraxiaSlash.Factory _apraxiaSlashBehaviourFactory;
        private readonly SoakingWetSlash.Factory _soakingWetSlashBehaviourFactory;
        private readonly BurningSlash.Factory _burningSlashBehaviourFactory;

        [Inject]
        public AttributeSlashFactory
        (
            NormalSlash.Factory normalSlashBehaviourFactory,
            PoisonSlash.Factory poisonSlashBehaviourFactory,
            ParalysisSlash.Factory paralysisSlashBehaviourFactory,
            FrozenSlash.Factory frozenSlashBehaviourFactory,
            ConfusionSlash.Factory confusionSlashBehaviourFactory,
            NockBackSlash.Factory nockBackSlashBehaviourFactory,
            CharmSlash.Factory charmSlashBehaviourFactory,
            MiasmaSlash.Factory miasmaSlashBehaviourFactory,
            DarknessSlash.Factory darknessSlashBehaviourFactory,
            SealedSlash.Factory sealedSlashBehaviourFactory,
            LifeStealSlash.Factory lifeStealSlashBehaviourFactory,
            CurseSlash.Factory curseSlashBehaviourFactory,
            HellFireSlash.Factory hellFireSlashBehaviourFactory,
            FearSlash.Factory fearSlashBehaviourFactory,
            TimeStopSlash.Factory timeStopSlashBehaviourFactory,
            ApraxiaSlash.Factory apraxiaSlashBehaviourFactory,
            SoakingWetSlash.Factory soakingWetSlashBehaviourFactory,
            BurningSlash.Factory burningSlashBehaviourFactory
        )
        {
            _normalSlashBehaviourFactory = normalSlashBehaviourFactory;
            _poisonSlashBehaviourFactory = poisonSlashBehaviourFactory;
            _paralysisSlashBehaviourFactory = paralysisSlashBehaviourFactory;
            _frozenSlashBehaviourFactory = frozenSlashBehaviourFactory;
            _confusionSlashBehaviourFactory = confusionSlashBehaviourFactory;
            _nockBackSlashBehaviourFactory = nockBackSlashBehaviourFactory;
            _charmSlashBehaviourFactory = charmSlashBehaviourFactory;
            _miasmaSlashBehaviourFactory = miasmaSlashBehaviourFactory;
            _darknessSlashBehaviourFactory = darknessSlashBehaviourFactory;
            _sealedSlashBehaviourFactory = sealedSlashBehaviourFactory;
            _lifeStealSlashBehaviourFactory = lifeStealSlashBehaviourFactory;
            _curseSlashBehaviourFactory = curseSlashBehaviourFactory;
            _hellFireSlashBehaviourFactory = hellFireSlashBehaviourFactory;
            _fearSlashBehaviourFactory = fearSlashBehaviourFactory;
            _timeStopSlashBehaviourFactory = timeStopSlashBehaviourFactory;
            _apraxiaSlashBehaviourFactory = apraxiaSlashBehaviourFactory;
            _soakingWetSlashBehaviourFactory = soakingWetSlashBehaviourFactory;
            _burningSlashBehaviourFactory = burningSlashBehaviourFactory;
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
                return _normalSlashBehaviourFactory.Create(animator);
            }

            return attribute switch
            {
                AbnormalCondition.None => _normalSlashBehaviourFactory.Create(animator),
                AbnormalCondition.Poison => _poisonSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Paralysis => _paralysisSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Frozen => _frozenSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Confusion => _confusionSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.NockBack => _nockBackSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Charm => _charmSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Miasma => _miasmaSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Darkness => _darknessSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Sealed => _sealedSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.LifeSteal => _lifeStealSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Curse => _curseSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.HellFire => _hellFireSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Fear => _fearSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.TimeStop => _timeStopSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Apraxia => _apraxiaSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.SoakingWet => _soakingWetSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.Burning => _burningSlashBehaviourFactory.Create(skillId, playerTransform, attack),
                AbnormalCondition.ParalyzingThunder => throw new System.NotImplementedException(),
                _ => throw new System.NotImplementedException()
            };
        }

        public class Factory : PlaceholderFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}