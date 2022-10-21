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
        public Dictionary<int, CharacterData> Characters;

        public void SetUser(User user)
        {
            Gender = user.Gender;
            EquipCharacterId = user.EquipCharacterId;
            Level = user.Level;
            Name = user.Name;
            IsTutorial = user.IsTutorial;
            Characters = user.Characters;
        }

        public User Create()
        {
            var user = new User();
            return user;
        }
    }
}