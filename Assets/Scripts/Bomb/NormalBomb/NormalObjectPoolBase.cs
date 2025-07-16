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
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase
        ) : base(bombBase, parent, translateStatusInBattleUseCase)
        {
        }
    }
}