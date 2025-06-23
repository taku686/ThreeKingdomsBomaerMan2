using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using Player.Common;
using UniRx;
using UnityEngine;

namespace Skill
{
    public class UnderAbnormalConditionsBySkillUseCase : IDisposable
    {
        private readonly Subject<SkillMasterData> _onDamageSubject = new();
        private readonly Subject<(SkillMasterData, bool)> _onAbnormalConditionSubject = new();

        public IObservable<SkillMasterData> OnDamageAsObservable()
        {
            return _onDamageSubject
                .Where(skillMasterData => skillMasterData != null)
                .AsObservable();
        }

        public IObservable<(SkillMasterData, bool)> OnAbnormalConditionAsObservable()
        {
            return _onAbnormalConditionSubject
                .Where(tuple => tuple.Item1 != null)
                .AsObservable();
        }

        public void OnNextDamageSubject(SkillMasterData skillMasterData)
        {
            _onDamageSubject.OnNext(skillMasterData);
        }

        public async UniTaskVoid OnNextAbnormalConditionSubject(PlayerConditionInfo playerConditionInfo, SkillMasterData skillMasterData)
        {
            if (Mathf.Approximately(skillMasterData.EffectTime, GameCommonData.InvalidNumber))
            {
                return;
            }

            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                playerConditionInfo.AddAbnormalCondition(abnormalCondition);
            }

            var isActive = playerConditionInfo.HasAbnormalCondition();
            _onAbnormalConditionSubject.OnNext((skillMasterData, isActive));
            await UniTask.Delay(TimeSpan.FromSeconds(skillMasterData.EffectTime));

            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                playerConditionInfo.RemoveAbnormalCondition(abnormalCondition);
            }

            isActive = playerConditionInfo.HasAbnormalCondition();
            _onAbnormalConditionSubject.OnNext((skillMasterData, isActive));
        }

        public void Dispose()
        {
            _onDamageSubject?.Dispose();
        }
    }
}