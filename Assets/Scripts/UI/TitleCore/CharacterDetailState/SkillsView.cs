using System;
using Common.Data;
using UnityEngine;
using UnityEngine.UI;

public class SkillsView : MonoBehaviour
{
    [SerializeField] private SkillGridView normalSkillGridView;
    [SerializeField] private SkillGridView specialSkillGridView;
    [SerializeField] private SkillGridView _weaponSkillGridView;

    public IObservable<Button> _OnClickNormalSkillButtonAsObservable => normalSkillGridView._OnClickSkillButtonAsObservable;
    public IObservable<Button> _OnClickSpecialSkillButtonAsObservable => specialSkillGridView._OnClickSkillButtonAsObservable;
    public IObservable<Button> _OnClickWeaponSkillButtonAsObservable => _weaponSkillGridView._OnClickSkillButtonAsObservable;

    public void ApplyViewModel(ViewModel viewModel)
    {
        var isNormalSkillActive = viewModel._CharacterLevel >= GameCommonData.NormalSkillReleaseLevel;
        var isSpecialSkillActive = viewModel._CharacterLevel >= GameCommonData.SpecialSkillReleaseLevel;
        var isWeaponSkillActive = viewModel._WeaponImage != null;
        normalSkillGridView.ApplyViewModel(isNormalSkillActive, viewModel._NormalImage, GameCommonData.NormalSkillReleaseLevel);
        specialSkillGridView.ApplyViewModel(isSpecialSkillActive, viewModel._SpecialImage, GameCommonData.SpecialSkillReleaseLevel);
        _weaponSkillGridView.ApplyViewModel(isWeaponSkillActive, viewModel._WeaponImage, GameCommonData.InvalidNumber);
    }

    public class ViewModel
    {
        public Sprite _NormalImage { get; }
        public Sprite _SpecialImage { get; }
        public Sprite _WeaponImage { get; }
        public int _CharacterLevel { get; }

        public ViewModel
        (
            Sprite normalImage,
            Sprite specialImage,
            Sprite weaponImage,
            int characterLevel
        )
        {
            _NormalImage = normalImage;
            _SpecialImage = specialImage;
            _WeaponImage = weaponImage;
            _CharacterLevel = characterLevel;
        }
    }
}