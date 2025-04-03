using System;
using System.Collections.Generic;
using Common.Data;
using UI.Title;

namespace Repository
{
    public class RewardDataRepository : IDisposable
    {
        private (int, GameCommonData.RewardType)[] _rewards;

        public void SetRewardIds((int, GameCommonData.RewardType)[] rewards)
        {
            _rewards = rewards;
        }

        public IReadOnlyCollection<(int, GameCommonData.RewardType)> GetRewardIds()
        {
            return _rewards;
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}