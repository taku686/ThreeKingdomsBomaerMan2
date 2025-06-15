using UnityEngine;

public class CommonView : MonoBehaviour
{
    public GameObject commonCanvas;

    public GameObject waitPopup;

    // public RewardPopup _rewardPopup;
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
        purchaseErrorView.gameObject.SetActive(false);
        errorView.gameObject.SetActive(false);
        virtualCurrencyView.gameObject.SetActive(false);
        if (_popupParent != null)
        {
            _popupParent.SetActive(true);
        }

        SetCharacterStageActive(true);
        SetGachaStageActive(false);
    }

    public void SetCharacterStageActive(bool isActive)
    {
        if (_characterStage == null)
        {
            return;
        }

        _characterStage.SetActive(isActive);
    }

    public void SetGachaStageActive(bool isActive)
    {
        if (_gachaStage == null)
        {
            return;
        }

        _gachaStage.SetActive(isActive);
    }
}