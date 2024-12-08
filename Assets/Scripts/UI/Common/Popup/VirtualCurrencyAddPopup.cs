using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class VirtualCurrencyAddPopup : MonoBehaviour
{
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button addButton;
    [SerializeField] private Button closeButton;

    public IObservable<Unit> OnClickCancelButton => cancelButton.OnClickAsObservable();
    public IObservable<Unit> OnClickAddButton => addButton.OnClickAsObservable();
    public IObservable<Unit> OnClickCloseButton => closeButton.OnClickAsObservable();
    public Button CancelButton => cancelButton;
    public Button AddButton => addButton;
    public Button CloseButton => closeButton;
}