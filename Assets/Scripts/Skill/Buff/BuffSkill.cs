using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using Photon.Pun;
using Player.Common;
using UniRx;
using UnityEngine;
using Zenject;

public class BuffSkill : IDisposable
{
    private readonly ApplyStatusSkillUseCase _applyStatusSkillUseCase;
    private Subject<(StatusType statusType, float value)> _statusBuff;
    private Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> _statusBuffUi;
    private int _characterId;
    private SkillMasterData[] _statusSKillMasterDatum;
    private TranslateStatusInBattleUseCase _translateStatusInBattleUseCase;
    private PlayerStatusInfo _playerStatusInfo;
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
        Subject<(StatusType statusType, float value)> statusBuff,
        Subject<(StatusType statusType, int value, bool isBuff, bool isDebuff)> statusBuffUi,
        int characterId,
        SkillMasterData[] statusSKillMasterDatum,
        TranslateStatusInBattleUseCase translateStatusInBattleUseCase,
        PlayerStatusInfo playerStatusInfo
    )
    {
        _statusBuff = statusBuff;
        _statusBuffUi = statusBuffUi;
        _characterId = characterId;
        _statusSKillMasterDatum = statusSKillMasterDatum;
        _translateStatusInBattleUseCase = translateStatusInBattleUseCase;
        _playerStatusInfo = playerStatusInfo;
    }

    public async UniTaskVoid Buff(SkillMasterData skillMasterData, int buffCount = StatusAmount)
    {
        var skillId = skillMasterData.Id;
        var effectTime = skillMasterData.EffectTime;
        var playerIndex = _playerStatusInfo.GetPlayerIndex();

        var dic = new Dictionary<int, int> { { playerIndex, skillId } };
        PhotonNetwork.LocalPlayer.SetSkillData(dic);
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

        foreach (var (statusType, (applyStatusSkill, applyBuffSkill)) in fixedBuffStatus)
        {
            var isBuff = applyBuffSkill > applyStatusSkill;
            var translatedValue = _translateStatusInBattleUseCase.TranslateStatusValue(statusType, applyBuffSkill);
            _statusBuff.OnNext((statusType, translatedValue));
            _statusBuffUi.OnNext((statusType, value: applyBuffSkill, isBuff, !isBuff));
        }

        await UniTask.Delay(TimeSpan.FromSeconds(effectTime));

        foreach (var (statusType, (applyStatusSkill, _)) in fixedBuffStatus)
        {
            var translatedPrefValue = _translateStatusInBattleUseCase.TranslateStatusValue(statusType, applyStatusSkill);
            _statusBuff.OnNext((statusType, translatedPrefValue));
            _statusBuffUi.OnNext((statusType, applyStatusSkill, isBuff: false, isDebuff: false));
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

            var applyBuffSkill = _applyStatusSkillUseCase.ApplyBuffStatusSkill(normalSkillId, statusType, applyStatusSkill);
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