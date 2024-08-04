using System;
using Common.Data;
using UnityEngine;

namespace Player.Common
{
    public class CharacterStatusManager : IDisposable
    {
        private readonly bool isMine;
        private const float HpRate = 1.8f;
        public int CurrentHp;
        public readonly int MaxHp;
        public readonly float Speed;
        private readonly int maxBombLimit;
        public int CurrentBombLimit;
        public readonly int DamageAmount;
        public readonly int FireRange;

        public CharacterStatusManager(CharacterData characterData, bool isMine)
        {
            CurrentHp = (int)(characterData.Hp * HpRate);
            MaxHp = (int)(characterData.Hp * HpRate);
            Speed = Mathf.Sqrt(characterData.Speed * 0.1f);
            CurrentBombLimit = 0;
            maxBombLimit = characterData.BombLimit;
            DamageAmount = characterData.Attack;
            FireRange = characterData.FireRange;
            this.isMine = isMine;
        }

        public bool CanPutBomb()
        {
            return CurrentBombLimit <= maxBombLimit;
        }

        public void IncrementBombCount()
        {
            if (!isMine)
            {
                return;
            }

            CurrentBombLimit++;
        }

        public void DecrementBombCount()
        {
            if (!isMine || CurrentBombLimit <= 0)
            {
                return;
            }

            CurrentBombLimit--;
        }


        public void Dispose()
        {
        }
    }
}