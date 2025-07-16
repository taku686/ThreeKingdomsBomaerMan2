using System;
using System.Collections.Generic;
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
        [SerializeField] protected List<GameObject> explosionList;
        [HideInInspector] public int _fireRange;
        public IObservable<Unit> _OnFinishIObservable => _onFinishSubject.Take(1);

        private int _damageAmount;
        private int _explosionTime;
        private readonly Subject<Unit> _onExplosionSubject = new();
        private readonly Subject<Unit> _onFinishSubject = new();

        protected int _skillId;
        protected bool _isExplosion;
        protected int _instantiationId;
        protected LayerMask _obstaclesLayerMask;
        protected Renderer _bombRenderer;
        protected BoxCollider _boxCollider;
        protected CancellationTokenSource _cts;
        protected const float ExplosionDisplayDuration = 0.9f;
        protected const float MinDistance = 1.0f;

        public void Initialize()
        {
            _bombRenderer = GetComponent<Renderer>();
            _boxCollider = GetComponent<BoxCollider>();
            _cts = new CancellationTokenSource();
            _obstaclesLayerMask = GameCommonData.GetLayerAffectedByTheBlast();
            gameObject.layer = LayerMask.NameToLayer(GameCommonData.BombLayer);
        }

        public virtual void Setup
        (
            int damageAmount,
            int fireRange,
            int instantiationId,
            int explosionTime,
            int skillId,
            AbnormalCondition abnormalCondition
        )
        {
            _cts ??= new CancellationTokenSource();
            gameObject.tag = GameCommonData.BombTag;
            _bombRenderer.enabled = true;
            _boxCollider.enabled = true;
            _boxCollider.isTrigger = true;
            _damageAmount = damageAmount;
            _instantiationId = instantiationId;
            _explosionTime = explosionTime;
            _fireRange = fireRange;
            _skillId = skillId;
            _isExplosion = false;
            foreach (var bombEffect in explosionList)
            {
                bombEffect.SetActive(false);
            }

            gameObject.UpdateAsObservable().Subscribe(_ => { CountDown(_explosionTime); }).AddTo(_cts.Token);
        }

        private void CountDown(int explosionTime)
        {
            if (_isExplosion)
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
            if (_cts == null)
            {
                return;
            }

            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(GameCommonData.BombEffectTag) || _isExplosion)
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

            _boxCollider.isTrigger = false;
        }

        private void OnDestroy()
        {
            _onFinishSubject.Dispose();
            _onExplosionSubject.Dispose();
            Cancel();
        }
    }
}