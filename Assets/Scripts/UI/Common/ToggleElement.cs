using System;
using UI.Title;
using UniRx;
using UnityEngine;
using UnityEngine.UI;


public class ToggleElement : MonoBehaviour
{
    [SerializeField] private Button onButton;
    [SerializeField] private Button offButton;
    [SerializeField] private TemporaryCharacterRepository.OrderType orderType;

    public IObservable<TemporaryCharacterRepository.OrderType> ClickOffButtonObservable =>
        offButton.OnClickAsObservable().Select(_ => orderType);

    public TemporaryCharacterRepository.OrderType OrderType => orderType;

    public void SetActive(bool isActive)
    {
        onButton.gameObject.SetActive(isActive);
        offButton.gameObject.SetActive(!isActive);
    }
}