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
      public override void InstallBindings()
      {
         Container.Bind<ILoadResource>().To<ResourceManager>().FromComponentInNewPrefab(resourceManagerGameObject).AsCached();
         Container.Bind<CharacterDataModel>().FromNew().AsCached();
         Container.Bind<PhotonNetworkManager>().FromComponentInNewPrefab(photonNetworkGameObject).AsSingle();
      }
   }
}
