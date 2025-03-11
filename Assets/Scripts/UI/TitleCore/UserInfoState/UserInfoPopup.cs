using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UI.Common;
using UI.Common.Popup;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.TitleCore.UserInfoState
{
    public class UserInfoPopup : PopupBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Image _iconImage;
        [Inject] private UIAnimation _uiAnimation;
        private IObservable<Unit> _onClickCancel;
        public IObservable<Unit> _OnClickButton => _onClickCancel;

        public async UniTask Open(ViewModel viewModel)
        {
            ApplyViewModel(viewModel);
            _onClickCancel = _closeButton
                .OnClickAsObservable()
                .Take(1)
                .SelectMany(_ => OnClickButtonAnimation(_closeButton).ToObservable())
                .SelectMany(_ => Close().ToObservable())
                .Select(_ => Unit.Default);

            await base.Open(null);
        }

        private async UniTask OnClickButtonAnimation(Button button)
        {
            await _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
        }

        private void ApplyViewModel(ViewModel viewModel)
        {
            _nameText.text = viewModel._UserName;
            _iconImage.sprite = viewModel._UserIcon;
        }

        public class ViewModel : PopupBase.ViewModel
        {
            public string _UserName { get; }
            public Sprite _UserIcon { get; }

            public ViewModel
            (
                string titleText,
                string explanationText,
                string userName,
                Sprite userIcon
            ) : base(titleText, explanationText)
            {
                _UserName = userName;
                _UserIcon = userIcon;
            }
        }

        public class Factory : PlaceholderFactory<UserInfoPopup>
        {
        }
    }
}