using System;
using Common.Data;
using UniRx;

namespace Character
{
    public class PlayerStatusInfo : IDisposable
    {
        public readonly ReactiveProperty<(int, int)> _hp;
        public readonly ReactiveProperty<int> _speed;
        public readonly ReactiveProperty<int> _attack;
        public readonly ReactiveProperty<int> _defense;
        public readonly ReactiveProperty<int> _resistance;
        public readonly ReactiveProperty<int> _fireRange;
        public readonly ReactiveProperty<int> _bombLimit;

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
            _bombLimit = new ReactiveProperty<int>(bombLimit);
            _hp = new ReactiveProperty<(int, int)>((maxHp, currentHp));
            _speed = new ReactiveProperty<int>(speed);
            _attack = new ReactiveProperty<int>(attack);
            _defense = new ReactiveProperty<int>(defense);
            _resistance = new ReactiveProperty<int>(resistance);
            _fireRange = new ReactiveProperty<int>(fireRange);
        }

        public int GetStatusValue(StatusType statusType)
        {
            return statusType switch
            {
                StatusType.Hp => _hp.Value.Item2,
                StatusType.Attack => _attack.Value,
                StatusType.Speed => _speed.Value,
                StatusType.BombLimit => _bombLimit.Value,
                StatusType.FireRange => _fireRange.Value,
                StatusType.Defense => _defense.Value,
                StatusType.Resistance => _resistance.Value,
                StatusType.None => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null)
            };
        }

        public void SetStatusValue(StatusType statusType, int value)
        {
            switch (statusType)
            {
                case StatusType.Hp:
                    _hp.Value = (_hp.Value.Item1, value);
                    break;
                case StatusType.Attack:
                    _attack.Value = value;
                    break;
                case StatusType.Speed:
                    _speed.Value = value;
                    break;
                case StatusType.BombLimit:
                    _bombLimit.Value = value;
                    break;
                case StatusType.FireRange:
                    _fireRange.Value = value;
                    break;
                case StatusType.Defense:
                    _defense.Value = value;
                    break;
                case StatusType.Resistance:
                    _resistance.Value = value;
                    break;
                case StatusType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null);
            }
        }

        public void Dispose()
        {
            _hp?.Dispose();
            _speed?.Dispose();
            _attack?.Dispose();
            _defense?.Dispose();
            _resistance?.Dispose();
            _fireRange?.Dispose();
            _bombLimit?.Dispose();
        }
    }
}