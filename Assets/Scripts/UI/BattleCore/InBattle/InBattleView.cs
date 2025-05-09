using System;
using Common.Data;
using TMPro;
using UI.BattleCore;
using UI.Common;
using UniRx;
using UnityEngine;

public class InBattleView : BattleViewBase
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private StatusInBattleView statusInBattleView;
    [SerializeField] private InputView _inputView;

    public void ApplyStatusViewModel(StatusInBattleView.ViewModel viewModel)
    {
        statusInBattleView.ApplyViewModel(viewModel);
    }

    public void ApplyBuffState(StatusType statusType, int value, bool isBuff, bool isDebuff)
    {
        statusInBattleView.ApplyBuffState(statusType, value, isBuff, isDebuff);
    }

    public void ApplyInputViewModel(InputView.ViewModel viewModel)
    {
        _inputView.ApplyViewModel(viewModel);
    }

    public void UpdateTime(int time)
    {
        timerText.text = time.ToString();
    }

    public IObservable<Unit> OnClickNormalSkillButtonAsObservable()
    {
        return _inputView.OnClickNormalSkillButtonAsObservable();
    }

    public IObservable<Unit> OnClickSpecialSkillButtonAsObservable()
    {
        return _inputView.OnClickSpecialSkillButtonAsObservable();
    }

    public IObservable<Unit> OnClickBombButtonAsObservable()
    {
        return _inputView.OnClickBombButtonAsObservable();
    }

    public IObservable<Unit> OnClickDashButtonAsObservable()
    {
        return _inputView.OnClickDashButtonAsObservable();
    }

    public void UpdateSkillUI()
    {
        _inputView.UpdateSkillUI();
    }
}