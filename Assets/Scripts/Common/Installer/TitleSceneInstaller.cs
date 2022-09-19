using Manager.ResourceManager;
using UI.Title;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class TitleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private GameObject resourceManagerGameObject;

        public override void InstallBindings()
        {
            //Manager
            Container.Bind<ILoadResource>().To<ResourceManager>().FromComponentOn(resourceManagerGameObject).AsCached();
            //Model
            Container.Bind<TitleModel>().FromNew().AsCached();
        }
    }
}