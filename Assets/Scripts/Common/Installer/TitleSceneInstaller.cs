using Assets.Scripts.Common.Data;
using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Manager.BattleManager;
using Manager.ResourceManager;
using UI.Common;
using UI.Title;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class TitleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private GameObject playFabManagerGameObject;
      

        public override void InstallBindings()
        {
            Container.Bind<PlayFabManager>().FromComponentOn(playFabManagerGameObject).AsCached();
            Container.Bind<UIAnimation>().FromNew().AsCached();
            Container.Bind<Catalog>().FromNew().AsCached();
            Container.Bind<User>().FromNew().AsCached();
        }
    }
}