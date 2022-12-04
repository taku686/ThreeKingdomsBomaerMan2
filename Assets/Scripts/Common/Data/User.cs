using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine.Tilemaps;

namespace Common.Data
{
    public class User : IDisposable
    {
        public Gender Gender;
        public int EquipCharacterId;
        public int Level;
        public string Name;
        public bool IsTutorial;
        public Currency Currency = new Currency();
        public Dictionary<int, CharacterData> Characters = new Dictionary<int, CharacterData>();

        public void SetUserData(User user)
        {
            Gender = user.Gender;
            EquipCharacterId = user.EquipCharacterId;
            Level = user.Level;
            Name = user.Name;
            IsTutorial = user.IsTutorial;
            Characters = user.Characters;
            Currency = user.Currency;
        }

        public User GetUserData()
        {
            return this;
        }

        public User Create(CharacterData characterData)
        {
            var user = this;
            user.Gender = Gender.Male;
            user.EquipCharacterId = 0;
            user.Level = 1;
            user.Name = "";
            user.IsTutorial = false;
            user.Characters[0] = characterData;
            return user;
        }

        public void Dispose()
        {
            Currency?.Dispose();
        }
    }
}