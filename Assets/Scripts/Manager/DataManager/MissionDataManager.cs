using System.Collections.Generic;
using System.Linq;
using Common.Data;
using UnityEngine;

namespace Manager.DataManager
{
    public class MissionDataManager : MonoBehaviour
    {
        private readonly List<MissionData> _missionDatum = new();

        public void AddMissionData(MissionData data)
        {
            _missionDatum.Add(data);
        }

        public MissionData GetMissionData(int index)
        {
            return _missionDatum.FirstOrDefault(x => x.index == index);
        }
    }
}