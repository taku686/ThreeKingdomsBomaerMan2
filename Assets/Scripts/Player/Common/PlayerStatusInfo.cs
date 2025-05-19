using Common.Data;
using UniRx;
using UnityEngine;

public class PlayerStatusInfo : MonoBehaviour
{
    private int _playerIndex;
    private readonly ReactiveCollection<AbnormalCondition> _abnormalConditions = new();
    public IReadOnlyReactiveCollection<AbnormalCondition> _AbnormalConditions => _abnormalConditions;

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