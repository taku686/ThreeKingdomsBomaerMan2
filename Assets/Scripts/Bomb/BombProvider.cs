using System;
using Common.Data;
using Manager.BattleManager.Environment;
using Player.Common;
using UniRx;
using UnityEngine;

namespace Bomb
{
    public class BombProvider : MonoBehaviour
    {
        [SerializeField] private BombObjectPoolProvider bombObjectPoolProvider;
        private BombObjectPoolBase _normalBombProvider;
        private BombObjectPoolBase _penetrationBombProvider;
        private BombObjectPoolBase _dangerBombProvider;
        private BombObjectPoolBase _attributeBombProvider;

        public void Initialize
        (
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase,
            BombType bombType
        )
        {
            switch (bombType)
            {
                case BombType.Normal:
                    _normalBombProvider = bombObjectPoolProvider.GetNormalBombPool(translateStatusInBattleUseCase);
                    break;
                case BombType.Penetration:
                    break;
                case BombType.Diffusion:
                    break;
                case BombType.Attribute:
                    _attributeBombProvider = bombObjectPoolProvider.GetAttributeBombPool(translateStatusInBattleUseCase);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(bombType), bombType, null);
            }
        }

        public BombBase GetBomb
        (
            int bombType,
            int damageAmount,
            int fireRange,
            int explosionTime,
            int instantiationId,
            int skillId,
            AbnormalCondition abnormalCondition
        )
        {
            var bombPool = GetBombObjectPoolBase(bombType);
            var bomb = bombPool.Rent();
            if (bomb == null)
            {
                return null;
            }

            bomb.Setup
            (
                damageAmount,
                fireRange,
                instantiationId,
                explosionTime,
                skillId,
                abnormalCondition
            );
            bomb._OnFinishIObservable.Take(1).Subscribe(_ => { bombPool.Return(bomb); });
            return bomb;
        }

        private BombObjectPoolBase GetBombObjectPoolBase(int bombType)
        {
            return bombType switch
            {
                (int)BombType.Normal => _normalBombProvider,
                (int)BombType.Penetration => _penetrationBombProvider,
                (int)BombType.Diffusion => _dangerBombProvider,
                (int)BombType.Attribute => _attributeBombProvider,
                _ => null
            };
        }
    }
}