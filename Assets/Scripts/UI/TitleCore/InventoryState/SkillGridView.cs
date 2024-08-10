using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class SkillGridView : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private TextMeshProUGUI explanation;

        public void ApplyViewModel(ViewModel viewModel)
        {
            iconImage.sprite = viewModel.Icon;
            skillName.text = viewModel.Name;
            explanation.text = viewModel.Explanation;
        }

        public class ViewModel
        {
            public Sprite Icon { get; }
            public string Name { get; }
            public string Explanation { get; }

            public ViewModel(Sprite icon, string name, string explanation)
            {
                Icon = icon;
                Name = name;
                Explanation = explanation;
            }
        }
    }
}