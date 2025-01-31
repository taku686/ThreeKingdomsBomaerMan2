using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UI.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SingleButtonPopup : PopupBase
{
    [SerializeField] private Button _okButton;
    [SerializeField] private TextMeshProUGUI _okText;
    [Inject] private UIAnimation _uiAnimation;
    public IObservable<Unit> _OnClickButton { get; private set; }

    public async UniTask Open(ViewModel viewModel)
    {
        ApplyViewModel(viewModel);
        _OnClickButton = _okButton
            .OnClickAsObservable()
            .Take(1)
            .SelectMany(_ => OnClickButtonAnimation(_okButton).ToObservable())
            .SelectMany(_ => Close().ToObservable())
            .Select(_ => Unit.Default);

        await base.Open(viewModel);
    }

    private void ApplyViewModel(ViewModel viewModel)
    {
        _okText.text = viewModel._OkText;
    }

    private async UniTask OnClickButtonAnimation(Button button)
    {
        await _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
    }

    public class ViewModel : PopupBase.ViewModel
    {
        public string _OkText { get; }

        public ViewModel
        (
            string titleText,
            string explanationText,
            string okText
        ) : base(titleText, explanationText)
        {
            _OkText = okText;
        }
    }
}