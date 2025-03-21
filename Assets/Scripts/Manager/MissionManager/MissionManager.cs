using System;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
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

    public void CheckMission(GameCommonData.MissionActionId actionType, int amount, int characterId = -1, int weaponId = -1)
    {
        var actionId = (int)actionType;
        foreach (var missionBase in _missionBases)
        {
            if (missionBase.GetActionId() != actionId)
            {
                continue;
            }

            if (GameCommonData.IsMissionsUsingCharacter(actionId))
            {
                missionBase.CharacterMissionAction(amount, characterId);
                continue;
            }

            if (GameCommonData.IsMissionsUsingWeapon(actionId))
            {
                missionBase.WeaponMissionAction(amount, weaponId);
                continue;
            }

            missionBase.Action(amount);
        }
    }

    private static MissionBase GenerateMissionBase(MissionMasterData missionMasterData, UserDataRepository userDataRepository)
    {
        return new MissionBase(missionMasterData, userDataRepository);
    }

    public void Dispose()
    {
    }
}