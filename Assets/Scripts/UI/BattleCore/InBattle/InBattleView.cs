using Common.Data;
using TMPro;
using UI.BattleCore;
using UnityEngine;

public class InBattleView : BattleViewBase
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private StatusInBattleView statusInBattleView;

    public void ApplyStatusViewModel(StatusInBattleView.ViewModel viewModel)
    {
        statusInBattleView.ApplyViewModel(viewModel);
    }

    public void ApplyBuffState(StatusType statusType, int value, bool isBuff, bool isDebuff)
    {
        statusInBattleView.ApplyBuffState(statusType, value, isBuff, isDebuff);
    }

    public void UpdateTime(int time)
    {
        timerText.text = time.ToString();
    }
}