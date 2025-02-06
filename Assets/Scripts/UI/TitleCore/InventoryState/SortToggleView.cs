using System;
using Repository;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class SortToggleView : MonoBehaviour
    {
        [SerializeField] private WeaponSortRepository.SortType _sortType;
        [SerializeField] private Button _sortButton;

        public IObservable<(WeaponSortRepository.SortType, bool)> _OnClickSortButtonAsObservable => _sortButton
            .OnClickAsObservable()
            .Select(_ => (_sortType, _sortButton.interactable));

        public void SetActive(WeaponSortRepository.SortType sortType, bool isActive)
        {
            if (_sortType != sortType) return;
            _sortButton.interactable = isActive;
        }
    }
}