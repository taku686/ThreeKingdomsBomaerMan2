using System.Collections.Generic;
using Common.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Skill;
using UnityEngine;

namespace Repository
{
    public class SlashSkillEffectRepository : SerializedMonoBehaviour
    {
        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Abnormal Condition", ValueLabel = "Skill Effect")]
        private Dictionary<AbnormalCondition, SkillEffect> _skillEffectDictionary;

        public SkillEffect GetSkillEffect(AbnormalCondition abnormalCondition)
        {
            if (_skillEffectDictionary.TryGetValue(abnormalCondition, out var skillEffect))
            {
                return skillEffect;
            }

            Debug.LogError($"Skill effect not found for {abnormalCondition}");
            return null;
        }
    }
}