using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UI.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InputNamePopup : PopupBase
{
    [SerializeField] private TextMeshProUGUI _okText;
    [SerializeField] private Button _okButton;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _validationText;
    [Inject] private UIAnimation _uiAnimation;
    public IObservable<string> _OnClickButton { get; private set; }

    public async UniTask Open(ViewModel viewModel)
    {
        ApplyViewModel(viewModel);
        _OnClickButton = _okButton
            .OnClickAsObservable()
            .Take(1)
            .SelectMany(_ => OnClickButtonAnimation(_okButton).ToObservable())
            .SelectMany(_ => Close().ToObservable())
            .Select(_ => _inputField.text);

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

    public class Factory : PlaceholderFactory<InputNamePopup>
    {
    }
}