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
    }

    public class ViewModel
    {
        public Sprite _SkillIcon { get; }
        public string _SkillName { get; }
        public string _SkillDescription { get; }

        public ViewModel
        (
            Sprite skillIcon,
            string skillName,
            string skillDescription
        )
        {
            _SkillIcon = skillIcon;
            _SkillName = skillName;
            _SkillDescription = skillDescription;
        }
    }

    public class Factory : PlaceholderFactory<SkillDetailPopup>
    {
    }
}