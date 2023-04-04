using TMPro;
using UnityEngine;

public class StatusView : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI hpText;
   [SerializeField] private TextMeshProUGUI damageText;
   [SerializeField] private TextMeshProUGUI speedText;
   [SerializeField] private TextMeshProUGUI bombLimitText;
   [SerializeField] private TextMeshProUGUI fireRangeText;

   public TextMeshProUGUI HpText => hpText;

   public TextMeshProUGUI DamageText => damageText;

   public TextMeshProUGUI SpeedText => speedText;

   public TextMeshProUGUI BombLimitText => bombLimitText;

   public TextMeshProUGUI FireRangeText => fireRangeText;
}
