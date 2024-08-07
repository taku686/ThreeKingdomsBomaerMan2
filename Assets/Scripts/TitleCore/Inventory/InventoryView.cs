using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : ViewBase
{
    [SerializeField] private Button backButton;
    
    public IObservable<Unit> ClickedBackButton => backButton.OnClickAsObservable();
}