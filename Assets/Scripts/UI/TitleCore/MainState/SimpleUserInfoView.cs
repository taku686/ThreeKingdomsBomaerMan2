using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace UI.Title
{
    public class SimpleUserInfoView : MonoBehaviour
    {
        [SerializeField] private Image _userIcon;
        [SerializeField] private TMPro.TextMeshProUGUI _userName;

        public void ApplyViewModel(ViewModel viewModel)
        {
            _userIcon.sprite = viewModel._UserIcon;
            _userName.text = viewModel._UserName;
        }

        public class ViewModel
        {
            public Sprite _UserIcon { get; }
            public string _UserName { get; }

            public ViewModel
            (
                Sprite userIcon,
                string userName
            )
            {
                _UserIcon = userIcon;
                _UserName = userName;
            }
        }
    }
}