using System;
using Common.Data;
using Zenject;

public class StatusViewModelUseCase : IDisposable
{
    private readonly UserDataRepository userDataRepository;
    private readonly StatusSkillUseCase statusSkillUseCase;

    [Inject]
    public StatusViewModelUseCase
    (
        UserDataRepository userDataRepository,
        StatusSkillUseCase statusSkillUseCase
    )
    {
        this.userDataRepository = userDataRepository;
        this.statusSkillUseCase = statusSkillUseCase;
    }

    public StatusInBattleView.ViewModel InAsTask()
    {
        var characterData = userDataRepository.GetEquippedCharacterData();
        var characterId = characterData.Id;
        var weaponData = userDataRepository.GetEquippedWeaponData(characterId);
        var statusSkillId = weaponData.StatusSkillMasterData.Id;
        var hp = statusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.Hp);
        var attack = statusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.Attack);
        var speed = statusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.Speed);
        var bombLimit = statusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.BombLimit);
        var fireRange = statusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, StatusType.FireRange);
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