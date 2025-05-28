using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.ShopState
{
    public class ShopView : ViewBase
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button thousandCoinButton;
        [SerializeField] private Button fiveThousandCoinButton;
        [SerializeField] private Button twelveThousandCoinButton;
        [SerializeField] private Button twentyGemButton;
        [SerializeField] private Button hundredGemButton;
        [SerializeField] private Button twoHundredGemButton;
        [SerializeField] private Button adsButton;
        [SerializeField] private Button gachaButton;
        [SerializeField] private PurchaseErrorView purchaseErrorView;
        [SerializeField] private ShopWeaponGridView _shopWeaponGridView;

        public PurchaseErrorView _PurchaseErrorView => purchaseErrorView;
        public ShopWeaponGridView _ShopWeaponGridView => _shopWeaponGridView;
        public Button _AdsButton => adsButton;
        public Button _GachaButton => gachaButton;
        public Button _BackButton => backButton;
        public IObservable<Unit> _OnClickAddThousandCoin => thousandCoinButton.OnClickAsObservable();
        public Button _FiveThousandCoinButton => fiveThousandCoinButton;
        public Button _TwelveThousandCoinButton => twelveThousandCoinButton;
        public Button _TwentyGemButton => twentyGemButton;
        public Button _HundredGemButton => hundredGemButton;
        public Button _TwoHundredGemButton => twoHundredGemButton;
    }
}