using System;
using UnityEngine;

namespace Common.Data
{
    public class CharacterData : IDisposable
    {
        private string charaObj;
        public GameObject CharacterObject;
        private int team;
        private int level;
        private string name;
        private int id;
        private int speed;
        private int bombLimit;
        private int attack;
        private int fireRange;
        private int hp;
        private int defense;
        private int resistance;
        private int type;
        private int passiveSkillId;
        private int normalSkillId;
        private int specialSkillId;
        private string charaColor;
        private int rarity;
        public Sprite SelfPortraitSprite;
        public Sprite ColorSprite;
        public SkillMasterData _PassiveSkillMasterData;
        public SkillMasterData _NormalSkillMasterData;
        public SkillMasterData _SpecialSkillMasterData;


        public string CharaObj
        {
            get => charaObj;
            set => charaObj = value;
        }

        public int Team
        {
            get => team;
            set => team = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Speed
        {
            get => speed;
            set => speed = value;
        }

        public int BombLimit
        {
            get => bombLimit;
            set => bombLimit = value;
        }

        public int Attack
        {
            get => attack;
            set => attack = value;
        }

        public int FireRange
        {
            get => fireRange;
            set => fireRange = value;
        }

        public int Hp
        {
            get => hp;
            set => hp = value;
        }

        public int Defense
        {
            get => defense;
            set => defense = value;
        }

        public int Resistance
        {
            get => resistance;
            set => resistance = value;
        }

        public string CharaColor
        {
            get => charaColor;
            set => charaColor = value;
        }

        public int Type
        {
            get => type;
            set => type = value;
        }

        public int PassiveSkillId
        {
            get => passiveSkillId;
            set => passiveSkillId = value;
        }
        
        public int NormalSkillId
        {
            get => normalSkillId;
            set => normalSkillId = value;
        }
        
        public int SpecialSkillId
        {
            get => specialSkillId;
            set => specialSkillId = value;
        }
        
        public int Rarity
        {
            get => rarity;
            set => rarity = value;
        }

        public CharacterData Clone()
        {
            return (CharacterData)MemberwiseClone();
        }

        public void Dispose()
        {
        }
    }
}