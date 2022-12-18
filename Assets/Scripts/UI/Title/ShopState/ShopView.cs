using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.ShopState
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button thousandCoinButton;
        [SerializeField] private GameObject textGameObject;

        public GameObject TextGameObject => textGameObject;

        public Button BackButton => backButton;
        public Button ThousandCoinButton => thousandCoinButton;
    }
}