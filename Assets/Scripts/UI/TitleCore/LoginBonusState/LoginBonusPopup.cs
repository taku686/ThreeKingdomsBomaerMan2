using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UI.Common;
using UI.Common.Popup;
using UI.TitleCore.LoginBonusState;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TitleCore.LoginBonusState
{
    public class LoginBonusPopup : PopupBase
    {
        [SerializeField] private LoginBonusGridView[] _loginBonusGridViews;
        public Button[] _buttons = new Button[7];
        public Button _closeButton;

        [Inject] private UIAnimation _uiAnimation;
        [Inject] private PopupGenerateUseCase _popupGenerateUseCase;

        private Action<bool> _setActivePanelAction;
        public IObservable<Unit> _OnClickButton { get; private set; }

        public async UniTask<LoginBonusPopup> Open(ViewModel viewModel)
        {
            ApplyViewModel(viewModel);

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

        private void ApplyViewModel(ViewModel viewModel)
        {
            for (var i = 0; i < _buttons.Length; i++)
            {
                if (viewModel._StampActiveDictionary.TryGetValue(i, out var isActive))
                {
                    var stampAnimation = _buttons[i].GetComponentInChildren<StampUiAnimation>();
                    stampAnimation.ImageActivate(isActive);
                }
            }

            foreach (var (day, sprite) in viewModel._RewardSprites)
            {
                var amount = viewModel._RewardAmounts[day];
                _loginBonusGridViews[day].ApplyView(sprite, amount);
            }
        }

        public class ViewModel
        {
            public Dictionary<int, bool> _StampActiveDictionary { get; }
            public Dictionary<int, Sprite> _RewardSprites { get; }
            public Dictionary<int, int> _RewardAmounts { get; }

            public ViewModel
            (
                Dictionary<int, bool> stampActiveDictionary,
                Dictionary<int, Sprite> rewardSprites,
                Dictionary<int, int> rewardAmounts
            )
            {
                _StampActiveDictionary = stampActiveDictionary;
                _RewardSprites = rewardSprites;
                _RewardAmounts = rewardAmounts;
            }
        }

        public class Factory : PlaceholderFactory<LoginBonusPopup>
        {
        }
    }
}