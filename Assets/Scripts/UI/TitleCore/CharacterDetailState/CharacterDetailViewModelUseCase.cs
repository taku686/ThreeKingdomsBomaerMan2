using System;
using Common.Data;
using Manager.DataManager;
using UI.Common;
using UI.Title;
using UnityEngine;
using Zenject;

public class CharacterDetailViewModelUseCase : IDisposable
{
    private readonly UserDataRepository _userDataRepository;
    private readonly CharacterMasterDataRepository _characterMasterDataRepository;
    private readonly CharacterTypeManager _characterTypeManager;
    private readonly SkillMasterDataRepository _skillMasterDataRepository;

    [Inject]
    public CharacterDetailViewModelUseCase
    (
        UserDataRepository userDataRepository,
        CharacterMasterDataRepository characterMasterDataRepository,
        CharacterTypeManager characterTypeManager,
        SkillMasterDataRepository skillMasterDataRepository
    )
    {
        _userDataRepository = userDataRepository;
        _characterMasterDataRepository = characterMasterDataRepository;
        _characterTypeManager = characterTypeManager;
        _skillMasterDataRepository = skillMasterDataRepository;
    }

    public CharacterDetailView.ViewModel InAsTask(int characterId)
    {
        var characterData = _characterMasterDataRepository.GetCharacterData(characterId);
        var currentLevelData = _userDataRepository.GetCurrentLevelData(characterId);
        var nextLevelData = _userDataRepository.GetNextLevelData(characterId);
        var skillsViewModel = CreateSkillsViewModel(characterId, currentLevelData.Level);
        var weaponData = _userDataRepository.GetEquippedWeaponData(characterId);
        var (typeSprite, typeColor) = _characterTypeManager.GetCharacterTypeData(characterData.Type);
        var passiveSkillData = _skillMasterDataRepository.GetSkillData(characterData.PassiveSkillId);
        return new CharacterDetailView.ViewModel
        (
            characterData,
            currentLevelData,
            nextLevelData,
            skillsViewModel,
            weaponData,
            typeSprite,
            typeColor,
            passiveSkillData
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