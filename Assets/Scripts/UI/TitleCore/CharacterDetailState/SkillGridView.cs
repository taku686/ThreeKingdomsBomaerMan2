using UnityEngine;
using UnityEngine.UI;

public class SkillGridView : MonoBehaviour
{
    [SerializeField] private GameObject releaseObject;
    [SerializeField] private GameObject lockObject;
    [SerializeField] private Image skillImage;

    public void ApplyViewModel(bool isRelease, Sprite skillSprite)
    {
        releaseObject.SetActive(isRelease);
        lockObject.SetActive(!isRelease);
        if (!isRelease)
        {
            return;
        }

        skillImage.sprite = skillSprite;
    }
}