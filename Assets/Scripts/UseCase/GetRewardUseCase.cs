using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Zenject;

namespace UseCase
{
    public class GetRewardUseCase : IDisposable
    {
        private readonly PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
        private readonly UserDataRepository _userDataRepository;

        [Inject]
        public GetRewardUseCase
        (
            PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager,
            UserDataRepository userDataRepository
        )
        {
            _playFabVirtualCurrencyManager = playFabVirtualCurrencyManager;
            _userDataRepository = userDataRepository;
        }

        public async UniTask InAsTask((int, GameCommonData.RewardType)[] rewardResults, int cost = 0, string key = "")
        {
            var totalCoinAmount = 0;
            var totalGemAmount = 0;
            foreach (var (rewardAmount, rewardType) in rewardResults)
            {
                if (rewardType == GameCommonData.RewardType.Coin)
                {
                    totalCoinAmount += rewardAmount;
                }
                else if (rewardType == GameCommonData.RewardType.Gem)
                {
                    totalGemAmount += rewardAmount;
                }
            }

            if (cost > 0 && !string.IsNullOrEmpty(key))
            {
                if (key == GameCommonData.CoinKey)
                {
                    await _playFabVirtualCurrencyManager.SubtractVirtualCurrency(GameCommonData.CoinKey, cost);
                }
                else if (key == GameCommonData.GemKey)
                {
                    await _playFabVirtualCurrencyManager.SubtractVirtualCurrency(GameCommonData.GemKey, cost);
                }
            }

            await _playFabVirtualCurrencyManager.AddVirtualCurrency(GameCommonData.CoinKey, totalCoinAmount);
            await _playFabVirtualCurrencyManager.AddVirtualCurrency(GameCommonData.GemKey, totalGemAmount);
            await _userDataRepository.UpdateUserData();
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}