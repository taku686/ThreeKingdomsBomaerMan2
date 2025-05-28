using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UI.Common;
using UI.Common.Popup;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RewardPopup : PopupBase
{
    [SerializeField] private Button _okButton;
    [Inject] private UIAnimation _uiAnimation;
    public Image rewardImage;
    public TextMeshProUGUI rewardText;
    private IObservable<Unit> _onClickOk;
    public IObservable<Unit> _OnClickButton => _onClickOk;

    public async UniTask Open(ViewModel viewModel)
    {
        ApplyViewModel(viewModel);
        _onClickOk = _okButton
            .OnClickAsObservable()
            .Take(1)
            .SelectMany(_ => OnClickButtonAnimation(_okButton).ToObservable())
            .SelectMany(_ => Close().ToObservable())
            .Select(_ => Unit.Default);

        await base.Open(viewModel);
    }

    private void ApplyViewModel(ViewModel viewModel)
    {
        rewardImage.sprite = viewModel._RewardImage;
        rewardText.text = viewModel._RewardCount.ToString();
    }

    private async UniTask OnClickButtonAnimation(Button button)
    {
        await _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
    }

    public class ViewModel : PopupBase.ViewModel
    {
        public Sprite _RewardImage { get; }
        public int _RewardCount { get; }

        public ViewModel
        (
            string titleText,
            string explanationText,
            Sprite rewardImage,
            int rewardCount
        ) : base(titleText, explanationText)
        {
            _RewardImage = rewardImage;
            _RewardCount = rewardCount;
        }
    }

    public class Factory : PlaceholderFactory<RewardPopup>
    {
    }
}