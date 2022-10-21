using System;
using UniRx;
using UnityEngine;

namespace Common.Data
{
    public class UserManager : MonoBehaviour
    {
        [HideInInspector] public ReactiveProperty<int> equipCharacterId;
        private User _user;

        public void Initialize(User user)
        {
            _user = user;
            equipCharacterId.Subscribe(index => { _user.EquipCharacterId = index; }).AddTo(this);
        }
    }
}