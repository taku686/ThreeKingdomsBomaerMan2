using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class SortPopupView : MonoBehaviour
    {
        [SerializeField] private Button _okButton;
        [SerializeField] private SortToggleView[] _sortToggleViews;
        [SerializeField] private WeaponFilterToggleView[] _filterToggleViews;
        [SerializeField] private RareFilterToggleView[] _rareFilterToggleViews;
        [SerializeField] private SwitchView _ascendingSwitchView;

        public IObservable<Button> _OnClickOkButtonAsObservable => _okButton.OnClickAsObservable().Select(_ => _okButton);
        public IObservable<bool> _OnChangeAscendingToggleAsObservable => _ascendingSwitchView._OnChangeAscendingToggleAsObservable;
        public SortToggleView[] _SortToggleViews => _sortToggleViews;
        public WeaponFilterToggleView[] _FilterToggleViews => _filterToggleViews;
        public RareFilterToggleView[] _RareFilterToggleViews => _rareFilterToggleViews;

        public void ApplyAscendingSwitch(bool isOn)
        {
            _ascendingSwitchView.ApplyViewModel(isOn);
        }
    }
}