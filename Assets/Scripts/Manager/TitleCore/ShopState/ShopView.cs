using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.ShopState
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button thousandCoinButton;
        [SerializeField] private Button adsButton;
        [SerializeField] private GameObject textGameObject;
        public Button AdsButton => adsButton;
        public GameObject TextGameObject => textGameObject;

        public Button BackButton => backButton;
        public Button ThousandCoinButton => thousandCoinButton;
    }
}