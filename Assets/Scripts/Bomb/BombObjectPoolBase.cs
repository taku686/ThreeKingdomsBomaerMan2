using Common.Data;
using UniRx.Toolkit;
using UnityEngine;

namespace Bomb
{
    public abstract class BombObjectPoolBase : ObjectPool<BombBase>
    {
        protected ObjectPool<BombBase> Pool;
        protected BombBase BombBase;
        protected Transform BombParent;
        private static readonly Vector3 ColliderCenter = new Vector3(0, 0.5f, 0);
        private static readonly Vector3 ColliderScale = new Vector3(0.7f, 1, 0.7f);

        protected BombObjectPoolBase(BombBase bombBase, Transform parent)
        {
            BombBase = bombBase;
            BombParent = parent;
        }

        protected override BombBase CreateInstance()
        {
            var newBomb = Object.Instantiate(BombBase, BombParent);
            AddCollider(newBomb.gameObject);
            AddRigidbody(newBomb.gameObject);
            newBomb.gameObject.SetActive(false);
            return newBomb;
        }

        private void AddCollider(GameObject bomb)
        {
            var collider = bomb.AddComponent<BoxCollider>();
            collider.center = ColliderCenter;
            collider.size = ColliderScale;
            bomb.layer = LayerMask.NameToLayer(GameSettingData.BombLayer);
        }

        private void AddRigidbody(GameObject bomb)
        {
            var rigid = bomb.AddComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }

        protected override void OnBeforeRent(BombBase instance)
        {
            var collider = instance.GetComponent<BoxCollider>();
            collider.enabled = true;
            base.OnBeforeRent(instance);
        }
    }
}