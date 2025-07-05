using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using MoreMountains.Tools;
using UI.Common;
using UI.Common.Popup;
using UI.Title;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TitleCore.LoginBonusState
{
    public class LoginBonusPopup : PopupBase
    {
        public Button[] _buttons = new Button[7];
        public Image[] _clearImages = new Image[7];
        public Button _closeButton;
        public GameObject _focusObj;

        [Inject] private UIAnimation _uiAnimation;
        [Inject] private PopupGenerateUseCase _popupGenerateUseCase;

        private Action<bool> _setActivePanelAction;
        public IObservable<Unit> _OnClickButton { get; private set; }

        public async UniTask<LoginBonusPopup> Open()
        {
            _OnClickButton =
                _closeButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => OnClickButtonAnimation(_closeButton).ToObservable())
                    .SelectMany(_ => Close().ToObservable())
                    .Select(_ => Unit.Default);

            await base.Open(null);
            return this;
        }

        private async UniTask OnClickButtonAnimation(Button button)
        {
            await _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
        }

        public class Factory : PlaceholderFactory<LoginBonusPopup>
        {
        }
    }
}