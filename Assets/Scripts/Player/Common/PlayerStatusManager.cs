using System;
using Common.Data;
using Photon.Pun;
using UnityEngine;

namespace Player.Common
{
    public class PlayerStatusManager : IDisposable
    {
        private bool _isMine;
        private const float HpRate = 1.8f;
        public int CurrentHp;
        public readonly int MaxHp;
        public readonly float Speed;
        private readonly int _maxBombLimit;
        public int CurrentBombLimit;
        public readonly int DamageAmount;
        public readonly int FireRange;

        public PlayerStatusManager(CharacterData characterData, bool isMine)
        {
            CurrentHp = (int)(characterData.Hp * HpRate);
            MaxHp = (int)(characterData.Hp * HpRate);
            Speed = Mathf.Sqrt(characterData.Speed * 0.1f);
            CurrentBombLimit = 0;
            _maxBombLimit = characterData.BombLimit;
            DamageAmount = characterData.Attack;
            FireRange = characterData.FireRange;
            _isMine = isMine;
        }

        public bool CanPutBomb()
        {
            return CurrentBombLimit <= _maxBombLimit;
        }

        public void IncrementBombCount()
        {
            if (!_isMine)
            {
                return;
            }

            CurrentBombLimit++;
            Debug.Log(CurrentBombLimit);
        }

        public void DecrementBombCount()
        {
            if (!_isMine || CurrentBombLimit <= 0)
            {
                return;
            }

            CurrentBombLimit--;
            Debug.Log(CurrentBombLimit);
        }


        public void Dispose()
        {
        }
    }
}