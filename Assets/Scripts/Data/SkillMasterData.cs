using System;
using UnityEngine;

namespace Common.Data
{
    public class SkillMasterData : IDisposable
    {
        public int Id { get; }
        public string Explanation { get; }
        public string Name { get; }
        public Sprite Icon { get; }
        public int IconID { get; set; }
        public GameObject SkillEffectObj { get; }
        
        public int SkillEffectObjID { get; set; }
        public SkillType SkillType { get; }
        public int SkillTypeInt { get; set; }
        public AttributeType AttributeType { get; }
        public int AttributeTypeInt { get; set; }

        public SkillMasterData
        (
            int id,
            string explanation,
            string name,
            Sprite icon,
            int skillType,
            GameObject skillEffectObj,
            int attributeType
        )
        {
            Id = id;
            Explanation = explanation;
            Name = name;
            Icon = icon;
            SkillType = (SkillType)skillType;
            SkillEffectObj = skillEffectObj;
            AttributeType = (AttributeType)attributeType;
        }

        public void Dispose()
        {
        }
    }
}