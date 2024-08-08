using Assets.Scripts.Common.Data;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Manager;
using Manager.DataManager;
using Manager.NetworkManager;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class ProjectInstaller : MonoInstaller

    {
        [SerializeField] private GameObject photonNetworkGameObject;
        [SerializeField] private GameObject mainManagerGameObject;

        public override void InstallBindings()
        {
            Container.Bind<CharacterDataRepository>().FromNew().AsSingle();
            Container.Bind<CatalogDataManager>().FromNew().AsSingle();
            Container.Bind<CharacterLevelDataRepository>().FromNew().AsSingle();
            Container.Bind<MissionDataRepository>().FromNew().AsCached();
            Container.Bind<PhotonNetworkManager>().FromComponentInNewPrefab(photonNetworkGameObject).AsSingle();
            Container.Bind<MainManager>().FromComponentsInNewPrefab(mainManagerGameObject).AsSingle();
            Container.Bind<UserDataManager>().FromNew().AsSingle();
            Container.Bind<MissionManager>().FromNew().AsSingle();
            Container.Bind<PlayFabCatalogManager>().FromNew().AsCached();
            Container.Bind<PlayFabUserDataManager>().FromNew().AsCached();
        }
    }
}