using System;
using Common.Data;
using Zenject;

public class StatusInBattleViewModelUseCase : IDisposable
{
    private readonly UserDataRepository userDataRepository;
    private readonly ApplyStatusSkillUseCase applyStatusSkillUseCase;

    [Inject]
    public StatusInBattleViewModelUseCase
    (
        UserDataRepository userDataRepository,
        ApplyStatusSkillUseCase applyStatusSkillUseCase
    )
    {
        this.userDataRepository = userDataRepository;
        this.applyStatusSkillUseCase = applyStatusSkillUseCase;
    }

    public StatusInBattleView.ViewModel InAsTask()
    {
        var characterData = userDataRepository.GetEquippedCharacterData();
        var characterId = characterData.Id;
        var weaponData = userDataRepository.GetEquippedWeaponData(characterId);
        var statusSkillId = weaponData.StatusSkillMasterDatum.Id;
        var hp = applyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.Hp);
        var attack = applyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.Attack);
        var speed = applyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.Speed);
        var bombLimit = applyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.BombLimit);
        var fireRange = applyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.FireRange);
        return new StatusInBattleView.ViewModel
        (
            hp,
            attack,
            speed,
            bombLimit,
            fireRange
        );
    }

    public void Dispose()
    {
        userDataRepository?.Dispose();
    }
}