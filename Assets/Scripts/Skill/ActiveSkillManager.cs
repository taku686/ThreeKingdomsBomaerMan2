﻿using System;
using Common.Data;
using Photon.Pun;
using Player.Common;
using Skill.Attack;
using Skill.Attack.FlyingSlash;
using Skill.CrushImpact;
using Skill.DashAttack;
using Skill.MagicShot;
using Skill.SlashSpin;
using UnityEngine;
using Zenject;

namespace Skill
{
    public class ActiveSkillManager : IDisposable
    {
        private readonly AttributeSlashFactory.Factory _slashFactory;
        private readonly AttributeFlyingSlashFactory.Factory _flyingSlashFactory;
        private readonly AttributeDashAttackFactory.Factory _dashAttackFactory;
        private readonly AttributeCrushImpactFactory.Factory _crushImpactFactory;
        private readonly AttributeSlashSpinFactory.Factory _slashSpinFactory;
        private readonly AttributeMagicShotFactory.Factory _magicShotFactory;
        private readonly BuffSkill _buffSkill;
        private readonly Heal.Heal _heal;
        private Animator _animator;
        private const int GodSignBuffSkillId = 160;
        private const int TopThree = 3;

        [Inject]
        public ActiveSkillManager
        (
            AttributeSlashFactory.Factory slashFactory,
            AttributeFlyingSlashFactory.Factory flyingSlashFactory,
            AttributeDashAttackFactory.Factory dashAttackFactory,
            AttributeCrushImpactFactory.Factory crushImpactFactory,
            AttributeSlashSpinFactory.Factory slashSpinFactory,
            AttributeMagicShotFactory.Factory magicShotFactory,
            BuffSkill buffSkill,
            Heal.Heal heal
        )
        {
            _slashFactory = slashFactory;
            _flyingSlashFactory = flyingSlashFactory;
            _dashAttackFactory = dashAttackFactory;
            _crushImpactFactory = crushImpactFactory;
            _slashSpinFactory = slashSpinFactory;
            _magicShotFactory = magicShotFactory;
            _buffSkill = buffSkill;
            _heal = heal;
        }

        public void Initialize
        (
            SkillMasterData[] statusSkillMasterDatum,
            Transform playerTransform,
            int characterId,
            PlayerCore.PlayerStatusInfo playerStatusInfo
        )
        {
            var playerConditionInfo = playerTransform.GetComponent<PlayerConditionInfo>();
            _buffSkill.Initialize
            (
                characterId,
                statusSkillMasterDatum,
                playerConditionInfo,
                playerStatusInfo
            );

            _heal.Initialize
            (
                playerConditionInfo,
                playerStatusInfo
            );
        }

        public void SetupAnimator(Animator animator)
        {
            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            _animator = animator;
        }

        public void ActivateSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            if (IsSlashSkillActionType(skillMasterData))
            {
                SlashSkill(skillMasterData, playerTransform);
            }

            if (IsFlyingSlashSkillActionType(skillMasterData))
            {
                FlyingSlashSkill(skillMasterData, playerTransform);
            }

            if (IsMagicShotSkillActionType(skillMasterData))
            {
                MagicShotSkill(skillMasterData, playerTransform);
            }

            if (IsDashAttackSkillActionType(skillMasterData))
            {
                DashAttackSkill(skillMasterData, playerTransform);
            }

            if (IsCrushImpactSkillActionType(skillMasterData))
            {
                CrushImpactSkill(skillMasterData, playerTransform);
            }

            if (IsSlashSpinSkillActionType(skillMasterData))
            {
                SlashSpinSkill(skillMasterData, playerTransform);
            }
        }

        public void Heal(SkillMasterData skillMasterData)
        {
            if (IsHealSkillActionType(skillMasterData))
            {
                _heal.HealSkill(skillMasterData);
            }

            if (IsContinuousHealSkillActionType(skillMasterData))
            {
                _heal.ContinuousHealSkill(skillMasterData);
            }
        }

        public void BuffSkill(SkillMasterData skillMasterData)
        {
            if (!IsBuffSkillActionType(skillMasterData))
            {
                return;
            }

            if (skillMasterData.Id == GodSignBuffSkillId)
            {
                _buffSkill.Buff(skillMasterData, TopThree).Forget();
            }
            else
            {
                _buffSkill.Buff(skillMasterData).Forget();
            }
        }

        private void SlashSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            var skillId = skillMasterData.Id;
            var slash = _slashFactory.Create(skillId, _animator, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                slash = _slashFactory.Create(skillId, _animator, playerTransform, abnormalCondition, slash);
            }

            slash.Attack();
        }

        private void FlyingSlashSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            var skillId = skillMasterData.Id;
            var flyingSlash = _flyingSlashFactory.Create(skillId, _animator, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                flyingSlash = _flyingSlashFactory.Create(skillId, _animator, playerTransform, abnormalCondition, flyingSlash);
            }

            flyingSlash.Attack();
        }

        private void MagicShotSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            var skillId = skillMasterData.Id;
            var magicShot = _magicShotFactory.Create(skillId, _animator, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                magicShot = _magicShotFactory.Create(skillId, _animator, playerTransform, abnormalCondition, magicShot);
            }

            magicShot.Attack();
        }

        private void DashAttackSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            var skillId = skillMasterData.Id;
            var dashAttack = _dashAttackFactory.Create(skillId, _animator, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                dashAttack = _dashAttackFactory.Create(skillId, _animator, playerTransform, abnormalCondition, dashAttack);
            }

            dashAttack.Attack();
        }

        private void SlashSpinSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            var skillId = skillMasterData.Id;
            var slashSpin = _slashSpinFactory.Create(skillId, _animator, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                slashSpin = _slashSpinFactory.Create(skillId, _animator, playerTransform, abnormalCondition, slashSpin);
            }

            slashSpin.Attack();
        }

        private void CrushImpactSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            var skillId = skillMasterData.Id;
            var crushImpact = _crushImpactFactory.Create(skillId, _animator, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                crushImpact = _crushImpactFactory.Create(skillId, _animator, playerTransform, abnormalCondition, crushImpact);
            }

            crushImpact.Attack();
        }

        private static bool IsBuffSkillActionType(SkillMasterData skillMasterData)
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

        private static bool IsMagicShotSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.Shot;
        }

        private static bool IsFlyingSlashSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.FlyingSlash;
        }

        private static bool IsSlashSpinSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.SlashSpin;
        }

        private static bool IsDashAttackSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.DashAttack;
        }

        private static bool IsCrushImpactSkillActionType(SkillMasterData skillMasterData)
        {
            var skillActionType = skillMasterData._SkillActionTypeEnum;
            return skillActionType is SkillActionType.Impact;
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
            _buffSkill?.Dispose();
            _heal?.Dispose();
        }
    }
}