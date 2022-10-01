using Manager.ResourceManager;
using UI.Common;
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
            Container.Bind<UIAnimation>().FromNew().AsCached();
        }
    }
}