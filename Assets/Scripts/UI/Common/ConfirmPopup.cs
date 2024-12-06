using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPopup : PopupBase
{
    [SerializeField]
    private Button okButton;
    [SerializeField]
    private Button cancelButton;
    
    public IObservable<Unit> OnClickOkButtonAsObservable()
    {
        return okButton.OnClickAsObservable();
    }
    
    public IObservable<Unit> OnClickCancelButtonAsObservable()
    {
        return cancelButton.OnClickAsObservable();
    }
}