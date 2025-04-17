using System;
using Common.Data;
using Zenject;

public class StatusInBattleViewModelUseCase : IDisposable
{
    private readonly UserDataRepository _userDataRepository;
    private readonly ApplyStatusSkillUseCase _applyStatusSkillUseCase;

    [Inject]
    public StatusInBattleViewModelUseCase
    (
        UserDataRepository userDataRepository,
        ApplyStatusSkillUseCase applyStatusSkillUseCase
    )
    {
        _userDataRepository = userDataRepository;
        _applyStatusSkillUseCase = applyStatusSkillUseCase;
    }

    public StatusInBattleView.ViewModel InAsTask()
    {
        var characterData = _userDataRepository.GetEquippedCharacterData();
        var characterId = characterData.Id;
        var weaponData = _userDataRepository.GetEquippedWeaponData(characterId);
        var statusSkillDatum = weaponData.StatusSkillMasterDatum;
        var hp = 0;
        var attack = 0;
        var speed = 0;
        var bombLimit = 0;
        var fireRange = 0;
        var defense = 0;
        var resistance = 0;

        foreach (var statusSkillData in statusSkillDatum)
        {
            var skillId = statusSkillData.Id;
            hp = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Hp);
            speed = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Speed);
            attack = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Attack);
            fireRange = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.FireRange);
            bombLimit = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.BombLimit);
            defense = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Defense);
            resistance = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, skillId, StatusType.Resistance);
        }

        return new StatusInBattleView.ViewModel
        (
            hp,
            attack,
            speed,
            bombLimit,
            fireRange,
            defense,
            resistance
        );
    }

    public void Dispose()
    {
        _userDataRepository?.Dispose();
    }
}