using System;
using Common.Data;
using Manager.DataManager;
using Repository;
using UI.Title;
using Zenject;

public class CharacterDetailViewModelUseCase : IDisposable
{
    private readonly UserDataRepository userDataRepository;
    private readonly CharacterMasterDataRepository characterMasterDataRepository;
    private readonly WeaponMasterDataRepository weaponMasterDataRepository;

    [Inject]
    public CharacterDetailViewModelUseCase
    (
        UserDataRepository userDataRepository,
        CharacterMasterDataRepository characterMasterDataRepository,
        WeaponMasterDataRepository weaponMasterDataRepository
    )
    {
        this.userDataRepository = userDataRepository;
        this.characterMasterDataRepository = characterMasterDataRepository;
        this.weaponMasterDataRepository = weaponMasterDataRepository;
    }

    public CharacterDetailView.ViewModel InAsTask(int characterId)
    {
        var characterData = characterMasterDataRepository.GetCharacterData(characterId);
        var currentLevelData = userDataRepository.GetCurrentLevelData(characterId);
        var nextLevelData = userDataRepository.GetNextLevelData(characterId);
        var skillsViewModel = CreateSkillsViewModel(characterId, currentLevelData.Level);

        return new CharacterDetailView.ViewModel
        (
            characterData,
            currentLevelData,
            nextLevelData,
            skillsViewModel
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
        // TODO マネージリソースをここで解放します
    }
}