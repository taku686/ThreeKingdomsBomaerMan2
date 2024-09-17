using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusGridView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Image upperArrowImage;
    [SerializeField] private Image lowerArrowImage;

    public void SetValueText(int value)
    {
        valueText.text = value.ToString();
        upperArrowImage.gameObject.SetActive(false);
        lowerArrowImage.gameObject.SetActive(false);
    }

    public void SetBuffState(bool isBuff, bool isDebuff, int value)
    {
        var prefValue = int.Parse(valueText.text);
        valueText.DOCounter(prefValue, value, 0.5f);
        upperArrowImage.gameObject.SetActive(isBuff && !isDebuff);
        lowerArrowImage.gameObject.SetActive(isDebuff && !isBuff);
    }

    public void SetDebuffState(bool isDebuff, int value)
    {
        var prefValue = int.Parse(valueText.text);
        valueText.DOCounter(prefValue, value, 0.5f);
        lowerArrowImage.gameObject.SetActive(isDebuff);
    }
}