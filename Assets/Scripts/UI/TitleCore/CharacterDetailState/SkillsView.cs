using Common.Data;
using UnityEngine;

public class SkillsView : MonoBehaviour
{
    [SerializeField] SkillGridView statusSkillGridView;
    [SerializeField] SkillGridView normalSkillGridView;
    [SerializeField] SkillGridView specialSkillGridView;

    public void ApplyViewModel(ViewModel viewModel)
    {
        var isStatusSkillActive = viewModel.CharacterLevel >= GameCommonData.StatusSkillReleaseLevel;
        var isNormalSkillActive = viewModel.CharacterLevel >= GameCommonData.NormalSkillReleaseLevel;
        var isSpecialSkillActive = viewModel.CharacterLevel >= GameCommonData.SpecialSkillReleaseLevel;
        statusSkillGridView.ApplyViewModel(isStatusSkillActive, viewModel.StatusImage);
        normalSkillGridView.ApplyViewModel(isNormalSkillActive, viewModel.NormalImage);
        specialSkillGridView.ApplyViewModel(isSpecialSkillActive, viewModel.SpecialImage);
    }

    public class ViewModel
    {
        public Sprite StatusImage { get; }
        public Sprite NormalImage { get; }
        public Sprite SpecialImage { get; }
        public int CharacterLevel { get; }

        public ViewModel
        (
            Sprite statusImage,
            Sprite normalImage,
            Sprite specialImage,
            int characterLevel
        )
        {
            StatusImage = statusImage;
            NormalImage = normalImage;
            SpecialImage = specialImage;
            CharacterLevel = characterLevel;
        }
    }
}