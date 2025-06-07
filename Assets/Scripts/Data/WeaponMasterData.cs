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
        public float Scale { get; set; }
        public bool IsBothHands { get; set; }
        public int Rare { get; }
        public GameObject WeaponObject { get; }
        public Sprite WeaponIcon { get; }
        public WeaponType WeaponType { get; }
        public int WeaponTypeInt { get; set; }
        public float CoinMul;
        public float GemMul;
        public float SkillMul;
        public float RangeMul;


        public WeaponMasterData
        (
            string name,
            int id,
            GameObject weaponObject,
            Sprite weaponIcon,
            WeaponType weaponType,
            SkillMasterData normalSkillMasterData,
            SkillMasterData[] statusSkillMasterDatum,
            float scale,
            bool isBothHands,
            int rare,
            float coinMul,
            float gemMul,
            float skillMul,
            float rangeMul
        )
        {
            Name = name;
            Id = id;
            WeaponObject = weaponObject;
            WeaponIcon = weaponIcon;
            WeaponType = weaponType;
            NormalSkillMasterData = normalSkillMasterData;
            StatusSkillMasterDatum = statusSkillMasterDatum;
            Scale = scale;
            IsBothHands = isBothHands;
            Rare = rare;
            CoinMul = coinMul;
            GemMul = gemMul;
            SkillMul = skillMul;
            RangeMul = rangeMul;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}