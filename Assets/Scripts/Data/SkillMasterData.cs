using System;
using UnityEngine;

namespace Common.Data
{
    public class SkillMasterData : IDisposable
    {
        public int Id { get; }
        public string Name { get; }
        public string Explanation { get; }
        public int IconID { get; set; }
        public Sprite Sprite { get; }
        public string _SkillActionType { get; set; }
        public SkillActionType _SkillActionTypeEnum { get; }
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
        public float Range { get; set; }
        public float Interval { get; set; }
        public float EffectTime { get; set; }
        public bool IsAll { get; set; }
        public string BombType { get; set; }
        public BombType BombTypeEnum { get; set; }
        public string NumberRequirement { get; set; }
        public float[] NumberRequirements { get; set; }
        public string NumberRequirementType { get; set; }
        public NumberRequirementType NumberRequirementTypeEnum { get; }
        public string _BoolRequirementType { get; set; }
        public BoolRequirementType BoolRequirementTypeEnum { get; }
        public string SkillDirection { get; set; }
        public SkillDirection SkillDirectionEnum { get; }
        public string InvalidAbnormalCondition { get; set; }
        public AbnormalCondition[] InvalidAbnormalConditionEnum { get; }
        public string AbnormalCondition { get; set; }
        public AbnormalCondition[] AbnormalConditionEnum { get; set; }
        public SkillType SkillType { get; }
        public int SkillTypeInt { get; set; }

        public SkillMasterData
        (
            int id,
            string explanation,
            string name,
            Sprite sprite,
            SkillActionType skillActionType,
            SkillType skillType,
            float hpPlu,
            float attackPlu,
            float defensePlu,
            float speedPlu,
            float resistancePlu,
            float bombPlu,
            float firePlu,
            float coinPlu,
            float gemPlu,
            float skillPlu,
            float damagePlu,
            float hpMul,
            float attackMul,
            float defenseMul,
            float speedMul,
            float resistanceMul,
            float bombMul,
            float fireMul,
            float damageMul,
            float coinMul,
            float gemMul,
            float skillMul,
            float[] numberRequirements,
            NumberRequirementType numberRequirementType,
            BoolRequirementType boolRequirementType,
            SkillDirection skillDirection,
            AbnormalCondition[] invalidAbnormalConditionEnum,
            AbnormalCondition[] abnormalConditionEnum,
            BombType bombType,
            bool isAll,
            float range,
            float interval,
            float effectTime
        )
        {
            Id = id;
            Explanation = explanation;
            Name = name;
            Sprite = sprite;
            _SkillActionTypeEnum = skillActionType;
            SkillType = skillType;
            HpPlu = hpPlu;
            AttackPlu = attackPlu;
            DefensePlu = defensePlu;
            SpeedPlu = speedPlu;
            ResistancePlu = resistancePlu;
            BombPlu = bombPlu;
            FirePlu = firePlu;
            CoinPlu = coinPlu;
            GemPlu = gemPlu;
            SkillPlu = skillPlu;
            DamagePlu = damagePlu;
            HpMul = hpMul;
            AttackMul = attackMul;
            DefenseMul = defenseMul;
            SpeedMul = speedMul;
            ResistanceMul = resistanceMul;
            BombMul = bombMul;
            FireMul = fireMul;
            DamageMul = damageMul;
            CoinMul = coinMul;
            GemMul = gemMul;
            SkillMul = skillMul;
            NumberRequirements = numberRequirements;
            NumberRequirementTypeEnum = numberRequirementType;
            BoolRequirementTypeEnum = boolRequirementType;
            SkillDirectionEnum = skillDirection;
            InvalidAbnormalConditionEnum = invalidAbnormalConditionEnum;
            AbnormalConditionEnum = abnormalConditionEnum;
            BombTypeEnum = bombType;
            IsAll = isAll;
            Range = range;
            Interval = interval;
            EffectTime = effectTime;
        }

        public void Dispose()
        {
        }
    }
}