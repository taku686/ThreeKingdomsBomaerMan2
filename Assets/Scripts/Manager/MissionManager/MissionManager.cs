using System;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
using UnityEngine;
using Zenject;

public class MissionManager : IDisposable
{
    [Inject] private UserDataRepository _userDataRepository;
    [Inject] private MissionDataRepository _missionDataRepository;
    private readonly List<MissionBase> _missionBases = new();

    public void Initialize()
    {
        foreach (var mission in _userDataRepository.GetMissionProgressDatum())
        {
            var missionData = _missionDataRepository.GetMissionData(mission.Key);
            var missionBase = GenerateMissionBase(missionData, _userDataRepository);
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

    private MissionBase GenerateMissionBase(MissionData missionData, UserDataRepository userDataRepository)
    {
        switch (missionData.action)
        {
            case GameCommonData.LevelUpActionId:
                return new LevelUpMission(missionData, userDataRepository);
            case GameCommonData.BattleCountActionId:
                return new BattleCountMission(missionData, userDataRepository);
            case GameCommonData.CharacterBattleActionId:
                return new CharacterBattleMission(missionData, userDataRepository);
            default:
                return null;
        }
    }

    public void Dispose()
    {
    }
}