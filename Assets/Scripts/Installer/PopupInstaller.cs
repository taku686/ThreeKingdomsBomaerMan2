using UnityEngine;
using Zenject;

public class PopupInstaller : MonoInstaller<PopupInstaller>
{
    [SerializeField] private Transform _popupParent;
    [SerializeField] private GameObject _confirmPopupPrefab;
    [SerializeField] private GameObject _blockingImageObject;

    public override void InstallBindings()
    {
        Container.BindFactory<ConfirmPopup, ConfirmPopup.Factory>()
            .FromComponentInNewPrefab(_confirmPopupPrefab).UnderTransform(_popupParent).AsTransient();
        Container.Bind<PopupGenerateUseCase>().AsCached();
        Container.Bind<BlockingGameObject>().FromComponentOn(_blockingImageObject).AsCached();
    }
}