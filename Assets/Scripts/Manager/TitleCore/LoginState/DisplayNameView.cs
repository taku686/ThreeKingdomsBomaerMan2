using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.LoginState
{
    public class DisplayNameView : MonoBehaviour
    {
        [SerializeField] private Button okButton;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TextMeshProUGUI errorText;

        public TextMeshProUGUI ErrorText => errorText;
        public Button OkButton => okButton;
        public TMP_InputField InputField => inputField;
    }
}