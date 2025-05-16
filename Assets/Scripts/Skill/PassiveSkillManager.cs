using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using ModestTree;
using Player.Common;
using Skill.Heal;
using UniRx;
using UnityEngine;
using Zenject;

namespace Skill
{
    public class PassiveSkillManager : IDisposable
    {
        private SkillMasterData _normalSkillMasterData;
        private SkillMasterData _specialSkillMasterData;
        private readonly BuffSkill _buffSkill;
        private readonly HealSkill _healSkill;
        private readonly SkillActivationConditionsUseCase _skillActivationConditionsUseCase;
        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        public PassiveSkillManager
        (
            BuffSkill buffSkill,
            HealSkill healSkill,
            SkillActivationConditionsUseCase skillActivationConditionsUseCase
        )
        {
            _buffSkill = buffSkill;
            _healSkill = healSkill;
            _skillActivationConditionsUseCase = skillActivationConditionsUseCase;
        }

        public void Initialize
        (
            SkillMasterData normalSkillMasterData,
            SkillMasterData specialSkillMasterData,
            SkillMasterData[] statusSkillMasterDatum,
            Transform playerTransform,
            Subject<(StatusType statusType, float value)> statusBuff,
            Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> statusBuffUi,
            int characterId,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase
        )
        {
            _normalSkillMasterData = normalSkillMasterData;
            _specialSkillMasterData = specialSkillMasterData;
            _cancellationTokenSource = new CancellationTokenSource();
            var playerStatusInfo = playerTransform.GetComponent<PlayerStatusInfo>();
            _buffSkill.Initialize
            (
                statusBuff,
                statusBuffUi,
                characterId,
                statusSkillMasterDatum,
                translateStatusInBattleUseCase,
                playerStatusInfo
            );
            PassiveSkill();
        }

        private void PassiveSkill()
        {
            _skillActivationConditionsUseCase
                .OnDamageAsObservable()
                .Where(skillData => skillData.SkillType == SkillType.Passive)
                .Where(skillData => skillData.BoolRequirementTypeEnum == BoolRequirementType.ReceiveDamage)
                .Subscribe(skillMasterData =>
                {
                    if (skillMasterData == null)
                    {
                        return;
                    }

                    _buffSkill.Buff(skillMasterData).Forget();
                })
                .AddTo(_cancellationTokenSource.Token);

            _skillActivationConditionsUseCase
                .OnAbnormalConditionAsObservable()
                .Where(tuple => tuple.Item1 != null)
                .Where(tuple => tuple.Item1.SkillType != SkillType.Passive)
                .Subscribe(tuple =>
                {
                    if (_normalSkillMasterData != null)
                    {
                        if (_normalSkillMasterData.SkillType != SkillType.Passive)
                        {
                            return;
                        }

                        if (_normalSkillMasterData.BoolRequirementTypeEnum != BoolRequirementType.AbnormalCondition)
                        {
                            return;
                        }

                        var isActive = tuple.Item2;
                        _buffSkill.BuffInAbnormalCondition(_normalSkillMasterData, isActive);
                        _healSkill.ContinuousHealInAbnormalCondition(_normalSkillMasterData);
                    }

                    if (_specialSkillMasterData != null)
                    {
                        if (_specialSkillMasterData.SkillType != SkillType.Passive)
                        {
                            return;
                        }

                        if (_specialSkillMasterData.BoolRequirementTypeEnum != BoolRequirementType.AbnormalCondition)
                        {
                            return;
                        }

                        var isActive = tuple.Item2;
                        _buffSkill.BuffInAbnormalCondition(_specialSkillMasterData, isActive);
                        _healSkill.ContinuousHealInAbnormalCondition(_specialSkillMasterData);
                    }
                })
                .AddTo(_cancellationTokenSource.Token);
        }

        private void Cancel()
        {
            if (_cancellationTokenSource == null)
            {
                return;
            }

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }

        public void Dispose()
        {
            Cancel();
        }
    }
}