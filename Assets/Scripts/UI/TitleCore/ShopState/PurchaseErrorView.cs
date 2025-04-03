using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseErrorView : MonoBehaviour
{
    public Button okButton;
    public TextMeshProUGUI errorInfoText;

    private void OnEnable()
    {
        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(() => { gameObject.SetActive(false); });
    }
}