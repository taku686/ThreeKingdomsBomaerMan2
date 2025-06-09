using Player.Common;
using UnityEngine;

namespace Bomb
{
    public class NormalObjectPoolBase : BombObjectPoolBase
    {
        public NormalObjectPoolBase
        (
            BombBase bombBase,
            Transform parent,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase,
            MapManager mapManager
        ) : base(bombBase, parent, translateStatusInBattleUseCase, mapManager)
        {
        }
    }
}