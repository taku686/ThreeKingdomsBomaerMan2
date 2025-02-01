using System;
using Common.Data;
using Repository;
using Zenject;

public class SkillDetailViewModelUseCase : IDisposable
{
    private readonly WeaponMasterDataRepository _weaponMasterDataRepository;

    [Inject]
    public SkillDetailViewModelUseCase
    (
        WeaponMasterDataRepository weaponMasterDataRepository,
        UserDataRepository userDataRepository
    )
    {
        _weaponMasterDataRepository = weaponMasterDataRepository;
    }

    public SkillDetailView.ViewModel InAsTask(int weaponId, SkillType skillType)
    {
        var weaponData = _weaponMasterDataRepository.GetWeaponData(weaponId);
        var skillData = weaponData.GetSkillData(skillType);
        return new SkillDetailView.ViewModel
        (
            skillData.Sprite,
            skillData.Name,
            skillData.Explanation
        );
    }

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}