using UniRx.Toolkit;
using UnityEngine;

namespace Bomb
{
    public abstract class BombObjectPoolBase : ObjectPool<BombBase>
    {
        protected ObjectPool<BombBase> Pool;
        protected BombBase BombBase;
        protected Transform BombParent;

        public BombObjectPoolBase(BombBase bombBase, Transform parent)
        {
            BombBase = bombBase;
            BombParent = parent;
        }

        protected override BombBase CreateInstance()
        {
            var newBomb = GameObject.Instantiate(BombBase, BombParent);
            newBomb.gameObject.SetActive(false);
            return newBomb;
        }
    }
}