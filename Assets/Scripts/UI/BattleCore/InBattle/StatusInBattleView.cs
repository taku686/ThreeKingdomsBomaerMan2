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

    public void ApplyViewModel(ViewModel viewModel)
    {
        hpStatusGridView.SetValueText(viewModel._Hp);
        attackStatusGridView.SetValueText(viewModel._Attack);
        speedStatusGridView.SetValueText(viewModel._Speed);
        bombLimitStatusGridView.SetValueText(viewModel._BombLimit);
        firePowerStatusGridView.SetValueText(viewModel._FireRange);
    }

    //todo 後で修正　防御と抵抗値を追加する
    public void ApplyBuffState(StatusType statusType, int value, bool isBuff, bool isDebuff)
    {
        switch (statusType)
        {
            case StatusType.Hp:
                hpStatusGridView.SetBuffState(isBuff, isDebuff, value);
                break;
            case StatusType.Attack:
                attackStatusGridView.SetBuffState(isBuff, isDebuff, value);
                break;
            case StatusType.Speed:
                speedStatusGridView.SetBuffState(isBuff, isDebuff, value);
                break;
            case StatusType.BombLimit:
                bombLimitStatusGridView.SetBuffState(isBuff, isDebuff, value);
                break;
            case StatusType.FireRange:
                firePowerStatusGridView.SetBuffState(isBuff, isDebuff, value);
                break;
        }
    }

    public void ApplyDebuffState(StatusType statusType, int value)
    {
        switch (statusType)
        {
            case StatusType.Hp:
                hpStatusGridView.SetDebuffState(true, value);
                break;
            case StatusType.Attack:
                attackStatusGridView.SetDebuffState(true, value);
                break;
            case StatusType.Speed:
                speedStatusGridView.SetDebuffState(true, value);
                break;
            case StatusType.BombLimit:
                bombLimitStatusGridView.SetDebuffState(true, value);
                break;
            case StatusType.FireRange:
                firePowerStatusGridView.SetDebuffState(true, value);
                break;
            case StatusType.Defense:
                break;
            case StatusType.Resistance:
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