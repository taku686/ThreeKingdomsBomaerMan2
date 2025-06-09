using System;
using Common.Data;
using Player.Common;
using Skill.Attack;
using Skill.Attack.FlyingSlash;
using Skill.Heal;
using UniRx;
using UnityEngine;
using Zenject;

namespace Skill
{
    public class ActiveSkillManager : IDisposable
    {
        private readonly AttributeSlashFactory.Factory _slashFactory;
        private readonly AttributeFlyingSlashFactory.Factory _flyingSlashFactory;
        private readonly BuffSkill _buffSkill;
        private readonly HealSkill _healSkill;
        private Animator _animator;
        private DC.Scanner.TargetScanner _targetScanner;
        private Transform _playerTransform;
        private const int GodSignBuffSkillId = 160;
        private const int TopThree = 3;


        [Inject]
        public ActiveSkillManager
        (
            AttributeSlashFactory.Factory slashFactory,
            AttributeFlyingSlashFactory.Factory flyingSlashFactory,
            BuffSkill buffSkill,
            HealSkill healSkill
        )
        {
            _slashFactory = slashFactory;
            _flyingSlashFactory = flyingSlashFactory;
            _buffSkill = buffSkill;
            _healSkill = healSkill;
        }

        public void Initialize
        (
            DC.Scanner.TargetScanner targetScanner,
            SkillMasterData[] statusSkillMasterDatum,
            Transform playerTransform,
            Animator animator,
            Subject<(StatusType statusType, float value)> statusBuff,
            Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> statusBuffUi,
            int characterId,
            TranslateStatusInBattleUseCase translateStatusInBattleUseCase,
            Func<int, int> hpCalculateFunc
        )
        {
            _targetScanner = targetScanner;
            _playerTransform = playerTransform;
            var playerStatusInfo = playerTransform.GetComponent<PlayerStatusInfo>();
            SetupAnimator(animator);
            _buffSkill.Initialize
            (
                statusBuff,
                statusBuffUi,
                characterId,
                statusSkillMasterDatum,
                translateStatusInBattleUseCase,
                playerStatusInfo
            );
            _healSkill.Initialize
            (
                hpCalculateFunc,
                translateStatusInBattleUseCase,
                playerStatusInfo
            );
        }

        public void SetupAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void ActivateSkill(SkillMasterData skillMasterData)
        {
            if (IsSlashSkillActionType(skillMasterData))
            {
                SlashSkill(skillMasterData);
            }

            if (IsFlyingSlashSkillActionType(skillMasterData))
            {
                var flyingSlash = _flyingSlashFactory.Create(_animator, AbnormalCondition.None, null);
                flyingSlash.Attack();
            }

            if (IsBuffSkillActionType(skillMasterData))
            {
                BuffSkill(skillMasterData);
            }

            if (IsHealSkillActionType(skillMasterData))
            {
                _animator.SetTrigger(GameCommonData.BuffHashKey);
                _healSkill.Heal(skillMasterData);
            }

            if (IsContinuousHealSkillActionType(skillMasterData))
            {
                _animator.SetTrigger(GameCommonData.BuffHashKey);
                _healSkill.ContinuousHeal(skillMasterData);
            }
        }

        private void BuffSkill(SkillMasterData skillMasterData)
        {
            _animator.SetTrigger(GameCommonData.BuffHashKey);
            if (skillMasterData.Id == GodSignBuffSkillId)
            {
                _buffSkill.Buff(skillMasterData, TopThree).Forget();
            }
            else
            {
                _buffSkill.Buff(skillMasterData).Forget();
            }
        }

        private void SlashSkill(SkillMasterData skillMasterData)
        {
            var skillId = skillMasterData.Id;
            var slash = _slashFactory.Create(skillId, _targetScanner, _animator, _playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                slash = _slashFactory.Create(skillId, _targetScanner, _animator, _playerTransform, abnormalCondition, slash);
            }

            slash.Attack();
        }

        private bool IsBuffSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is
                SkillActionType.HpBuff or
                SkillActionType.AttackBuff or
                SkillActionType.SpeedBuff or
                SkillActionType.BombLimitBuff or
                SkillActionType.FireRangeBuff or
                SkillActionType.ResistanceBuff or
                SkillActionType.DefenseBuff or
                SkillActionType.AllBuff;
        }

        private static bool IsSlashSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.Slash;
        }

        private bool IsFlyingSlashSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.FlyingSlash;
        }

        private static bool IsHealSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.Heal;
        }

        private static bool IsContinuousHealSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.ContinuousHeal;
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}