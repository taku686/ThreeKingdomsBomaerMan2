using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class RareFilterToggleView : MonoBehaviour
    {
        [SerializeField] private int _rarity;
        [SerializeField] private GameObject _onObj;
        [SerializeField] private GameObject _offObj;
        [SerializeField] private TextMeshProUGUI _labelText;
        [SerializeField] private Image _rarityImage;
        private Toggle _filterToggle;
        private static readonly Color OffColor = new(0.784f, 0.784f, 0.784f, 0.5f);

        public void Initialize()
        {
            if (_filterToggle == null) _filterToggle = GetComponent<Toggle>();
        }

        public IObservable<int> _OnChangedValueFilterToggleAsObservable => _filterToggle
            .OnValueChangedAsObservable()
            .Select(_ => _rarity);

        public void SetActive(int rarity, bool isDisable)
        {
            if (rarity != _rarity) return;
            _onObj.SetActive(!isDisable);
            _offObj.SetActive(isDisable);
            _labelText.color = isDisable ? OffColor : Color.white;
            if (_rarityImage == null) return;
            _rarityImage.color = isDisable ? OffColor : Color.white;
        }
    }
}