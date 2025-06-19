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
        [SerializeField] private MapManager mapManager;

        private BombObjectPoolBase _normalBombPool;
        private BombObjectPoolBase _penetrationBombPool;
        private BombObjectPoolBase _dangerBombPool;
        private GameObject _normalBombPoolParent;
        private CancellationToken _token;
        private const int PreloadCount = 20;
        private const int Threshold = 20;

        public BombObjectPoolBase GetNormalBombPool(TranslateStatusInBattleUseCase translateStatusInBattleUseCase)
        {
            if (_normalBombPool != null)
            {
                //破棄の処理を入れるべきか？
                _normalBombPool.Clear();
                Initialize(translateStatusInBattleUseCase);
                return _normalBombPool;
            }

            _normalBombPoolParent = new GameObject("NormalBombPool");
            _normalBombPoolParent.transform.SetParent(transform);
            Initialize(translateStatusInBattleUseCase);
            return _normalBombPool;
        }

        private void Initialize(TranslateStatusInBattleUseCase translateStatusInBattleUseCase)
        {
            _normalBombPool = new NormalObjectPoolBase(normalBomb, _normalBombPoolParent.transform, translateStatusInBattleUseCase, mapManager);
            _normalBombPool.PreloadAsync(PreloadCount, Threshold).Subscribe().AddTo(_token);
        }


        private void OnDestroy()
        {
            _normalBombPool?.Dispose();
            _penetrationBombPool?.Dispose();
            _dangerBombPool?.Dispose();
        }
    }
}