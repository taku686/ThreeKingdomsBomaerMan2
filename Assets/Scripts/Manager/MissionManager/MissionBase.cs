using System;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
using UnityEngine;


public class MissionBase : IDisposable
{
    private readonly KeyValuePair<int, UserData.MissionData> _missionData;
    private readonly UserDataRepository _userDataRepository;
    private readonly MissionMasterDataRepository _missionMasterDataRepository;

    public MissionBase
    (
        KeyValuePair<int, UserData.MissionData> missionData,
        UserDataRepository userDataRepository,
        MissionMasterDataRepository missionMasterDataRepository
    )
    {
        _missionData = missionData;
        _userDataRepository = userDataRepository;
        _missionMasterDataRepository = missionMasterDataRepository;
    }

    public int GetAction()
    {
        var masterData = _missionMasterDataRepository.GetMissionData(_missionData.Key);
        return masterData.Action;
    }

    public void Action(int amount)
    {
        IncreaseMissionProgress(amount);
    }

    public void CharacterMissionAction(int amount, int characterId)
    {
        if (_missionData.Value._characterId != characterId)
        {
            return;
        }

        IncreaseMissionProgress(amount);
    }

    public void WeaponMissionAction(int amount, int weaponId)
    {
        if (_missionData.Value._weaponId != weaponId)
        {
            return;
        }

        IncreaseMissionProgress(amount);
    }

    private void IncreaseMissionProgress(int amount)
    {
        var missionProgress = _userDataRepository.GetMissionProgress(_missionData.Key);
        if (missionProgress == -1)
        {
            Debug.LogError(missionProgress);
            return;
        }

        missionProgress += amount;
        _userDataRepository.SetMissionProgress(_missionData.Key, missionProgress);
    }


    public void Dispose()
    {
    }
}