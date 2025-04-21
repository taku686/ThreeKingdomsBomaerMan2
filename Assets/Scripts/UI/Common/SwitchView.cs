using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SwitchView : MonoBehaviour
{
    [SerializeField] private GameObject _onObj;
    [SerializeField] private GameObject _offObj;
    [SerializeField] private Toggle _switchToggle;

    public IObservable<bool> _OnChangeAscendingToggleAsObservable => _switchToggle.OnValueChangedAsObservable();

    public void ApplyViewModel(bool isOn)
    {
        _switchToggle.SetIsOnWithoutNotify(isOn);
        _onObj.SetActive(isOn);
        _offObj.SetActive(!isOn);
    }
}