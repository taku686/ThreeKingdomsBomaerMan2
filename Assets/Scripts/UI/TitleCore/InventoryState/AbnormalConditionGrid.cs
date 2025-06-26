using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class AbnormalConditionGrid : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _abnormalConditionName;
        [SerializeField] private TextMeshProUGUI _abnormalConditionExplanation;

        public void ApplyViewModel(ViewModel viewModel)
        {
            _icon.sprite = viewModel._Icon;
            _abnormalConditionName.text = viewModel._AbnormalConditionName;
            _abnormalConditionExplanation.text = viewModel._AbnormalConditionExplanation;
        }

        public class ViewModel
        {
            public Sprite _Icon { get; }
            public string _AbnormalConditionName { get; }
            public string _AbnormalConditionExplanation { get; }

            public ViewModel
            (
                Sprite icon,
                string abnormalConditionName,
                string abnormalConditionExplanation
            )
            {
                _Icon = icon;
                _AbnormalConditionName = abnormalConditionName;
                _AbnormalConditionExplanation = abnormalConditionExplanation;
            }
        }
    }
}