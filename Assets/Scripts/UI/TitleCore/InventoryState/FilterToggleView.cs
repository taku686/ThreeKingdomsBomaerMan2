using System;
using Repository;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class FilterToggleView : MonoBehaviour
    {
        [SerializeField] private WeaponSortRepository.FilterType _filterType;
        [SerializeField] private Button _filterButton;

        public IObservable<(WeaponSortRepository.FilterType, bool)> _OnClickFilterButtonAsObservable => _filterButton
            .OnClickAsObservable()
            .Select(_ => (_filterType, _filterButton.interactable));

        public void SetActive(WeaponSortRepository.FilterType filterType, bool isActive)
        {
            if (_filterType != filterType) return;
            _filterButton.interactable = isActive;
        }
    }
}