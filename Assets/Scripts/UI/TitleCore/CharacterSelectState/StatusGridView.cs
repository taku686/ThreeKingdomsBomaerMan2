using TMPro;
using UnityEngine;

namespace UI.Title
{
    public class StatusGridView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private CharacterSelectRepository.OrderType orderType;

        public CharacterSelectRepository.OrderType OrderType => orderType;

        public void ApplyViewModel(string statusName, string value)
        {
            transform.localPosition = Vector3.zero;
            nameText.text = statusName;
            valueText.text = value;
        }
    }
}