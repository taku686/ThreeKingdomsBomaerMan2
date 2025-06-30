using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Player.Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Skill
{
    public class OnDamageFacade : IDisposable
    {
        private readonly Subject<SkillMasterData> _onDamageSubject = new();
        private readonly Subject<(int, SkillMasterData)> _onAbnormalConditionSubject = new();
        private CancellationTokenSource _cts;

        [Inject]
        public OnDamageFacade()
        {
            _cts = new CancellationTokenSource();
        }

        public IObservable<SkillMasterData> OnDamageAsObservable()
        {
            return _onDamageSubject
                .Where(skillMasterData => skillMasterData != null)
                .AsObservable();
        }

        public IObservable<(int, SkillMasterData)> OnAbnormalConditionAsObservable()
        {
            return _onAbnormalConditionSubject
                .Where(tuple => tuple.Item2 != null)
                .AsObservable();
        }

        public void OnNextDamageSubject(SkillMasterData skillMasterData)
        {
            _onDamageSubject.OnNext(skillMasterData);
        }

        public void OnNextAbnormalConditionSubject(PlayerConditionInfo playerConditionInfo, SkillMasterData skillMasterData)
        {
            if (Mathf.Approximately(skillMasterData.EffectTime, GameCommonData.InvalidNumber))
            {
                return;
            }

            _onAbnormalConditionSubject.OnNext((playerConditionInfo.GetPlayerIndex(), skillMasterData));

            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                playerConditionInfo.AddAbnormalCondition(abnormalCondition);
            }

            Observable
                .Timer(TimeSpan.FromSeconds(skillMasterData.EffectTime))
                .Subscribe(_ =>
                {
                    foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
                    {
                        playerConditionInfo.RemoveAbnormalCondition(abnormalCondition);
                    }
                }).AddTo(_cts.Token);
        }

        public void Dispose()
        {
            _onDamageSubject?.Dispose();
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }
    }
}