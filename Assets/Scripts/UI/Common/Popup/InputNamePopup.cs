using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InputNamePopup : PopupBase
{
    [SerializeField] private Button _okButton;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _validationText;
    
    public class Factory : PlaceholderFactory<InputNamePopup>
    {
    }
}