using System;
using Common.Data;
using UnityEngine;


public class MissionBase : IDisposable
{
    private readonly MissionData _missionData;
    private readonly UserDataRepository userDataRepository;

    protected MissionBase(MissionData missionData, UserDataRepository userDataRepository)
    {
        _missionData = missionData;
        this.userDataRepository = userDataRepository;
    }

    public int GetActionId()
    {
        return _missionData.action;
    }

    public int GetMissionId()
    {
        return _missionData.index;
    }

    public int GetCharacterId()
    {
        return _missionData.characterId;
    }

    public virtual void Action()
    {
        IncreaseMissionProgress();
    }

    public virtual void Action(int characterId)
    {
        if (_missionData.characterId != characterId)
        {
            return;
        }

        IncreaseMissionProgress();
    }

    private void IncreaseMissionProgress()
    {
        var missionProgress = userDataRepository.GetMissionProgress(_missionData.index);
        if (missionProgress == GameCommonData.ExceptionMissionProgress)
        {
            Debug.Log(missionProgress);
            return;
        }

        missionProgress += 1;
        userDataRepository.SetMissionProgress(_missionData.index, missionProgress);
    }


    public void Dispose()
    {
    }
}