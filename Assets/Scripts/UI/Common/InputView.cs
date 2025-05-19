using System;
using System.Globalization;
using Common.Data;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    public class InputView : MonoBehaviour
    {
        public Button bombButton;
        public Button normalSkillButton;
        public Button specialSkillButton;
        public Button _dashButton;
        public Image normalSkillIntervalImage;
        public Image specialSkillIntervalImage;
        public Image _dashIntervalImage;
        public Image normalSkillImage;
        public Image specialSkillImage;
        [SerializeField] private GameObject _dashButtonGameObject;
        [SerializeField] private GameObject _normalSkillButtonGameObject;
        [SerializeField] private GameObject _specialSkillButtonGameObject;
        [SerializeField] private TextMeshProUGUI _normalSkillActiveCountdownText;
        [SerializeField] private TextMeshProUGUI _specialSkillActiveCountdownText;
        [SerializeField] private Image _normalSkillActiveCountdownImage;
        [SerializeField] private Image _specialSkillActiveCountdownImage;

        private const float MaxFillAmount = 1;
        private const float MinFillAmount = 0;
        private float _timerNormalSkill;
        private float _timerSpecialSkill;
        private float _timerDashSkill;
        private float _timerNormalSkillEffectTime;
        private float _timerSpecialSkillEffectTime;
        private float _normalSkillInterval;
        private float _specialSkillInterval;
        private float _dashInterval;
        private float _normalSkillEffectTime;
        private float _specialSkillEffectTime;
        private SkillActionType _normalSkillActionType;
        private SkillActionType _specialSkillActionType;

        public void ApplyViewModel(ViewModel viewModel)
        {
            var normalSkill = viewModel._NormalSkillMasterData;
            var specialSkill = viewModel._SpecialSkillMasterData;
            var levelMasterData = viewModel._LevelMasterData;

            if (normalSkill != null)
            {
                var isNormalSkillActive = levelMasterData.Level >= GameCommonData.NormalSkillReleaseLevel;
                var isActiveNormalButton = isNormalSkillActive && normalSkill.SkillType == SkillType.Active;
                _normalSkillButtonGameObject.SetActive(isActiveNormalButton);
                normalSkillIntervalImage.fillAmount = MaxFillAmount;
                normalSkillImage.sprite = normalSkill.Sprite;
                //_normalSkillInterval = normalSkill.Interval;
                _normalSkillInterval = 1;
                _timerNormalSkill = 0;
                _normalSkillEffectTime = normalSkill.EffectTime;
                _timerNormalSkillEffectTime = normalSkill.EffectTime;
                normalSkillIntervalImage.fillAmount = 0f;
                _normalSkillActiveCountdownImage.fillAmount = 0f;
                _normalSkillActiveCountdownText.text = string.Empty;
                _normalSkillActionType = normalSkill._SkillActionTypeEnum;
                normalSkillButton.interactable = false;
                _normalSkillActiveCountdownText.gameObject.SetActive(false);
                _normalSkillActiveCountdownImage.gameObject.SetActive(false);
            }
            else
            {
                _normalSkillButtonGameObject.SetActive(false);
            }

            if (specialSkill != null)
            {
                var isSpecialSkillActive = levelMasterData.Level >= GameCommonData.SpecialSkillReleaseLevel;
                var isActiveSpecialButton = isSpecialSkillActive && specialSkill.SkillType == SkillType.Active;
                _specialSkillButtonGameObject.SetActive(isActiveSpecialButton);
                specialSkillIntervalImage.fillAmount = MaxFillAmount;
                specialSkillImage.sprite = specialSkill.Sprite;
                _specialSkillInterval = specialSkill.Interval;
                _timerSpecialSkill = 0;
                _specialSkillEffectTime = specialSkill.EffectTime;
                _timerSpecialSkillEffectTime = specialSkill.EffectTime;
                specialSkillIntervalImage.fillAmount = 0f;
                _specialSkillActiveCountdownImage.fillAmount = 0f;
                _specialSkillActiveCountdownText.text = string.Empty;
                _specialSkillActionType = specialSkill._SkillActionTypeEnum;
                specialSkillButton.interactable = false;
                _specialSkillActiveCountdownText.gameObject.SetActive(false);
                _specialSkillActiveCountdownImage.gameObject.SetActive(false);
            }
            else
            {
                _specialSkillButtonGameObject.SetActive(false);
            }

            _dashInterval = GameCommonData.DashInterval;
            _dashIntervalImage.fillAmount = 0f;
            _dashButton.interactable = false;
        }

        public void UpdateSkillUI()
        {
            NormalSkillIntervalTimer();
            SpecialSkillIntervalTimer();
            DashIntervalTimer();
            NormalSkillEffectTimer();
            SpecialSkillEffectTimer();
        }

        #region Timer

        private void NormalSkillIntervalTimer()
        {
            if (!Mathf.Approximately(_normalSkillInterval, GameCommonData.InvalidNumber))
            {
                if (_timerNormalSkill < _normalSkillInterval)
                {
                    _timerNormalSkill += Time.deltaTime;
                    var rate = _timerNormalSkill / _normalSkillInterval;
                    normalSkillIntervalImage.fillAmount = rate;
                    if (rate >= MaxFillAmount)
                    {
                        normalSkillButton.interactable = true;
                    }
                }
            }
        }

        private void SpecialSkillIntervalTimer()
        {
            if (!Mathf.Approximately(_specialSkillInterval, GameCommonData.InvalidNumber))
            {
                if (_timerSpecialSkill < _specialSkillInterval)
                {
                    _timerSpecialSkill += Time.deltaTime;
                    var rate = _timerSpecialSkill / _specialSkillInterval;
                    specialSkillIntervalImage.fillAmount = rate;
                    if (rate >= MaxFillAmount)
                    {
                        specialSkillButton.interactable = true;
                    }
                }
            }
        }

        private void DashIntervalTimer()
        {
            if (_timerDashSkill < _dashInterval)
            {
                _timerDashSkill += Time.deltaTime;
                var rate = _timerDashSkill / _dashInterval;
                _dashIntervalImage.fillAmount = rate;
                if (rate >= MaxFillAmount)
                {
                    _dashButton.interactable = true;
                }
            }
        }

        private void NormalSkillEffectTimer()
        {
            if (IsEffectTimeActive(_normalSkillEffectTime, _normalSkillActionType))
            {
                if (_timerNormalSkillEffectTime < _normalSkillEffectTime)
                {
                    _timerNormalSkillEffectTime += Time.deltaTime;
                    var rate = _timerNormalSkillEffectTime / _normalSkillEffectTime;
                    _normalSkillActiveCountdownImage.fillAmount = rate;
                    var count = Mathf.FloorToInt(_normalSkillEffectTime - _timerNormalSkillEffectTime);
                    _normalSkillActiveCountdownText.text = count.ToString(CultureInfo.InvariantCulture);
                    if (rate >= MaxFillAmount)
                    {
                        _normalSkillActiveCountdownText.gameObject.SetActive(false);
                        _normalSkillActiveCountdownImage.gameObject.SetActive(false);
                    }
                }
            }
        }

        private void SpecialSkillEffectTimer()
        {
            if (IsEffectTimeActive(_specialSkillEffectTime, _specialSkillActionType))
            {
                if (_timerSpecialSkillEffectTime < _specialSkillEffectTime)
                {
                    _timerSpecialSkillEffectTime += Time.deltaTime;
                    var rate = _timerSpecialSkillEffectTime / _specialSkillEffectTime;
                    _specialSkillActiveCountdownImage.fillAmount = rate;
                    var count = Mathf.FloorToInt(_specialSkillEffectTime - _timerSpecialSkillEffectTime);
                    _specialSkillActiveCountdownText.text = count.ToString(CultureInfo.InvariantCulture);
                    if (rate >= MaxFillAmount)
                    {
                        _specialSkillActiveCountdownText.gameObject.SetActive(false);
                        _specialSkillActiveCountdownImage.gameObject.SetActive(false);
                    }
                }
            }
        }

        #endregion

        #region OnClick

        public IObservable<Unit> OnClickNormalSkillButtonAsObservable()
        {
            return normalSkillButton
                .OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(_normalSkillInterval))
                .Do(_ => ResetNormalSkillIntervalImage())
                .Select(_ => Unit.Default);
        }

        public IObservable<Unit> OnClickSpecialSkillButtonAsObservable()
        {
            return specialSkillButton
                .OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(_specialSkillInterval))
                .Do(_ => ResetSpecialSkillIntervalImage())
                .Select(_ => Unit.Default);
        }

        public IObservable<Unit> OnClickBombButtonAsObservable()
        {
            return bombButton
                .OnClickAsObservable()
                .Select(_ => Unit.Default);
        }

        public IObservable<Unit> OnClickDashButtonAsObservable()
        {
            return _dashButton
                .OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(_dashInterval))
                .Do(_ => ResetDashIntervalImage())
                .Select(_ => Unit.Default);
        }

        #endregion

        #region Reset

        private void ResetNormalSkillIntervalImage()
        {
            _timerNormalSkill = 0;
            normalSkillIntervalImage.fillAmount = MinFillAmount;
            normalSkillButton.interactable = false;

            if (!IsEffectTimeActive(_normalSkillEffectTime, _normalSkillActionType))
            {
                return;
            }

            _normalSkillActiveCountdownText.gameObject.SetActive(true);
            _normalSkillActiveCountdownImage.gameObject.SetActive(true);
            _normalSkillActiveCountdownText.text = _normalSkillEffectTime.ToString(CultureInfo.InvariantCulture);
            _normalSkillActiveCountdownImage.fillAmount = MinFillAmount;
            _timerNormalSkillEffectTime = 0;
        }

        private void ResetSpecialSkillIntervalImage()
        {
            _timerSpecialSkill = 0;
            specialSkillIntervalImage.fillAmount = MinFillAmount;
            specialSkillButton.interactable = false;

            if (!IsEffectTimeActive(_specialSkillEffectTime, _specialSkillActionType))
            {
                return;
            }

            _specialSkillActiveCountdownText.gameObject.SetActive(true);
            _specialSkillActiveCountdownImage.gameObject.SetActive(true);
            _specialSkillActiveCountdownText.text = _specialSkillEffectTime.ToString(CultureInfo.InvariantCulture);
            _specialSkillActiveCountdownImage.fillAmount = MinFillAmount;
            _timerSpecialSkillEffectTime = 0;
        }

        private void ResetDashIntervalImage()
        {
            _timerDashSkill = 0;
            _dashIntervalImage.fillAmount = MinFillAmount;
            _dashButton.interactable = false;
        }

        #endregion

        private bool IsEffectTimeActive(float effectTime, SkillActionType skillActionType)
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


        public class ViewModel
        {
            public SkillMasterData _NormalSkillMasterData { get; }
            public SkillMasterData _SpecialSkillMasterData { get; }
            public LevelMasterData _LevelMasterData { get; }

            public ViewModel
            (
                SkillMasterData normalSkillMasterData,
                SkillMasterData specialSkillMasterData,
                LevelMasterData levelMasterData
            )
            {
                _NormalSkillMasterData = normalSkillMasterData;
                _SpecialSkillMasterData = specialSkillMasterData;
                _LevelMasterData = levelMasterData;
            }
        }
    }
}