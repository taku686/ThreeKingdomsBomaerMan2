using System;
using Common.Data;
using UnityEngine;

namespace Player.Common
{
    public class CharacterStatusManager : IDisposable
    {
        private readonly bool isMine;
        private const float HpRate = 1.8f;
        private int maxHp;
        private float speed;
        private int maxBombLimit;
        private int currentBombLimit;
        private int damageAmount;
        private int fireRange;
        public int CurrentHp { get; set; }
        public int MaxHp => maxHp;
        public float Speed => speed;
        public int MaxBombLimit => maxBombLimit;
        public int DamageAmount => damageAmount;
        public int FireRange => fireRange;


        public CharacterStatusManager(CharacterData characterData, bool isMine)
        {
            CurrentHp = (int)(characterData.Hp * HpRate);
            maxHp = (int)(characterData.Hp * HpRate);
            speed = Mathf.Sqrt(characterData.Speed * 0.1f);
            currentBombLimit = 0;
            maxBombLimit = characterData.BombLimit;
            damageAmount = characterData.Attack;
            fireRange = Mathf.RoundToInt(characterData.FireRange / 2f);
            this.isMine = isMine;
        }

        public void ApplyBuff(StatusType statusType, int value)
        {
            switch (statusType)
            {
                case StatusType.Hp:
                    maxHp = (int)(value * HpRate);
                    break;
                case StatusType.Attack:
                    damageAmount = value;
                    break;
                case StatusType.Speed:
                    speed = Mathf.Sqrt(value * 0.1f);
                    break;
                case StatusType.BombLimit:
                    maxBombLimit = value;
                    break;
                case StatusType.FireRange:
                    fireRange = Mathf.RoundToInt(value / 2f);
                    break;
            }
        }

        public void ApplyDebuff(StatusType statusType, int value)
        {
            switch (statusType)
            {
                case StatusType.Hp:
                    maxHp = (int)(value * HpRate);
                    break;
                case StatusType.Attack:
                    damageAmount = value;
                    break;
                case StatusType.Speed:
                    speed = Mathf.Sqrt(value * 0.1f);
                    break;
                case StatusType.BombLimit:
                    maxBombLimit = value;
                    break;
                case StatusType.FireRange:
                    fireRange = Mathf.RoundToInt(value / 2f);
                    break;
            }
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