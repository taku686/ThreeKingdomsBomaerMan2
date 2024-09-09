using System;
using UnityEngine;

namespace Common.Data
{
    public class SkillMasterData : IDisposable
    {
        public int Id { get; }
        public string Explanation { get; }
        public string Name { get; }
        public Sprite Sprite { get; }
        public int IconID { get; set; }
        public GameObject SkillEffectObj { get; }
        public SkillEffectType SkillEffectType { get; }
        public float Amount { get; set; }
        public float Range { get; }
        public float Interval { get; }

        public int SkillEffectObjID { get; set; }
        public SkillType SkillType { get; }
        public int SkillTypeInt { get; set; }
        public AttributeType AttributeType { get; }
        public int AttributeTypeInt { get; set; }
        public string SkillEffectTypeString { get; set; }

        public SkillMasterData
        (
            int id,
            string explanation,
            string name,
            Sprite sprite,
            SkillType skillType,
            GameObject skillEffectObj,
            AttributeType attributeType,
            SkillEffectType skillEffectType,
            float amount,
            float range,
            float interval
        )
        {
            Id = id;
            Explanation = explanation;
            Name = name;
            Sprite = sprite;
            SkillType = skillType;
            SkillEffectObj = skillEffectObj;
            SkillEffectType = skillEffectType;
            Amount = amount;
            Range = range;
            Interval = interval;
            AttributeType = attributeType;
        }

        public void Dispose()
        {
        }
    }
}