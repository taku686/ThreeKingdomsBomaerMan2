using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Manager.DataManager;
using Zenject;

namespace Repository
{
    public class RewardDataRepository : IDisposable
    {
        private readonly UserDataRepository _userDataRepository;
        private readonly WeaponMasterDataRepository _weaponMasterDataRepository;
        private readonly CharacterMasterDataRepository _characterMasterDataRepository;
        private readonly MissionMasterDataRepository _missionMasterDataRepository;
        private List<(int, GameCommonData.RewardType)> _rewards = new();

        [Inject]
        public RewardDataRepository
        (
            UserDataRepository userDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository,
            CharacterMasterDataRepository characterMasterDataRepository,
            MissionMasterDataRepository missionMasterDataRepository
        )
        {
            _userDataRepository = userDataRepository;
            _weaponMasterDataRepository = weaponMasterDataRepository;
            _characterMasterDataRepository = characterMasterDataRepository;
            _missionMasterDataRepository = missionMasterDataRepository;
        }

        public void SetRewardIds((int, GameCommonData.RewardType)[] rewards)
        {
            _rewards = rewards.ToList();
        }

        public IReadOnlyCollection<(int, GameCommonData.RewardType)> GetRewardIds()
        {
            return _rewards;
        }

        public (int, GameCommonData.RewardType)[] SetReward(MissionMasterData missionMasterData)
        {
            _rewards.Clear();
            var reward = new List<(int, GameCommonData.RewardType)>();
            switch ((GameCommonData.RewardType)missionMasterData.RewardId)
            {
                case GameCommonData.RewardType.Coin:
                    reward.Add((missionMasterData.RewardAmount, GameCommonData.RewardType.Coin));
                    break;
                case GameCommonData.RewardType.Gem:
                    reward.Add((missionMasterData.RewardAmount, GameCommonData.RewardType.Gem));
                    break;
                case GameCommonData.RewardType.Weapon:
                    reward.AddRange(GetRandomWeaponReward(missionMasterData.RewardAmount));
                    break;
                case GameCommonData.RewardType.Character:
                    reward.AddRange(GetRandomCharacterReward(missionMasterData.RewardAmount));
                    break;
                case GameCommonData.RewardType.Consumable:
                    reward.Add((missionMasterData.RewardAmount, GameCommonData.RewardType.Consumable));
                    break;
                case GameCommonData.RewardType.TreasureBox:
                    reward.AddRange(GetTreasureBox(missionMasterData.RewardAmount));
                    break;
            }

            _rewards = reward;
            return _rewards.ToArray();
        }

        public (int, GameCommonData.RewardType)[] SetReward(GameCommonData.RewardType rewardType, int rewardAmount)
        {
            _rewards.Clear();
            var reward = new List<(int, GameCommonData.RewardType)>();
            switch (rewardType)
            {
                case GameCommonData.RewardType.Coin:
                    reward.Add((rewardAmount, GameCommonData.RewardType.Coin));
                    break;
                case GameCommonData.RewardType.Gem:
                    reward.Add((rewardAmount, GameCommonData.RewardType.Gem));
                    break;
                case GameCommonData.RewardType.Weapon:
                    reward.AddRange(GetRandomWeaponReward(rewardAmount));
                    break;
                case GameCommonData.RewardType.Character:
                    reward.AddRange(GetRandomCharacterReward(rewardAmount));
                    break;
                case GameCommonData.RewardType.Consumable:
                    reward.Add((rewardAmount, GameCommonData.RewardType.Consumable));
                    break;
                case GameCommonData.RewardType.TreasureBox:
                    reward.AddRange(GetTreasureBox(rewardAmount));
                    break;
            }

            _rewards = reward;
            return _rewards.ToArray();
        }

        private IEnumerable<(int, GameCommonData.RewardType)> GetTreasureBox(int rewardAmount)
        {
            var result = new List<(int, GameCommonData.RewardType)>();
            const int characterRate = 5;
            const int weaponRate = 30;
            const int gemRate = 65;

            for (var i = 0; i < rewardAmount; i++)
            {
                var randomValue = UnityEngine.Random.Range(0, 100);
                if (randomValue < characterRate)
                {
                    var characterReward = GetRandomCharacterReward(1);
                    result.AddRange(characterReward);
                }
                else if (randomValue < weaponRate)
                {
                    var weaponReward = GetRandomWeaponReward(1);
                    result.AddRange(weaponReward);
                }
                else if (randomValue < gemRate)
                {
                    var gemReward = GetRandomGemReward(1);
                    result.AddRange(gemReward);
                }
                else
                {
                    var coinReward = GetRandomCoinReward(1);
                    result.AddRange(coinReward);
                }
            }

            return result;
        }

        public IReadOnlyCollection<(int, GameCommonData.RewardType)> GetRandomWeaponReward(int rewardAmount)
        {
            _rewards.Clear();
            var result = new List<(int, GameCommonData.RewardType)>();
            var weaponMasterDatum = _weaponMasterDataRepository.GetAllWeaponData().ToArray();
# if UNITY_EDITOR
            foreach (var weaponMasterData in weaponMasterDatum)
            {
                _userDataRepository.AddWeaponData(weaponMasterData.Id);
                result.Add((weaponMasterData.Id, GameCommonData.RewardType.Weapon));
            }
#else
            for (var i = 0; i < rewardAmount; i++)
            {
                var weaponId = weaponMasterDatum[UnityEngine.Random.Range(0, weaponMasterDatum.Length)].Id;
                _userDataRepository.AddWeaponData(weaponId);
                result.Add((weaponId, GameCommonData.RewardType.Weapon));
            }
#endif


            _rewards = result;
            return result;
        }

        public IReadOnlyCollection<(int, GameCommonData.RewardType)> GetRandomCharacterReward(int rewardAmount)
        {
            var result = new List<(int, GameCommonData.RewardType)>();
            var characterDatum = _characterMasterDataRepository.GetAllCharacterData().ToArray();
            for (var i = 0; i < rewardAmount; i++)
            {
                var characterId = characterDatum[UnityEngine.Random.Range(0, characterDatum.Length)].Id;
                _userDataRepository.AddCharacterData(characterId);
                result.Add((characterId, GameCommonData.RewardType.Character));
            }

            _rewards = result;
            return result;
        }

        private IReadOnlyCollection<(int, GameCommonData.RewardType)> GetRandomCoinReward(int rewardAmount)
        {
            var result = new List<(int, GameCommonData.RewardType)>();
            var missionDatum = _missionMasterDataRepository._MissionDatum.ToArray();
            var filteredMissionDatum = missionDatum.Where(missionData => missionData.RewardId == (int)GameCommonData.RewardType.Coin).ToArray();
            for (var i = 0; i < rewardAmount; i++)
            {
                var index = UnityEngine.Random.Range(0, filteredMissionDatum.Length);
                var coinAmount = filteredMissionDatum[index].RewardAmount;
                result.Add((coinAmount, GameCommonData.RewardType.Coin));
            }

            return result;
        }

        private IReadOnlyCollection<(int, GameCommonData.RewardType)> GetRandomGemReward(int rewardAmount)
        {
            var result = new List<(int, GameCommonData.RewardType)>();
            var missionDatum = _missionMasterDataRepository._MissionDatum.ToArray();
            var filteredMissionDatum = missionDatum.Where(missionData => missionData.RewardId == (int)GameCommonData.RewardType.Gem).ToArray();
            for (var i = 0; i < rewardAmount; i++)
            {
                var index = UnityEngine.Random.Range(0, filteredMissionDatum.Length);
                var gemAmount = filteredMissionDatum[index].RewardAmount;
                result.Add((gemAmount, GameCommonData.RewardType.Gem));
            }

            return result;
        }

        public void Dispose()
        {
            _rewards.Clear();
            // TODO マネージリソースをここで解放します
        }
    }
}