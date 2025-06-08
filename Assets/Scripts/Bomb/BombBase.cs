using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.BattleManager.Environment;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Bomb
{
    public abstract class BombBase : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> explosionList;
        protected const float ExplosionDisplayDuration = 0.9f;
        protected const float MinDistance = 1.0f;
        protected CancellationTokenSource _Cts;
        public int _fireRange;
        protected LayerMask _ObstaclesLayerMask;
        protected bool _IsExplosion;
        protected Renderer _BombRenderer;
        protected BoxCollider _BoxColliderComponent;
        protected Action _BlockShakeAction;
        private int _damageAmount;
        private int _playerId;
        private int _explosionTime;
        private readonly Subject<Unit> _onExplosionSubject = new();
        private readonly Subject<Unit> _onFinishSubject = new();

        private CancellationToken _token;
        public IObservable<Unit> _OnFinishIObservable => _onFinishSubject.Take(1);

        public void Initialize()
        {
            _BombRenderer = GetComponent<Renderer>();
            _BoxColliderComponent = GetComponent<BoxCollider>();
            _Cts = new CancellationTokenSource();
            _token = this.GetCancellationTokenOnDestroy();
            _ObstaclesLayerMask = LayerMask.GetMask(GameCommonData.ObstacleLayer);
            gameObject.layer = LayerMask.NameToLayer(GameCommonData.BombLayer);
        }

        public void Setup
        (
            int damageAmount,
            int fireRange,
            int playerId,
            int explosionTime,
            StageOrnamentsBlock stageOrnamentsBlock
        )
        {
            gameObject.tag = GameCommonData.BombTag;
            _BombRenderer.enabled = true;
            _BoxColliderComponent.enabled = true;
            _damageAmount = damageAmount;
            _playerId = playerId;
            _explosionTime = explosionTime;
            _fireRange = fireRange;
            _BlockShakeAction = stageOrnamentsBlock.Shake;
            _IsExplosion = false;
            foreach (var bombEffect in explosionList)
            {
                bombEffect.SetActive(false);
            }

            gameObject.UpdateAsObservable().Subscribe(_ => { CountDown(_explosionTime); }).AddTo(_Cts.Token);
        }

        private void CountDown(int explosionTime)
        {
            if (_IsExplosion)
            {
                return;
            }

            if (unchecked(PhotonNetwork.ServerTimestamp - explosionTime) >= 0)
            {
                Explosion(_damageAmount).Forget();
            }
        }

        protected virtual async UniTask Explosion(int damageAmount)
        {
            OnDisableBomb();
        }

        private void OnDisableBomb()
        {
            Cancel();
            _onFinishSubject.OnNext(Unit.Default);
        }

        private void Cancel()
        {
            _Cts ??= new CancellationTokenSource();
            _Cts.Cancel();
            _Cts.Dispose();
            _Cts = new CancellationTokenSource();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(GameCommonData.BombEffectTag) || _IsExplosion)
            {
                return;
            }

            Explosion(_damageAmount).Forget();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(GameCommonData.PlayerTag))
            {
                return;
            }

            _BoxColliderComponent.isTrigger = false;
        }

        private void OnDestroy()
        {
            _onFinishSubject.Dispose();
            _onExplosionSubject.Dispose();
        }
    }
}