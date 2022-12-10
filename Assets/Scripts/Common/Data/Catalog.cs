using System;
using System.Collections.Generic;
using Common.Data;
using PlayFab.ClientModels;

namespace Assets.Scripts.Common.Data
{
    public class Catalog : IDisposable
    {
        private readonly Dictionary<int, CharacterData> _characters = new Dictionary<int, CharacterData>();
        public Dictionary<int, CharacterData> Characters => _characters;

        public void SetCharacter(int index, CharacterData data)
        {
            _characters[index] = data;
        }

        public CharacterData GetCharacterData(int index)
        {
            return _characters[index];
        }

        public void Dispose()
        {
            _characters.Clear();
        }
    }
}