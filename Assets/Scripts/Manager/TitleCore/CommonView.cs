using UnityEngine;

public class CommonView : MonoBehaviour
{
    public GameObject waitPopup;
    public RewardGetView rewardGetView;
    public PurchaseErrorView purchaseErrorView;
    public ErrorView errorView;

    public void Initialize()
    {
        waitPopup.SetActive(false);
        rewardGetView.gameObject.SetActive(false);
        purchaseErrorView.gameObject.SetActive(false);
        errorView.gameObject.SetActive(false);
    }
}