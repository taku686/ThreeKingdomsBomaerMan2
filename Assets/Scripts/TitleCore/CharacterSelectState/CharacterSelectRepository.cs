using System;
using UnityEngine;

namespace UI.Title
{
    public class CharacterSelectRepository : IDisposable
    {
        private OrderType orderType;
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
            Fire
        }

        public void SetOrderType(OrderType type)
        {
            orderType = type;
            PlayerPrefs.SetInt(OrderTypeKey, (int)type);
        }

        public OrderType GetOrderType()
        {
            var type = PlayerPrefs.GetInt(OrderTypeKey, 0);
            orderType = (OrderType)type;
            return orderType;
        }

        public void Dispose()
        {
        }
    }
}