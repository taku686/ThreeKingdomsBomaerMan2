using System;
using Common.Data;
using UnityEngine;

namespace Player.Common
{
    public class TranslateStatusInBattleUseCase : IDisposable
    {
        private readonly bool _isMine;
        private const float HpRate = 1.8f;
        private int _maxBombLimit;
        private int _currentBombLimit;
        public int _CurrentHp { get; set; }
        public int _MaxHp { get; private set; }
        public float _Speed { get; private set; }
        public int _Attack { get; private set; }
        public int _Defense { get; private set; }
        public int _Resistance { get; private set; }
        public int _FireRange { get; private set; }


        public TranslateStatusInBattleUseCase
        (
            int hp,
            int speed,
            int bombLimit,
            int attack,
            int fireRange,
            int defense,
            int resistance,
            bool isMine
        )
        {
            _CurrentHp = (int)(hp * HpRate);
            _MaxHp = (int)(hp * HpRate);
            _Speed = Mathf.Sqrt(speed * 0.1f);
            _currentBombLimit = 0;
            _maxBombLimit = bombLimit;
            _Attack = attack;
            _Defense = defense / 2;
            _Resistance = resistance;
            _FireRange = Mathf.RoundToInt(fireRange / 2f);
            _isMine = isMine;
        }

        public float TranslateStatusValue(StatusType statusType, int value)
        {
            switch (statusType)
            {
                case StatusType.Hp:
                    _MaxHp = Mathf.FloorToInt(value * HpRate);
                    return _MaxHp;
                case StatusType.Attack:
                    _Attack = value;
                    return _Attack;
                case StatusType.Speed:
                    _Speed = Mathf.Sqrt(value * 0.1f);
                    return _Speed;
                case StatusType.BombLimit:
                    _maxBombLimit = value;
                    return _maxBombLimit;
                case StatusType.FireRange:
                    _FireRange = Mathf.FloorToInt(value / 2f);
                    return _FireRange;
                case StatusType.Defense:
                    return _Defense;
                case StatusType.Resistance:
                    return _Resistance;
                default:
                    throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null);
            }
        }

        public float Heal(int value)
        {
            _CurrentHp += value;
            var rate = (float)_CurrentHp / _MaxHp;
            if (!(rate > 1)) return rate;
            _CurrentHp = _MaxHp;
            rate = 1;

            return rate;
        }

        public bool CanPutBomb()
        {
            return _currentBombLimit <= _maxBombLimit;
        }

        public void IncrementBombCount()
        {
            if (!_isMine)
            {
                return;
            }

            _currentBombLimit++;
        }

        public void DecrementBombCount()
        {
            if (!_isMine || _currentBombLimit <= 0)
            {
                return;
            }

            _currentBombLimit--;
        }


        public void Dispose()
        {
        }
    }
}