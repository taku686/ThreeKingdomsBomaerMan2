using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Skill
{
    public class SkillActivationConditionsUseCase : IDisposable
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

        public async UniTaskVoid OnNextAbnormalConditionSubject(PlayerStatusInfo playerStatusInfo, SkillMasterData skillMasterData)
        {
            if (Mathf.Approximately(skillMasterData.EffectTime, GameCommonData.InvalidNumber))
            {
                return;
            }

            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                playerStatusInfo.AddAbnormalCondition(abnormalCondition);
            }

            var isActive = playerStatusInfo.HasAbnormalCondition();
            _onAbnormalConditionSubject.OnNext((skillMasterData, isActive));
            await UniTask.Delay(TimeSpan.FromSeconds(skillMasterData.EffectTime));

            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                playerStatusInfo.RemoveAbnormalCondition(abnormalCondition);
            }

            isActive = playerStatusInfo.HasAbnormalCondition();
            _onAbnormalConditionSubject.OnNext((skillMasterData, isActive));
        }

        public void Dispose()
        {
            _onDamageSubject?.Dispose();
        }
    }
}