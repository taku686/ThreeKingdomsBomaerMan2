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
            Container.Bind<CharacterDataRepository>().AsSingle();
            Container.Bind<CatalogDataManager>().AsSingle();
            Container.Bind<CharacterLevelDataRepository>().AsSingle();
            Container.Bind<MissionDataRepository>().AsCached();
            Container.Bind<PhotonNetworkManager>().FromComponentInNewPrefab(photonNetworkGameObject).AsSingle();
            Container.Bind<MainManager>().FromComponentsInNewPrefab(mainManagerGameObject).AsSingle();
            Container.Bind<UserDataManager>().AsSingle();
            Container.Bind<MissionManager>().AsSingle();
            Container.Bind<PlayFabCatalogManager>().AsCached();
            Container.Bind<PlayFabUserDataManager>().AsCached();
            Container.Bind<SkillDataRepository>().AsCached();
        }
    }
}