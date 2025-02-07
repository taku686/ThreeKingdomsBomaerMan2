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

        public IObservable<WeaponSortRepository.SortType> _OnClickSortButtonAsObservable =>
            _sortButton
                .OnClickAsObservable()
                .Select(_ => _sortType);

        public void SetActive(WeaponSortRepository.SortType sortType, bool isDisable)
        {
            if (_sortType != sortType) return;
            _sortButton.interactable = !isDisable;
        }
    }
}