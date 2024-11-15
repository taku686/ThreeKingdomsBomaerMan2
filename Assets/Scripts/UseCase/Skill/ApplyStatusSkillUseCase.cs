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
        var levelData = userDataRepository.GetCurrentLevelData(characterId);
        var appliedLevelValue = ApplyLevelStatus(characterId, statusType);
        if (levelData.Level < GameCommonData.StatusSkillReleaseLevel)
        {
            return appliedLevelValue;
        }

        var skillData = skillMasterDataRepository.GetSkillData(skillId);
        return skillData.SkillEffectType switch
        {
            SkillEffectType.Hp when statusType == StatusType.Hp
                => appliedLevelValue + (int)skillData.Amount,
            SkillEffectType.Attack when statusType == StatusType.Attack
                => appliedLevelValue + (int)skillData.Amount,
            SkillEffectType.Speed when statusType == StatusType.Speed
                => appliedLevelValue + (int)skillData.Amount,
            SkillEffectType.BombLimit when statusType == StatusType.BombLimit
                => appliedLevelValue + (int)skillData.Amount,
            SkillEffectType.FireRange when statusType == StatusType.FireRange
                => appliedLevelValue + (int)skillData.Amount,
            _ => appliedLevelValue
        };
    }

    public int ApplyBuffStatusSkill(int characterId, int skillId, StatusType statusType, int value)
    {
        var levelData = userDataRepository.GetCurrentLevelData(characterId);
        if (levelData.Level < GameCommonData.StatusSkillReleaseLevel)
        {
            return value;
        }

        var skillData = skillMasterDataRepository.GetSkillData(skillId);
        value = skillData.SkillEffectType switch
        {
            SkillEffectType.HpBuff when statusType == StatusType.Hp
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AttackBuff when statusType == StatusType.Attack
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.SpeedBuff when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.BombLimitBuff when statusType == StatusType.BombLimit
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.FireRangeBuff when statusType == StatusType.FireRange
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusBuff when statusType == StatusType.Hp
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusBuff when statusType == StatusType.Attack
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusBuff when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusBuff when statusType == StatusType.BombLimit
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusBuff when statusType == StatusType.FireRange
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.Hp
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.Attack
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.BombLimit
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.FireRange
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.FastMove when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.GodPower when statusType == StatusType.Hp
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.GodPower when statusType == StatusType.Attack
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.GodPower when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.GodPower when statusType == StatusType.BombLimit
                => Mathf.FloorToInt(value * skillData.Amount),
            SkillEffectType.GodPower when statusType == StatusType.FireRange
                => Mathf.FloorToInt(value * skillData.Amount),
            _ => value
        };

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
        switch (statusType)
        {
            case StatusType.Hp:
                return characterData.Hp;
            case StatusType.Attack:
                return characterData.Attack;
            case StatusType.Speed:
                return characterData.Speed;
            case StatusType.FireRange:
                return characterData.FireRange;
            case StatusType.BombLimit:
                return characterData.BombLimit;
            default:
                return 0;
        }
    }


    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}