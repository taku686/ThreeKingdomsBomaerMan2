using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TitleCore.UserInfoState
{
    public class UserInfoView : ViewBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _editButton;
        [SerializeField] private TextMeshProUGUI _userNameText;
        [SerializeField] private Image _userIconImage;

        public IObservable<Button> OnClickCloseButtonAsObservable()
            => _closeButton.OnClickAsObservable()
                .Select(_ => _closeButton);

        public void ApplyViewModel(ViewModel viewModel)
        {
            _userNameText.text = viewModel._UserName;
            _userIconImage.sprite = viewModel._UserIcon;
        }

        public class ViewModel
        {
            public string _UserName { get; }
            public Sprite _UserIcon { get; }


            public ViewModel
            (
                string userName,
                Sprite userIcon
            )
            {
                _UserName = userName;
                _UserIcon = userIcon;
            }
        }
    }
}