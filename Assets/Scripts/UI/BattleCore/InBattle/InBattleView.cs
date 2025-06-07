using System;
using Common.Data;
using TMPro;
using UI.BattleCore;
using UI.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class InBattleView : BattleViewBase
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private StatusInBattleView statusInBattleView;
    [SerializeField] private InputView _inputView;
    [SerializeField] private Transform _abnormalConditionParent;
    [SerializeField] private Image _abnormalConditionImage;

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

    public Image GenerateAbnormalConditionImage(Sprite abnormalConditionSprite)
    {
        var iconObj = Instantiate(_abnormalConditionImage.gameObject, _abnormalConditionParent);
        var image = iconObj.GetComponent<Image>();
        image.sprite = abnormalConditionSprite;
        return image;
    }

    public void UpdateTime(int time)
    {
        timerText.text = time.ToString();
    }
    
    public void UpdateInputViewTimer()
    {
        _inputView.UpdateTimer();
    }

    public IObservable<Unit> OnClickWeaponSkillButtonAsObservable()
    {
        return _inputView.OnClickWeaponSkillButtonAsObservable();
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

    public IObservable<Unit> OnClickCharacterChangeButtonAsObservable()
    {
        return _inputView.OnClickCharacterChangeButtonAsObservable();
    }

    public IObservable<Unit> OnClickDashButtonAsObservable()
    {
        return _inputView.OnClickDashButtonAsObservable();
    }
}