using System;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;

namespace Common.Data
{
    public class UserManager : MonoBehaviour
    {
        [HideInInspector] public ReactiveProperty<int> equipCharacterId;
        private User _user;

        public void Initialize(User user)
        {
            _user = user;
            _user.Currency = new Currency();
            equipCharacterId.Subscribe(index => { _user.EquipCharacterId = index; }).AddTo(this);
        }

        public User GetUser()
        {
            return _user;
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