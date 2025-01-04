using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UI.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetailView : MonoBehaviour
{
    [SerializeField] private Image skillIcon;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private Button closeButton;
    private UIAnimation _uiAnimation;
    private Action<bool> _setActivePanelAction;

    public IObservable<AsyncUnit> OnClickCloseButtonAsObservable()
    {
        return closeButton.OnClickAsObservable()
            .Do(_ => _setActivePanelAction.Invoke(true))
            .SelectMany(_ => _uiAnimation.ClickScaleColor(closeButton.gameObject).ToUniTask().ToObservable());
    }

    public void ApplyViewModel(ViewModel viewModel, UIAnimation uiAnimation, Action<bool> setActivePanelAction)
    {
        gameObject.SetActive(true);
        _uiAnimation = uiAnimation;
        skillIcon.sprite = viewModel._SkillIcon;
        skillName.text = viewModel._SkillName;
        skillDescription.text = viewModel._SkillDescription;
        _setActivePanelAction = setActivePanelAction;
    }

    public void Close()
    {
        gameObject.SetActive(false);
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
}