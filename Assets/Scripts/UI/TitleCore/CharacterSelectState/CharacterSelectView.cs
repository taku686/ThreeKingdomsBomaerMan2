using System;
using TMPro;
using UI.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterSelectView : ViewBase
    {
        [SerializeField] private Button backButton;
        [SerializeField] private GameObject horizontalGroupGameObject;
        [SerializeField] private GameObject grid;
        [SerializeField] private GameObject gridDisable;
        [SerializeField] private RectTransform contentsTransform;
        [SerializeField] private VirtualCurrencyAddPopup virtualCurrencyAddPopup;
        [SerializeField] private TextMeshProUGUI characterAmountText;
        [SerializeField] private ToggleView toggleView;

        public Button _BackButton => backButton;
        public GameObject _HorizontalGroupGameObject => horizontalGroupGameObject;
        public GameObject _Grid => grid;
        public GameObject _GridDisable => gridDisable;
        public RectTransform _ContentsTransform => contentsTransform;
        public ToggleElement[] _ToggleElements => toggleView.ToggleElements;

        public void ApplyViewModel(ViewModel viewModel)
        {
            var availableAmount = viewModel._AvailableAmount;
            var totalAmount = viewModel._TotalAmount;
            var orderType = viewModel._OrderType;
            SetCharacterAmount(availableAmount, totalAmount);
            ApplyToggleView(orderType);
        }

        private void SetCharacterAmount(int availableAmount, int totalAmount)
        {
            characterAmountText.text = $"{availableAmount} <#6b87a3>/ {totalAmount}";
        }

        public void InitializeUiPosition()
        {
            contentsTransform.anchoredPosition = new Vector2(contentsTransform.anchoredPosition.x, 0);
        }

        public void ApplyToggleView(CharacterSelectRepository.OrderType orderType)
        {
            toggleView.ApplyView(orderType);
        }

        public class ViewModel
        {
            public int _AvailableAmount { get; }
            public int _TotalAmount { get; }
            public CharacterSelectRepository.OrderType _OrderType { get; }


            public ViewModel
            (
                int availableAmount,
                int totalAmount,
                CharacterSelectRepository.OrderType orderType
            )
            {
                _AvailableAmount = availableAmount;
                _TotalAmount = totalAmount;
                _OrderType = orderType;
            }
        }
    }
}