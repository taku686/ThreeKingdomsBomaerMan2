using System;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
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

        private const float MaxFillAmount = 1;
        private const float MinFillAmount = 0;
        private float _timerNormalSkill;
        private float _timerSpecialSkill;
        private float _timerDashSkill;
        private float _normalSkillInterval;
        private float _specialSkillInterval;
        private float _dashInterval;

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
                //todo 後でしゅうせいする
                //_normalSkillInterval = normalSkill.Interval;
                _normalSkillInterval = 1;
                _timerNormalSkill = 0;
                normalSkillIntervalImage.fillAmount = 0f;
                normalSkillButton.interactable = false;
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
                //todo 後でしゅうせいする
                //_specialSkillInterval = specialSkill.Interval;
                _specialSkillInterval = 1;
                _timerSpecialSkill = 0;
                specialSkillIntervalImage.fillAmount = 0f;
                specialSkillButton.interactable = false;
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


        private void ResetNormalSkillIntervalImage()
        {
            _timerNormalSkill = 0;
            normalSkillIntervalImage.fillAmount = MinFillAmount;
            normalSkillButton.interactable = false;
        }

        private void ResetSpecialSkillIntervalImage()
        {
            _timerSpecialSkill = 0;
            specialSkillIntervalImage.fillAmount = MinFillAmount;
            specialSkillButton.interactable = false;
        }

        private void ResetDashIntervalImage()
        {
            _timerDashSkill = 0;
            _dashIntervalImage.fillAmount = MinFillAmount;
            _dashButton.interactable = false;
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