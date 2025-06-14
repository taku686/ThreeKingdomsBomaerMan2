using System.Collections.Generic;
using Common.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Skill;
using UnityEngine;

namespace Repository
{
    public class SkillEffectRepository : SerializedMonoBehaviour
    {
        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Abnormal Condition", ValueLabel = "Slash Effect")]
        private Dictionary<AbnormalCondition, SkillEffect> _skillEffectDictionary;

        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Abnormal Condition", ValueLabel = "FlyingSlash Effect")]
        private Dictionary<AbnormalCondition, SkillEffect> _flyingSlashEffectDictionary;

        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Abnormal Condition", ValueLabel = "DashAttack Effect")]
        private Dictionary<AbnormalCondition, SkillEffect> _dashAttackEffectDictionary;

        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Abnormal Condition", ValueLabel = "CrushImpact Effect")]
        private Dictionary<AbnormalCondition, SkillEffect> _crushImpactEffectDictionary;


        public SkillEffect GetSlashEffect(AbnormalCondition abnormalCondition)
        {
            if (_skillEffectDictionary.TryGetValue(abnormalCondition, out var skillEffect))
            {
                return skillEffect;
            }

            Debug.LogError($"Skill effect not found for {abnormalCondition}");
            return null;
        }

        public SkillEffect GetFlyingSlashEffect(AbnormalCondition abnormalCondition)
        {
            if (_flyingSlashEffectDictionary.TryGetValue(abnormalCondition, out var skillEffect))
            {
                return skillEffect;
            }

            Debug.LogError($"Skill effect not found for {abnormalCondition}");
            return null;
        }

        public SkillEffect GetDashAttackEffect(AbnormalCondition abnormalCondition)
        {
            if (_dashAttackEffectDictionary.TryGetValue(abnormalCondition, out var skillEffect))
            {
                return skillEffect;
            }

            Debug.LogError($"Skill effect not found for {abnormalCondition}");
            return null;
        }

        public SkillEffect GetCrushImpactEffect(AbnormalCondition abnormalCondition)
        {
            if (_crushImpactEffectDictionary.TryGetValue(abnormalCondition, out var skillEffect))
            {
                return skillEffect;
            }

            Debug.LogError($"Skill effect not found for {abnormalCondition}");
            return null;
        }
    }
}