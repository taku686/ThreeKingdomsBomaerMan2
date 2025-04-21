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

        [Inject]
        public RewardDataUseCase
        (
            CharacterMasterDataRepository characterMasterDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository
        )
        {
            _characterMasterDataRepository = characterMasterDataRepository;
            _weaponMasterDataRepository = weaponMasterDataRepository;
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
                            1
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
                            weaponData.Rare
                        );
                        rewardDataList.Add(weaponReward);
                        break;
                    case GameCommonData.RewardType.Coin:
                        break;
                    case GameCommonData.RewardType.Gem:
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

        private Color GetRarityColor(Rarity r)
        {
            switch (r)
            {
                case Rarity.Common:
                    return new Color32(188, 188, 188, 255);
                case Rarity.Uncommon:
                    return new Color32(165, 226, 57, 255);
                case Rarity.Rare:
                    return new Color32(74, 160, 241, 255);
                case Rarity.Epic:
                    return new Color32(202, 67, 250, 255);
                case Rarity.Legendary:
                    return new Color32(255, 225, 0, 255);
                default:
                    return new Color32(188, 188, 188, 255);
            }
        }

        public void Dispose()
        {
        }


        public class RewardData : IDisposable
        {
            public int _Rarity { get; }
            public string _Name { get; }
            public Sprite _Icon { get; }
            public Color _Color { get; }

            public RewardData
            (
                Color color,
                Sprite icon,
                string name,
                int rarity
            )
            {
                _Color = color;
                _Icon = icon;
                _Name = name;
                _Rarity = rarity;
            }

            public void Dispose()
            {
            }
        }
    }
}