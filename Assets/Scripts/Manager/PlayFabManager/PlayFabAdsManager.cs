using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using GoogleMobileAds.Api;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PlayFabAdsManager : IDisposable
    {
        private string _placementId;
        private string _rewardId;
        private int? _placementViewsRemaining;
        private double? _placementViewsRestMinutes;
        [Inject] private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
        private RewardedAd _rewardAd;
        private bool _isProcessing;

        private async UniTask ReportAdActivityAsync(AdActivity activity)
        {
            var request = new ReportAdActivityRequest
            {
                PlacementId = _placementId,
                RewardId = _rewardId,
                Activity = activity
            };

            var result = await PlayFabClientAPI.ReportAdActivityAsync(request);
            if (result.Error != null)
            {
                if (result.Error.Error == PlayFabErrorCode.AllAdPlacementViewsAlreadyConsumed)
                {
                    Debug.Log("You have exceeded the viewing limit for video ads.");
                }

                Debug.Log(result.Error.GenerateErrorReport());
            }
            else
            {
                if (activity == AdActivity.End)
                {
                    var rewardRequest = new RewardAdActivityRequest
                    {
                        PlacementId = _placementId,
                        RewardId = _rewardId
                    };
                    var rewardResult = await PlayFabClientAPI.RewardAdActivityAsync(rewardRequest);
                    if (rewardResult.Error != null)
                    {
                        Debug.Log(rewardResult.Error.GenerateErrorReport());
                        return;
                    }

                    _isProcessing = false;
                    await _playFabVirtualCurrencyManager.SetVirtualCurrency();
                }
            }
        }

        public void Dispose()
        {
        }

        private async void HandleUserEarnedReward(object sender, Reward args)
        {
            await ReportAdActivityAsync(AdActivity.End);
        }
    }
}