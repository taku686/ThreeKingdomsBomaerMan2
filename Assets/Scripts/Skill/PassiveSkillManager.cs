using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using ModestTree;
using Player.Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace Skill
{
    public class PassiveSkillManager : IDisposable
    {
        private readonly BuffSkill _buffSkill;
        private readonly ActivatableSkillUseCase _activatableSkillUseCase;
        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        public PassiveSkillManager
        (
            BuffSkill buffSkill,
            ActivatableSkillUseCase activatableSkillUseCase
        )
        {
            _buffSkill = buffSkill;
            _activatableSkillUseCase = activatableSkillUseCase;
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
            _activatableSkillUseCase
                .OnDamageAsObservable()
                .Where(skillData => skillData.SkillType == SkillType.Passive)
                .Where(skillData => skillData.BoolRequirementTypeEnum == BoolRequirementType.ReceiveDamage)
                .Subscribe(skillMasterData =>
                {
                    if (skillMasterData == null)
                    {
                        return;
                    }

                    BuffSkill(skillMasterData);
                })
                .AddTo(_cancellationTokenSource.Token);
        }

        private void BuffSkill(SkillMasterData skillMasterData)
        {
            _buffSkill.Buff(skillMasterData).Forget();
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