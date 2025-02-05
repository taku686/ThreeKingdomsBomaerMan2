using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class SortView : MonoBehaviour
    {
        [SerializeField] private Button _okButton;

        public IObservable<Button> _OnClickOkButtonAsObservable => _okButton
            .OnClickAsObservable()
            .Select(_ => _okButton);

        public void ApplyViewModel()
        {
        }
    }
}