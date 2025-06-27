using System;
using Common.Data;
using UniRx;
using UnityEngine;

namespace Enemy
{
    public class EnemySkillTimer : IDisposable
    {
        public IObservable<bool> TimerSubscribe(SkillMasterData skillMasterData)
        {
            var timer = 0f;

            return Observable
                .EveryUpdate()
                .Do(_ => timer += Time.deltaTime)
                .Select(_ =>
                {
                    if (timer >= skillMasterData.Interval)
                    {
                        timer = 0f;
                        return true;
                    }

                    return false;
                });
        }

        public void Dispose()
        {
        }
    }
}