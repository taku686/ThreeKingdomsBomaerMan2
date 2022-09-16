using Manager;
using Manager.ResourceManager;
using Player.Common;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class Installer : MonoInstaller<Installer>
    {
        [SerializeField] private GameObject resourceManagerGameObject;
        [SerializeField] private GameObject inputManagerGameObject;
        [SerializeField] private GameObject animationManagerGameObject;

        public override void InstallBindings()
        {
            Container.Bind<InputManager>().FromComponentOn(inputManagerGameObject).AsCached();
            Container.Bind<AnimationManager>().FromComponentOn(animationManagerGameObject).AsCached();
           
            InstallResourceManager();
        }

        private void InstallResourceManager()
        {
            Container
                .Bind<ILoadResource>()
                .To<ResourceManager>()
                .FromComponentOn(resourceManagerGameObject)
                .AsCached();
        }
    }
}