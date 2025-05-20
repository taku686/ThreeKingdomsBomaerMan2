using System;
using Common.Data;
using Manager.NetworkManager;
using Zenject;

public class StatusInBattleViewModelUseCase : IDisposable
{
    private readonly UserDataRepository _userDataRepository;
    private readonly ApplyStatusSkillUseCase _applyStatusSkillUseCase;
    private readonly PhotonNetworkManager _photonNetworkManager;

    [Inject]
    public StatusInBattleViewModelUseCase
    (
        UserDataRepository userDataRepository,
        ApplyStatusSkillUseCase applyStatusSkillUseCase,
        PhotonNetworkManager photonNetworkManager
    )
    {
        _userDataRepository = userDataRepository;
        _applyStatusSkillUseCase = applyStatusSkillUseCase;
        _photonNetworkManager = photonNetworkManager;
    }

    public StatusInBattleView.ViewModel InAsTask(int playerKey)
    {
        //todo 後でチームでの処理に修正する
        var characterData = _photonNetworkManager.GetCharacterData(playerKey);
        var characterId = characterData.Id;
        var weaponData = _photonNetworkManager.GetWeaponData(playerKey);
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