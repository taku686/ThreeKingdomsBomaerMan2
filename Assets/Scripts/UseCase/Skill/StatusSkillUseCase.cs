using System;
using Common.Data;
using Manager.DataManager;
using UnityEngine;

public class StatusSkillUseCase : IDisposable
{
    private readonly SkillDataRepository skillDataRepository;
    private readonly UserDataRepository userDataRepository;

    public StatusSkillUseCase
    (
        SkillDataRepository skillDataRepository,
        UserDataRepository userDataRepository
    )
    {
        this.skillDataRepository = skillDataRepository;
        this.userDataRepository = userDataRepository;
    }

    public int ApplyStatusSkill(int characterId, int skillId, int statusValue, StatusType statusType)
    {
        var levelData = userDataRepository.GetCurrentLevelData(characterId);
        if (levelData.Level < GameCommonData.StatusSkillReleaseLevel)
        {
            return statusValue;
        }

        var skillData = skillDataRepository.GetSkillData(skillId);
        return skillData.SkillEffectType switch
        {
            SkillEffectType.Hp when statusType == StatusType.Hp => statusValue + (int)skillData.Amount,
            SkillEffectType.Attack when statusType == StatusType.Attack => statusValue + (int)skillData.Amount,
            SkillEffectType.Speed when statusType == StatusType.Speed => statusValue + (int)skillData.Amount,
            SkillEffectType.BombLimit when statusType == StatusType.BombLimit => statusValue + (int)skillData.Amount,
            SkillEffectType.FireRange when statusType == StatusType.FireRange => statusValue + (int)skillData.Amount,
            _ => statusValue
        };
    }


    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}