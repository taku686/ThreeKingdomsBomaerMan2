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
        hpStatusGridView.SetValueText(viewModel.Hp);
        attackStatusGridView.SetValueText(viewModel.Attack);
        speedStatusGridView.SetValueText(viewModel.Speed);
        bombLimitStatusGridView.SetValueText(viewModel.BombLimit);
        firePowerStatusGridView.SetValueText(viewModel.FirePower);
    }

    public void ApplyBuffState(StatusType statusType, int value)
    {
        switch (statusType)
        {
            case StatusType.Hp:
                hpStatusGridView.SetBuffState(true, value);
                break;
            case StatusType.Attack:
                attackStatusGridView.SetBuffState(true, value);
                break;
            case StatusType.Speed:
                speedStatusGridView.SetBuffState(true, value);
                break;
            case StatusType.BombLimit:
                bombLimitStatusGridView.SetBuffState(true, value);
                break;
            case StatusType.FireRange:
                firePowerStatusGridView.SetBuffState(true, value);
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
        }
    }

    public class ViewModel
    {
        public int Hp { get; }
        public int Attack { get; }
        public int Speed { get; }
        public int BombLimit { get; }
        public int FirePower { get; }

        public ViewModel
        (
            int hp,
            int attack,
            int speed,
            int bombLimit,
            int firePower
        )
        {
            Hp = hp;
            Attack = attack;
            Speed = speed;
            BombLimit = bombLimit;
            FirePower = firePower;
        }
    }
}