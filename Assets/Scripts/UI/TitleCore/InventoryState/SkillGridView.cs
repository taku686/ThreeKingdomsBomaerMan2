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

        public Button _DetailButton => detailButton;

        public void ApplyViewModel(ViewModel viewModel)
        {
            if (viewModel == null)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);
            iconImage.sprite = viewModel._Icon;
            skillName.text = viewModel._Name;
        }

        public IObservable<Unit> OnClickDetailButtonAsObservable()
        {
            return detailButton.OnClickAsObservable();
        }

        public class ViewModel
        {
            public Sprite _Icon { get; }
            public string _Name { get; }

            public ViewModel(Sprite icon, string name)
            {
                _Icon = icon;
                _Name = name;
            }
        }
    }
}