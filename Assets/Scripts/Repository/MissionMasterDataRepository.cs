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
            var ids = _MissionDatum.Select(data => data.Index).ToArray();
            if (ids.Contains(masterData.Index))
            {
                return; // Mission data already exists
            }

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