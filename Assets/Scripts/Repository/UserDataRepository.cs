using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using Repository;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Common.Data
{
    public class UserDataRepository : IDisposable
    {
        private UserData _userData;
        private CancellationTokenSource _cancellationTokenSource;
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private LevelMasterDataRepository _levelMasterDataRepository;
        [Inject] private MissionDataRepository _missionDataRepository;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;

        public async UniTask Initialize(UserData data)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            SetUserData(data);
            await AddMissionData();
        }

        public UserData GetUserData()
        {
            return _userData;
        }

        public void SetUserData(UserData data)
        {
            _userData = data;
        }

        public async UniTask UpdateUserData(UserData data)
        {
            _userData = data;
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

        public int GetEquippedCharacterId()
        {
            return _characterMasterDataRepository.GetCharacterData(_userData.EquippedCharacterId).Id;
        }

        public CharacterData GetEquippedCharacterData()
        {
            return _characterMasterDataRepository.GetCharacterData(_userData.EquippedCharacterId);
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

        private void SetMissionData(int index, int progress)
        {
            if (_userData.MissionProgressDatum.ContainsKey(index))
            {
                return;
            }

            if (progress >= GameCommonData.MaxMissionProgress)
            {
                progress = GameCommonData.MaxMissionProgress;
            }

            _userData.MissionProgressDatum[index] = progress;
        }

        public Dictionary<int, int> GetMissionProgressDatum()
        {
            return _userData.MissionProgressDatum;
        }

        public int GetMissionProgress(int missionId)
        {
            return _userData.MissionProgressDatum.GetValueOrDefault(missionId, GameCommonData.ExceptionMissionProgress);
        }

        public void SetMissionProgress(int missionId, int missionProgress)
        {
            if (!_userData.MissionProgressDatum.ContainsKey(missionId))
            {
                return;
            }

            _userData.MissionProgressDatum[missionId] = missionProgress;
        }

        public async UniTask AddMissionData()
        {
            if (_userData.MissionProgressDatum.Count >= GameCommonData.MaxMissionCount)
            {
                return;
            }

            var missionDatum = _missionDataRepository.MissionDatum;
            while (_userData.MissionProgressDatum.Count < GameCommonData.MaxMissionCount)
            {
                var index = Random.Range(0, missionDatum.Count);
                var missionIndex = missionDatum[index].index;
                SetMissionData(missionIndex, 0);
            }

            await _playFabUserDataManager.TryUpdateUserDataAsync(_userData);
        }

        public async UniTask RemoveMissionData(int missionId)
        {
            if (!_userData.MissionProgressDatum.ContainsKey(missionId))
            {
                return;
            }

            _userData.MissionProgressDatum.Remove(missionId);
            await _playFabUserDataManager.TryUpdateUserDataAsync(_userData);
        }

        public async UniTask<bool> AddCharacterData(int characterId)
        {
            if (_userData.Characters.Contains(characterId))
            {
                return false;
            }

            var data = GetUserData();
            data.Characters.Add(characterId);
            data.CharacterLevels[characterId] = 1;
            data.EquippedWeapons[characterId] = GameCommonData.DefaultWeaponId;
            SetUserData(data);
            var result = await _playFabUserDataManager.TryUpdateUserDataAsync(data);
            return result;
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

        public void SubtractWeaponData(int weaponId, int amount)
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