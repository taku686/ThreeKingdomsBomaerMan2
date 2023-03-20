using UniRx;
using UnityEngine;

namespace Common.Data
{
    public class UserDataManager : MonoBehaviour
    {
        [HideInInspector] public ReactiveProperty<int> equipCharacterId;
        private User _user;

        public void Initialize(User user)
        {
            _user = user;
            equipCharacterId.Subscribe(index => { _user.EquipCharacterId = index; }).AddTo(this);
        }

        public User GetUser()
        {
            return _user;
        }

        public void SetUser(User user)
        {
            _user = user;
        }

        public bool IsGetCharacter(int characterId)
        {
            return _user.Characters.ContainsKey(characterId);
        }

        private void OnDestroy()
        {
            _user?.Dispose();
        }
    }
}