using System;
using Common.Data;
using Manager.DataManager;
using UnityEngine;
using Zenject;

public class NormalSkillStatusChangeUseCase : IDisposable
{
    private readonly SkillMasterDataRepository _skillMasterDataRepository;
    private readonly UserDataRepository _userDataRepository;
    private readonly CharacterMasterDataRepository _characterMasterDataRepository;

    [Inject]
    public NormalSkillStatusChangeUseCase
    (
        SkillMasterDataRepository skillMasterDataRepository,
        UserDataRepository userDataRepository,
        CharacterMasterDataRepository characterMasterDataRepository
    )
    {
        _skillMasterDataRepository = skillMasterDataRepository;
        _userDataRepository = userDataRepository;
        _characterMasterDataRepository = characterMasterDataRepository;
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