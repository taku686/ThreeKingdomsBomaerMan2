using System;
using System.Collections.Generic;
using UI.Title;

namespace Repository
{
    public class RewardDataRepository : IDisposable
    {
        private (int, RewardDataUseCase.RewardData.RewardType)[] _rewards;

        public void SetRewardIds((int, RewardDataUseCase.RewardData.RewardType)[] rewards)
        {
            _rewards = rewards;
        }

        public IReadOnlyCollection<(int, RewardDataUseCase.RewardData.RewardType)> GetRewardIds()
        {
            return _rewards;
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}