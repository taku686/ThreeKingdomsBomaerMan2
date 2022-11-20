using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Effect;
using Photon.Pun;
using UniRx;
using UnityEngine;

namespace Bomb
{
    public abstract class BombBase : MonoBehaviour
    {
        [SerializeField] protected ExplosionEffect explosionEffect;
        protected int DamageAmount;
        protected int FireRange;
        protected int PlayerId;
        protected int ExplosionTime;
        protected readonly Subject<Unit> OnExplosionSubject = new Subject<Unit>();
        private readonly Subject<Unit> _onFinishSubject = new Subject<Unit>();
        private CancellationToken _token;
        private CancellationTokenSource _cts;

        public IObservable<Unit> OnFinishIObservable => _onFinishSubject.Take(1);

        public void Setup(int damageAmount, int fireRange, int playerId, int explosionTime)
        {
            _cts = new CancellationTokenSource();
            _token = this.GetCancellationTokenOnDestroy();
            DamageAmount = damageAmount;
            FireRange = fireRange;
            PlayerId = playerId;
            ExplosionTime = explosionTime;
            Observable.EveryUpdate().Subscribe(_ => { CountDown(explosionTime); }).AddTo(_cts.Token);
        }

        private void CountDown(int explosionTime)
        {
            if (unchecked(PhotonNetwork.ServerTimestamp - explosionTime) >= 0)
            {
                Explosion();
            }
        }

        protected virtual void Explosion()
        {
            OnDisableBomb();
        }

        private void OnDisableBomb()
        {
            Debug.Log("爆破完了");
            Cancel();
            _onFinishSubject.OnNext(Unit.Default);
        }

        private void Cancel()
        {
            _cts ??= new CancellationTokenSource();
            _cts.Cancel();
            _cts.Dispose();
            _cts = new CancellationTokenSource();
        }

        private void OnDestroy()
        {
            _onFinishSubject.Dispose();
            OnExplosionSubject.Dispose();
        }
    }
}