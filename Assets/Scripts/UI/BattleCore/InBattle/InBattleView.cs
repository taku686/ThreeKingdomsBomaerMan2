using TMPro;
using UnityEngine;

public class InBattleView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    public void UpdateTime(int time)
    {
        timerText.text = time.ToString();
    }
}