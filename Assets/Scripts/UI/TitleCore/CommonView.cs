using UnityEngine;

public class CommonView : MonoBehaviour
{
    public GameObject commonCanvas;
    public GameObject waitPopup;
    public RewardGetView rewardGetView;
    public PurchaseErrorView purchaseErrorView;
    public ErrorView errorView;
    public VirtualCurrencyView virtualCurrencyView;
    [SerializeField] private GameObject _popupParent;
    [SerializeField] private GameObject _characterStage;
    [SerializeField] private GameObject _gachaStage;

    public void Initialize()
    {
        commonCanvas.gameObject.SetActive(true);
        waitPopup.SetActive(false);
        rewardGetView.gameObject.SetActive(false);
        purchaseErrorView.gameObject.SetActive(false);
        errorView.gameObject.SetActive(false);
        virtualCurrencyView.gameObject.SetActive(false);
        _popupParent.SetActive(true);
        SetCharacterStageActive(true);
        SetGachaStageActive(false);
    }

    public void SetCharacterStageActive(bool isActive)
    {
        _characterStage.SetActive(isActive);
    }

    public void SetGachaStageActive(bool isActive)
    {
        _gachaStage.SetActive(isActive);
    }
}