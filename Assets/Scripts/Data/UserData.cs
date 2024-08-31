using System;
using System.Collections.Generic;

namespace Common.Data
{
    public class UserData : IDisposable
    {
        public Gender Gender;
        public int EquippedCharacterId;
        public int Level;
        public string Name;
        public bool IsTutorial;
        public int Gem;
        public int Coin;
        public int Ticket;
        public readonly List<int> Characters = new();
        public readonly Dictionary<int, int> CharacterLevels = new();
        public readonly Dictionary<int, int> LoginBonus = new();
        public readonly Dictionary<int, int> PossessedWeapons = new();
        public readonly Dictionary<int, int> EquippedWeapons = new();
        public Dictionary<int, int> MissionProgressDatum = new();

        public UserData Create(CharacterData characterData)
        {
            var user = this;
            user.Gender = Gender.Male;
            user.EquippedCharacterId = 0;
            user.Level = 1;
            user.Name = "";
            user.IsTutorial = false;
            user.Characters.Add(characterData.Id);
            user.Gem = 0;
            user.Coin = 0;
            user.Ticket = 0;
            user.CharacterLevels[0] = 0;
            user.PossessedWeapons[GameCommonData.DefaultWeaponId] = 1;
            user.EquippedWeapons[0] = GameCommonData.DefaultWeaponId;
            for (int i = 0; i < 7; i++)
            {
                user.LoginBonus[i] = (int)LoginBonusStatus.Disable;
            }

            user.MissionProgressDatum = MissionProgressDatum;
            return user;
        }

        public void Dispose()
        {
            Characters.Clear();
            CharacterLevels.Clear();
            LoginBonus.Clear();
            MissionProgressDatum.Clear();
        }
    }
}