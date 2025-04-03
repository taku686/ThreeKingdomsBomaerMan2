using System;
using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
using UnityEngine;
using Zenject;

namespace Repository
{
    public class MissionSpriteDataRepository : IDisposable
    {
        private readonly ResourceManager _resourceManager;
        private readonly Dictionary<GameCommonData.RewardType, Sprite> _rewardSpriteDatum = new();
        private readonly Dictionary<GameCommonData.MissionActionId, Sprite> _actionSpriteDatum = new();

        [Inject]
        public MissionSpriteDataRepository
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

            foreach (var missionId in Enum.GetValues(typeof(GameCommonData.MissionActionId)))
            {
                await AddMissionActionSpriteData((GameCommonData.MissionActionId)missionId, default);
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

        private async UniTask AddMissionActionSpriteData(GameCommonData.MissionActionId actionId, Sprite sprite)
        {
            if (_actionSpriteDatum.ContainsKey(actionId))
            {
                return;
            }

            sprite = await _resourceManager.LoadMissionActionSprite(actionId, default);
            if (sprite == null)
            {
                return;
            }

            _actionSpriteDatum.Add(actionId, sprite);
        }

        public Sprite GetRewardSprite(GameCommonData.RewardType rewardType)
        {
            return _rewardSpriteDatum[rewardType];
        }

        public Sprite GetActionSprite(GameCommonData.MissionActionId actionId)
        {
            return _actionSpriteDatum[actionId];
        }

        public void Dispose()
        {
        }
    }
}