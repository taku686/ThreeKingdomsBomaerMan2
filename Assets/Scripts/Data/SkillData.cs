using System;
using UnityEngine;

namespace Common.Data
{
    public class SkillData : IDisposable
    {
        public int ID { get; }
        public string Explanation { get; }
        public string Name { get; }
        public Sprite Icon { get; }
        public int IconID { get; }
        public GameObject SkillEffectObj { get; }
        public int SkillEffectObjID { get; }
        public SkillType SkillType { get; }
        public AttributeType AttributeType { get; }

        public SkillData
        (
            int id,
            string explanation,
            string name,
            Sprite icon,
            int iconID,
            SkillType skillType,
            GameObject skillEffectObj,
            int skillEffectObjID,
            AttributeType attributeType
        )
        {
            ID = id;
            Explanation = explanation;
            Name = name;
            Icon = icon;
            IconID = iconID;
            SkillType = skillType;
            SkillEffectObj = skillEffectObj;
            SkillEffectObjID = skillEffectObjID;
            AttributeType = attributeType;
        }

        public void Dispose()
        {
        }
    }
}