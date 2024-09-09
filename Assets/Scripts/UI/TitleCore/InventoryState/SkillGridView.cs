using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class SkillGridView : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private Button detailButton;

        public void ApplyViewModel(ViewModel viewModel)
        {
            iconImage.sprite = viewModel.Icon;
            skillName.text = viewModel.Name;
        }
        
        public IObservable<Unit> OnClickDetailButtonAsObservable()
        {
            return detailButton.OnClickAsObservable();
        }

        public class ViewModel
        {
            public Sprite Icon { get; }
            public string Name { get; }

            public ViewModel(Sprite icon, string name)
            {
                Icon = icon;
                Name = name;
            }
        }
    }
}