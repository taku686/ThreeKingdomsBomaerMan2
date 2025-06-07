using System;
using System.Globalization;
using Common.Data;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonView : MonoBehaviour
{
    [SerializeField] private Button _skillButton;
    [SerializeField] private Image _skillIntervalImage;
    [SerializeField] private Image _skillIconImage;
    [SerializeField] private Image _skillActiveCountdownImage;
    [SerializeField] private Image _disableImage;
    [SerializeField] private TextMeshProUGUI _skillActiveCountdownText;
    [SerializeField] private SkillButtonType _skillButtonType;
    private float _timerSkill;
    private float _timerSkillEffectTime;
    private float _skillInterval;
    private float _skillEffectTime;
    private bool _isActive;
    private SkillActionType _skillActionType;
    private const float MaxFillAmount = 1;
    private const float MinFillAmount = 0;

    private enum SkillButtonType
    {
        WeaponSkillButton,
        NormalSkillButton,
        SpecialSkillButton,
        JumpSkillButton,
        CharacterChangeSkillButton
    }

    public void UpdateTimer()
    {
        SkillIntervalTimer();

        if (IsRequiredType())
        {
            return;
        }

        SkillEffectTimer();
    }

    public void InitializeSkillButton(SkillMasterData skillMasterData, LevelMasterData levelMasterData)
    {
        _timerSkill = 0;
        _skillIntervalImage.fillAmount = MinFillAmount;
        _skillButton.interactable = false;
        _disableImage.gameObject.SetActive(false);
        _skillInterval = GetIntervalTime(skillMasterData);
        _isActive = true;

        if (IsRequiredType())
        {
            return;
        }

        var isSkillActive = IsButtonActive(skillMasterData, levelMasterData);
        _skillIntervalImage.fillAmount = MaxFillAmount;
        _skillIconImage.sprite = skillMasterData.Sprite;
        _skillEffectTime = skillMasterData.EffectTime;
        _timerSkillEffectTime = skillMasterData.EffectTime;
        _skillActiveCountdownText.text = string.Empty;
        _skillActionType = skillMasterData._SkillActionTypeEnum;
        _skillIconImage.gameObject.SetActive(isSkillActive);
        _skillActiveCountdownText.gameObject.SetActive(isSkillActive);
        _disableImage.gameObject.SetActive(!isSkillActive);

        _skillActiveCountdownText.gameObject.SetActive(false);
        _skillActiveCountdownImage.gameObject.SetActive(false);
    }

    public void ActivateButton(bool isActivate)
    {
        _skillButton.interactable = isActivate;
        _disableImage.gameObject.SetActive(!isActivate);
        _isActive = isActivate;
        if (IsRequiredType())
        {
            return;
        }

        _skillActiveCountdownText.gameObject.SetActive(isActivate);
    }

    private float GetIntervalTime(SkillMasterData skillMasterData)
    {
        return _skillButtonType switch
        {
            SkillButtonType.WeaponSkillButton => skillMasterData.Interval,
            SkillButtonType.NormalSkillButton => skillMasterData.Interval,
            SkillButtonType.SpecialSkillButton => skillMasterData.Interval,
            SkillButtonType.JumpSkillButton => GameCommonData.DashInterval,
            SkillButtonType.CharacterChangeSkillButton => GameCommonData.CharacterChangeInterval,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private bool IsButtonActive(SkillMasterData skillMasterData, LevelMasterData levelMasterData)
    {
        switch (_skillButtonType)
        {
            case SkillButtonType.WeaponSkillButton:
                return skillMasterData != null;
            case SkillButtonType.NormalSkillButton:
                var isNormalSkillActive = levelMasterData.Level >= GameCommonData.NormalSkillReleaseLevel;
                return isNormalSkillActive && skillMasterData.SkillType == SkillType.Active;
            case SkillButtonType.SpecialSkillButton:
                var isSpecialSkillActive = levelMasterData.Level >= GameCommonData.SpecialSkillReleaseLevel;
                return isSpecialSkillActive && skillMasterData.SkillType == SkillType.Active;
            case SkillButtonType.JumpSkillButton:
                return true;
            case SkillButtonType.CharacterChangeSkillButton:
                return true;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void SkillIntervalTimer()
    {
        if (!_isActive) return;
        if (Mathf.Approximately(_skillInterval, GameCommonData.InvalidNumber)) return;
        if (_timerSkill >= _skillInterval) return;

        _timerSkill += Time.deltaTime;
        var rate = _timerSkill / _skillInterval;
        _skillIntervalImage.fillAmount = rate;
        if (rate >= MaxFillAmount)
        {
            _skillButton.interactable = true;
        }
    }

    private void SkillEffectTimer()
    {
        if (!IsEffectTimeActive(_skillEffectTime, _skillActionType)) return;
        if (_timerSkillEffectTime >= _skillEffectTime) return;

        _timerSkillEffectTime += Time.deltaTime;
        var rate = _timerSkillEffectTime / _skillEffectTime;
        _skillActiveCountdownImage.fillAmount = rate;
        var count = Mathf.CeilToInt(_skillEffectTime - _timerSkillEffectTime);
        _skillActiveCountdownText.text = count.ToString(CultureInfo.InvariantCulture);
        if (rate >= MaxFillAmount)
        {
            _skillActiveCountdownText.gameObject.SetActive(false);
            _skillActiveCountdownImage.gameObject.SetActive(false);
        }
    }

    private static bool IsEffectTimeActive(float effectTime, SkillActionType skillActionType)
    {
        if (Mathf.Approximately(effectTime, GameCommonData.InvalidNumber))
        {
            return false;
        }

        if
        (
            skillActionType
            is SkillActionType.Heal
            or SkillActionType.ContinuousHeal
            or SkillActionType.AllBuff
            or SkillActionType.AttackBuff
            or SkillActionType.DefenseBuff
            or SkillActionType.SpeedBuff
            or SkillActionType.FireRangeBuff
            or SkillActionType.BombLimitBuff
            or SkillActionType.ResistanceBuff
        )
        {
            return true;
        }

        return false;
    }

    public IObservable<Unit> OnClickSkillButtonAsObservable()
    {
        return _skillButton
            .OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(_skillInterval))
            .Do(_ => ResetSkillIntervalImage())
            .Select(_ => Unit.Default);
    }

    private void ResetSkillIntervalImage()
    {
        _timerSkill = 0;
        _skillIntervalImage.fillAmount = MinFillAmount;
        _skillButton.interactable = false;
        if (IsRequiredType())
        {
            return;
        }

        if (!IsEffectTimeActive(_skillEffectTime, _skillActionType))
        {
            return;
        }

        _skillActiveCountdownText.gameObject.SetActive(true);
        _skillActiveCountdownImage.gameObject.SetActive(true);
        _skillActiveCountdownText.text = _skillEffectTime.ToString(CultureInfo.InvariantCulture);
        _skillActiveCountdownImage.fillAmount = MinFillAmount;
        _timerSkillEffectTime = 0;
    }

    private bool IsRequiredType()
    {
        return _skillButtonType is not (SkillButtonType.NormalSkillButton or SkillButtonType.SpecialSkillButton or SkillButtonType.WeaponSkillButton);
    }
}