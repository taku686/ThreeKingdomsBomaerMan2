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

        [Inject]
        public AttributeChangeBombFactory
        (
            NormalChangeBomb.Factory normalChangeBombFactory,
            ParalysisChangeBomb.Factory paralysisChangeBombFactory
        )
        {
            _normalChangeBombFactory = normalChangeBombFactory;
            _paralysisChangeBombFactory = paralysisChangeBombFactory;
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
                /*AbnormalCondition.Poison => expr,
                AbnormalCondition.Frozen => expr,
                AbnormalCondition.Confusion => expr,
                AbnormalCondition.Charm => expr,
                AbnormalCondition.Miasma => expr,
                AbnormalCondition.Darkness => expr,
                AbnormalCondition.LifeSteal => expr,
                AbnormalCondition.HellFire => expr,
                AbnormalCondition.TimeStop => expr,
                AbnormalCondition.SoakingWet => expr,
                AbnormalCondition.Burning => expr,*/
                _ => throw new ArgumentOutOfRangeException(nameof(attribute), attribute, null)
            };
        }

        public class Factory : PlaceholderFactory<int, PutBomb, PlayerStatusInfo, AbnormalCondition, IAttackBehaviour, IAttackBehaviour>
        {
        }
    }
}