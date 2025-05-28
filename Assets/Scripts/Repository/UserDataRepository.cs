using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using Newtonsoft.Json;
using Repository;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Common.Data
{
    public class UserDataRepository : IDisposable
    {
        private Sprite _userIconSprite;
        private UserData _userData;
        private CancellationTokenSource _cancellationTokenSource;
        private int _candidateTeamMemberIndex = GameCommonData.InvalidNumber;
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private LevelMasterDataRepository _levelMasterDataRepository;
        [Inject] private MissionMasterDataRepository _missionMasterDataRepository;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;

        public void Initialize(UserData data, string userName, Sprite userIcon)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            SetUserData(data);
            _userData.Name = userName;
            _userIconSprite = userIcon;
        }

        public Sprite GetUserIconSprite()
        {
            return _userIconSprite;
        }

        public UserData GetUserData()
        {
            return _userData;
        }

        public void SetUserData(UserData data)
        {
            _userData = data;
        }

        public async UniTask UpdateUserData(UserData data = null)
        {
            if (data != null)
            {
                _userData = data;
            }

            await _playFabUserDataManager.TryUpdateUserDataAsync(_userData);
        }

        public async UniTask<bool> SetLoginBonus(int index, LoginBonusStatus status)
        {
            if (!_userData.LoginBonus.ContainsKey(index))
            {
                return false;
            }

            var data = GetUserData();
            data.LoginBonus[index] = (int)status;
            SetUserData(data);
            var result = await _playFabUserDataManager.TryUpdateUserDataAsync(data).AttachExternalCancellation(_cancellationTokenSource.Token);
            return result;
        }

        public async UniTask<bool> ResetLoginBonus()
        {
            var data = GetUserData();
            for (var i = 0; i < _userData.LoginBonus.Count; i++)
            {
                _userData.LoginBonus[i] = (int)LoginBonusStatus.Disable;
            }

            SetUserData(data);
            var result = await _playFabUserDataManager.TryUpdateUserDataAsync(data)
                .AttachExternalCancellation(_cancellationTokenSource.Token);
            return result;
        }

        public LoginBonusStatus GetLoginBonusStatus(int index)
        {
            var status = _userData.LoginBonus[index];
            return GameCommonData.GetLoginBonusStatus(status);
        }

        public LevelMasterData GetCurrentLevelData(int characterId)
        {
            var level = _userData.CharacterLevels[characterId];
            return _levelMasterDataRepository.GetLevelMasterData(level);
        }

        public LevelMasterData GetNextLevelData(int characterId)
        {
            var level = _userData.CharacterLevels[characterId] + 1;
            return _levelMasterDataRepository.GetLevelMasterData(level);
        }

        public bool UpgradeCharacterLevel(int characterId, int level)
        {
            if (!_userData.CharacterLevels.TryGetValue(characterId, out var characterLevel))
            {
                Debug.LogError("characterId is not found.");
                return false;
            }

            if (characterLevel >= level)
            {
                Debug.LogError("level is not enough.");
                return false;
            }

            _userData.CharacterLevels[characterId] = level;
            return true;
        }

        private void SetMissionData(KeyValuePair<int, UserData.MissionData> mission, int progress)
        {
            var index = mission.Key;
            var masterData = _missionMasterDataRepository.GetMissionData(index);
            if (_userData.MissionDatum.ContainsKey(index))
            {
                return;
            }

            if (progress >= masterData.ActionCount)
            {
                progress = masterData.ActionCount;
            }

            mission.Value._progress = progress;
            var json = JsonConvert.SerializeObject(mission.Value);
            _userData.MissionDatum[index] = json;
        }

        public Dictionary<int, UserData.MissionData> GetMissionDatum()
        {
            var result = new Dictionary<int, UserData.MissionData>();
            foreach (var mission in _userData.MissionDatum)
            {
                var missionData = JsonConvert.DeserializeObject<UserData.MissionData>(mission.Value);
                result.Add(mission.Key, missionData);
            }

            return result;
        }

        public bool HaveClearMission()
        {
            var missionDatum = _userData.MissionDatum;
            foreach (var missionData in missionDatum)
            {
                var masterData = _missionMasterDataRepository.GetMissionData(missionData.Key);
                var progress = GetMissionProgress(missionData.Key);
                if (progress >= masterData.ActionCount)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetMissionProgress(int missionId)
        {
            if (!_userData.MissionDatum.TryGetValue(missionId, out var value))
            {
                return -1;
            }

            var missionData = JsonConvert.DeserializeObject<UserData.MissionData>(value);
            return missionData._progress;
        }

        public void SetMissionProgress(int missionId, int missionProgress)
        {
            if (!_userData.MissionDatum.TryGetValue(missionId, out var value))
            {
                return;
            }

            var missionData = JsonConvert.DeserializeObject<UserData.MissionData>(value);
            missionData._progress = missionProgress;
            var json = JsonConvert.SerializeObject(missionData);
            _userData.MissionDatum[missionId] = json;
        }

        public async UniTask AddMissionData()
        {
            if (_userData == null)
            {
                return;
            }

            var missionDatum = _userData.MissionDatum ?? new Dictionary<int, string>();
            var masterDatum = _missionMasterDataRepository._MissionDatum;
            if (missionDatum.Count >= GameCommonData.MaxMissionCount)
            {
                return;
            }

            while (missionDatum.Count < GameCommonData.MaxMissionCount)
            {
                var index = Random.Range(0, masterDatum.Count);
                var masterData = masterDatum[index];
                var missionIndex = masterData.Index;
                var actionId = masterData.Action;
                var missionData = _userData.CreateMissionData();

                if (_userData.MissionDatum.ContainsKey(missionIndex))
                {
                    continue;
                }

                if (GameCommonData.IsMissionsUsingCharacter(actionId))
                {
                    var characterId = _characterMasterDataRepository.GetRandomCharacterId();
                    missionData._characterId = characterId;
                }

                if (GameCommonData.IsMissionsUsingWeapon(actionId))
                {
                    var weaponId = _weaponMasterDataRepository.GetRandomWeaponId();
                    missionData._weaponId = weaponId;
                }

                var keyValuePair = new KeyValuePair<int, UserData.MissionData>(missionIndex, missionData);
                SetMissionData(keyValuePair, 0);
                var json = JsonConvert.SerializeObject(missionData);
                _userData.MissionDatum[missionIndex] = json;
            }

            await _playFabUserDataManager.TryUpdateUserDataAsync(_userData);
        }

        public async UniTask RemoveMissionData(int missionId)
        {
            if (!_userData.MissionDatum.ContainsKey(missionId))
            {
                return;
            }

            _userData.MissionDatum.Remove(missionId);
            await _playFabUserDataManager.TryUpdateUserDataAsync(_userData);
        }

        public UserData AddCharacterData(int characterId)
        {
            if (_userData.Characters.Contains(characterId))
            {
                return _userData;
            }

            var data = GetUserData();
            data.Characters.Add(characterId);
            data.CharacterLevels[characterId] = 1;
            data.EquippedWeapons[characterId] = GameCommonData.DefaultWeaponId;
            SetUserData(data);
            return _userData;
        }

        public int GetAvailableCharacterAmount()
        {
            return _userData.Characters.Count;
        }

        public IReadOnlyCollection<CharacterData> GetAvailableCharacters()
        {
            return _userData.Characters
                .Select(_characterMasterDataRepository.GetCharacterData)
                .ToArray();
        }

        public IReadOnlyCollection<CharacterData> GetNotAvailableCharacters()
        {
            return _characterMasterDataRepository.GetAllCharacterData()
                .Where(data => !_userData.Characters.Contains(data.Id))
                .ToArray();
        }

        public IReadOnlyDictionary<WeaponMasterData, int> GetAllPossessedWeaponDatum()
        {
            return _userData.PossessedWeapons
                .ToDictionary(keyValue => _weaponMasterDataRepository.GetWeaponData(keyValue.Key),
                    keyValue => keyValue.Value);
        }

        public async UniTask SetEquippedWeapon(int selectedCharacterId, int weaponId)
        {
            var data = GetUserData();
            data.EquippedWeapons[selectedCharacterId] = weaponId;

            SetUserData(data);
            await _playFabUserDataManager.TryUpdateUserDataAsync(data);
        }

        public int GetEquippedWeaponId(int selectedCharacterId)
        {
            return _userData.EquippedWeapons[selectedCharacterId];
        }

        public WeaponMasterData GetEquippedWeaponData(int selectedCharacterId)
        {
            var weaponId = GetEquippedWeaponId(selectedCharacterId);
            return _weaponMasterDataRepository.GetWeaponData(weaponId);
        }

        public void AddWeaponData(int weaponId)
        {
            if (!_userData.PossessedWeapons.TryAdd(weaponId, 1))
            {
                _userData.PossessedWeapons[weaponId]++;
            }
        }

        public void RemoveWeaponData(int weaponId, int amount)
        {
            if (!_userData.PossessedWeapons.ContainsKey(weaponId))
            {
                return;
            }


            _userData.PossessedWeapons[weaponId] -= amount;
            if (_userData.PossessedWeapons[weaponId] <= 0)
            {
                _userData.PossessedWeapons.Remove(weaponId);
            }
        }

        public void SetCoin(int coin)
        {
            _userData.Coin = coin;
        }

        public void SetGem(int gem)
        {
            _userData.Gem = gem;
        }

        public IReadOnlyDictionary<int, int> GetTeamMembers()
        {
            return _userData.TeamMembers;
        }

        public int GetTeamMember(int index)
        {
            return _userData.TeamMembers.GetValueOrDefault(index, GameCommonData.InvalidNumber);
        }

        public void SetTeamMember(int characterId)
        {
            if (_userData.TeamMembers.ContainsValue(characterId))
            {
                return;
            }

            _userData.TeamMembers[_candidateTeamMemberIndex] = characterId;
        }

        public void SetCandidateTeamMemberIndex(int index)
        {
            _candidateTeamMemberIndex = index;
        }

        public void Dispose()
        {
            _userData?.Dispose();
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource?.Dispose();
            _characterMasterDataRepository?.Dispose();
            _levelMasterDataRepository?.Dispose();
            _playFabUserDataManager?.Dispose();
        }
    }
}