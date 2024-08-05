using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterSelectView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private GameObject horizontalGroupGameObject;
        [SerializeField] private GameObject grid;
        [SerializeField] private GameObject gridDisable;
        [SerializeField] private RectTransform contentsTransform;
        [SerializeField] private VirtualCurrencyAddPopup virtualCurrencyAddPopup;
        [SerializeField] private TextMeshProUGUI characterAmountText;

        public VirtualCurrencyAddPopup VirtualCurrencyAddPopup => virtualCurrencyAddPopup;
        public Button BackButton => backButton;
        public IObservable<Unit> OnClickBackButton => backButton.OnClickAsObservable();

        public GameObject HorizontalGroupGameObject => horizontalGroupGameObject;

        public GameObject Grid => grid;

        public GameObject GridDisable => gridDisable;

        public RectTransform ContentsTransform => contentsTransform;

        public void ApplyViewModel(ViewModel viewModel)
        {
            var availableAmount = viewModel.AvailableAmount;
            var totalAmount = viewModel.TotalAmount;
            SetCharacterAmount(availableAmount, totalAmount);
        }

        private void SetCharacterAmount(int availableAmount, int totalAmount)
        {
            characterAmountText.text = $"{availableAmount} <#6b87a3>/ {totalAmount}";
        }

        public void InitializeUiPosition()
        {
            contentsTransform.anchoredPosition = new Vector2(contentsTransform.anchoredPosition.x, 0);
        }

        public class ViewModel
        {
            public int AvailableAmount { get; }
            public int TotalAmount { get; }

            public ViewModel
            (
                int availableAmount,
                int totalAmount
            )
            {
                AvailableAmount = availableAmount;
                TotalAmount = totalAmount;
            }
        }
    }
}