using System;
using Cysharp.Threading.Tasks;
using TitleCore.LoginBonusState;
using UI.Common.Popup;
using UI.Title;
using UI.TitleCore.UserInfoState;
using UniRx;
using Zenject;

public class PopupGenerateUseCase : IDisposable
{
    [Inject] private ConfirmPopup.Factory _confirmPopupFactory;
    [Inject] private InputNamePopup.Factory _inputNamePopupFactory;
    [Inject] private ErrorPopup.Factory _errorPopupFactory;
    [Inject] private UserInfoPopup.Factory _userInfoPopupFactory;
    [Inject] private SkillDetailPopup.Factory _skillDetailPopupFactory;
    [Inject] private AbnormalConditionPopup.Factory _abnormalConditionPopupFactory;
    [Inject] private RewardPopup.Factory _rewardPopupFactory;
    [Inject] private SettingPopup.Factory _settingPopupFactory;
    [Inject] private CheckingPopup.Factory _checkingPopupFactory;
    [Inject] private LoginBonusPopup.Factory _loginBonusPopupFactory;

    public IObservable<bool> GenerateConfirmPopup
    (
        string title,
        string explanation,
        string okText = "はい",
        string cancelText = "いいえ"
    )
    {
        var viewModel = new ConfirmPopup.ViewModel(title, explanation, okText, cancelText);
        var confirmPopup = _confirmPopupFactory.Create();
        confirmPopup.Open(viewModel).Forget();
        return confirmPopup._OnClickButton;
    }

    public IObservable<string> GenerateInputNamePopup
    (
        string title,
        string explanation,
        string okText = "決定"
    )
    {
        var viewModel = new InputNamePopup.ViewModel(title, explanation, okText);
        var inputNamePopup = _inputNamePopupFactory.Create();
        inputNamePopup.Open(viewModel).Forget();
        return inputNamePopup._OnClickButton;
    }

    public IObservable<Unit> GenerateErrorPopup
    (
        string explanation,
        string title = "エラー",
        string okText = "OK"
    )
    {
        var viewModel = new SingleButtonPopup.ViewModel(title, explanation, okText);
        var errorPopup = _errorPopupFactory.Create();
        errorPopup.Open(viewModel).Forget();
        return errorPopup._OnClickButton;
    }

    public IObservable<Unit> GenerateCheckingPopup
    (
        string explanation,
        string title,
        string buttonText
    )
    {
        var viewModel = new SingleButtonPopup.ViewModel(title, explanation, buttonText);
        var checkingPopup = _checkingPopupFactory.Create();
        checkingPopup.Open(viewModel).Forget();
        return checkingPopup._OnClickButton;
    }

    public IObservable<Unit> GenerateUserInfoPopup(UserInfoPopup.ViewModel viewModel)
    {
        var userInfoPopup = _userInfoPopupFactory.Create();
        userInfoPopup.Open(viewModel).Forget();
        return userInfoPopup._OnClickButton;
    }

    public IObservable<Unit> GenerateSkillDetailPopup(SkillDetailPopup.ViewModel viewModel)
    {
        var skillDetailPopup = _skillDetailPopupFactory.Create();
        skillDetailPopup.Open(viewModel).Forget();
        return skillDetailPopup._OnClickButton;
    }

    public IObservable<Unit> GenerateAbnormalConditionPopup(AbnormalConditionPopup.ViewModel viewModel)
    {
        var abnormalConditionPopup = _abnormalConditionPopupFactory.Create();
        abnormalConditionPopup.Open(viewModel).Forget();
        return abnormalConditionPopup._OnClickButton;
    }

    public IObservable<Unit> GenerateRewardPopup(RewardPopup.ViewModel viewModel)
    {
        var rewardPopup = _rewardPopupFactory.Create();
        rewardPopup.Open(viewModel).Forget();
        return rewardPopup._OnClickButton;
    }

    public IObservable<Unit> GenerateSettingPopup(SettingPopup.ViewModel viewModel)
    {
        var settingPopup = _settingPopupFactory.Create();
        settingPopup.Open(viewModel).Forget();
        return settingPopup._OnClickButton;
    }

    public async UniTask<LoginBonusPopup> GenerateLoginBonusPopup()
    {
        var loginBonusPopup = _loginBonusPopupFactory.Create();
        return await loginBonusPopup.Open();
    }

    public void Dispose()
    {
        // TODO マネージリソースをここで解放します
    }
}