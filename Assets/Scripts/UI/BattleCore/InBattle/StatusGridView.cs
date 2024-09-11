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

    public void SetBuffState(bool isBuff, int value)
    {
        var prefValue = int.Parse(valueText.text);
        valueText.DOCounter(prefValue, value, 1f);
        upperArrowImage.gameObject.SetActive(isBuff);
    }

    public void SetDebuffState(bool isDebuff, int value)
    {
        var prefValue = int.Parse(valueText.text);
        valueText.DOCounter(prefValue, value, 1f);
        lowerArrowImage.gameObject.SetActive(isDebuff);
    }
}