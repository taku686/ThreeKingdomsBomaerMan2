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

    public async UniTask Open(ViewModel viewModel, Action okAction = null, Action cancelAction = null)
    {
        ApplyViewModel(viewModel);
        _okButton.OnClickAsObservable().Take(1).SelectMany(_ => Close().ToObservable())
            .Subscribe(_ => okAction?.Invoke()).AddTo(gameObject.GetCancellationTokenOnDestroy());
        _cancelButton.OnClickAsObservable().Take(1).SelectMany(_ => Close().ToObservable())
            .Subscribe(_ => cancelAction?.Invoke()).AddTo(gameObject.GetCancellationTokenOnDestroy());
        await base.Open(viewModel);
    }

    private void ApplyViewModel(ViewModel viewModel)
    {
        _okText.text = viewModel.OkText;
        _cancelText.text = viewModel.CancelText;
    }

    public class ViewModel : PopupBase.ViewModel
    {
        public string OkText { get; }
        public string CancelText { get; }

        public ViewModel
        (
            string titleText,
            string explanationText,
            string okText,
            string cancelText
        ) : base(titleText, explanationText)
        {
            OkText = okText;
            CancelText = cancelText;
        }
    }

    public class Factory : PlaceholderFactory<ConfirmPopup>
    {
    }
}