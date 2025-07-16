using Player.Common;
using UnityEngine;

namespace Bomb
{
    public class AttributeBombPoolBase : BombObjectPoolBase
    {
        public AttributeBombPoolBase
        (
            BombBase bombBase,
            Transform parent,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase
        ) : base(bombBase, parent, translateStatusInBattleUseCase)
        {
        }
    }
}