using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.ShopState
{
    public class Shop : ViewBase
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
        [SerializeField] private RewardGetView rewardGetView;
        [SerializeField] private PurchaseErrorView purchaseErrorView;

        public PurchaseErrorView PurchaseErrorView => purchaseErrorView;
        public RewardGetView RewardGetView => rewardGetView;
        public Button AdsButton => adsButton;
        public Button GachaButton => gachaButton;
        public Button BackButton => backButton;
        public Button ThousandCoinButton => thousandCoinButton;
        public Button FiveThousandCoinButton => fiveThousandCoinButton;
        public Button TwelveThousandCoinButton => twelveThousandCoinButton;
        public Button TwentyGemButton => twentyGemButton;
        public Button HundredGemButton => hundredGemButton;
        public Button TwoHundredGemButton => twoHundredGemButton;
    }
}