using AttributeAttack;
using Character;
using Common.Data;
using Photon.Pun;
using Player.Common;
using UnityEngine;
using Zenject;

namespace Skill.ChangeBomb
{
    public class ChangeBombBase : IAttackBehaviour
    {
        private readonly PutBomb _putBomb;
        private readonly PlayerStatusInfo _playerStatusInfo;

        [Inject]
        public ChangeBombBase
        (
            PutBomb putBomb,
            PlayerStatusInfo playerStatusInfo
        )
        {
            _putBomb = putBomb;
            _playerStatusInfo = playerStatusInfo;
        }

        public virtual void Attack()
        {
        }

        protected void ChangeBomb
        (
            AbnormalCondition abnormalCondition,
            int skillId
        )
        {
            var explosionTime = PhotonNetwork.ServerTimestamp + GameCommonData.WaitDurationBeforeExplosion;
            var damageAmount = (int)TranslateStatusInBattleUseCase.Translate(StatusType.Attack, _playerStatusInfo._attack.Value);
            var fireRange = (int)TranslateStatusInBattleUseCase.Translate(StatusType.FireRange, _playerStatusInfo._fireRange.Value);
            _putBomb.SetBomb
            (
                (int)BombType.Attribute,
                damageAmount,
                fireRange,
                explosionTime,
                skillId,
                abnormalCondition
            );
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}