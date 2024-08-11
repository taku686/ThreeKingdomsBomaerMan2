using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Manager.NetworkManager;
using Manager.PlayFabManager;
using Repository;
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
        [SerializeField] private Transform characterGenerateParent;


        public override void InstallBindings()
        {
            Container.Bind<PlayFabLoginManager>().FromComponentOn(playFabManagerGameObject).AsCached();
            Container.Bind<UIAnimation>().AsCached();
            Container.Bind<UserData>().AsCached();
            Container.Bind<PlayFabShopManager>().AsCached();
            Container.Bind<PlayFabAdsManager>().AsCached();
            Container.Bind<PlayFabVirtualCurrencyManager>().AsCached();
            Container.Bind<PlayFabTitleDataManager>().AsCached();
            Container.Bind<ChatGPTManager>().AsCached();
            Container.Bind<CharacterCreateUseCase>().AsCached().WithArguments(characterGenerateParent);
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