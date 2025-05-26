using System;
using UnityEngine;

namespace Common.Data
{
    public class WeaponMasterData : IDisposable
    {
        public string Name { get; }
        public int Id { get; }
        public string StatusSkillId { get; set; }
        public SkillMasterData[] StatusSkillMasterDatum { get; }
        public int NormalSkillId { get; set; }
        public SkillMasterData NormalSkillMasterData { get; }
        public int SpecialSkillId { get; set; }
        public SkillMasterData SpecialSkillMasterData { get; }
        public float Scale { get; set; }
        public bool IsBothHands { get; set; }
        public int Rare { get; }
        public GameObject WeaponObject { get; }
        public Sprite WeaponIcon { get; }
        public WeaponType WeaponType { get; }
        public int WeaponTypeInt { get; set; }

        public WeaponMasterData
        (
            string name,
            int id,
            GameObject weaponObject,
            Sprite weaponIcon,
            WeaponType weaponType,
            SkillMasterData normalSkillMasterData,
            SkillMasterData[] statusSkillMasterDatum,
            SkillMasterData specialSkillMasterData,
            float scale,
            bool isBothHands,
            int rare
        )
        {
            Name = name;
            Id = id;
            WeaponObject = weaponObject;
            WeaponIcon = weaponIcon;
            WeaponType = weaponType;
            NormalSkillMasterData = normalSkillMasterData;
            StatusSkillMasterDatum = statusSkillMasterDatum;
            SpecialSkillMasterData = specialSkillMasterData;
            Scale = scale;
            IsBothHands = isBothHands;
            Rare = rare;
        }

        public SkillMasterData GetSkillData(int skillType)
        {
            return skillType switch
            {
                1 => NormalSkillMasterData,
                2 => SpecialSkillMasterData,
                _ => null
            };
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}