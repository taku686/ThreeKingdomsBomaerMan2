using UniRx.Toolkit;
using UnityEngine;

namespace Bomb;

public abstract class BombObjectPoolBase : ObjectPool<BombBase>
{
    protected ObjectPool<BombBase> _pool;
    protected BombBase _bombBase;
    protected Transform _bombParent;

    public BombObjectPoolBase(BombBase bombBase, Transform parent)
    {
        _bombBase = bombBase;
        _bombParent = parent;
    }

    protected override BombBase CreateInstance()
    {
        var newBomb = GameObject.Instantiate(_bombBase);
        newBomb.transform.parent = _bombParent;
        return newBomb;
    }
}