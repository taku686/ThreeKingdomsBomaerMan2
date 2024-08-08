using System;

namespace Common.Data
{
    public class MissionData : IDisposable
    {
        public int index;
        public string rewardId;
        public string explanation;
        public int count;
        public int action;
        public int characterId;

        public void Dispose()
        {
        }
    }
}