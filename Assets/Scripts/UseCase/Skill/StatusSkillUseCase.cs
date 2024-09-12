using System;
using Common.Data;
using Manager.DataManager;
using UnityEngine;
using Zenject;

public class StatusSkillUseCase : IDisposable
{
    private readonly SkillMasterDataRepository skillMasterDataRepository;
    private readonly UserDataRepository userDataRepository;
    private readonly CharacterMasterDataRepository characterMasterDataRepository;

    [Inject]
    public StatusSkillUseCase
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
        var characterData = characterMasterDataRepository.GetCharacterData(characterId);
        var statusValue = GetStatus(characterData, statusType);
        var fixedValue = Mathf.FloorToInt(levelData.StatusRate * statusValue);
        if (levelData.Level < GameCommonData.StatusSkillReleaseLevel)
        {
            return fixedValue;
        }

        var skillData = skillMasterDataRepository.GetSkillData(skillId);
        return skillData.SkillEffectType switch
        {
            SkillEffectType.Hp when statusType == StatusType.Hp => fixedValue + (int)skillData.Amount,
            SkillEffectType.Attack when statusType == StatusType.Attack => fixedValue + (int)skillData.Amount,
            SkillEffectType.Speed when statusType == StatusType.Speed => fixedValue + (int)skillData.Amount,
            SkillEffectType.BombLimit when statusType == StatusType.BombLimit => fixedValue + (int)skillData.Amount,
            SkillEffectType.FireRange when statusType == StatusType.FireRange => fixedValue + (int)skillData.Amount,
            _ => fixedValue
        };
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