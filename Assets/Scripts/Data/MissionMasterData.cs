using System;

namespace Common.Data
{
    public class MissionMasterData : IDisposable
    {
        public int Index;
        public string Explanation;
        public int RewardId;
        public int RewardAmount;
        public int Action;
        public int ActionCount;

        public void Dispose()
        {
        }
    }
}