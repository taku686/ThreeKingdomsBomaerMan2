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
        //[SerializeField] private GameObject userManagerGameObject;

        public override void InstallBindings()
        {
            Container.Bind<CharacterDataManager>().FromNew().AsSingle();
            Container.Bind<CatalogDataManager>().FromNew().AsSingle();
            Container.Bind<CharacterLevelDataManager>().FromNew().AsSingle();
            Container.Bind<PhotonNetworkManager>().FromComponentInNewPrefab(photonNetworkGameObject).AsSingle();
            Container.Bind<MainManager>().FromComponentsInNewPrefab(mainManagerGameObject).AsSingle();
            Container.Bind<UserDataManager>().FromNew().AsSingle();
            Container.Bind<PlayFabCatalogManager>().FromNew().AsCached();
        }
    }
}