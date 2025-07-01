using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Manager.DataManager
{
    public class LevelMasterDataRepository : IDisposable
    {
        private readonly List<LevelMasterData> _levelMasterDatum = new();

        public LevelMasterData GetLevelMasterData(int level)
        {
            return level switch
            {
                > GameCommonData.MaxCharacterLevel => _levelMasterDatum[GameCommonData.MaxCharacterLevel - 1],
                < GameCommonData.MinCharacterLevel => _levelMasterDatum[0],
                _ => _levelMasterDatum.FirstOrDefault(x => x.Level == level)
            };
        }

        public void SetCharacterLevelData(LevelMasterData levelMasterData)
        {
            var ids = _levelMasterDatum.Select(data => data.Level).ToArray();
            if (ids.Contains(levelMasterData.Level))
            {
                return;
            }

            _levelMasterDatum.Add(levelMasterData);
        }

        public void Dispose()
        {
        }
    }
}