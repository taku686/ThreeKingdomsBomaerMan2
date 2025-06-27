using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Zenject;
using Random = UnityEngine.Random;

namespace Manager.DataManager
{
    public class CharacterMasterDataRepository : IDisposable
    {
        private static readonly Dictionary<int, CharacterData> CharacterDatum = new();

        public void SetCharacterData(CharacterData characterData)
        {
            CharacterDatum[characterData.Id] = characterData;
        }

        public CharacterData GetCharacterData(int id)
        {
            if (!CharacterDatum.TryGetValue(id, out var value))
            {
                return null;
            }

            return id == GameCommonData.InvalidNumber ? null : value;
        }

        public IReadOnlyCollection<CharacterData> GetAllCharacterData()
        {
            return CharacterDatum.Values;
        }

        public int GetAllCharacterAmount()
        {
            return CharacterDatum.Count;
        }

        public int GetRandomCharacterId()
        {
            var keys = CharacterDatum.Keys.ToArray();
            var index = Random.Range(0, keys.Length);
            return keys[index];
        }

        public void Dispose()
        {
        }
    }
}