using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using Data;
using Manager.NetworkManager;
using MoreMountains.Tools;
using UI.Common;
using UI.Common.Popup;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;

        private Action<bool> _setActivePanelAction;
        public IObservable<Unit> _OnClickButton { get; private set; }

        public async UniTask Open(ViewModel viewModel)
        {
            ApplyViewModel(viewModel);
            Subscribe();
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
        }

        private void Subscribe()
        {
            var confirmToDelete =
                _deleteAccountButton
                    .OnClickAsObservable()
                    .SelectMany(_ => _popupGenerateUseCase.GenerateConfirmPopup
                    (
                        GameCommonData.Terms.AccountDeleteConfirmExplanation,
                        GameCommonData.Terms.AccountDeleteConfirmTitle
                    ))
                    .Publish();

            confirmToDelete
                .Where(result => result)
                .SelectMany(_ => DeleteAccountAsync().ToObservable())
                .SelectMany(_ => _popupGenerateUseCase.GenerateCheckingPopup
                (
                    GameCommonData.Terms.AccountDeleteExplanation,
                    GameCommonData.Terms.AccountDeleteTitle,
                    GameCommonData.Terms.ToTitle
                )).Subscribe(_ => { MMSceneLoadingManager.LoadScene(GameCommonData.LoginScene); })
                .AddTo(gameObject);

            confirmToDelete
                .Where(result => !result)
                .Subscribe()
                .AddTo(gameObject);
            
            confirmToDelete.Connect();
        }

        private async UniTask<bool> DeleteAccountAsync()
        {
            return await _playFabUserDataManager.DeletePlayerDataAsync();
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