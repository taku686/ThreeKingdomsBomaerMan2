using System;
using Common.Data;
using TMPro;
using UI.BattleCore;
using UI.BattleCore.InBattle;
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

    public void ApplyBuffState(StatusType statusType, int value)
    {
        statusInBattleView.ApplyBuffState(statusType, value);
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
    
    public void ActivateBombButton(bool isActive)
    {
        _inputView.ActivateBombButton(isActive);
    }

    public void ActiveSkillButton(bool isActive)
    {
        _inputView.ActivateWeaponSkillButton(isActive);
        _inputView.ActivateNormalSkillButton(isActive);
        _inputView.ActivateSpecialSkillButton(isActive);
        _inputView.ActivateJumpSkillButton(isActive);
    }
    
    public void ActiveCharacterChangeButton(bool isActive)
    {
        _inputView.ActivateChangeCharacterButton(isActive);
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

    public IObservable<SkillIndicatorViewBase.SkillIndicatorInfo> OnTouchWeaponSkillButtonAsObservable()
    {
        return _inputView.OnTouchWeaponSkillButtonAsObservable();
    }

    public IObservable<SkillIndicatorViewBase.SkillIndicatorInfo> OnTouchNormalSkillButtonAsObservable()
    {
        return _inputView.OnTouchNormalSkillButtonAsObservable();
    }

    public IObservable<SkillIndicatorViewBase.SkillIndicatorInfo> OnTouchSpecialSkillButtonAsObservable()
    {
        return _inputView.OnTouchSpecialSkillButtonAsObservable();
    }
}