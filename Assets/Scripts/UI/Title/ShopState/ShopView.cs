using UnityEngine;
using UnityEngine.UI;

namespace UI.Title.ShopState
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button thousandCoinButton;

        public Button BackButton => backButton;
        public Button ThousandCoinButton => thousandCoinButton;
    }
}