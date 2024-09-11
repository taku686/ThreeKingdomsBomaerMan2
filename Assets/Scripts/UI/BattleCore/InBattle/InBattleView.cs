using TMPro;
using UnityEngine;

public class InBattleView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private StatusInBattleView statusInBattleView;

    public void ApplyStatusViewModel(StatusInBattleView.ViewModel viewModel)
    {
        statusInBattleView.ApplyViewModel(viewModel);
    }

    public void UpdateTime(int time)
    {
        timerText.text = time.ToString();
    }
}