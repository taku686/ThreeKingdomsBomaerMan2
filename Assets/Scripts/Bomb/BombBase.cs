using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Bomb
{
    public abstract class BombBase : MonoBehaviour
    {
        [SerializeField] protected List<Transform> colliders;
        [SerializeField] protected List<Transform> explosionTransforms;
        protected static readonly float ExplosionDisplayDuration = 0.9f;
        protected static readonly float MinDistance = 1.0f;
        protected CancellationTokenSource Cts;
        protected int FireRange;
        protected Vector3 StartPos;
        protected LayerMask ObstaclesLayerMask;
        protected bool IsExplosion;
        protected Renderer BombRenderer;
        protected BoxCollider BoxColliderComponent;
        private int _damageAmount;
        private int _playerId;
        private int _explosionTime;
        private readonly Subject<Unit> _onExplosionSubject = new Subject<Unit>();
        private readonly Subject<Unit> _onFinishSubject = new Subject<Unit>();

        private CancellationToken _token;


        public IObservable<Unit> OnFinishIObservable => _onFinishSubject.Take(1);

        public void Setup(int damageAmount, int fireRange, int playerId, int explosionTime)
        {
            Cts = new CancellationTokenSource();
            _token = this.GetCancellationTokenOnDestroy();
            BombRenderer = GetComponent<Renderer>();
            BoxColliderComponent = GetComponent<BoxCollider>();
            BombRenderer.enabled = true;
            _damageAmount = damageAmount;
            _playerId = playerId;
            _explosionTime = explosionTime;
            FireRange = fireRange;
            ObstaclesLayerMask = LayerMask.GetMask(GameSettingData.ObstacleLayer);
            IsExplosion = false;
            var count = 0;
            foreach (var boxCollider in colliders.Select(x => x.GetComponent<BoxCollider>()))
            {
                boxCollider.isTrigger = true;
                explosionTransforms[count].gameObject.SetActive(false);
            }

            gameObject.UpdateAsObservable().Subscribe(_ => { CountDown(explosionTime); }).AddTo(Cts.Token);
            gameObject.OnTriggerEnterAsObservable()
                .Where(effectCollider => effectCollider.CompareTag(GameSettingData.BombEffectTag)).Subscribe(
                    _ => { Explosion().Forget(); });
        }

        private void CountDown(int explosionTime)
        {
            if (IsExplosion)
            {
                return;
            }

            if (unchecked(PhotonNetwork.ServerTimestamp - explosionTime) >= 0)
            {
                Explosion().Forget();
            }
        }

        protected virtual async UniTask Explosion()
        {
            await UniTask.NextFrame(Cts.Token);
            OnDisableBomb();
        }

        private void OnDisableBomb()
        {
            Cancel();
            _onFinishSubject.OnNext(Unit.Default);
        }

        private void Cancel()
        {
            Cts ??= new CancellationTokenSource();
            Cts.Cancel();
            Cts.Dispose();
            Cts = new CancellationTokenSource();
        }

        private void OnDestroy()
        {
            _onFinishSubject.Dispose();
            _onExplosionSubject.Dispose();
        }
    }
}