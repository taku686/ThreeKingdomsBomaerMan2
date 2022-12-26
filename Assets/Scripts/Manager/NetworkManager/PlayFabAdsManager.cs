using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using GoogleMobileAds.Api;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Manager.NetworkManager
{
    public class PlayFabAdsManager : IDisposable
    {
        private string _placementId;
        private string _rewardId;
        private int? _placementViewsRemaining;
        private double? _placementViewsRestMinutes;


        public async UniTask GetAdPlacementAsync(CancellationToken token, RewardedAd rewardedAd)
        {
            rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            var request = new GetAdPlacementsRequest { AppId = GameSettingData.GameID };
            var result = await PlayFabClientAPI.GetAdPlacementsAsync(request);

            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
            }
            else
            {
                var placement = result.Result.AdPlacements.Find(x => x.PlacementName == GameSettingData.PlacementName);
                _placementId = placement.PlacementId;
                _rewardId = placement.RewardId;
                _placementViewsRemaining = placement.PlacementViewsRemaining;
                _placementViewsRestMinutes = placement.PlacementViewsResetMinutes;
            }
        }

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
                    Debug.Log("ジェムを5個獲得");
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