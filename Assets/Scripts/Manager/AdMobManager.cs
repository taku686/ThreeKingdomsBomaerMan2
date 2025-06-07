using System;
using Common.Data;
using GoogleMobileAds.Api;
using UniRx;
using UnityEngine;

namespace Manager
{
    public class AdMobManager : IDisposable
    {
        private readonly Subject<(int, GameCommonData.RewardType)> _rewardSubject = new();
        private readonly Subject<string> _errorSubject = new();
        private RewardedAd _rewardedAd;
        private const string ADUnitId = "ca-app-pub-3940256099942544/5224354917";
        private const int RewardAmount = 5;
        public IObservable<(int, GameCommonData.RewardType)> _RewardSubject => _rewardSubject;
        public IObservable<string> _ErrorSubject => _errorSubject;

        public void Initialize()
        {
            MobileAds.RaiseAdEventsOnUnityMainThread = true;
            MobileAds.Initialize(state =>
            {
                Debug.Log(state);
                LoadRewardedAd();
            });
        }

        /// <summary>
        /// Loads the rewarded ad.
        /// </summary>
        private void LoadRewardedAd()
        {
            if (_rewardedAd != null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }

            var adRequest = new AdRequest();

            RewardedAd.Load(ADUnitId, adRequest,
                (ad, error) =>
                {
                    if (error != null || ad == null)
                    {
                        _errorSubject.OnNext($"Rewarded ad failed to load with error: {error?.GetMessage()}");
                        return;
                    }

                    _rewardedAd = ad;
                    RegisterEventHandlers(_rewardedAd);
                });
        }

        public void ShowRewardedAd()
        {
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show(_ => { });
            }
        }

        private void RegisterEventHandlers(RewardedAd ad)
        {
            ad.OnAdPaid += _ => { _rewardSubject.OnNext((RewardAmount, GameCommonData.RewardType.Gem)); };
            ad.OnAdImpressionRecorded += () => { };
            ad.OnAdClicked += () => { };
            ad.OnAdFullScreenContentOpened += () => { };
            ad.OnAdFullScreenContentClosed += LoadRewardedAd;
            ad.OnAdFullScreenContentFailed += error =>
            {
                var message = $"Rewarded ad failed to open full screen content with error: {error}";
                _errorSubject.OnNext(message);
                LoadRewardedAd();
            };
        }

        public void Dispose()
        {
            if (_rewardedAd != null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }

            _rewardSubject.Dispose();
            _errorSubject.Dispose();
        }
    }
}