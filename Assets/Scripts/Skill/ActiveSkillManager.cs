using System;
using Character;
using Common.Data;
using Photon.Pun;
using Player.Common;
using Skill.Attack;
using Skill.Attack.FlyingSlash;
using Skill.ChangeBomb;
using Skill.CrushImpact;
using Skill.DashAttack;
using Skill.ImpactRock;
using Skill.MagicShot;
using Skill.RainArrow;
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
        private readonly AttributeRainArrowFactory.Factory _rainArrowFactory;
        private readonly AttributeImpactRockFactory.Factory _impactRockFactory;
        private readonly AttributeChangeBombFactory.Factory _changeBombFactory;
        private readonly BuffSkill _buffSkill;
        private readonly Heal.Heal _heal;
        private Animator _animator;
        private PlayerStatusInfo _playerStatusInfo;
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
            AttributeRainArrowFactory.Factory rainArrowFactory,
            AttributeImpactRockFactory.Factory impactRockFactory,
            AttributeChangeBombFactory.Factory changeBombFactory,
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
            _rainArrowFactory = rainArrowFactory;
            _impactRockFactory = impactRockFactory;
            _changeBombFactory = changeBombFactory;
            _buffSkill = buffSkill;
            _heal = heal;
        }

        public void Initialize
        (
            SkillMasterData[] statusSkillMasterDatum,
            Transform playerTransform,
            int characterId,
            PlayerStatusInfo playerStatusInfo
        )
        {
            _playerStatusInfo = playerStatusInfo;
            var playerConditionInfo = playerTransform.GetComponent<PlayerConditionInfo>();

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

        public void ActivateSkill
        (
            SkillMasterData skillMasterData,
            Transform playerTransform,
            PutBomb putBomb
        )
        {
            if (IsActionType(skillMasterData, SkillActionType.Slash))
            {
                SlashSkill(skillMasterData, playerTransform);
            }

            if (IsActionType(skillMasterData, SkillActionType.FlyingSlash))
            {
                FlyingSlashSkill(skillMasterData, playerTransform);
            }

            if (IsActionType(skillMasterData, SkillActionType.Shot))
            {
                MagicShotSkill(skillMasterData, playerTransform);
            }

            if (IsActionType(skillMasterData, SkillActionType.DashAttack))
            {
                DashAttackSkill(skillMasterData, playerTransform);
            }

            if (IsActionType(skillMasterData, SkillActionType.Impact))
            {
                CrushImpactSkill(skillMasterData, playerTransform);
            }

            if (IsActionType(skillMasterData, SkillActionType.SlashSpin))
            {
                SlashSpinSkill(skillMasterData, playerTransform);
            }

            if (IsActionType(skillMasterData, SkillActionType.RainArrow))
            {
                RainArrowSkill(skillMasterData, playerTransform);
            }

            if (IsActionType(skillMasterData, SkillActionType.ImpactRock))
            {
                ImpactRockSkill(skillMasterData, playerTransform);
            }

            if (IsActionType(skillMasterData, SkillActionType.Bomb))
            {
                ChangeBomb(putBomb, _playerStatusInfo, skillMasterData);
            }
        }

        public void Heal(SkillMasterData skillMasterData)
        {
            if (IsActionType(skillMasterData, SkillActionType.Heal))
            {
                _heal.HealSkill(skillMasterData);
            }

            if (IsActionType(skillMasterData, SkillActionType.ContinuousHeal))
            {
                _heal.ContinuousHealSkill(skillMasterData);
            }
        }

        public void BuffSkill
        (
            SkillMasterData skillMasterData,
            SkillMasterData[] statusSkillMasterDatum,
            int characterId,
            PlayerStatusInfo playerStatusInfo
        )
        {
            if (!IsBuffSkillActionType(skillMasterData))
            {
                return;
            }

            if (skillMasterData.Id == GodSignBuffSkillId)
            {
                _buffSkill.Buff
                (
                    skillMasterData,
                    statusSkillMasterDatum,
                    characterId,
                    playerStatusInfo,
                    TopThree
                ).Forget();
            }
            else
            {
                _buffSkill.Buff
                (
                    skillMasterData,
                    statusSkillMasterDatum,
                    characterId,
                    playerStatusInfo
                ).Forget();
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

        private void RainArrowSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            var skillId = skillMasterData.Id;
            var rainArrow = _rainArrowFactory.Create(skillId, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                rainArrow = _rainArrowFactory.Create(skillId, playerTransform, abnormalCondition, rainArrow);
            }

            rainArrow.Attack();
        }

        private void ChangeBomb
        (
            PutBomb putBomb,
            PlayerStatusInfo playerStatusInfo,
            SkillMasterData skillMasterData
        )
        {
            var skillId = skillMasterData.Id;
            var changeBomb = _changeBombFactory.Create(skillId, putBomb, playerStatusInfo, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                changeBomb = _changeBombFactory.Create(skillId, putBomb, playerStatusInfo, abnormalCondition, changeBomb);
            }

            changeBomb.Attack();
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

        private void ImpactRockSkill(SkillMasterData skillMasterData, Transform playerTransform)
        {
            var skillId = skillMasterData.Id;
            var impactRock = _impactRockFactory.Create(skillId, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                impactRock = _impactRockFactory.Create(skillId, playerTransform, abnormalCondition, impactRock);
            }

            impactRock.Attack();
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

        private static bool IsActionType(SkillMasterData skillMasterData, SkillActionType skillActionType)
        {
            return skillMasterData._SkillActionTypeEnum == skillActionType;
        }

        public void Dispose()
        {
            _buffSkill?.Dispose();
            _heal?.Dispose();
        }
    }
}