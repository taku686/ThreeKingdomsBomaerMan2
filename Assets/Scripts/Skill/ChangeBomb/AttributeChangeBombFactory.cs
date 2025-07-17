using System;
using AttributeAttack;
using Character;
using Common.Data;
using Player.Common;
using Zenject;

namespace Skill.ChangeBomb
{
    public class AttributeChangeBombFactory : IFactory<int, PutBomb, PlayerStatusInfo, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
    {
        private readonly NormalChangeBomb.Factory _normalChangeBombFactory;
        private readonly ParalysisChangeBomb.Factory _paralysisChangeBombFactory;
        private readonly HellFireChangeBomb.Factory _hellFireChangeBombFactory;
        private readonly DarknessChangeBomb.Factory _darknessChangeBombFactory;
        private readonly LifeStealChangeBomb.Factory _lifeStealChangeBombFactory;
        private readonly MiasmaChangeBomb.Factory _miasmaChangeBombFactory;
        private readonly SoakingWetChangeBomb.Factory _soakingWetChangeBombFactory;
        private readonly StigmataChangeBomb.Factory _stigmataChangeBombFactory;
        private readonly CharmChangeBomb.Factory _charmChangeBombFactory;
        private readonly BurningChangeBomb.Factory _burningChangeBombFactory;
        private readonly ConfusionChangeBomb.Factory _confusionChangeBombFactory;
        private readonly FrozenChangeBomb.Factory _frozenChangeBombFactory;
        private readonly PoisonChangeBomb.Factory _poisonChangeBombFactory;

        [Inject]
        public AttributeChangeBombFactory
        (
            NormalChangeBomb.Factory normalChangeBombFactory,
            ParalysisChangeBomb.Factory paralysisChangeBombFactory,
            HellFireChangeBomb.Factory hellFireChangeBombFactory,
            DarknessChangeBomb.Factory darknessChangeBombFactory,
            LifeStealChangeBomb.Factory lifeStealChangeBombFactory,
            MiasmaChangeBomb.Factory miasmaChangeBombFactory,
            SoakingWetChangeBomb.Factory soakingWetChangeBombFactory,
            StigmataChangeBomb.Factory stigmataChangeBombFactory,
            CharmChangeBomb.Factory charmChangeBombFactory,
            BurningChangeBomb.Factory burningChangeBombFactory,
            ConfusionChangeBomb.Factory confusionChangeBombFactory,
            FrozenChangeBomb.Factory frozenChangeBombFactory,
            PoisonChangeBomb.Factory poisonChangeBombFactory
        )
        {
            _normalChangeBombFactory = normalChangeBombFactory;
            _paralysisChangeBombFactory = paralysisChangeBombFactory;
            _hellFireChangeBombFactory = hellFireChangeBombFactory;
            _darknessChangeBombFactory = darknessChangeBombFactory;
            _lifeStealChangeBombFactory = lifeStealChangeBombFactory;
            _miasmaChangeBombFactory = miasmaChangeBombFactory;
            _soakingWetChangeBombFactory = soakingWetChangeBombFactory;
            _stigmataChangeBombFactory = stigmataChangeBombFactory;
            _charmChangeBombFactory = charmChangeBombFactory;
            _burningChangeBombFactory = burningChangeBombFactory;
            _confusionChangeBombFactory = confusionChangeBombFactory;
            _frozenChangeBombFactory = frozenChangeBombFactory;
            _poisonChangeBombFactory = poisonChangeBombFactory;
        }

        public IAttackBehaviour Create
        (
            int skillId,
            PutBomb putBomb,
            PlayerStatusInfo playerStatusInfo,
            AbnormalCondition attribute,
            IAttackBehaviour attack
        )
        {
            if (attack == null && attribute == AbnormalCondition.None)
            {
                return _normalChangeBombFactory.Create();
            }

            return attribute switch
            {
                AbnormalCondition.Paralysis => _paralysisChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.Poison => _poisonChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.Frozen => _frozenChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.Confusion => _confusionChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.Charm => _charmChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.Miasma => _miasmaChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.Darkness => _darknessChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.LifeSteal => _lifeStealChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.HellFire => _hellFireChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.TimeStop => _stigmataChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.SoakingWet => _soakingWetChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                AbnormalCondition.Burning => _burningChangeBombFactory.Create(skillId, putBomb, playerStatusInfo, attack),
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, PutBomb, PlayerStatusInfo, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}