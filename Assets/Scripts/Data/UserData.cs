using System;
using System.Collections.Generic;

namespace Common.Data
{
    public class UserData : IDisposable
    {
        public Gender Gender;
        public int EquipCharacterId;
        public int Level;
        public string Name;
        public bool IsTutorial;
        public int Gem;
        public int Coin;
        public List<int> Characters = new();
        public readonly Dictionary<int, int> CharacterLevels = new();

        public void SetUserData(UserData userData)
        {
            Gender = userData.Gender;
            EquipCharacterId = userData.EquipCharacterId;
            Level = userData.Level;
            Name = userData.Name;
            IsTutorial = userData.IsTutorial;
            Characters = userData.Characters;
            Gem = userData.Gem;
            Coin = userData.Coin;
        }

        public UserData GetUserData()
        {
            return this;
        }

        public UserData Create(CharacterData characterData)
        {
            var user = this;
            user.Gender = Gender.Male;
            user.EquipCharacterId = 0;
            user.Level = 1;
            user.Name = "";
            user.IsTutorial = false;
            user.Characters.Add(characterData.ID);
            user.Gem = 0;
            user.Coin = 0;
            user.CharacterLevels[0] = 0;
            return user;
        }

        public void Dispose()
        {
        }
    }
}