using Photon.Pun;
using Player.Common;
using UniRx.Toolkit;
using UnityEngine;

namespace Bomb
{
    public abstract class BombObjectPoolBase : ObjectPool<BombBase>
    {
        private readonly BombBase _bombBase;
        private readonly TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
        private readonly MapManager _mapManager;
        private readonly Transform _bombParent;
        private static readonly Vector3 ColliderCenter = new(0, 0.5f, 0);
        private static readonly Vector3 ColliderScale = new(1f, 1, 1f);

        protected BombObjectPoolBase
        (
            BombBase bombBase,
            Transform parent,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase,
            MapManager mapManager
        )
        {
            _bombBase = bombBase;
            _bombParent = parent;
            _translateStatusInBattleUseCase = translateStatusInBattleUseCase;
            _mapManager = mapManager;
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
            var position = instance.transform.position;
            _mapManager.RemoveMap(position.x, position.z);
            for (var i = 1; i <= instance._fireRange; i++)
            {
                _mapManager.RemoveMap(position.x + i, position.z);
                _mapManager.RemoveMap(position.x - i, position.z);
                _mapManager.RemoveMap(position.x, position.z + i);
                _mapManager.RemoveMap(position.x, position.z - i);
            }

            base.OnBeforeReturn(instance);


            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            _translateStatusInBattleUseCase.DecrementBombCount();
        }

        private static void AddCollider(GameObject bomb)
        {
            var collider = bomb.AddComponent<BoxCollider>();
            collider.center = ColliderCenter;
            collider.size = ColliderScale;
            collider.enabled = true;
            collider.isTrigger = true;
        }

        private static void AddRigidbody(GameObject bomb)
        {
            var rigid = bomb.AddComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}