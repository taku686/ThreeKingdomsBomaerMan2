using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using UI.Title;
using Zenject;
using Random = UnityEngine.Random;

namespace Common.Data
{
    public class UserDataManager : IDisposable
    {
        private UserData userData;
        private CancellationTokenSource cancellationTokenSource;
        [Inject] private CharacterDataManager characterDataManager;
        [Inject] private CharacterLevelDataManager characterLevelDataManager;
        [Inject] private MissionDataManager missionDataManager;
        [Inject] private PlayFabUserDataManager playFabUserDataManager;

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

        public CharacterData GetEquippedCharacterData()
        {
            return characterDataManager.GetCharacterData(userData.EquippedCharacterId);
        }
        
        public int GetEquippedCharacterId()
        {
            return characterDataManager.GetCharacterData(userData.EquippedCharacterId).Id;
        }

        public CharacterLevelData GetCurrentLevelData(int characterId)
        {
            var level = userData.CharacterLevels[characterId];
            return characterLevelDataManager.GetCharacterLevelData(level);
        }

        public CharacterLevelData GetNextLevelData(int characterId)
        {
            var level = userData.CharacterLevels[characterId] + 1;
            return characterLevelDataManager.GetCharacterLevelData(level);
        }

        public bool UpgradeCharacterLevel(int characterId, int level)
        {
            if (!userData.CharacterLevels.ContainsKey(characterId))
            {
                return false;
            }

            if (userData.CharacterLevels[characterId] >= level)
            {
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
            if (!userData.MissionProgressDatum.ContainsKey(missionId))
            {
                return GameCommonData.ExceptionMissionProgress;
            }

            return userData.MissionProgressDatum[missionId];
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

            var missionDatum = missionDataManager.MissionDatum;
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
                .Select(characterDataManager.GetCharacterData)
                .ToArray();
        }

        public IReadOnlyCollection<CharacterData> GetNotAvailableCharacters()
        {
            return characterDataManager.GetAllCharacterData()
                .Where(data => !userData.Characters.Contains(data.Id))
                .ToList();
        }

        private int TranslateOrderType(CharacterSelectRepository.OrderType orderType, CharacterData data)
        {
            return orderType switch
            {
                CharacterSelectRepository.OrderType.Id => data.Id,
                CharacterSelectRepository.OrderType.Level => data.Level,
                CharacterSelectRepository.OrderType.Hp => data.Hp,
                CharacterSelectRepository.OrderType.Attack => data.Attack,
                CharacterSelectRepository.OrderType.Speed => data.Speed,
                CharacterSelectRepository.OrderType.Bomb => data.BombLimit,
                CharacterSelectRepository.OrderType.Fire => data.FireRange,
                _ => 0
            };
        }

        public void Dispose()
        {
            userData?.Dispose();
            cancellationTokenSource.Cancel();
            cancellationTokenSource?.Dispose();
            characterDataManager?.Dispose();
            characterLevelDataManager?.Dispose();
            playFabUserDataManager?.Dispose();
        }
    }
}