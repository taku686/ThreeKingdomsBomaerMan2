using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Manager.DataManager
{
    public class MissionMasterDataRepository : IDisposable
    {
        public List<MissionMasterData> _MissionDatum { get; } = new();

        public void AddMissionData(MissionMasterData masterData)
        {
            _MissionDatum.Add(masterData);
        }

        public MissionMasterData GetMissionData(int index)
        {
            return _MissionDatum.FirstOrDefault(x => x.Index == index);
        }

        public void Dispose()
        {
        }
    }
}