using System;
using Common.Data;
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

        public void Initialize(PlayerStatusManager playerStatusManager)
        {
            Debug.Log(bombObjectPoolProvider);
            _normalBombProvider = bombObjectPoolProvider.GetNormalBombPool(playerStatusManager);
        }

        public BombBase GetBomb(int bombType, int damageAmount, int fireRange, int explosionTime, int playerId)
        {
            var bombPool = GetBombObjectPoolBase(bombType);
            BombBase bomb = bombPool.Rent();
            if (bomb == null)
            {
                return null;
            }

            bomb.Setup(damageAmount, fireRange, playerId, explosionTime);
            bomb.OnFinishIObservable.Take(1).Subscribe(_ => { bombPool.Return(bomb); });
            return bomb;
        }

        private BombObjectPoolBase GetBombObjectPoolBase(int bombType)
        {
            switch (bombType)
            {
                case (int)BombType.Normal:
                    return _normalBombProvider;
                case (int)BombType.Penetration:
                    return _penetrationBombProvider;
                case (int)BombType.Danger:
                    return _dangerBombProvider;
                case (int)BombType.Error:
                    return null;
                default:
                    return null;
            }
        }
    }
}