using System;
using System.Collections.Generic;

namespace Common.Data
{
    public class UserData : IDisposable
    {
        public int EquippedCharacterId;
        public string UserIconFileName;
        public int Level;
        public string Name;
        public int EntitledId;
        public bool IsTutorial;
        public int Gem;
        public int Coin;
        public readonly List<int> Characters = new();
        public readonly Dictionary<int, int> CharacterLevels = new();
        public readonly Dictionary<int, int> LoginBonus = new();
        public readonly Dictionary<int, int> PossessedWeapons = new();
        public readonly Dictionary<int, int> EquippedWeapons = new();
        public Dictionary<int, string> MissionDatum = new();

        [Serializable]
        public class MissionData
        {
            public int _progress;
            public int _characterId;
            public int _weaponId;
        }

        public MissionData CreateMissionData()
        {
            return new MissionData
            {
                _progress = 0,
                _characterId = 0,
                _weaponId = 0
            };
        }

        public UserData Create()
        {
            var user = this;
            user.EquippedCharacterId = 0;
            user.Level = 1;
            user.Name = "";
            user.EntitledId = 0;
            user.UserIconFileName = "default";
            user.IsTutorial = false;
            user.Characters.Add(0);
            user.Gem = 0;
            user.Coin = 0;
            user.CharacterLevels[0] = 1;
            user.PossessedWeapons[GameCommonData.DefaultWeaponId] = 1;
            user.EquippedWeapons[0] = GameCommonData.DefaultWeaponId;
            for (var i = 0; i < 7; i++)
            {
                user.LoginBonus[i] = (int)LoginBonusStatus.Disable;
            }

            user.MissionDatum = new Dictionary<int, string>();
            return user;
        }

        public void Dispose()
        {
            Characters.Clear();
            CharacterLevels.Clear();
            LoginBonus.Clear();
            MissionDatum.Clear();
        }
    }
}