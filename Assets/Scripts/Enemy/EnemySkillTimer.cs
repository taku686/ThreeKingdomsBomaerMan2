using System;
using Common.Data;
using UniRx;
using UnityEngine;

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
                .Select(_ =>
                {
                    if (_timer >= skillMasterData.Interval)
                    {
                        Debug.Log("Skill can be used now");
                        return true;
                    }

                    return false;
                });
        }
        
        public void ResetTimer()
        {
            _timer = 0f;
        }

        public void Dispose()
        {
        }
    }
}