using System;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
using PUROPORO;
using Repository;
using UnityEngine;
using Zenject;

namespace UI.Title
{
    public class RewardDataUseCase : IDisposable
    {
        private readonly CharacterMasterDataRepository _characterMasterDataRepository;
        private readonly WeaponMasterDataRepository _weaponMasterDataRepository;
        private readonly MissionSpriteDataRepository _missionSpriteDataRepository;

        [Inject]
        public RewardDataUseCase
        (
            CharacterMasterDataRepository characterMasterDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository,
            MissionSpriteDataRepository missionSpriteDataRepository
        )
        {
            _characterMasterDataRepository = characterMasterDataRepository;
            _weaponMasterDataRepository = weaponMasterDataRepository;
            _missionSpriteDataRepository = missionSpriteDataRepository;
        }

        public IReadOnlyCollection<RewardData> InAsTask((int, GameCommonData.RewardType)[] rewards)
        {
            var rewardDataList = new List<RewardData>();
            foreach (var (rewardId, rewardType) in rewards)
            {
                switch (rewardType)
                {
                    case GameCommonData.RewardType.Character:
                        var characterData = _characterMasterDataRepository.GetCharacterData(rewardId);
                        var characterReward = new RewardData
                        (
                            Color.white,
                            characterData.SelfPortraitSprite,
                            characterData.Name,
                            characterData.Rarity,
                            GameCommonData.RewardType.Character
                        );
                        rewardDataList.Add(characterReward);
                        break;
                    case GameCommonData.RewardType.Weapon:
                        var weaponData = _weaponMasterDataRepository.GetWeaponData(rewardId);
                        var weaponReward = new RewardData
                        (
                            Color.white,
                            weaponData.WeaponIcon,
                            weaponData.Name,
                            weaponData.Rare,
                            GameCommonData.RewardType.Weapon
                        );
                        rewardDataList.Add(weaponReward);
                        break;
                    case GameCommonData.RewardType.Coin:
                        var coinReward = new RewardData
                        (
                            Color.white,
                            _missionSpriteDataRepository.GetRewardSprite(GameCommonData.RewardType.Coin),
                            rewardId.ToString(),
                            1,
                            GameCommonData.RewardType.Coin
                        );
                        rewardDataList.Add(coinReward);
                        break;
                    case GameCommonData.RewardType.Gem:
                        var gemReward = new RewardData
                        (
                            Color.white,
                            _missionSpriteDataRepository.GetRewardSprite(GameCommonData.RewardType.Coin),
                            rewardId.ToString(),
                            1,
                            GameCommonData.RewardType.Gem
                        );
                        rewardDataList.Add(gemReward);
                        break;
                    case GameCommonData.RewardType.Consumable:
                        break;
                    case GameCommonData.RewardType.TreasureBox:
                        break;
                    case GameCommonData.RewardType.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return rewardDataList;
        }


        public void Dispose()
        {
            _characterMasterDataRepository?.Dispose();
            _weaponMasterDataRepository?.Dispose();
            _missionSpriteDataRepository?.Dispose();
        }


        public class RewardData : IDisposable
        {
            public int _Rarity { get; }
            public GameCommonData.RewardType _RewardType { get; }
            public string _Name { get; }
            public Sprite _Icon { get; }
            public Color _Color { get; }

            public RewardData
            (
                Color color,
                Sprite icon,
                string name,
                int rarity,
                GameCommonData.RewardType rewardType
            )
            {
                _Color = color;
                _Icon = icon;
                _Name = name;
                _Rarity = rarity;
                _RewardType = rewardType;
            }

            public void Dispose()
            {
            }
        }
    }
}