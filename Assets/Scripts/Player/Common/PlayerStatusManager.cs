using System;
using UnityEngine;

namespace Player.Common
{
    public class PlayerStatusManager : IDisposable
    {
        private const float HpRate = 1.8f;
        public int CurrentHp;
        public readonly int MaxHp;
        public readonly float Speed;

        public PlayerStatusManager(int maxHp, int speed)
        {
            CurrentHp = (int)(maxHp * HpRate);
            MaxHp = (int)(maxHp * HpRate);
            Speed = Mathf.Sqrt(speed * 0.1f);
            Debug.Log(Speed);
        }


        public void Dispose()
        {
        }
    }
}