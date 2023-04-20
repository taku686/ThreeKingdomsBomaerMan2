using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using Zenject;
using Random = UnityEngine.Random;

namespace Common.Data
{
    public class UserDataManager : IDisposable
    {
        private UserData _userData;
        private CancellationTokenSource _cancellationTokenSource;
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private CharacterLevelDataManager _characterLevelDataManager;
        [Inject] private MissionDataManager _missionDataManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;

        public async UniTask Initialize(UserData userData)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            SetUserData(userData);
            await AddMissionData();
        }

        public UserData GetUserData()
        {
            return _userData;
        }

        public void SetUserData(UserData userData)
        {
            _userData = userData;
        }

        public async UniTask UpdateUserData(UserData userData)
        {
            _userData = userData;
            await _playFabUserDataManager.TryUpdateUserDataAsync(_userData);
        }

        public async UniTask<bool> AddCharacterData(int characterId)
        {
            if (_userData.Characters.Contains(characterId))
            {
                return false;
            }

            var userData = GetUserData();
            userData.Characters.Add(characterId);
            userData.CharacterLevels[characterId] = 0;
            SetUserData(userData);
            var result = await _playFabUserDataManager.TryUpdateUserDataAsync(userData)
                .AttachExternalCancellation(_cancellationTokenSource.Token);
            return result;
        }

        public async UniTask<bool> SetLoginBonus(int index, LoginBonusStatus status)
        {
            if (!_userData.LoginBonus.ContainsKey(index))
            {
                return false;
            }

            var userData = GetUserData();
            userData.LoginBonus[index] = (int)status;
            SetUserData(userData);
            var result = await _playFabUserDataManager.TryUpdateUserDataAsync(userData)
                .AttachExternalCancellation(_cancellationTokenSource.Token);
            return result;
        }

        public async UniTask<bool> ResetLoginBonus()
        {
            var userData = GetUserData();
            for (int i = 0; i < _userData.LoginBonus.Count; i++)
            {
                _userData.LoginBonus[i] = (int)LoginBonusStatus.Disable;
            }

            SetUserData(userData);
            var result = await _playFabUserDataManager.TryUpdateUserDataAsync(userData)
                .AttachExternalCancellation(_cancellationTokenSource.Token);
            return result;
        }

        public LoginBonusStatus GetLoginBonusStatus(int index)
        {
            var status = _userData.LoginBonus[index];
            return GameCommonData.GetLoginBonusStatus(status);
        }

        public CharacterData GetEquippedCharacterData()
        {
            return _characterDataManager.GetCharacterData(_userData.EquipCharacterId);
        }

        public CharacterLevelData GetCurrentLevelData(int characterId)
        {
            var level = _userData.CharacterLevels[characterId];
            return _characterLevelDataManager.GetCharacterLevelData(level);
        }

        public CharacterLevelData GetNextLevelData(int characterId)
        {
            var level = _userData.CharacterLevels[characterId] + 1;
            return _characterLevelDataManager.GetCharacterLevelData(level);
        }

        public async UniTask<bool> UpgradeCharacterLevel(int characterId, int level)
        {
            if (!_userData.CharacterLevels.ContainsKey(characterId))
            {
                return false;
            }

            if (_userData.CharacterLevels[characterId] >= level)
            {
                return false;
            }

            _userData.CharacterLevels[characterId] = level;
            return true;
        }

        public void SetMissionData(int index, int progress)
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
            if (!_userData.MissionProgressDatum.ContainsKey(missionId))
            {
                return GameCommonData.ExceptionMissionProgress;
            }

            return _userData.MissionProgressDatum[missionId];
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

            var missionDatum = _missionDataManager.MissionDatum;
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

        public int GetCoin()
        {
            return _userData.Coin;
        }

        public int GetGem()
        {
            return _userData.Gem;
        }

        public bool IsGetCharacter(int characterId)
        {
            return _userData.Characters.Contains(characterId);
        }


        public void Dispose()
        {
            _userData?.Dispose();
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource?.Dispose();
            _characterDataManager?.Dispose();
            _characterLevelDataManager?.Dispose();
            _playFabUserDataManager?.Dispose();
        }
    }
}