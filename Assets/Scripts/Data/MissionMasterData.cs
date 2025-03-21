using System;

namespace Common.Data
{
    public class MissionMasterData : IDisposable
    {
        public int Index;
        public string Explanation;
        public string RewardId;
        public string RewardAmount;
        public int Action;
        public int ActionCount;
        public int CharacterId;
        public int WeaponId;

        public void Dispose()
        {
        }
    }
}