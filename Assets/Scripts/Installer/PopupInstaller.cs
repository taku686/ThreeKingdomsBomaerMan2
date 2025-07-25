using TitleCore.LoginBonusState;
using UI.Common.Popup;
using UI.Title;
using UI.TitleCore.UserInfoState;
using UnityEngine;
using Zenject;

public class PopupInstaller : MonoInstaller<PopupInstaller>
{
    [SerializeField] private Transform _popupParent;
    [SerializeField] private GameObject _confirmPopupPrefab;
    [SerializeField] private GameObject _blockingImageObject;
    [SerializeField] private GameObject _inputNamePopupPrefab;
    [SerializeField] private GameObject _errorPopupPrefab;
    [SerializeField] private GameObject _userInfoPopupPrefab;
    [SerializeField] private GameObject _skillDetailPopupPrefab;
    [SerializeField] private GameObject _abnormalConditionPopupPrefab;
    [SerializeField] private GameObject _rewardPopupPrefab;
    [SerializeField] private GameObject _settingsPopupPrefab;
    [SerializeField] private GameObject _checkingPopupPrefab;
    [SerializeField] private GameObject _loginBonusPopupPrefab;

    public override void InstallBindings()
    {
        Container.Bind<PopupGenerateUseCase>().AsCached();

        Container.Bind<BlockingGameObject>().FromComponentOn(_blockingImageObject).AsCached();

        Container.BindFactory<ConfirmPopup, ConfirmPopup.Factory>()
            .FromComponentInNewPrefab(_confirmPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container.BindFactory<InputNamePopup, InputNamePopup.Factory>()
            .FromComponentInNewPrefab(_inputNamePopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container.BindFactory<ErrorPopup, ErrorPopup.Factory>()
            .FromComponentInNewPrefab(_errorPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container.BindFactory<UserInfoPopup, UserInfoPopup.Factory>()
            .FromComponentInNewPrefab(_userInfoPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container
            .BindFactory<SkillDetailPopup, SkillDetailPopup.Factory>()
            .FromComponentInNewPrefab(_skillDetailPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container.BindFactory<AbnormalConditionPopup, AbnormalConditionPopup.Factory>()
            .FromComponentInNewPrefab(_abnormalConditionPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container.BindFactory<RewardPopup, RewardPopup.Factory>()
            .FromComponentInNewPrefab(_rewardPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container.BindFactory<SettingPopup, SettingPopup.Factory>()
            .FromComponentInNewPrefab(_settingsPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container.BindFactory<CheckingPopup, CheckingPopup.Factory>()
            .FromComponentInNewPrefab(_checkingPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();

        Container.BindFactory<LoginBonusPopup, LoginBonusPopup.Factory>()
            .FromComponentInNewPrefab(_loginBonusPopupPrefab)
            .UnderTransform(_popupParent)
            .AsTransient();
    }
}