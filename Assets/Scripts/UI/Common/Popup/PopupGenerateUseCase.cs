using System;
using Cysharp.Threading.Tasks;
using Zenject;

public class PopupGenerateUseCase : IDisposable
{
    [Inject] private ConfirmPopup.Factory _confirmPopupFactory;

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

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}