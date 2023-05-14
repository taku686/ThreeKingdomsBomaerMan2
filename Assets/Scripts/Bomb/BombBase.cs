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
        protected static readonly float ExplosionDisplayDuration = 0.9f;
        protected static readonly float MinDistance = 1.0f;
        protected CancellationTokenSource Cts;
        protected int FireRange;
        protected LayerMask ObstaclesLayerMask;
        protected bool IsExplosion;
        protected Renderer BombRenderer;
        protected BoxCollider BoxColliderComponent;
        protected Action BlockShakeAction;
        private int _damageAmount;
        private int _playerId;
        private int _explosionTime;
        private readonly Subject<Unit> _onExplosionSubject = new();
        private readonly Subject<Unit> _onFinishSubject = new();

        private CancellationToken _token;


        public IObservable<Unit> OnFinishIObservable => _onFinishSubject.Take(1);

        public void Initialize()
        {
            BombRenderer = GetComponent<Renderer>();
            BoxColliderComponent = GetComponent<BoxCollider>();
            Cts = new CancellationTokenSource();
            _token = this.GetCancellationTokenOnDestroy();
            ObstaclesLayerMask = LayerMask.GetMask(GameCommonData.ObstacleLayer);
            gameObject.layer = LayerMask.NameToLayer(GameCommonData.BombLayer);
        }

        public void Setup(int damageAmount, int fireRange, int playerId, int explosionTime,
            StageOrnamentsBlock stageOrnamentsBlock)
        {
            gameObject.tag = GameCommonData.BombTag;
            BombRenderer.enabled = true;
            BoxColliderComponent.enabled = true;
            _damageAmount = damageAmount;
            _playerId = playerId;
            _explosionTime = explosionTime;
            FireRange = fireRange;
            BlockShakeAction = stageOrnamentsBlock.Shake;
            IsExplosion = false;
            foreach (var bombEffect in explosionList)
            {
                bombEffect.SetActive(false);
            }

            gameObject.UpdateAsObservable().Subscribe(_ => { CountDown(_explosionTime); }).AddTo(Cts.Token);
        }

        private void CountDown(int explosionTime)
        {
            if (IsExplosion)
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
            Cts ??= new CancellationTokenSource();
            Cts.Cancel();
            Cts.Dispose();
            Cts = new CancellationTokenSource();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(GameCommonData.BombEffectTag) || IsExplosion)
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

            BoxColliderComponent.isTrigger = false;
        }

        private void OnDestroy()
        {
            _onFinishSubject.Dispose();
            _onExplosionSubject.Dispose();
        }
    }
}