using System;
using Cysharp.Threading.Tasks;
using UI.Common;
using UniRx;
using UnityEngine.UI;
using Zenject;

public class PopupGenerateUseCase : IDisposable
{
    [Inject] private ConfirmPopup.Factory _confirmPopupFactory;
    [Inject] private InputNamePopup.Factory _inputNamePopupFactory;
    [Inject] private ErrorPopup.Factory _errorPopupFactory;

    public IObservable<bool> GenerateConfirmPopup
    (
        string title,
        string explanation,
        string okText = "はい",
        string cancelText = "いいえ"
    )
    {
        var viewModel = new ConfirmPopup.ViewModel(title, explanation, okText, cancelText);
        var confirmPopup = _confirmPopupFactory.Create();
        confirmPopup.Open(viewModel).Forget();
        return confirmPopup._OnClickButton;
    }

    public IObservable<string> GenerateInputNamePopup
    (
        string title,
        string explanation,
        string okText = "決定"
    )
    {
        var viewModel = new InputNamePopup.ViewModel(title, explanation, okText);
        var inputNamePopup = _inputNamePopupFactory.Create();
        inputNamePopup.Open(viewModel).Forget();
        return inputNamePopup._OnClickButton;
    }

    public IObservable<Unit> GenerateErrorPopup
    (
        string explanation,
        string title = "エラー",
        string okText = "OK"
    )
    {
        var viewModel = new SingleButtonPopup.ViewModel(title, explanation, okText);
        var errorPopup = _errorPopupFactory.Create();
        errorPopup.Open(viewModel).Forget();
        return errorPopup._OnClickButton;
    }

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}