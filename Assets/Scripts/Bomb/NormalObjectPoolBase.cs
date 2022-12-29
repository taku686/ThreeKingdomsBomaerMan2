using Player.Common;
using UniRx.Toolkit;
using UnityEngine;

namespace Bomb
{
    public class NormalObjectPoolBase : BombObjectPoolBase
    {
        public NormalObjectPoolBase(BombBase bombBase, Transform parent,PlayerStatusManager playerStatusManager) : base(bombBase, parent,playerStatusManager)
        {
        }
    }
}