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

        public void ActivateSkill
        (
            DC.Scanner.TargetScanner targetScanner,
            SkillMasterData skillMasterData,
            Transform playerTransform,
            Animator animator,
            int skillId
        )
        {
            var slash = _slashFactory.Create(skillId, targetScanner, animator, playerTransform, AbnormalCondition.None, null);
            foreach (var abnormalCondition in skillMasterData.AbnormalConditionEnum)
            {
                if (abnormalCondition == AbnormalCondition.None)
                    continue;
                slash = _slashFactory.Create(skillId, targetScanner, animator, playerTransform, abnormalCondition, slash);
            }

            slash.Attack();
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}