using System;
using Common.Data;
using UnityEngine;

namespace Player.Common
{
    public class TranslateStatusForBattleUseCase : IDisposable
    {
        private readonly bool isMine;
        private const float HpRate = 1.8f;
        private int maxHp;
        private float speed;
        private int maxBombLimit;
        private int currentBombLimit;
        private int attack;
        private int fireRange;
        public int CurrentHp { get; set; }
        public int MaxHp => maxHp;
        public float Speed => speed;
        public int Attack => attack;
        public int FireRange => fireRange;


        public TranslateStatusForBattleUseCase
        (
            int hp,
            int speed,
            int bombLimit,
            int attack,
            int fireRange,
            bool isMine
        )
        {
            CurrentHp = (int)(hp * HpRate);
            maxHp = (int)(hp * HpRate);
            this.speed = Mathf.Sqrt(speed * 0.1f);
            currentBombLimit = 0;
            maxBombLimit = bombLimit;
            this.attack = attack;
            this.fireRange = Mathf.RoundToInt(fireRange / 2f);
            this.isMine = isMine;
        }

        public float TranslateStatusValue(StatusType statusType, int value)
        {
            switch (statusType)
            {
                case StatusType.Hp:
                    maxHp = (int)(value * HpRate);
                    return maxHp;
                case StatusType.Attack:
                    attack = value;
                    return attack;
                case StatusType.Speed:
                    speed = Mathf.Sqrt(value * 0.1f);
                    return speed;
                case StatusType.BombLimit:
                    maxBombLimit = value;
                    return maxBombLimit;
                case StatusType.FireRange:
                    fireRange = Mathf.RoundToInt(value / 2f);
                    return fireRange;
            }

            return value;
        }

        public float Heal(int value)
        {
            CurrentHp += value;
            var rate = (float)CurrentHp / maxHp;
            if (rate > 1)
            {
                CurrentHp = maxHp;
                rate = 1;
            }

            return rate;
        }

        public bool CanPutBomb()
        {
            return currentBombLimit <= maxBombLimit;
        }

        public void IncrementBombCount()
        {
            if (!isMine)
            {
                return;
            }

            currentBombLimit++;
        }

        public void DecrementBombCount()
        {
            if (!isMine || currentBombLimit <= 0)
            {
                return;
            }

            currentBombLimit--;
        }


        public void Dispose()
        {
        }
    }
}