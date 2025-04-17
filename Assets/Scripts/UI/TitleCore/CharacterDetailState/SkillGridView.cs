using System;
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
        if (skillSprite == null)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        releaseObject.SetActive(isRelease);
        lockObject.SetActive(!isRelease);
        _lvText.text = "Lv" + releaseLv;
        if (!isRelease)
        {
            return;
        }

        skillImage.sprite = skillSprite;
    }
}