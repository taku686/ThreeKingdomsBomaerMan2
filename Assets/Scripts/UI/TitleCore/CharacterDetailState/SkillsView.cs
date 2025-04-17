using System;
using Common.Data;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SkillsView : MonoBehaviour
{
    [SerializeField] SkillGridView normalSkillGridView;
    [SerializeField] SkillGridView specialSkillGridView;

    public IObservable<Button> _OnClickNormalSkillButtonAsObservable => normalSkillGridView._OnClickSkillButtonAsObservable;
    public IObservable<Button> _OnClickSpecialSkillButtonAsObservable => specialSkillGridView._OnClickSkillButtonAsObservable;

    public void ApplyViewModel(ViewModel viewModel)
    {
        var isNormalSkillActive = viewModel._CharacterLevel >= GameCommonData.NormalSkillReleaseLevel;
        var isSpecialSkillActive = viewModel._CharacterLevel >= GameCommonData.SpecialSkillReleaseLevel;
        normalSkillGridView.ApplyViewModel(isNormalSkillActive, viewModel._NormalImage, GameCommonData.NormalSkillReleaseLevel);
        specialSkillGridView.ApplyViewModel(isSpecialSkillActive, viewModel._SpecialImage, GameCommonData.SpecialSkillReleaseLevel);
    }

    public class ViewModel
    {
        public Sprite _NormalImage { get; }
        public Sprite _SpecialImage { get; }
        public int _CharacterLevel { get; }

        public ViewModel
        (
            Sprite normalImage,
            Sprite specialImage,
            int characterLevel
        )
        {
            _NormalImage = normalImage;
            _SpecialImage = specialImage;
            _CharacterLevel = characterLevel;
        }
    }
}