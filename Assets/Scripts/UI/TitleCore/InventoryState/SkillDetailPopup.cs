using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UI.Common;
using UI.Common.Popup;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SkillDetailPopup : PopupBase
{
    [SerializeField] private Image skillIcon;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private TextMeshProUGUI _intervalText;
    [SerializeField] private TextMeshProUGUI _effectTimeText;
    [SerializeField] private TextMeshProUGUI _rangeText;
    [SerializeField] private TextMeshProUGUI _abnormalConditionText;
    [SerializeField] private TextMeshProUGUI _skillTypeText;
    [SerializeField] private Button closeButton;

    [Inject] private UIAnimation _uiAnimation;
    private Action<bool> _setActivePanelAction;
    private IObservable<Unit> _onClickCancel;
    public IObservable<Unit> _OnClickButton => _onClickCancel;

    public async UniTask Open(ViewModel viewModel)
    {
        ApplyViewModel(viewModel);
        _onClickCancel = closeButton
            .OnClickAsObservable()
            .Take(1)
            .SelectMany(_ => OnClickButtonAnimation(closeButton).ToObservable())
            .SelectMany(_ => Close().ToObservable())
            .Select(_ => Unit.Default);

        await base.Open(null);
    }

    private async UniTask OnClickButtonAnimation(Button button)
    {
        await _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
    }

    private void ApplyViewModel(ViewModel viewModel)
    {
        gameObject.SetActive(true);
        skillIcon.sprite = viewModel._SkillIcon;
        skillName.text = viewModel._SkillName;
        skillDescription.text = viewModel._SkillDescription;
        _intervalText.text = viewModel._Interval;
        _effectTimeText.text = viewModel._EffectTime;
        _rangeText.text = viewModel._Range;
        _abnormalConditionText.text = viewModel._AbnormalCondition;
        _skillTypeText.text = viewModel._SkillType;
    }

    public class ViewModel
    {
        public Sprite _SkillIcon { get; }
        public string _SkillName { get; }
        public string _SkillDescription { get; }
        public string _Interval { get; }
        public string _EffectTime { get; }
        public string _Range { get; }
        public string _SkillType { get; }
        public string _AbnormalCondition { get; }

        public ViewModel
        (
            Sprite skillIcon,
            string skillName,
            string skillDescription,
            string interval,
            string effectTime,
            string range,
            string skillType,
            string abnormalCondition
        )
        {
            _SkillIcon = skillIcon;
            _SkillName = skillName;
            _SkillDescription = skillDescription;
            _Interval = interval;
            _EffectTime = effectTime;
            _Range = range;
            _SkillType = skillType;
            _AbnormalCondition = abnormalCondition;
        }
    }

    public class Factory : PlaceholderFactory<SkillDetailPopup>
    {
    }
}