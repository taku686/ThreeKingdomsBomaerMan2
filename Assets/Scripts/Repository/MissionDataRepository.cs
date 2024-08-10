using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Manager.DataManager
{
    public class MissionDataRepository : IDisposable
    {
        private readonly List<MissionData> missionDatum = new();
        public List<MissionData> MissionDatum => missionDatum;

        public void AddMissionData(MissionData data)
        {
            missionDatum.Add(data);
        }

        public MissionData GetMissionData(int index)
        {
            return missionDatum.FirstOrDefault(x => x.index == index);
        }

        public void Dispose()
        {
        }
    }
}