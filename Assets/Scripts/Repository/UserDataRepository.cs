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
        private UserData userData;
        private CancellationTokenSource cancellationTokenSource;
        [Inject] private CharacterMasterDataRepository characterMasterDataRepository;
        [Inject] private CharacterLevelMasterDataRepository characterLevelMasterDataRepository;
        [Inject] private MissionDataRepository missionDataRepository;
        [Inject] private PlayFabUserDataManager playFabUserDataManager;
        [Inject] private WeaponMasterDataRepository weaponMasterDataRepository;

        public async UniTask Initialize(UserData data)
        {
            cancellationTokenSource = new CancellationTokenSource();
            SetUserData(data);
            await AddMissionData();
        }

        public UserData GetUserData()
        {
            return userData;
        }

        public void SetUserData(UserData data)
        {
            userData = data;
        }

        public async UniTask UpdateUserData(UserData data)
        {
            userData = data;
            await playFabUserDataManager.TryUpdateUserDataAsync(userData);
        }

        public async UniTask<bool> SetLoginBonus(int index, LoginBonusStatus status)
        {
            if (!userData.LoginBonus.ContainsKey(index))
            {
                return false;
            }

            var data = GetUserData();
            data.LoginBonus[index] = (int)status;
            SetUserData(data);
            var result = await playFabUserDataManager.TryUpdateUserDataAsync(data)
                .AttachExternalCancellation(cancellationTokenSource.Token);
            return result;
        }

        public async UniTask<bool> ResetLoginBonus()
        {
            var data = GetUserData();
            for (var i = 0; i < userData.LoginBonus.Count; i++)
            {
                userData.LoginBonus[i] = (int)LoginBonusStatus.Disable;
            }

            SetUserData(data);
            var result = await playFabUserDataManager.TryUpdateUserDataAsync(data)
                .AttachExternalCancellation(cancellationTokenSource.Token);
            return result;
        }

        public LoginBonusStatus GetLoginBonusStatus(int index)
        {
            var status = userData.LoginBonus[index];
            return GameCommonData.GetLoginBonusStatus(status);
        }

        public int GetEquippedCharacterId()
        {
            return characterMasterDataRepository.GetCharacterData(userData.EquippedCharacterId).Id;
        }

        public CharacterLevelData GetCurrentLevelData(int characterId)
        {
            var level = userData.CharacterLevels[characterId];
            return characterLevelMasterDataRepository.GetCharacterLevelData(level);
        }

        public CharacterLevelData GetNextLevelData(int characterId)
        {
            var level = userData.CharacterLevels[characterId] + 1;
            return characterLevelMasterDataRepository.GetCharacterLevelData(level);
        }

        public bool UpgradeCharacterLevel(int characterId, int level)
        {
            if (!userData.CharacterLevels.TryGetValue(characterId, out var characterLevel))
            {
                Debug.LogError("characterId is not found.");
                return false;
            }

            if (characterLevel >= level)
            {
                Debug.LogError("level is not enough.");
                return false;
            }

            userData.CharacterLevels[characterId] = level;
            return true;
        }

        private void SetMissionData(int index, int progress)
        {
            if (userData.MissionProgressDatum.ContainsKey(index))
            {
                return;
            }

            if (progress >= GameCommonData.MaxMissionProgress)
            {
                progress = GameCommonData.MaxMissionProgress;
            }

            userData.MissionProgressDatum[index] = progress;
        }

        public Dictionary<int, int> GetMissionProgressDatum()
        {
            return userData.MissionProgressDatum;
        }

        public int GetMissionProgress(int missionId)
        {
            return userData.MissionProgressDatum.GetValueOrDefault(missionId, GameCommonData.ExceptionMissionProgress);
        }

        public void SetMissionProgress(int missionId, int missionProgress)
        {
            if (!userData.MissionProgressDatum.ContainsKey(missionId))
            {
                return;
            }

            userData.MissionProgressDatum[missionId] = missionProgress;
        }

        public async UniTask AddMissionData()
        {
            if (userData.MissionProgressDatum.Count >= GameCommonData.MaxMissionCount)
            {
                return;
            }

            var missionDatum = missionDataRepository.MissionDatum;
            while (userData.MissionProgressDatum.Count < GameCommonData.MaxMissionCount)
            {
                var index = Random.Range(0, missionDatum.Count);
                var missionIndex = missionDatum[index].index;
                SetMissionData(missionIndex, 0);
            }

            await playFabUserDataManager.TryUpdateUserDataAsync(userData);
        }

        public async UniTask RemoveMissionData(int missionId)
        {
            if (!userData.MissionProgressDatum.ContainsKey(missionId))
            {
                return;
            }

            userData.MissionProgressDatum.Remove(missionId);
            await playFabUserDataManager.TryUpdateUserDataAsync(userData);
        }

        public async UniTask<bool> AddCharacterData(int characterId)
        {
            if (userData.Characters.Contains(characterId))
            {
                return false;
            }

            var data = GetUserData();
            data.Characters.Add(characterId);
            data.CharacterLevels[characterId] = 0;
            SetUserData(data);
            var result = await playFabUserDataManager.TryUpdateUserDataAsync(data)
                .AttachExternalCancellation(cancellationTokenSource.Token);
            return result;
        }

        public int GetAvailableCharacterAmount()
        {
            return userData.Characters.Count;
        }

        public IReadOnlyCollection<CharacterData> GetAvailableCharacters()
        {
            return userData.Characters
                .Select(characterMasterDataRepository.GetCharacterData)
                .ToArray();
        }

        public IReadOnlyCollection<CharacterData> GetNotAvailableCharacters()
        {
            return characterMasterDataRepository.GetAllCharacterData()
                .Where(data => !userData.Characters.Contains(data.Id))
                .ToArray();
        }

        public IReadOnlyDictionary<WeaponMasterData, int> GetAllPossessedWeaponDatum()
        {
            return userData.PossessedWeapons
                .ToDictionary(keyValue => weaponMasterDataRepository.GetWeaponData(keyValue.Key),
                    keyValue => keyValue.Value);
        }

        public async UniTask SetEquippedWeapon(int selectedCharacterId, int weaponId)
        {
            var data = GetUserData();
            data.EquippedWeapons[selectedCharacterId] = weaponId;
            SetUserData(data);
            await playFabUserDataManager.TryUpdateUserDataAsync(data);
        }

        //todo 後で消す
        public async UniTask DebugSetWeapon()
        {
            var data = GetUserData();
            foreach (var characterId in data.Characters)
            {
                data.EquippedWeapons[characterId] = 0;
            }

            foreach (var weaponData in weaponMasterDataRepository.GetAllWeaponData())
            {
                data.PossessedWeapons[weaponData.Id] = 1;
            }

            SetUserData(data);
            await playFabUserDataManager.TryUpdateUserDataAsync(data);
        }

        public int GetEquippedWeaponId(int selectedCharacterId)
        {
            return userData.EquippedWeapons.GetValueOrDefault(selectedCharacterId, 0);
        }

        public WeaponMasterData GetEquippedWeaponData(int selectedCharacterId)
        {
            var weaponId = GetEquippedWeaponId(selectedCharacterId);
            return weaponMasterDataRepository.GetWeaponData(weaponId);
        }

        public void Dispose()
        {
            userData?.Dispose();
            cancellationTokenSource.Cancel();
            cancellationTokenSource?.Dispose();
            characterMasterDataRepository?.Dispose();
            characterLevelMasterDataRepository?.Dispose();
            playFabUserDataManager?.Dispose();
        }
    }
}