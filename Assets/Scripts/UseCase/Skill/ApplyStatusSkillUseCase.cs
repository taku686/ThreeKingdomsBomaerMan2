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
                => appliedLevelValue + (int)skillData.DamagePlu,
            SkillEffectType.Attack when statusType == StatusType.Attack
                => appliedLevelValue + (int)skillData.DamagePlu,
            SkillEffectType.Speed when statusType == StatusType.Speed
                => appliedLevelValue + (int)skillData.DamagePlu,
            SkillEffectType.BombLimit when statusType == StatusType.BombLimit
                => appliedLevelValue + (int)skillData.DamagePlu,
            SkillEffectType.FireRange when statusType == StatusType.FireRange
                => appliedLevelValue + (int)skillData.DamagePlu,
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
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AttackBuff when statusType == StatusType.Attack
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.SpeedBuff when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.BombLimitBuff when statusType == StatusType.BombLimit
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.FireRangeBuff when statusType == StatusType.FireRange
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusBuff when statusType == StatusType.Hp
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusBuff when statusType == StatusType.Attack
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusBuff when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusBuff when statusType == StatusType.BombLimit
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusBuff when statusType == StatusType.FireRange
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.Hp
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.Attack
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.BombLimit
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.AllStatusDebuff when statusType == StatusType.FireRange
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.FastMove when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.GodPower when statusType == StatusType.Hp
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.GodPower when statusType == StatusType.Attack
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.GodPower when statusType == StatusType.Speed
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.GodPower when statusType == StatusType.BombLimit
                => Mathf.FloorToInt(value * skillData.DamagePlu),
            SkillEffectType.GodPower when statusType == StatusType.FireRange
                => Mathf.FloorToInt(value * skillData.DamagePlu),
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