using Manager.DataManager;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

namespace Common.Data
{
    public class UserDataManager : MonoBehaviour
    {
        private UserData _userData;
        private CharacterDataManager _characterDataManager;

        public void Initialize(UserData userData, CharacterDataManager characterDataManager)
        {
            SetUserData(userData);
            _characterDataManager = characterDataManager;
        }

        public UserData GetUserData()
        {
            return _userData;
        }

        public void SetUserData(UserData userData)
        {
            _userData = userData;
        }

        public CharacterData GetEquippedCharacterData()
        {
            return _characterDataManager.GetCharacterData(_userData.EquipCharacterId);
        }

        public bool IsGetCharacter(int characterId)
        {
            return _userData.Characters.Contains(characterId);
        }

        private void OnDestroy()
        {
            _userData?.Dispose();
        }
    }
}