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
        private int _damageAmount;
        private int _playerId;
        private int _explosionTime;
        public int _fireRange;
        protected bool _IsExplosion;
        protected LayerMask _ObstaclesLayerMask;
        protected Renderer _BombRenderer;
        protected BoxCollider _BoxCollider;
        protected CancellationTokenSource _Cts;
        protected const float ExplosionDisplayDuration = 0.9f;
        protected const float MinDistance = 1.0f;
        private readonly Subject<Unit> _onExplosionSubject = new();
        private readonly Subject<Unit> _onFinishSubject = new();
        public IObservable<Unit> _OnFinishIObservable => _onFinishSubject.Take(1);

        public void Initialize()
        {
            _BombRenderer = GetComponent<Renderer>();
            _BoxCollider = GetComponent<BoxCollider>();
            _Cts = new CancellationTokenSource();
            _ObstaclesLayerMask = GameCommonData.GetLayerAffectedByTheBlast();
            gameObject.layer = LayerMask.NameToLayer(GameCommonData.BombLayer);
        }

        public void Setup
        (
            int damageAmount,
            int fireRange,
            int playerId,
            int explosionTime
        )
        {
            _Cts ??= new CancellationTokenSource();
            gameObject.tag = GameCommonData.BombTag;
            _BombRenderer.enabled = true;
            _BoxCollider.enabled = true;
            _BoxCollider.isTrigger = true;
            _damageAmount = damageAmount;
            _playerId = playerId;
            _explosionTime = explosionTime;
            _fireRange = fireRange;
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
            _onFinishSubject.OnNext(Unit.Default);
            Cancel();
        }

        private void Cancel()
        {
            if (_Cts == null)
            {
                return;
            }

            _Cts.Cancel();
            _Cts.Dispose();
            _Cts = null;
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

            _BoxCollider.isTrigger = false;
        }

        private void OnDestroy()
        {
            _onFinishSubject.Dispose();
            _onExplosionSubject.Dispose();
            Cancel();
        }
    }
}