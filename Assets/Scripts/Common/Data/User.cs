using System.Collections.Generic;
using UniRx;

namespace Common.Data
{
    public class User
    {
        public Gender Gender;
        public int EquipCharacterId;
        public int Level;
        public string Name;
        public bool IsTutorial;
        public Dictionary<int, CharacterData> Characters = new Dictionary<int, CharacterData>();

        public void SetUser(User user)
        {
            Gender = user.Gender;
            EquipCharacterId = user.EquipCharacterId;
            Level = user.Level;
            Name = user.Name;
            IsTutorial = user.IsTutorial;
            Characters = user.Characters;
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
    }
}