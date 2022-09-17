using Manager;
using Manager.BattleManager;
using Manager.NetworkManager;
using Manager.ResourceManager;
using Player.Common;
using UI.Title.MainTitle;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class Installer : MonoInstaller<Installer>
    {
        [SerializeField] private GameObject resourceManagerGameObject;
        [SerializeField] private GameObject inputManagerGameObject;
        [SerializeField] private GameObject animationManagerGameObject;
        [SerializeField] private GameObject networkManagerGameObject;
        [SerializeField] private GameObject playerManagerGameObject;

        public override void InstallBindings()
        {
            //Manager
            Container.Bind<InputManager>().FromComponentOn(inputManagerGameObject).AsCached();
            Container.Bind<AnimationManager>().FromComponentOn(animationManagerGameObject).AsCached();
            Container.Bind<PlayerManager>().FromComponentOn(playerManagerGameObject).AsCached();
            Container.Bind<PhotonNetworkManager>().FromComponentOn(networkManagerGameObject).AsCached();
            Container
                .Bind<ILoadResource>()
                .To<ResourceManager>()
                .FromComponentOn(resourceManagerGameObject)
                .AsCached();
            //Model
            Container.Bind<TitleModel>().AsCached();
        }
    }
}