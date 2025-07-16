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
        [SerializeField] private StageOrnamentsBlock stageOrnamentsBlock;
        private BombObjectPoolBase _normalBombProvider;
        private BombObjectPoolBase _penetrationBombProvider;
        private BombObjectPoolBase _dangerBombProvider;

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
                case BombType.Paralysis:
                    break;
                case BombType.Poison:
                    break;
                case BombType.Frozen:
                    break;
                case BombType.Confusion:
                    break;
                case BombType.Sealed:
                    break;
                case BombType.GreatFire:
                    break;
                case BombType.LifeSteal:
                    break;
                case BombType.Holy:
                    break;
                case BombType.Apraxia:
                    break;
                case BombType.Burning:
                    break;
                case BombType.Charm:
                    break;
                case BombType.Curse:
                    break;
                case BombType.Darkness:
                    break;
                case BombType.Fear:
                    break;
                case BombType.HellFire:
                    break;
                case BombType.Miasma:
                    break;
                case BombType.ParalyzingThunder:
                    break;
                case BombType.SoakingWet:
                    break;
                case BombType.TimeStop:
                    break;
                case BombType.None:
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
            int playerId,
            AbnormalCondition abnormalCondition
        )
        {
            var bombPool = GetBombObjectPoolBase(bombType);
            var bomb = bombPool.Rent();
            if (bomb == null)
            {
                return null;
            }

            bomb.Setup(damageAmount, fireRange, playerId, explosionTime);
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
                _ => null
            };
        }
    }
}