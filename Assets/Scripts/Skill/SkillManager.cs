using System;
using Common.Data;
using Skill.Attack;
using UnityEngine;
using Zenject;

namespace Skill
{
    public class SkillManager : IDisposable
    {
        private readonly AttributeSlashFactory.SlashFactory _slashFactory;


        [Inject]
        public SkillManager
        (
            AttributeSlashFactory.SlashFactory slashFactory
        )
        {
            _slashFactory = slashFactory;
        }

        public void ActivateSkill(SkillMasterData skillMasterData, Transform playerTransform, Animator animator)
        {
            var slash = _slashFactory.Create(animator, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                slash = _slashFactory.Create(animator, playerTransform, abnormalCondition, slash);
            }

            slash.Attack();
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}