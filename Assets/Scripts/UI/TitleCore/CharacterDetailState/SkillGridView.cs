using System;
using Common.Data;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SkillGridView : MonoBehaviour
{
    [SerializeField] private GameObject releaseObject;
    [SerializeField] private GameObject lockObject;
    [SerializeField] private Image skillImage;
    [SerializeField] private TextMeshProUGUI _lvText;
    [SerializeField] private Button _skillButton;
    public IObservable<Button> _OnClickSkillButtonAsObservable => _skillButton.OnClickAsObservable().Select(_ => _skillButton);

    public void ApplyViewModel(bool isRelease, Sprite skillSprite, int releaseLv)
    {
        if (releaseLv != GameCommonData.InvalidNumber && _lvText != null)
        {
            _lvText.text = "Lv" + releaseLv;
        }

        releaseObject.SetActive(isRelease);
        lockObject.SetActive(!isRelease);

        if (!isRelease || skillSprite == null)
        {
            return;
        }

        skillImage.sprite = skillSprite;
    }
}