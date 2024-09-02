using System;
using UnityEngine;

namespace Common.Data
{
    public class WeaponMasterData : IDisposable
    {
        public string Name { get; }
        public int Id { get; }
        public int StatusSkillId { get; set; }
        public SkillMasterData StatusSkillMasterData { get; }
        public int NormalSkillId { get; set; }
        public SkillMasterData NormalSkillMasterData { get; }
        public int SpecialSkillId { get; set; }
        public SkillMasterData SpecialSkillMasterData { get; }
        public float Scale { get; set; }
        public GameObject WeaponObject { get; }
        public GameObject WeaponEffectObj { get; }
        public Sprite WeaponIcon { get; }
        public WeaponType WeaponType { get; }
        public int WeaponTypeInt { get; set; }
        public AttributeType AttributeType { get; }
        public int AttributeTypeInt { get; set; }

        public WeaponMasterData
        (
            string name,
            int id,
            GameObject weaponObject,
            GameObject weaponEffectObj,
            Sprite weaponIcon,
            WeaponType weaponType,
            AttributeType attributeType,
            SkillMasterData normalSkillMasterData,
            SkillMasterData statusSkillMasterData,
            SkillMasterData specialSkillMasterData,
            float scale)
        {
            Name = name;
            Id = id;
            WeaponObject = weaponObject;
            WeaponEffectObj = weaponEffectObj;
            WeaponIcon = weaponIcon;
            WeaponType = weaponType;
            AttributeType = attributeType;
            NormalSkillMasterData = normalSkillMasterData;
            StatusSkillMasterData = statusSkillMasterData;
            SpecialSkillMasterData = specialSkillMasterData;
            Scale = scale;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}