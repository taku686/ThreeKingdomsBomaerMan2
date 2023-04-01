using System;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
using UnityEngine;
using Zenject;

public class MissionManager : IDisposable
{
    [Inject] private UserDataManager _userDataManager;
    [Inject] private MissionDataManager _missionDataManager;
    private readonly List<MissionBase> _missionBases = new();

    public void Initialize()
    {
        foreach (var mission in _userDataManager.GetMissionProgressDatum())
        {
            var missionData = _missionDataManager.GetMissionData(mission.Key);
            var missionBase = GenerateMissionBase(missionData, _userDataManager);
            Debug.Log(missionBase);
            _missionBases.Add(missionBase);
        }
    }

    public void CheckMission(int actionId)
    {
        foreach (var missionBase in _missionBases)
        {
            if (missionBase.GetActionId() != actionId)
            {
                continue;
            }

            missionBase.Action();
        }
    }

    public void CheckMission(int actionId, int characterId)
    {
        foreach (var missionBase in _missionBases)
        {
            if (missionBase.GetActionId() != actionId)
            {
                continue;
            }

            missionBase.Action(characterId);
        }
    }

    private MissionBase GenerateMissionBase(MissionData missionData, UserDataManager userDataManager)
    {
        switch (missionData.action)
        {
            case GameCommonData.LevelUpActionId:
                return new LevelUpMission(missionData, userDataManager);
            case GameCommonData.BattleCountActionId:
                return new BattleCountMission(missionData, userDataManager);
            case GameCommonData.CharacterBattleActionId:
                return new CharacterBattleMission(missionData, userDataManager);
            default:
                return null;
        }
    }

    public void Dispose()
    {
    }
}