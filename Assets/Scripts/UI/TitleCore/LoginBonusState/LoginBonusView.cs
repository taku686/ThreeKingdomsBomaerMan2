using UnityEngine;
using UnityEngine.UI;

namespace TitleCore.LoginBonusState
{
    public class LoginBonusView : ViewBase
    {
        public Button[] buttons = new Button[7];
        public Image[] clearImages = new Image[7];
        public Button closeButton;
        public GameObject focusObj;
        public PurchaseErrorView purchaseErrorView;
        public RewardPopup _rewardPopup;
    }
}