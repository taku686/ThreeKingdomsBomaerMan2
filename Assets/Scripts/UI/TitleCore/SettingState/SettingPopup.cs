using System;
using Cysharp.Threading.Tasks;
using Data;
using UI.Common;
using UI.Common.Popup;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Title
{
    public class SettingPopup : PopupBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider _bgmSlider;
        [SerializeField] private Toggle _pushNotificationToggle;
        [SerializeField] private Button _deleteAccountButton;

        [Inject] private UIAnimation _uiAnimation;
        [Inject] private PopupGenerateUseCase _popupGenerateUseCase;
        [Inject] private AbnormalConditionViewModelUseCase _abnormalConditionViewModelUseCase;

        private Action<bool> _setActivePanelAction;
        public IObservable<Unit> _OnClickButton { get; private set; }

        public async UniTask Open(ViewModel viewModel)
        {
            ApplyViewModel(viewModel);
            _OnClickButton = _closeButton
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
            _bgmSlider.value = viewModel._SettingData._BgmVolume;
            //_pushNotificationToggle.isOn = viewModel._SettingData._IsActivePushNotification;
        }


        public class ViewModel : PopupBase.ViewModel
        {
            public SettingData _SettingData { get; }

            public ViewModel
            (
                string titleText,
                string explanationText,
                SettingData settingData
            ) : base(titleText, explanationText)
            {
                _SettingData = settingData;
            }
        }

        public class Factory : PlaceholderFactory<SettingPopup>
        {
        }
    }
}