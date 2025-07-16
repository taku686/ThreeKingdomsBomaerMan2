using Photon.Pun;
using Player.Common;
using UniRx.Toolkit;
using UnityEngine;

namespace Bomb
{
    public abstract class BombObjectPoolBase : ObjectPool<BombBase>
    {
        protected readonly Transform _bombParent;
        protected readonly BombBase _bombBase;
        private readonly TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
        private static readonly Vector3 ColliderCenter = new(0, 0.5f, 0);
        private static readonly Vector3 ColliderScale = new(1f, 1, 1f);

        protected BombObjectPoolBase
        (
            BombBase bombBase,
            Transform parent,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase
        )
        {
            _bombBase = bombBase;
            _bombParent = parent;
            _translateStatusInBattleUseCase = translateStatusInBattleUseCase;
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
            base.OnBeforeRent(instance);
            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            _translateStatusInBattleUseCase.IncrementBombCount();
        }

        protected override void OnBeforeReturn(BombBase instance)
        {
            base.OnBeforeReturn(instance);

            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            _translateStatusInBattleUseCase.DecrementBombCount();
        }

        protected static void AddCollider(GameObject bomb)
        {
            var collider = bomb.AddComponent<BoxCollider>();
            collider.center = ColliderCenter;
            collider.size = ColliderScale;
            collider.enabled = true;
            collider.isTrigger = true;
        }

        protected static void AddRigidbody(GameObject bomb)
        {
            var rigid = bomb.AddComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}