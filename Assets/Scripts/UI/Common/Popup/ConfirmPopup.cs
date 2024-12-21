using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ConfirmPopup : PopupBase
{
    [SerializeField] private Button _okButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private TextMeshProUGUI _okText;
    [SerializeField] private TextMeshProUGUI _cancelText;

    private IObservable<bool> _onClickCancel;
    private IObservable<bool> _onClickOk;
    public IObservable<bool> _OnClickButton => _onClickOk.Merge(_onClickCancel);

    public async UniTask Open(ViewModel viewModel)
    {
        ApplyViewModel(viewModel);
        _onClickOk = _okButton
            .OnClickAsObservable()
            .SelectMany(_ => Close().ToObservable())
            .Select(_ => true);

        _onClickCancel = _cancelButton
            .OnClickAsObservable()
            .SelectMany(_ => Close().ToObservable())
            .Select(_ => false);

        await base.Open(viewModel);
    }

    private void ApplyViewModel(ViewModel viewModel)
    {
        _okText.text = viewModel._OkText;
        _cancelText.text = viewModel._CancelText;
    }

    public class ViewModel : PopupBase.ViewModel
    {
        public string _OkText { get; }
        public string _CancelText { get; }

        public ViewModel
        (
            string titleText,
            string explanationText,
            string okText,
            string cancelText
        ) : base(titleText, explanationText)
        {
            _OkText = okText;
            _CancelText = cancelText;
        }
    }

    public class Factory : PlaceholderFactory<ConfirmPopup>
    {
    }
}