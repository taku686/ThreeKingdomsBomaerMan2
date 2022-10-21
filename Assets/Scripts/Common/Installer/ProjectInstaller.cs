using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Manager;
using Manager.NetworkManager;
using Manager.ResourceManager;
using UI.Title;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameObject resourceManagerGameObject;
        [SerializeField] private GameObject photonNetworkGameObject;
        [SerializeField] private GameObject mainManagerGameObject;
        [SerializeField] private GameObject catalogManagerGameObject;
        [SerializeField] private GameObject userManagerGameObject;

        public override void InstallBindings()
        {
            // Container.Bind<ILoadResource>().To<ResourceManager>().FromComponentInNewPrefab(resourceManagerGameObject).AsCached();
            /*Container.Bind<ILoadResource>().To<CatalogManager>().FromComponentInNewPrefab(catalogManagerGameObject)
                .AsCached();*/
            Container.Bind<CharacterDataModel>().FromNew().AsCached();
            Container.Bind<PhotonNetworkManager>().FromComponentInNewPrefab(photonNetworkGameObject).AsSingle();
            Container.Bind<MainManager>().FromComponentsInNewPrefab(mainManagerGameObject).AsSingle();
            Container.Bind<UserManager>().FromComponentsInNewPrefab(userManagerGameObject).AsSingle();
            Container.Bind<CatalogManager>().FromComponentsInNewPrefab(catalogManagerGameObject).AsSingle();
        }
    }
}