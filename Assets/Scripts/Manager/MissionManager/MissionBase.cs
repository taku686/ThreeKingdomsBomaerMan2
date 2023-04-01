using System;
using Common.Data;
using UnityEngine;


public class MissionBase : IDisposable
{
    private readonly MissionData _missionData;
    private readonly UserDataManager _userDataManager;

    protected MissionBase(MissionData missionData, UserDataManager userDataManager)
    {
        _missionData = missionData;
        _userDataManager = userDataManager;
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
        var missionProgress = _userDataManager.GetMissionProgress(_missionData.index);
        if (missionProgress == GameCommonData.ExceptionMissionProgress)
        {
            Debug.Log(missionProgress);
            return;
        }

        Debug.Log("ミッション進行");
        missionProgress += 1;
        _userDataManager.SetMissionProgress(_missionData.index, missionProgress);
    }


    public void Dispose()
    {
    }
}