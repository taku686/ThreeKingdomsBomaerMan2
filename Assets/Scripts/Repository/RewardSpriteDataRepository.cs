using System;
using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
using UnityEngine;
using Zenject;

namespace Repository
{
    public class RewardSpriteDataRepository : IDisposable
    {
        private readonly ResourceManager _resourceManager;
        private readonly Dictionary<GameCommonData.RewardType, Sprite> _rewardSpriteDatum = new();

        [Inject]
        public RewardSpriteDataRepository
        (
            ResourceManager resourceManager
        )
        {
            _resourceManager = resourceManager;
        }

        public async UniTask Initialize()
        {
            foreach (var rewardType in Enum.GetValues(typeof(GameCommonData.RewardType)))
            {
                await AddRewardSpriteData((GameCommonData.RewardType)rewardType, default);
            }
        }

        private async UniTask AddRewardSpriteData(GameCommonData.RewardType rewardType, Sprite sprite)
        {
            if (_rewardSpriteDatum.ContainsKey(rewardType))
            {
                return;
            }

            sprite = await _resourceManager.LoadRewardSprite(rewardType, default);
            if (sprite == null)
            {
                return;
            }

            _rewardSpriteDatum.Add(rewardType, sprite);
        }
        
        public Sprite GetRewardSprite(GameCommonData.RewardType rewardType)
        {
            return _rewardSpriteDatum[rewardType];
        }

        public void Dispose()
        {
        }
    }
}