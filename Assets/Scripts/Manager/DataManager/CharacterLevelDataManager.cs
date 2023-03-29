using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Manager.DataManager
{
    public class CharacterLevelDataManager : IDisposable
    {
        private readonly List<CharacterLevelData> _characterLevelMasterDatum = new();

        public CharacterLevelData GetCharacterLevelData(int level)
        {
            if (level > GameCommonData.MaxCharacterLevel)
            {
                return _characterLevelMasterDatum[GameCommonData.MaxCharacterLevel];
            }

            if (level < GameCommonData.MinCharacterLevel)
            {
                return _characterLevelMasterDatum[GameCommonData.MinCharacterLevel];
            }

            return _characterLevelMasterDatum.FirstOrDefault(x => x.Level == level);
        }

        public void SetCharacterLevelData(CharacterLevelData characterLevelData)
        {
            if (_characterLevelMasterDatum.Contains(characterLevelData))
            {
                return;
            }

            _characterLevelMasterDatum.Add(characterLevelData);
        }

        public void Dispose()
        {
        }
    }
}