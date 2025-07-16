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
        [SerializeField] private BombBase _attributeBomb;

        private BombObjectPoolBase _normalBombPool;
        private BombObjectPoolBase _penetrationBombPool;
        private BombObjectPoolBase _dangerBombPool;
        private BombObjectPoolBase _attributeBombPool;
        private GameObject _normalBombPoolParent;
        private GameObject _attributeBombPoolParent;
        private CancellationToken _token;
        private const int PreloadCount = 20;
        private const int Threshold = 20;

        public BombObjectPoolBase GetNormalBombPool(TranslateStatusInBattleUseCase translateStatusInBattleUseCase)
        {
            if (_normalBombPool != null)
            {
                _normalBombPool.Clear();
                InitializeNormalBombPool(translateStatusInBattleUseCase);
                return _normalBombPool;
            }

            _normalBombPoolParent = new GameObject("NormalBombPool");
            _normalBombPoolParent.transform.SetParent(transform);
            InitializeNormalBombPool(translateStatusInBattleUseCase);
            return _normalBombPool;
        }

        public BombObjectPoolBase GetAttributeBombPool(TranslateStatusInBattleUseCase translateStatusInBattleUseCase)
        {
            if (_attributeBombPool != null)
            {
                _attributeBombPool.Clear();
                InitializeAttributeBombPool(translateStatusInBattleUseCase);
                return _attributeBombPool;
            }

            _token = this.GetCancellationTokenOnDestroy();
            _attributeBombPoolParent = new GameObject("AttributeBombPool");
            _attributeBombPoolParent.transform.SetParent(transform);
            InitializeAttributeBombPool(translateStatusInBattleUseCase);
            return _attributeBombPool;
        }

        private void InitializeNormalBombPool(TranslateStatusInBattleUseCase translateStatusInBattleUseCase)
        {
            _normalBombPool = new NormalObjectPoolBase(normalBomb, _normalBombPoolParent.transform, translateStatusInBattleUseCase);
            _normalBombPool.PreloadAsync(PreloadCount, Threshold).Subscribe().AddTo(_token);
        }

        private void InitializeAttributeBombPool(TranslateStatusInBattleUseCase translateStatusInBattleUseCase)
        {
            _attributeBombPool = new AttributeBombPoolBase(_attributeBomb, _attributeBombPoolParent.transform, translateStatusInBattleUseCase);
            _attributeBombPool.PreloadAsync(PreloadCount, Threshold).Subscribe().AddTo(_token);
        }


        private void OnDestroy()
        {
            _normalBombPool?.Dispose();
            _penetrationBombPool?.Dispose();
            _dangerBombPool?.Dispose();
            _attributeBombPool?.Dispose();
            Destroy(_normalBombPoolParent.gameObject);
            Destroy(_attributeBombPoolParent.gameObject);
        }
    }
}