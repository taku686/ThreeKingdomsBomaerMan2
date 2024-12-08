using System;
using Cysharp.Threading.Tasks;
using Zenject;

public class PopupGenerateUseCase : IDisposable
{
    [Inject] private ConfirmPopup.Factory _confirmPopupFactory;

    public async UniTask GenerateConfirmPopup
    (
        string title,
        string explanation,
        string okText = "はい",
        string cancelText = "いいえ",
        Action okAction = null,
        Action cancelAction = null
    )
    {
        var viewModel = new ConfirmPopup.ViewModel(title, explanation, okText, cancelText);
        var confirmPopup = _confirmPopupFactory.Create();
        await confirmPopup.Open(viewModel, okAction, cancelAction);
    }

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}