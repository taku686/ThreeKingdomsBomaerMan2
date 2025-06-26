using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusGridView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Image upperArrowImage;
    [SerializeField] private Image lowerArrowImage;
    private int _originValue;

    public void SetValueText(int value)
    {
        valueText.text = value.ToString();
        _originValue = value;
        upperArrowImage.gameObject.SetActive(false);
        lowerArrowImage.gameObject.SetActive(false);
    }

    public void SetBuffState(int value)
    {
        var isEqual = value == _originValue;
        var isBuff = value > _originValue;
        var prefValue = int.Parse(valueText.text);
        valueText.DOCounter(prefValue, value, 0.5f);
        upperArrowImage.gameObject.SetActive(isBuff && !isEqual);
        lowerArrowImage.gameObject.SetActive(!isBuff && !isEqual);
    }
}