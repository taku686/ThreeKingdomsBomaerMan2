using Player.Common;
using UniRx.Toolkit;
using UnityEngine;

namespace Bomb
{
    public class NormalObjectPoolBase : BombObjectPoolBase
    {
        public NormalObjectPoolBase(BombBase bombBase, Transform parent, CharacterStatusManager characterStatusManager,
            MapManager mapManager) : base(bombBase, parent, characterStatusManager, mapManager)
        {
        }
    }
}