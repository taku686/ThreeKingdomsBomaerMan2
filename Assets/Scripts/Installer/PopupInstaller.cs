using UnityEngine;
using Zenject;

public class PopupInstaller : MonoInstaller<PopupInstaller>
{
    [SerializeField] private GameObject _confirmPopupPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<ConfirmPopup,  ConfirmPopup.Factory>()
            .FromComponentInNewPrefab(_confirmPopupPrefab).AsTransient();
    }
}