using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetailView : MonoBehaviour
{
    [SerializeField] private Image skillIcon;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private Button closeButton;

    public IObservable<Unit> OnClickCloseButtonAsObservable()
    {
        return closeButton.OnClickAsObservable();
        
    }
    public void ApplyViewModel(ViewModel viewModel)
    {
        gameObject.SetActive(true);
        skillIcon.sprite = viewModel.SkillIcon;
        skillName.text = viewModel.SkillName;
        skillDescription.text = viewModel.SkillDescription;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public class ViewModel
    {
        public Sprite SkillIcon { get; }
        public string SkillName { get; }
        public string SkillDescription { get; }

        public ViewModel
        (
            Sprite skillIcon,
            string skillName,
            string skillDescription
        )
        {
            SkillIcon = skillIcon;
            SkillName = skillName;
            SkillDescription = skillDescription;
        }
    }
}