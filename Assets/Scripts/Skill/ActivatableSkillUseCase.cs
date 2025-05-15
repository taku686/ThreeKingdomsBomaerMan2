using System;
using Common.Data;
using UniRx;

namespace Skill
{
    public class ActivatableSkillUseCase : IDisposable
    {
        private readonly Subject<SkillMasterData> _onDamageSubject = new();

        public IObservable<SkillMasterData> OnDamageAsObservable()
        {
            return _onDamageSubject
                .Where(skillMasterData => skillMasterData != null)
                .AsObservable();
        }

        public void OnNextDamageSubject(SkillMasterData skillMasterData)
        {
            _onDamageSubject.OnNext(skillMasterData);
        }

        public void Dispose()
        {
            _onDamageSubject?.Dispose();
        }
    }
}