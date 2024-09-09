using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Manager.DataManager
{
    public class LevelMasterDataRepository : IDisposable
    {
        private readonly List<LevelMasterData> levelMasterDatum = new();

        public LevelMasterData GetLevelMasterData(int level)
        {
            return level switch
            {
                > GameCommonData.MaxCharacterLevel => levelMasterDatum[GameCommonData.MaxCharacterLevel],
                < GameCommonData.MinCharacterLevel => levelMasterDatum[GameCommonData.MinCharacterLevel],
                _ => levelMasterDatum.FirstOrDefault(x => x.Level == level)
            };
        }

        public void SetCharacterLevelData(LevelMasterData levelMasterData)
        {
            if (levelMasterDatum.Contains(levelMasterData))
            {
                return;
            }

            levelMasterDatum.Add(levelMasterData);
        }

        public void Dispose()
        {
        }
    }
}