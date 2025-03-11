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

    public override void InstallBindings()
    {
        Container.BindFactory<ConfirmPopup, ConfirmPopup.Factory>()
            .FromComponentInNewPrefab(_confirmPopupPrefab).UnderTransform(_popupParent).AsTransient();
        Container.BindFactory<InputNamePopup, InputNamePopup.Factory>()
            .FromComponentInNewPrefab(_inputNamePopupPrefab).UnderTransform(_popupParent).AsTransient();
        Container.BindFactory<ErrorPopup, ErrorPopup.Factory>()
            .FromComponentInNewPrefab(_errorPopupPrefab).UnderTransform(_popupParent).AsTransient();
        Container.BindFactory<UserInfoPopup, UserInfoPopup.Factory>()
            .FromComponentInNewPrefab(_userInfoPopupPrefab).UnderTransform(_popupParent).AsTransient();
        Container.Bind<PopupGenerateUseCase>().AsCached();
        Container.Bind<BlockingGameObject>().FromComponentOn(_blockingImageObject).AsCached();
    }
}