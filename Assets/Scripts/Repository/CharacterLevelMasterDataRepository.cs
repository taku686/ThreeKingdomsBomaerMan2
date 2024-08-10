using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Manager.DataManager
{
    public class CharacterLevelMasterDataRepository : IDisposable
    {
        private readonly List<CharacterLevelData> characterLevelMasterDatum = new();

        public CharacterLevelData GetCharacterLevelData(int level)
        {
            return level switch
            {
                > GameCommonData.MaxCharacterLevel => characterLevelMasterDatum[GameCommonData.MaxCharacterLevel],
                < GameCommonData.MinCharacterLevel => characterLevelMasterDatum[GameCommonData.MinCharacterLevel],
                _ => characterLevelMasterDatum.FirstOrDefault(x => x.Level == level)
            };
        }

        public void SetCharacterLevelData(CharacterLevelData characterLevelData)
        {
            if (characterLevelMasterDatum.Contains(characterLevelData))
            {
                return;
            }

            characterLevelMasterDatum.Add(characterLevelData);
        }

        public void Dispose()
        {
        }
    }
}