using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Manager.NetworkManager;
using Manager.PlayFabManager;
using UI.Common;
using UI.Title;
using UnityEngine;
using UseCase;
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
            Container.Bind<PlayFabShopManager>().FromNew().AsCached();
            Container.Bind<PlayFabAdsManager>().FromNew().AsCached();
            Container.Bind<PlayFabVirtualCurrencyManager>().FromNew().AsCached();
            Container.Bind<PlayFabTitleDataManager>().FromNew().AsCached();
            Container.Bind<ChatGPTManager>().FromNew().AsCached();
            InstallCharacterSelect();
            InstallInventory();
        }

        private void InstallCharacterSelect()
        {
            Container.Bind<SortCharactersUseCase>().AsCached();
            Container.Bind<CharacterSelectViewModelUseCase>().AsCached();
            Container.Bind<CharacterSelectRepository>().AsCached();
        }

        private void InstallInventory()
        {
            Container.Bind<InventoryViewModelUseCase>().AsCached();
        }
    }
}