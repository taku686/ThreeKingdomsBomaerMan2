using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace UI.Title
{
    public class SimpleUserInfoView : MonoBehaviour
    {
        [SerializeField] private Image _userIcon;
        [SerializeField] private TextMeshProUGUI _userName;
        [SerializeField] private TextMeshProUGUI _entitledText;
        [SerializeField] private GameObject _notificationObj;

        public void ApplyViewModel(ViewModel viewModel)
        {
            _userIcon.sprite = viewModel._UserIcon;
            _userName.text = viewModel._UserName;
            _entitledText.text = viewModel._Entitled;
            _notificationObj.SetActive(false);
        }

        public class ViewModel
        {
            public Sprite _UserIcon { get; }
            public string _UserName { get; }
            public string _Entitled { get; }

            public ViewModel
            (
                Sprite userIcon,
                string userName,
                string entitled
            )
            {
                _UserIcon = userIcon;
                _UserName = userName;
                _Entitled = entitled;
            }
        }
    }
}