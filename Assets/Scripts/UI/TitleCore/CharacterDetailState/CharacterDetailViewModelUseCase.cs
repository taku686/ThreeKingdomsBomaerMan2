using System;
using Common.Data;
using Manager.DataManager;
using Repository;
using UI.Common;
using UI.Title;
using UnityEngine;
using Zenject;

public class CharacterDetailViewModelUseCase : IDisposable
{
    private readonly UserDataRepository _userDataRepository;
    private readonly CharacterMasterDataRepository _characterMasterDataRepository;
    private readonly CharacterTypeSpriteManager _characterTypeSpriteManager;
    private readonly SkillMasterDataRepository _skillMasterDataRepository;
    private readonly WeaponCautionRepository _weaponCautionRepository;

    [Inject]
    public CharacterDetailViewModelUseCase
    (
        UserDataRepository userDataRepository,
        CharacterMasterDataRepository characterMasterDataRepository,
        CharacterTypeSpriteManager characterTypeSpriteManager,
        SkillMasterDataRepository skillMasterDataRepository,
        WeaponCautionRepository weaponCautionRepository
    )
    {
        _userDataRepository = userDataRepository;
        _characterMasterDataRepository = characterMasterDataRepository;
        _characterTypeSpriteManager = characterTypeSpriteManager;
        _skillMasterDataRepository = skillMasterDataRepository;
        _weaponCautionRepository = weaponCautionRepository;
    }

    public CharacterDetailView.ViewModel InAsTask(int characterId, bool isTeamEdit)
    {
        var characterData = _characterMasterDataRepository.GetCharacterData(characterId);
        var currentLevelData = _userDataRepository.GetCurrentLevelData(characterId);
        var nextLevelData = _userDataRepository.GetNextLevelData(characterId);
        var skillsViewModel = CreateSkillsViewModel(characterId, currentLevelData.Level);
        var weaponData = _userDataRepository.GetEquippedWeaponData(characterId);
        var (typeSprite, typeColor) = _characterTypeSpriteManager.GetCharacterTypeData(characterData.Type);
        var passiveSkillData = _skillMasterDataRepository.GetSkillData(characterData.PassiveSkillId);
        var teamMembers = _userDataRepository.GetTeamMembers();
        var isCaution = _weaponCautionRepository.HaveCaution();
        return new CharacterDetailView.ViewModel
        (
            characterData,
            currentLevelData,
            nextLevelData,
            skillsViewModel,
            weaponData,
            typeSprite,
            typeColor,
            passiveSkillData,
            isTeamEdit,
            teamMembers,
            isCaution
        );
    }

    private SkillsView.ViewModel CreateSkillsViewModel(int characterId, int characterLevel)
    {
        var weaponData = _userDataRepository.GetEquippedWeaponData(characterId);
        var normalSkillSprite = weaponData.NormalSkillMasterData?.Sprite;
        var specialSkillSprite = weaponData.SpecialSkillMasterData?.Sprite;

        return new SkillsView.ViewModel
        (
            normalSkillSprite,
            specialSkillSprite,
            characterLevel
        );
    }


    public void Dispose()
    {
    }
}