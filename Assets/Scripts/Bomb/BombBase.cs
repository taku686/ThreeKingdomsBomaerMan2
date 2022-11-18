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
        
        public IObservable<Unit> OnFinishIObservable => _onFinishSubject.Take(1);
        public void Setup(int damageAmount, int fireRange, int playerId, int explosionTime)
        {
            _token = this.GetCancellationTokenOnDestroy();
            DamageAmount = damageAmount;
            FireRange = fireRange;
            PlayerId = playerId;
            ExplosionTime = explosionTime;
            Observable.EveryUpdate().Subscribe(_ => { CountDown(explosionTime); }).AddTo(_token);
            OnExplosionSubject.Subscribe(_ => { OnDisable(); }).AddTo(_token);
        }

        private void CountDown(int explosionTime)
        {
            if (unchecked(explosionTime - PhotonNetwork.ServerTimestamp) >= GameSettingData.ThreeSecondsBeforeExplosion)
            {
                Explosion();
            }
        }

        protected abstract void Explosion();

        protected void OnDisable()
        {
            Debug.Log("完了");
            _onFinishSubject.OnNext(Unit.Default);
        }

        private void OnDestroy()
        {
            _onFinishSubject.Dispose();
            OnExplosionSubject.Dispose();
        }
    }
}