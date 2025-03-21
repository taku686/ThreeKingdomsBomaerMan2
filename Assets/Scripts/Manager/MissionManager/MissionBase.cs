using System;
using Common.Data;
using UnityEngine;


public class MissionBase : IDisposable
{
    private readonly MissionMasterData _missionMasterData;
    private readonly UserDataRepository _userDataRepository;

    public MissionBase(MissionMasterData missionMasterData, UserDataRepository userDataRepository)
    {
        _missionMasterData = missionMasterData;
        _userDataRepository = userDataRepository;
    }

    public int GetActionId()
    {
        return _missionMasterData.Action;
    }

    public int GetMissionId()
    {
        return _missionMasterData.Index;
    }

    public int GetCharacterId()
    {
        return _missionMasterData.CharacterId;
    }

    public void Action(int amount)
    {
        IncreaseMissionProgress(amount);
    }

    public void CharacterMissionAction(int amount, int characterId)
    {
        if (_missionMasterData.CharacterId != characterId)
        {
            return;
        }

        IncreaseMissionProgress(amount);
    }

    public void WeaponMissionAction(int amount, int weaponId)
    {
        if (_missionMasterData.CharacterId != weaponId)
        {
            return;
        }

        IncreaseMissionProgress(amount);
    }

    private void IncreaseMissionProgress(int amount)
    {
        var missionProgress = _userDataRepository.GetMissionProgress(_missionMasterData.Index);
        if (missionProgress == -1)
        {
            Debug.LogError(missionProgress);
            return;
        }

        missionProgress += amount;
        _userDataRepository.SetMissionProgress(_missionMasterData.Index, missionProgress);
    }


    public void Dispose()
    {
    }
}