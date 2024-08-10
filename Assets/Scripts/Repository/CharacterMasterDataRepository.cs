using System;
using System.Collections.Generic;
using Common.Data;
using Zenject;

namespace Manager.DataManager
{
    public class CharacterMasterDataRepository : IDisposable
    {
        [Inject] private MainManager mainManager;
        [Inject] private UserDataRepository userDataRepository;
        private static readonly Dictionary<int, CharacterData> CharacterDatum = new();

        public void SetCharacterData(CharacterData characterData)
        {
            CharacterDatum[characterData.Id] = characterData;
        }

        public CharacterData GetCharacterData(int id)
        {
            return CharacterDatum[id];
        }

        public IReadOnlyCollection<CharacterData> GetAllCharacterData()
        {
            return CharacterDatum.Values;
        }

        public int GetAllCharacterAmount()
        {
            return CharacterDatum.Count;
        }

        public CharacterData GetUserEquippedCharacterData()
        {
            return GetCharacterData(userDataRepository.GetUserData().EquippedCharacterId);
        }

        public void Dispose()
        {
        }

        public CharacterData DebugGetCharacterData()
        {
            var characterData = new CharacterData()
            {
                Hp = 100,
                Speed = 100,
                BombLimit = 10,
                Attack = 100,
                FireRange = 10
            };
            return characterData;
        }
    }
}