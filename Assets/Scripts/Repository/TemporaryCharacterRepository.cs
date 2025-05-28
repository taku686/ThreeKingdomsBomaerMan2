using System;
using UnityEngine;

namespace UI.Title
{
    public class TemporaryCharacterRepository : IDisposable
    {
        private OrderType _orderType;
        private int _selectedCharacterId;
        private const string OrderTypeKey = "OrderType";


        public enum OrderType
        {
            Id,
            Type,
            Level,
            Hp,
            Attack,
            Speed,
            Bomb,
            Fire,
            WeaponType,
            Defense,
            Resistance,
        }

        public void SetOrderType(OrderType type)
        {
            _orderType = type;
            PlayerPrefs.SetInt(OrderTypeKey, (int)type);
        }

        public OrderType GetOrderType()
        {
            var type = PlayerPrefs.GetInt(OrderTypeKey, 0);
            _orderType = (OrderType)type;
            return _orderType;
        }

        public void SetSelectedCharacterId(int id)
        {
            _selectedCharacterId = id;
        }

        public int GetSelectedCharacterId()
        {
            return _selectedCharacterId;
        }

        public void Dispose()
        {
        }
    }
}