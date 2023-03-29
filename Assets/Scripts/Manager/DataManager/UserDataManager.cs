using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using UnityEngine;
using Zenject;

namespace Common.Data
{
    public class UserDataManager : IDisposable
    {
        private UserData _userData;
        private CancellationTokenSource _cancellationTokenSource;
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private CharacterLevelDataManager _characterLevelDataManager;
        private PlayFabUserDataManager _playFabUserDataManager;

        public void Initialize(UserData userData, PlayFabUserDataManager playFabUserDataManager)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _playFabUserDataManager = playFabUserDataManager;
            SetUserData(userData);
        }

        public UserData GetUserData()
        {
            return _userData;
        }

        public void SetUserData(UserData userData)
        {
            _userData = userData;
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
            var result = await _playFabUserDataManager.TryUpdateUserDataAsync(_userData);
            return result;
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