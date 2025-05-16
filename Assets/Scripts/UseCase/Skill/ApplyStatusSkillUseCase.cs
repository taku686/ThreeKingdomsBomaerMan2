using System;
using Common.Data;
using Manager.DataManager;
using UnityEngine;
using Zenject;

public class ApplyStatusSkillUseCase : IDisposable
{
    private readonly SkillMasterDataRepository _skillMasterDataRepository;
    private readonly UserDataRepository _userDataRepository;
    private readonly CharacterMasterDataRepository _characterMasterDataRepository;

    [Inject]
    public ApplyStatusSkillUseCase
    (
        SkillMasterDataRepository skillMasterDataRepository,
        UserDataRepository userDataRepository,
        CharacterMasterDataRepository characterMasterDataRepository
    )
    {
        _skillMasterDataRepository = skillMasterDataRepository;
        _userDataRepository = userDataRepository;
        _characterMasterDataRepository = characterMasterDataRepository;
    }

    public int ApplyStatusSkill(int characterId, int skillId, StatusType statusType)
    {
        var appliedLevelValue = ApplyLevelStatus(characterId, statusType);
        var skillData = _skillMasterDataRepository.GetSkillData(skillId);
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

    public int GetStatusSkillValue(int skillId, StatusType statusType)
    {
        var skillData = _skillMasterDataRepository.GetSkillData(skillId);
        if (skillData.SkillType != SkillType.Status)
        {
            return 0;
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
        return addValue;
    }

    public int ApplyMulBuffStatusSkill(int skillId, StatusType statusType, float value)
    {
        var skillData = _skillMasterDataRepository.GetSkillData(skillId);
        float buffValue;
        switch (statusType)
        {
            case StatusType.Hp:
                buffValue = skillData.HpMul;
                break;
            case StatusType.Attack:
                buffValue = skillData.AttackMul;
                break;
            case StatusType.Speed:
                buffValue = skillData.SpeedMul;
                break;
            case StatusType.BombLimit:
                buffValue = skillData.BombMul;
                break;
            case StatusType.FireRange:
                buffValue = skillData.FireMul;
                break;
            case StatusType.Defense:
                buffValue = skillData.DefenseMul;
                break;
            case StatusType.Resistance:
                buffValue = skillData.ResistanceMul;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null);
        }

        if (Mathf.Approximately(buffValue, GameCommonData.InvalidNumber))
        {
            return Mathf.FloorToInt(value);
        }

        value *= buffValue;
        var result = Mathf.FloorToInt(value);
        return result;
    }

    public int ApplyPluBuffStatusSkill(int skillId, StatusType statusType, float value)
    {
        var skillData = _skillMasterDataRepository.GetSkillData(skillId);
        float buffValue;
        switch (statusType)
        {
            case StatusType.Hp:
                buffValue = skillData.HpPlu;
                break;
            case StatusType.Attack:
                buffValue = skillData.AttackPlu;
                break;
            case StatusType.Speed:
                buffValue = skillData.SpeedPlu;
                break;
            case StatusType.BombLimit:
                buffValue = skillData.BombPlu;
                break;
            case StatusType.FireRange:
                buffValue = skillData.FirePlu;
                break;
            case StatusType.Defense:
                buffValue = skillData.DefensePlu;
                break;
            case StatusType.Resistance:
                buffValue = skillData.ResistancePlu;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null);
        }

        if (Mathf.Approximately(buffValue, GameCommonData.InvalidNumber))
        {
            return Mathf.FloorToInt(value);
        }

        value += buffValue;
        var result = Mathf.FloorToInt(value);
        return result;
    }

    public int ApplyLevelStatus(int characterId, StatusType statusType)
    {
        var levelData = _userDataRepository.GetCurrentLevelData(characterId);
        var characterData = _characterMasterDataRepository.GetCharacterData(characterId);
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