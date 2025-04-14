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
        public SkillEffectType SkillEffectType { get; }
        public float DamagePlu { get; set; }
        public float HpPlu { get; set; }
        public float AttackPlu { get; set; }
        public float DefensePlu { get; set; }
        public float SpeedPlu { get; set; }
        public float ResistancePlu { get; set; }
        public float BombPlu { get; set; }
        public float FirePlu { get; set; }
        public float CoinPlu { get; set; }
        public float GemPlu { get; set; }
        public float SkillPlu { get; set; }
        public float DamageMul { get; set; }
        public float HpMul { get; set; }
        public float AttackMul { get; set; }
        public float DefenseMul { get; set; }
        public float SpeedMul { get; set; }
        public float ResistanceMul { get; set; }
        public float BombMul { get; set; }
        public float FireMul { get; set; }
        public float CoinMul { get; set; }
        public float GemMul { get; set; }
        public float SkillMul { get; set; }
        public int AbnormalCondition { get; set; }
        public float Range { get; }
        public float Interval { get; }
        public float EffectTime { get; }
        public bool IsAll { get; }
        public string BombType { get; }
        public string NumberRequirement { get; }
        public string NumberRequirementType { get; }
        public string BoolRequirementType { get; }
        public string SkillDirection { get; }
        public string SkillInvalid { get; }
        public SkillType SkillType { get; }
        public int SkillTypeInt { get; set; }
        public string SkillEffectTypeString { get; set; }

        public SkillMasterData
        (
            int id,
            string explanation,
            string name,
            Sprite sprite,
            SkillType skillType,
            SkillEffectType skillEffectType,
            float damagePlu,
            float range,
            float interval,
            float effectTime
        )
        {
            Id = id;
            Explanation = explanation;
            Name = name;
            Sprite = sprite;
            SkillType = skillType;
            SkillEffectType = skillEffectType;
            DamagePlu = damagePlu;
            Range = range;
            Interval = interval;
            EffectTime = effectTime;
        }

        public void Dispose()
        {
        }
    }
}