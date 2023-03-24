using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Manager.NetworkManager;
using Manager.PlayFabManager;
using UI.Common;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class TitleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private GameObject playFabManagerGameObject;


        public override void InstallBindings()
        {
            Container.Bind<PlayFabLoginManager>().FromComponentOn(playFabManagerGameObject).AsCached();
            Container.Bind<UIAnimation>().FromNew().AsCached();
            Container.Bind<UserData>().FromNew().AsCached();
            Container.Bind<PlayFabUserDataManager>().FromNew().AsCached();
            Container.Bind<PlayFabShopManager>().FromNew().AsCached();
            Container.Bind<PlayFabAdsManager>().FromNew().AsCached();
            Container.Bind<PlayFabInventoryManager>().FromNew().AsCached();
            Container.Bind<PlayFabTitleDataManager>().FromNew().AsCached();
        }
    }
}