using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using UnityEngine;
using Zenject;

public class BuffSkill : IDisposable
{
    private readonly ApplyStatusSkillUseCase _applyStatusSkillUseCase;

    private int _characterId;

    private SkillMasterData[] _statusSKillMasterDatum;
    private PlayerConditionInfo _playerConditionInfo;
    private PlayerStatusInfo _playerStatusInfo;
    private bool _isBuffInAbnormalCondition;
    private const int StatusAmount = 7;

    [Inject]
    public BuffSkill
    (
        ApplyStatusSkillUseCase applyStatusSkillUseCase
    )
    {
        _applyStatusSkillUseCase = applyStatusSkillUseCase;
    }

    public void Initialize
    (
        int characterId,
        SkillMasterData[] statusSKillMasterDatum,
        PlayerConditionInfo playerConditionInfo,
        PlayerStatusInfo playerStatusInfo
    )
    {
        _characterId = characterId;
        _statusSKillMasterDatum = statusSKillMasterDatum;
        _playerConditionInfo = playerConditionInfo;
        _playerStatusInfo = playerStatusInfo;
    }

    public async UniTaskVoid Buff(SkillMasterData skillMasterData, int buffCount = StatusAmount)
    {
        var skillId = skillMasterData.Id;
        var effectTime = skillMasterData.EffectTime;
        var buffStatuses = GetBuffStatuses(skillId, _statusSKillMasterDatum, _characterId);
        var fixedBuffStatus = new Dictionary<StatusType, (int, int)>();
        foreach (var buffStatus in buffStatuses)
        {
            if (buffStatus.Key is not (StatusType.BombLimit or StatusType.FireRange))
            {
                fixedBuffStatus.Add(buffStatus.Key, buffStatus.Value);
                continue;
            }

            fixedBuffStatus.Add(buffStatus.Key, (buffStatus.Value.Item1 * 10, buffStatus.Value.Item2 * 10));
        }

        var fixedOrderBuffStatuses = fixedBuffStatus
            .OrderByDescending(buffStatus => buffStatus.Value.Item2)
            .Take(buffCount)
            .ToArray();

        if (fixedOrderBuffStatuses.Length == 0)
        {
            return;
        }

        fixedBuffStatus.Clear();

        foreach (var buffStatus in fixedOrderBuffStatuses)
        {
            if (buffStatus.Key is not (StatusType.BombLimit or StatusType.FireRange))
            {
                fixedBuffStatus.Add(buffStatus.Key, buffStatus.Value);
                continue;
            }

            fixedBuffStatus.Add(buffStatus.Key, (buffStatus.Value.Item1 / 10, buffStatus.Value.Item2 / 10));
        }

        foreach (var (statusType, (_, applyBuffSkill)) in fixedBuffStatus)
        {
            SetPlayerStatus(statusType, applyBuffSkill);
        }

        await UniTask.Delay(TimeSpan.FromSeconds(effectTime));

        foreach (var (statusType, (applyStatusSkill, _)) in fixedBuffStatus)
        {
            SetPlayerStatus(statusType, applyStatusSkill);
        }
    }

    public async UniTask BuffInAbnormalCondition(SkillMasterData skillMasterData, int buffCount = StatusAmount)
    {
        if (_isBuffInAbnormalCondition)
        {
            return;
        }

        _isBuffInAbnormalCondition = true;
        var skillId = skillMasterData.Id;
        var buffStatuses = GetBuffStatuses(skillId, _statusSKillMasterDatum, _characterId);

        BuffStatus(buffStatuses, buffCount);

        await UniTask.Delay(TimeSpan.FromSeconds(skillMasterData.EffectTime));

        _isBuffInAbnormalCondition = false;
        foreach (var (statusType, (applyStatusSkill, _)) in buffStatuses)
        {
            SetPlayerStatus(statusType, applyStatusSkill);
        }
    }

    private void BuffStatus(Dictionary<StatusType, (int, int)> buffStatuses, int buffCount)
    {
        var fixedBuffStatus = new Dictionary<StatusType, (int, int)>();
        foreach (var buffStatus in buffStatuses)
        {
            if (buffStatus.Key is not (StatusType.BombLimit or StatusType.FireRange))
            {
                fixedBuffStatus.Add(buffStatus.Key, buffStatus.Value);
                continue;
            }

            fixedBuffStatus.Add(buffStatus.Key, (buffStatus.Value.Item1 * 10, buffStatus.Value.Item2 * 10));
        }

        var fixedOrderBuffStatuses = fixedBuffStatus
            .OrderByDescending(buffStatus => buffStatus.Value.Item2)
            .Take(buffCount)
            .ToArray();

        if (fixedOrderBuffStatuses.Length == 0)
        {
            return;
        }

        fixedBuffStatus.Clear();

        foreach (var buffStatus in fixedOrderBuffStatuses)
        {
            if (buffStatus.Key is not (StatusType.BombLimit or StatusType.FireRange))
            {
                fixedBuffStatus.Add(buffStatus.Key, buffStatus.Value);
                continue;
            }

            fixedBuffStatus.Add(buffStatus.Key, (buffStatus.Value.Item1 / 10, buffStatus.Value.Item2 / 10));
        }

        foreach (var (statusType, (_, applyBuffSkill)) in fixedBuffStatus)
        {
            SetPlayerStatus(statusType, applyBuffSkill);
        }
    }

    private void SetPlayerStatus(StatusType statusType, int value)
    {
        switch (statusType)
        {
            case StatusType.Hp:
                var maxHp = _playerStatusInfo._Hp.Value.Item1;
                _playerStatusInfo._Hp.Value = (maxHp, value);
                break;
            case StatusType.Attack:
                _playerStatusInfo._Attack.Value = value;
                break;
            case StatusType.Speed:
                _playerStatusInfo._Speed.Value = value;
                break;
            case StatusType.BombLimit:
                _playerStatusInfo._BombLimit.Value = value;
                break;
            case StatusType.FireRange:
                _playerStatusInfo._FireRange.Value = value;
                break;
            case StatusType.Defense:
                _playerStatusInfo._Defense.Value = value;
                break;
            case StatusType.Resistance:
                _playerStatusInfo._Resistance.Value = value;
                break;
            case StatusType.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(statusType), statusType, null);
        }
    }

    private Dictionary<StatusType, (int, int)> GetBuffStatuses
    (
        int normalSkillId,
        SkillMasterData[] statusSKillMasterDatum,
        int characterId
    )
    {
        var buffStatuses = new Dictionary<StatusType, (int, int)>();
        foreach (var statusType in (StatusType[])Enum.GetValues(typeof(StatusType)))
        {
            if (statusType == StatusType.None)
            {
                continue;
            }

            var applyStatusSkill = _applyStatusSkillUseCase.ApplyLevelStatus(characterId, statusType);
            foreach (var statusSkillMasterData in statusSKillMasterDatum)
            {
                var statusTypeOfStatusSkill = SkillMasterDataRepository.GetStatusSkillValue(statusSkillMasterData);
                if (statusType == statusTypeOfStatusSkill.Item1 && !Mathf.Approximately(statusTypeOfStatusSkill.Item2, GameCommonData.InvalidNumber))
                {
                    var statusSkillId = statusSkillMasterData.Id;
                    applyStatusSkill = _applyStatusSkillUseCase.ApplyStatusSkill(characterId, statusSkillId, statusType);
                }
            }

            var applyBuffSkill = _applyStatusSkillUseCase.ApplyMulBuffStatusSkill(normalSkillId, statusType, applyStatusSkill);
            applyBuffSkill = _applyStatusSkillUseCase.ApplyPluBuffStatusSkill(normalSkillId, statusType, applyBuffSkill);
            if (applyStatusSkill == applyBuffSkill)
            {
                continue;
            }

            var tuple = (applyStatusSkill, applyBuffSkill);
            buffStatuses.Add(statusType, tuple);
        }

        return buffStatuses;
    }

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}