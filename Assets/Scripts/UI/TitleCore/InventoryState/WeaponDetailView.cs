using Common.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class WeaponDetailView : MonoBehaviour
    {
        [SerializeField] private Image weaponIcon;
        [SerializeField] private TextMeshProUGUI weaponName;
        [SerializeField] private SkillGridView statusSkillGridView;
        [SerializeField] private SkillGridView normalSkillGridView;
        [SerializeField] private SkillGridView specialSkillGridView;
        [SerializeField] private Button equipButton;
        [SerializeField] private Button sellButton;
        
        public Button EquipButton => equipButton;
        public Button SellButton => sellButton;

        public void ApplyViewModel(ViewModel viewModel)
        {
            weaponIcon.sprite = viewModel.Icon;
            weaponName.text = viewModel.Name;
            var statusSkillViewModel = TranslateSkillDataToViewModel(viewModel.StatusSkillMasterData);
            var normalSkillViewModel = TranslateSkillDataToViewModel(viewModel.NormalSkillMasterData);
            var specialSkillViewModel = TranslateSkillDataToViewModel(viewModel.SpecialSkillMasterData);
            statusSkillGridView.ApplyViewModel(statusSkillViewModel);
            normalSkillGridView.ApplyViewModel(normalSkillViewModel);
            specialSkillGridView.ApplyViewModel(specialSkillViewModel);
        }

        private SkillGridView.ViewModel TranslateSkillDataToViewModel(SkillMasterData skillMasterData)
        {
            return new SkillGridView.ViewModel(skillMasterData.Icon, skillMasterData.Name, skillMasterData.Explanation);
        }

        public class ViewModel
        {
            public Sprite Icon { get; }
            public string Name { get; }
            public SkillMasterData StatusSkillMasterData { get; }
            public SkillMasterData NormalSkillMasterData { get; }
            public SkillMasterData SpecialSkillMasterData { get; }

            public ViewModel
            (
                Sprite icon,
                string name,
                SkillMasterData statusSkillMasterData,
                SkillMasterData normalSkillMasterData,
                SkillMasterData specialSkillMasterData
            )
            {
                Icon = icon;
                Name = name;
                StatusSkillMasterData = statusSkillMasterData;
                NormalSkillMasterData = normalSkillMasterData;
                SpecialSkillMasterData = specialSkillMasterData;
            }
        }
    }
}