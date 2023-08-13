using UnityEngine;

public class CommonView : MonoBehaviour
{
    public GameObject commonCanvas;
    public GameObject waitPopup;
    public RewardGetView rewardGetView;
    public PurchaseErrorView purchaseErrorView;
    public ErrorView errorView;
    public VirtualCurrencyView virtualCurrencyView;

    public void Initialize()
    {
        commonCanvas.gameObject.SetActive(true);
        waitPopup.SetActive(false);
        rewardGetView.gameObject.SetActive(false);
        purchaseErrorView.gameObject.SetActive(false);
        errorView.gameObject.SetActive(false);
        virtualCurrencyView.gameObject.SetActive(false);
    }
}