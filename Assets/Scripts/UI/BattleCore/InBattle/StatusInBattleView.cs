using System;
using Common.Data;
using UnityEngine;

public class StatusInBattleView : MonoBehaviour
{
    [SerializeField] private StatusGridView hpStatusGridView;
    [SerializeField] private StatusGridView attackStatusGridView;
    [SerializeField] private StatusGridView speedStatusGridView;
    [SerializeField] private StatusGridView bombLimitStatusGridView;
    [SerializeField] private StatusGridView firePowerStatusGridView;
    [SerializeField] private StatusGridView _defenseStatusGridView;
    [SerializeField] private StatusGridView _resistanceStatusGridView;

    public void ApplyViewModel(ViewModel viewModel)
    {
        hpStatusGridView.SetValueText(viewModel._Hp);
        attackStatusGridView.SetValueText(viewModel._Attack);
        speedStatusGridView.SetValueText(viewModel._Speed);
        bombLimitStatusGridView.SetValueText(viewModel._BombLimit);
        firePowerStatusGridView.SetValueText(viewModel._FireRange);
        _defenseStatusGridView.SetValueText(viewModel._Defense);
        _resistanceStatusGridView.SetValueText(viewModel._Resistance);
    }

    //todo 後で修正　防御と抵抗値を追加する
    public void ApplyBuffState(StatusType statusType, int value)
    {
        switch (statusType)
        {
            case StatusType.Hp:
                hpStatusGridView.SetBuffState(value);
                break;
            case StatusType.Attack:
                attackStatusGridView.SetBuffState(value);
                break;
            case StatusType.Speed:
                speedStatusGridView.SetBuffState(value);
                break;
            case StatusType.BombLimit:
                bombLimitStatusGridView.SetBuffState(value);
                break;
            case StatusType.FireRange:
                firePowerStatusGridView.SetBuffState(value);
                break;
            case StatusType.Defense:
                _defenseStatusGridView.SetBuffState(value);
                break;
            case StatusType.Resistance:
                _resistanceStatusGridView.SetBuffState(value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null);
        }
    }

    public class ViewModel
    {
        public int _Hp { get; }
        public int _Attack { get; }
        public int _Speed { get; }
        public int _BombLimit { get; }
        public int _FireRange { get; }
        public int _Defense { get; }
        public int _Resistance { get; }

        public ViewModel
        (
            int hp,
            int attack,
            int speed,
            int bombLimit,
            int fireRange,
            int defense,
            int resistance
        )
        {
            _Hp = hp;
            _Attack = attack;
            _Speed = speed;
            _BombLimit = bombLimit;
            _FireRange = fireRange;
            _Defense = defense;
            _Resistance = resistance;
        }
    }
}