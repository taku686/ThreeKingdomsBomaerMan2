using System.Threading;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using UnityEngine;
using Zenject;

namespace Common.Data
{
    public class UserDataManager : MonoBehaviour
    {
        private UserData _userData;
        private CancellationTokenSource _cancellationTokenSource;
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private CharacterLevelDataManager _characterLevelDataManager;
        private PlayFabUserDataManager _playFabUserDataManager;

        public void Initialize(UserData userData, PlayFabUserDataManager playFabUserDataManager)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource.RegisterRaiseCancelOnDestroy(gameObject);
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
            var result = await _playFabUserDataManager.TryUpdateUserDataAsync(GameCommonData.UserKey, userData)
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

        public bool IsGetCharacter(int characterId)
        {
            return _userData.Characters.Contains(characterId);
        }

        private void OnDestroy()
        {
            _userData?.Dispose();
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}