using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Manager;
using Manager.NetworkManager;
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
        [SerializeField] private GameObject userManagerGameObject;

        public override void InstallBindings()
        {
            Container.Bind<CharacterDataManager>().FromNew().AsCached();
            Container.Bind<PhotonNetworkManager>().FromComponentInNewPrefab(photonNetworkGameObject).AsSingle();
            Container.Bind<MainManager>().FromComponentsInNewPrefab(mainManagerGameObject).AsSingle();
            Container.Bind<UserDataManager>().FromComponentsInNewPrefab(userManagerGameObject).AsSingle();
            Container.Bind<PlayFabCatalogManager>().FromNew().AsCached();
        }
    }
}