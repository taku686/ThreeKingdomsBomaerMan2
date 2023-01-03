using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Player.Common;
using UniRx;
using UnityEngine;

namespace Bomb
{
    public class BombObjectPoolProvider : MonoBehaviour
    {
        [SerializeField] private BombBase normalBomb;
        [SerializeField] private BombBase penetrationBomb;
        [SerializeField] private BombBase dangerBomb;

        private BombObjectPoolBase _normalBombPool;
        private BombObjectPoolBase _penetrationBombPool;
        private BombObjectPoolBase _dangerBombPool;
        private CancellationToken _token;
        private static readonly int PreloadCount = 20;
        private static readonly int Threshold = 20;

        public BombObjectPoolBase GetNormalBombPool(PlayerStatusManager playerStatusManager)
        {
            if (_normalBombPool != null)
            {
                return _normalBombPool;
            }

            var parentTransform = new GameObject("NormalBombPool").transform;
            parentTransform.parent = this.transform;

            _normalBombPool = new NormalObjectPoolBase(normalBomb, parentTransform,playerStatusManager);
            _normalBombPool.PreloadAsync(PreloadCount, Threshold).Subscribe().AddTo(_token);
            return _normalBombPool;
        }


        private void OnDestroy()
        {
            _normalBombPool?.Dispose();
            _penetrationBombPool?.Dispose();
            _dangerBombPool?.Dispose();
        }
    }
}