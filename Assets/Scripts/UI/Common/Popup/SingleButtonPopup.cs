using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SingleButtonPopup : PopupBase
{
    [SerializeField] private Button _okButton;
    [SerializeField] private TextMeshProUGUI _okText;
    private IObservable<Unit> _onClickOk;
    public IObservable<Unit> _OnClickButton => _onClickOk;
    public async UniTask Open(ViewModel viewModel)
    {
        ApplyViewModel(viewModel);
        _onClickOk = _okButton
            .OnClickAsObservable()
            .SelectMany(_ => Close().ToObservable())
            .Select(_ => Unit.Default);

        await base.Open(viewModel);
    }

    private void ApplyViewModel(ViewModel viewModel)
    {
        _okText.text = viewModel._OkText;
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
