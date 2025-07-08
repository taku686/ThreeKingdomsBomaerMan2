using System;
using Common.Data;
using UniRx;

namespace Character
{
    public class PlayerStatusInfo
    {
        public readonly ReactiveProperty<(int, int)> _Hp;
        public readonly ReactiveProperty<int> _Speed;
        public readonly ReactiveProperty<int> _Attack;
        public readonly ReactiveProperty<int> _Defense;
        public readonly ReactiveProperty<int> _Resistance;
        public readonly ReactiveProperty<int> _FireRange;
        public readonly ReactiveProperty<int> _BombLimit;

        public PlayerStatusInfo
        (
            int currentHp,
            int speed,
            int maxHp,
            int attack,
            int defense,
            int resistance,
            int fireRange,
            int bombLimit
        )
        {
            _BombLimit = new ReactiveProperty<int>(bombLimit);
            _Hp = new ReactiveProperty<(int, int)>((maxHp, currentHp));
            _Speed = new ReactiveProperty<int>(speed);
            _Attack = new ReactiveProperty<int>(attack);
            _Defense = new ReactiveProperty<int>(defense);
            _Resistance = new ReactiveProperty<int>(resistance);
            _FireRange = new ReactiveProperty<int>(fireRange);
        }

        public int GetStatusValue(StatusType statusType)
        {
            return statusType switch
            {
                StatusType.Hp => _Hp.Value.Item2,
                StatusType.Attack => _Attack.Value,
                StatusType.Speed => _Speed.Value,
                StatusType.BombLimit => _BombLimit.Value,
                StatusType.FireRange => _FireRange.Value,
                StatusType.Defense => _Defense.Value,
                StatusType.Resistance => _Resistance.Value,
                StatusType.None => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null)
            };
        }

        public void SetStatusValue(StatusType statusType, int value)
        {
            switch (statusType)
            {
                case StatusType.Hp:
                    _Hp.Value = (_Hp.Value.Item1, value);
                    break;
                case StatusType.Attack:
                    _Attack.Value = value;
                    break;
                case StatusType.Speed:
                    _Speed.Value = value;
                    break;
                case StatusType.BombLimit:
                    _BombLimit.Value = value;
                    break;
                case StatusType.FireRange:
                    _FireRange.Value = value;
                    break;
                case StatusType.Defense:
                    _Defense.Value = value;
                    break;
                case StatusType.Resistance:
                    _Resistance.Value = value;
                    break;
                case StatusType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null);
            }
        }
    }
}