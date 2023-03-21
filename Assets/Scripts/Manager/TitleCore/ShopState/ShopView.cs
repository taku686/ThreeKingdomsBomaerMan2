using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.ShopState
{
    public class ShopView : MonoBehaviour
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
        [SerializeField] private GameObject textGameObject;
        [SerializeField] private RewardGetView rewardGetView;
        public RewardGetView RewardGetView => rewardGetView;
        public Button AdsButton => adsButton;
        public GameObject TextGameObject => textGameObject;
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