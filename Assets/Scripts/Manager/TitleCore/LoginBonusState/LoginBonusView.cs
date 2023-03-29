using UnityEngine;
using UnityEngine.UI;

public class LoginBonusView : MonoBehaviour
{
    public Button[] buttons = new Button[7];
    public Image[] clearImages = new Image[7];
    public Button closeButton;
    public GameObject focusObj;
    public PurchaseErrorView purchaseErrorView;
    public RewardGetView rewardGetView;
}