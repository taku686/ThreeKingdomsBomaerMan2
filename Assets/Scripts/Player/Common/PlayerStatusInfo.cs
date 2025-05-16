using System.Collections.Generic;
using Common.Data;
using UnityEngine;

public class PlayerStatusInfo : MonoBehaviour
{
    private int _playerIndex;
    private readonly List<AbnormalCondition> _abnormalConditions = new();

    public void SetPlayerIndex(int userId)
    {
        _playerIndex = userId;
    }

    public int GetPlayerIndex()
    {
        return _playerIndex;
    }

    public void AddAbnormalCondition(AbnormalCondition abnormalCondition)
    {
        if (_abnormalConditions.Contains(abnormalCondition))
        {
            return;
        }

        _abnormalConditions.Add(abnormalCondition);
    }

    public void RemoveAbnormalCondition(AbnormalCondition abnormalCondition)
    {
        if (!_abnormalConditions.Contains(abnormalCondition))
        {
            return;
        }

        _abnormalConditions.Remove(abnormalCondition);
    }

    public bool HasAbnormalCondition()
    {
        return _abnormalConditions.Count > 0;
    }

    public void ClearAbnormalConditions()
    {
        _abnormalConditions.Clear();
    }
}