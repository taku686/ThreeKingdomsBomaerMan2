using Common.Data;
using Player.Common;
using UniRx.Toolkit;
using UnityEngine;

namespace Bomb
{
    public abstract class BombObjectPoolBase : ObjectPool<BombBase>
    {
        protected ObjectPool<BombBase> Pool;
        private readonly BombBase _bombBase;
        private readonly PlayerStatusManager _playerStatusManager;
        private readonly Transform _bombParent;
        private static readonly Vector3 ColliderCenter = new Vector3(0, 0.5f, 0);
        private static readonly Vector3 ColliderScale = new Vector3(0.7f, 1, 0.7f);

        protected BombObjectPoolBase(BombBase bombBase, Transform parent, PlayerStatusManager playerStatusManager)
        {
            _bombBase = bombBase;
            _bombParent = parent;
            _playerStatusManager = playerStatusManager;
        }

        protected override BombBase CreateInstance()
        {
            var newBomb = Object.Instantiate(_bombBase, _bombParent);
            AddCollider(newBomb.gameObject);
            AddRigidbody(newBomb.gameObject);
            newBomb.Initialize();
            newBomb.gameObject.SetActive(false);
            return newBomb;
        }

        protected override void OnBeforeRent(BombBase instance)
        {
            _playerStatusManager.IncrementBombCount();
            base.OnBeforeRent(instance);
        }

        protected override void OnBeforeReturn(BombBase instance)
        {
            _playerStatusManager.DecrementBombCount();
            base.OnBeforeReturn(instance);
        }

        private void AddCollider(GameObject bomb)
        {
            var collider = bomb.AddComponent<BoxCollider>();
            collider.center = ColliderCenter;
            collider.size = ColliderScale;
            collider.enabled = true;
            collider.isTrigger = true;
        }

        private void AddRigidbody(GameObject bomb)
        {
            var rigid = bomb.AddComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}