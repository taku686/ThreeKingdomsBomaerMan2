using System;
using UnityEngine;

namespace Common.Data
{
    public class WeaponData : IDisposable
    {
        public string Name { get; }
        public int ID { get; }
        public int NormalSkillId { get; }
        public int StatusSkillId { get; }
        public int SpecialSkillId { get; }
        public GameObject WeaponObject { get; }
        public int WeaponObjectID { get; }
        public GameObject WeaponEffectObj { get; }
        public int WeaponEffectObjID { get; }
        public Sprite WeaponIcon { get; }
        public int WeaponIconID { get; }
        public WeaponType WeaponType { get; }
        public AttributeType AttributeType { get; }

        public WeaponData
        (
            string name,
            int id,
            int normalSkillId,
            int statusSkillId,
            int specialSkillId,
            GameObject weaponObject,
            int weaponObjectID,
            GameObject weaponEffectObj,
            int weaponEffectObjID,
            Sprite weaponIcon,
            int weaponIconID,
            WeaponType weaponType,
            AttributeType attributeType
        )
        {
            Name = name;
            ID = id;
            NormalSkillId = normalSkillId;
            StatusSkillId = statusSkillId;
            SpecialSkillId = specialSkillId;
            WeaponObject = weaponObject;
            WeaponObjectID = weaponObjectID;
            WeaponEffectObj = weaponEffectObj;
            WeaponEffectObjID = weaponEffectObjID;
            WeaponIcon = weaponIcon;
            WeaponIconID = weaponIconID;
            WeaponType = weaponType;
            AttributeType = attributeType;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}