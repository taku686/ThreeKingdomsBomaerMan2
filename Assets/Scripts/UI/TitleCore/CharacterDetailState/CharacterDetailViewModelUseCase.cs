using System;
using Common.Data;
using Manager.DataManager;
using Repository;
using UI.Title;
using UnityEngine;
using Zenject;

public class CharacterDetailViewModelUseCase : IDisposable
{
    private readonly UserDataRepository userDataRepository;
    private readonly CharacterMasterDataRepository characterMasterDataRepository;
    private readonly StatusSkillUseCase statusSkillUseCase;

    [Inject]
    public CharacterDetailViewModelUseCase
    (
        UserDataRepository userDataRepository,
        CharacterMasterDataRepository characterMasterDataRepository,
        StatusSkillUseCase statusSkillUseCase
    )
    {
        this.userDataRepository = userDataRepository;
        this.characterMasterDataRepository = characterMasterDataRepository;
        this.statusSkillUseCase = statusSkillUseCase;
    }

    public CharacterDetailView.ViewModel InAsTask(int characterId)
    {
        var characterData = characterMasterDataRepository.GetCharacterData(characterId);
        var currentLevelData = userDataRepository.GetCurrentLevelData(characterId);
        var nextLevelData = userDataRepository.GetNextLevelData(characterId);
        var skillsViewModel = CreateSkillsViewModel(characterId, currentLevelData.Level);
        var weaponData = userDataRepository.GetEquippedWeaponData(characterId);
        return new CharacterDetailView.ViewModel
        (
            characterData,
            currentLevelData,
            nextLevelData,
            skillsViewModel,
            weaponData
        );
    }

    private SkillsView.ViewModel CreateSkillsViewModel(int characterId, int characterLevel)
    {
        var weaponData = userDataRepository.GetEquippedWeaponData(characterId);
        var statusSkillSprite = weaponData.StatusSkillMasterData.Sprite;
        var normalSkillSprite = weaponData.NormalSkillMasterData.Sprite;
        var specialSkillSprite = weaponData.SpecialSkillMasterData.Sprite;

        return new SkillsView.ViewModel
        (
            statusSkillSprite,
            normalSkillSprite,
            specialSkillSprite,
            characterLevel
        );
    }


    public void Dispose()
    {
    }
}