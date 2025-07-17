using AttributeAttack;
using Character;
using Common.Data;
using Player.Common;
using Zenject;

namespace Skill.ChangeBomb
{
    public class HellFireChangeBomb : ChangeBombBase
    {
        private readonly int _skillId;
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public HellFireChangeBomb
        (
            int skillId,
            PutBomb putBomb,
            PlayerStatusInfo playerStatusInfo,
            IAttackBehaviour attackBehaviour
        ) : base(putBomb, playerStatusInfo)
        {
            _skillId = skillId;
            _attackBehaviour = attackBehaviour;
        }

        public override void Attack()
        {
            _attackBehaviour.Attack();
            ChangeBomb(AbnormalCondition.HellFire, _skillId);
        }
        
        public class Factory : PlaceholderFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, HellFireChangeBomb>
        {
        }
    }
}