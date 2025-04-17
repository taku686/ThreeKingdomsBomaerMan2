using System;
using Common.Data;
using Manager.DataManager;
using UnityEngine;
using Zenject;

public class ApplyStatusSkillUseCase : IDisposable
{
    private readonly SkillMasterDataRepository skillMasterDataRepository;
    private readonly UserDataRepository userDataRepository;
    private readonly CharacterMasterDataRepository characterMasterDataRepository;

    [Inject]
    public ApplyStatusSkillUseCase
    (
        SkillMasterDataRepository skillMasterDataRepository,
        UserDataRepository userDataRepository,
        CharacterMasterDataRepository characterMasterDataRepository
    )
    {
        this.skillMasterDataRepository = skillMasterDataRepository;
        this.userDataRepository = userDataRepository;
        this.characterMasterDataRepository = characterMasterDataRepository;
    }

    public int ApplyStatusSkill(int characterId, int skillId, StatusType statusType)
    {
        var appliedLevelValue = ApplyLevelStatus(characterId, statusType);
        var skillData = skillMasterDataRepository.GetSkillData(skillId);
        if (skillData.SkillType != SkillType.Status)
        {
            return appliedLevelValue;
        }

        var addValue = statusType switch
        {
            StatusType.Hp => (int)skillData.HpPlu,
            StatusType.Attack => (int)skillData.AttackPlu,
            StatusType.Speed => (int)skillData.SpeedPlu,
            StatusType.BombLimit => (int)skillData.BombPlu,
            StatusType.FireRange => (int)skillData.FirePlu,
            StatusType.Defense => (int)skillData.DefensePlu,
            StatusType.Resistance => (int)skillData.ResistancePlu,
            _ => throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null)
        };
        addValue = addValue == GameCommonData.InvalidNumber ? 0 : addValue;
        return appliedLevelValue + addValue;
    }

    public int ApplyBuffStatusSkill(int characterId, int skillId, StatusType statusType, int value)
    {
        //todo 後で修正する
        var levelData = userDataRepository.GetCurrentLevelData(characterId);
        if (levelData.Level < GameCommonData.NormalSkillReleaseLevel)
        {
            return value;
        }

        var skillData = skillMasterDataRepository.GetSkillData(skillId);


        return value;
    }

    public int ApplyLevelStatus(int characterId, StatusType statusType)
    {
        var levelData = userDataRepository.GetCurrentLevelData(characterId);
        var characterData = characterMasterDataRepository.GetCharacterData(characterId);
        var statusValue = GetStatus(characterData, statusType);
        return Mathf.FloorToInt(levelData.StatusRate * statusValue);
    }

    private int GetStatus(CharacterData characterData, StatusType statusType)
    {
        return statusType switch
        {
            StatusType.Hp => characterData.Hp,
            StatusType.Attack => characterData.Attack,
            StatusType.Speed => characterData.Speed,
            StatusType.FireRange => characterData.FireRange,
            StatusType.BombLimit => characterData.BombLimit,
            _ => 0
        };
    }


    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}