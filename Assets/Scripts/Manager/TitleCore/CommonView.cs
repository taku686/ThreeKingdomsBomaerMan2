using UnityEngine;
using UnityEngine.Serialization;

public class CommonView : MonoBehaviour
{
    public GameObject waitPopup;
    public RewardGetView rewardGetView;
    public PurchaseErrorView purchaseErrorView;

    public void Initialize()
    {
        waitPopup.SetActive(false);
        rewardGetView.gameObject.SetActive(false);
        purchaseErrorView.gameObject.SetActive(false);
    }
}