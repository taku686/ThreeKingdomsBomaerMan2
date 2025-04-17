using TMPro;
using UnityEngine;

public class StatusView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI _attackText;
    [SerializeField] private TextMeshProUGUI _defenseText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI bombLimitText;
    [SerializeField] private TextMeshProUGUI fireRangeText;
    [SerializeField] private TextMeshProUGUI _resistanceText;
    public TextMeshProUGUI _HpText => hpText;
    public TextMeshProUGUI _AttackText => _attackText;
    public TextMeshProUGUI _DefenseText => _defenseText;
    public TextMeshProUGUI _SpeedText => speedText;
    public TextMeshProUGUI _BombLimitText => bombLimitText;
    public TextMeshProUGUI _FireRangeText => fireRangeText;
    public TextMeshProUGUI _ResistanceText => _resistanceText;
}