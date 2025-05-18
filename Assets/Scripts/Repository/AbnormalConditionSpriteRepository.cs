using System.Collections.Generic;
using Common.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Repository
{
    public class AbnormalConditionSpriteRepository : SerializedMonoBehaviour
    {
        [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "AbnormalCondition", ValueLabel = "Sprite")]
        private Dictionary<AbnormalCondition, Sprite> _abnormalConditionSprites;

        public Sprite GetAbnormalConditionSprite(AbnormalCondition abnormalCondition)
        {
            return _abnormalConditionSprites.GetValueOrDefault(abnormalCondition);
        }
    }
}