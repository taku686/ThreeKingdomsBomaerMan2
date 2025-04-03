using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardGetView : MonoBehaviour
{
    public Image rewardImage;
    public Button okButton;
    public TextMeshProUGUI rewardText;

    private void OnEnable()
    {
        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(() => { gameObject.SetActive(false); });
    }
}