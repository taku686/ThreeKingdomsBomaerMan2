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
        private readonly BuffSkill _buffSkill;
        private readonly HealSkill _healSkill;
        private readonly UnderAbnormalConditionsBySkillUseCase _underAbnormalConditionsBySkillUseCase;
        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        public PassiveSkillManager
        (
            BuffSkill buffSkill,
            HealSkill healSkill,
            UnderAbnormalConditionsBySkillUseCase underAbnormalConditionsBySkillUseCase
        )
        {
            _buffSkill = buffSkill;
            _healSkill = healSkill;
            _underAbnormalConditionsBySkillUseCase = underAbnormalConditionsBySkillUseCase;
        }

        public void Initialize
        (
            SkillMasterData[] statusSkillMasterDatum,
            Transform playerTransform,
            Subject<(StatusType statusType, float value)> statusBuff,
            Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> statusBuffUi,
            int characterId,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase
        )
        {
            Cancel();
            
            _cancellationTokenSource ??= new CancellationTokenSource();
            var playerStatusInfo = playerTransform.GetComponent<PlayerConditionInfo>();
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
            _underAbnormalConditionsBySkillUseCase
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

            _underAbnormalConditionsBySkillUseCase
                .OnAbnormalConditionAsObservable()
                .Where(tuple => tuple.Item1 != null)
                .Where(tuple => tuple.Item1.SkillType != SkillType.Passive)
                .Subscribe(tuple =>
                {
                    var skillMasterData = tuple.Item1;
                    var isActive = tuple.Item2;
                    if (skillMasterData.BoolRequirementTypeEnum != BoolRequirementType.AbnormalCondition)
                    {
                        return;
                    }

                    _buffSkill.BuffInAbnormalCondition(skillMasterData, isActive);
                    _healSkill.ContinuousHealInAbnormalCondition(skillMasterData);
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