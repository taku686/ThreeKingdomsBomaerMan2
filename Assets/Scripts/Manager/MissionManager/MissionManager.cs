using System;
using System.Collections.Generic;
using Common.Data;
using Manager.DataManager;
using Zenject;

public class MissionManager : IDisposable
{
    [Inject] private UserDataRepository _userDataRepository;
    [Inject] private MissionMasterDataRepository _missionMasterDataRepository;
    private readonly List<MissionBase> _missionBases = new();

    public void Initialize()
    {
        foreach (var mission in _userDataRepository.GetMissionDatum())
        {
            var missionBase = new MissionBase(mission, _userDataRepository, _missionMasterDataRepository);
            _missionBases.Add(missionBase);
        }
    }

    public void CheckMission(GameCommonData.MissionActionId actionType, int amount, int characterId = -1, int weaponId = -1)
    {
        var actionId = (int)actionType;
        foreach (var missionBase in _missionBases)
        {
            if (missionBase.GetAction() != actionId)
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

    public void Dispose()
    {
    }
}