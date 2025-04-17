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

        public void Initialize(TranslateStatusInBattleUseCase translateStatusInBattleUseCase)
        {
            _normalBombProvider = bombObjectPoolProvider.GetNormalBombPool(translateStatusInBattleUseCase);
        }

        public BombBase GetBomb(int bombType, int damageAmount, int fireRange, int explosionTime, int playerId)
        {
            var bombPool = GetBombObjectPoolBase(bombType);
            BombBase bomb = bombPool.Rent();
            if (bomb == null)
            {
                return null;
            }

            bomb.Setup(damageAmount, fireRange, playerId, explosionTime, stageOrnamentsBlock);
            bomb._OnFinishIObservable.Take(1).Subscribe(_ => { bombPool.Return(bomb); });
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
                case (int)BombType.Diffusion:
                    return _dangerBombProvider;
                default:
                    return null;
            }
        }
    }
}