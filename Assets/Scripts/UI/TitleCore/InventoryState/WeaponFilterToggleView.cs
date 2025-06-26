using System;
using Common.Data;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class WeaponFilterToggleView : MonoBehaviour
    {
        [SerializeField] private WeaponType _filterType;
        [SerializeField] private GameObject _onObj;
        [SerializeField] private GameObject _offObj;
        [SerializeField] private TextMeshProUGUI _filterText;
        private Toggle _filterToggle;
        private static readonly Color OffColor = new(0.784f, 0.784f, 0.784f, 0.5f);

        public void Initialize()
        {
            if (_filterToggle == null) _filterToggle = GetComponent<Toggle>();
        }

        public IObservable<WeaponType> _OnChangedValueFilterToggleAsObservable => _filterToggle
            .OnValueChangedAsObservable()
            .Select(_ => _filterType);

        public void SetActive(WeaponType filterType, bool isDisable)
        {
            if (_filterType != filterType) return;
            _onObj.SetActive(!isDisable);
            _offObj.SetActive(isDisable);
            if (_filterType == WeaponType.None)
            {
                _filterText.color = isDisable ? OffColor : Color.white;
            }
        }
    }
}