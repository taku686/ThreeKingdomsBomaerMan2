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
        [SerializeField] private FilterToggleView[] _filterToggleViews;

        public IObservable<Button> _OnClickOkButtonAsObservable => _okButton
            .OnClickAsObservable()
            .Select(_ => _okButton);

        public SortToggleView[] _SortToggleViews => _sortToggleViews;
        public FilterToggleView[] _FilterToggleViews => _filterToggleViews;
    }
}