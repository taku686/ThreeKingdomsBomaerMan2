using System;
using System.Diagnostics;
using Common.Data;
using TMPro;
using UniRx;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class FilterToggleView : MonoBehaviour
    {
        [SerializeField] private WeaponType _filterType;
        [SerializeField] private GameObject _onObj;
        [SerializeField] private GameObject _offObj;
        private TextMeshProUGUI _label;
        private Toggle _filterToggle;

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
        }

        private string Translate()
        {
            return _filterType switch
            {
                WeaponType.Sword => "剣",
                WeaponType.Axe => "斧",
                WeaponType.Spear => "槍",
                WeaponType.Bow => "弓",
                WeaponType.Staff => "杖",
                WeaponType.Shield => "盾",
                WeaponType.Knife => "短剣",
                WeaponType.BigSword => "大剣",
                WeaponType.Scythe => "鎌",
                WeaponType.Fan => "扇",
                WeaponType.Hammer => "ハンマー",
                WeaponType.None => "なし",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}