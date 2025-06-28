using System;
using Common.Data;
using UniRx;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemySkillTimer : IDisposable
    {
        private float _timer;

        public IObservable<bool> TimerSubscribe(SkillMasterData skillMasterData)
        {
            return Observable
                .EveryUpdate()
                .Where(_ => _timer < skillMasterData.Interval)
                .Do(_ => _timer += Time.deltaTime)
                .Select(_ => _timer >= skillMasterData.Interval);
        }

        public void ResetTimer()
        {
            _timer = 0f;
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<EnemySkillTimer>
        {
        }
    }
}