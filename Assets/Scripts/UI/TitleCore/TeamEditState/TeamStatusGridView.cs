using Common.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamStatusGridView : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _statusTitleText;
    [SerializeField] private TextMeshProUGUI _statusValueText;
    [SerializeField] private TextMeshProUGUI _iconText;

    public void ApplyViewModel(ViewModel viewModel)
    {
        if (viewModel._StatusType == StatusType.None)
        {
            _iconImage.gameObject.SetActive(false);
            _iconText.gameObject.SetActive(true);
            _iconText.text = "LV";
        }
        else
        {
            _iconImage.gameObject.SetActive(true);
            _iconText.gameObject.SetActive(false);
            _iconImage.sprite = viewModel._IconSprite;
        }

        _backgroundImage.color = viewModel._IconColor;
        _statusTitleText.text = GameCommonData.TranslateStatusTypeToString(viewModel._StatusType);
        _statusValueText.text = viewModel._StatusValue.ToString();
    }

    public class ViewModel
    {
        public StatusType _StatusType { get; }
        public int _StatusValue { get; }
        public Sprite _IconSprite { get; }
        public Color _IconColor { get; }


        public ViewModel
        (
            StatusType statusType,
            int statusValue,
            Sprite iconSprite,
            Color iconColor
        )
        {
            _StatusType = statusType;
            _StatusValue = statusValue;
            _IconSprite = iconSprite;
            _IconColor = iconColor;
        }
    }
}