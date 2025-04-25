using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Manager;
using Manager.NetworkManager;
using Manager.PlayFabManager;
using Manager.ResourceManager;
using PlayFab.MultiplayerModels;
using Repository;
using UI.Common;
using UI.Title;
using UI.TitleCore.UserInfoState;
using UnityEngine;
using UseCase;
using Zenject;

namespace Common.Installer
{
    public class TitleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private GameObject playFabManagerGameObject;
        [SerializeField] private Transform characterGenerateParent;
        [SerializeField] private GameObject animatorControllerRepository;
        [SerializeField] private GameObject _skyBoxManager;
        [SerializeField] private GameObject _statusSpriteManager;

        public override void InstallBindings()
        {
            Container.Bind<PlayFabLoginManager>().FromComponentOn(playFabManagerGameObject).AsCached();
            Container.Bind<SkyBoxManager>().FromComponentOn(_skyBoxManager).AsCached();
            Container.Bind<UIAnimation>().AsCached();
            Container.Bind<UserData>().AsCached();
            Container.Bind<PlayFabShopManager>().AsCached();
            Container.Bind<PlayFabAdsManager>().AsCached();
            Container.Bind<PlayFabVirtualCurrencyManager>().AsCached();
            Container.Bind<PlayFabTitleDataManager>().AsCached();
            Container.Bind<ChatGPTManager>().AsCached();
            Container.Bind<CharacterCreateUseCase>().AsCached().WithArguments(characterGenerateParent);
            Container.Bind<CharacterObjectRepository>().AsCached();
            Container.Bind<RewardDataUseCase>().AsCached();
            Container.Bind<RewardDataRepository>().AsCached();
            Container.Bind<AnimatorControllerRepository>().FromComponentOn(animatorControllerRepository).AsCached();
            Container.Bind<StatusSpriteManager>().FromComponentOn(_statusSpriteManager).AsCached();
            Container.Bind<ResourceManager>().AsCached();
            Container.Bind<MissionSpriteDataRepository>().AsCached();


            InstallCharacterSelect();
            InstallInventory();
            InstallCharacterDetail();
            InstallMain();
            InstallTeamEdit();
        }

        private void InstallCharacterSelect()
        {
            Container.Bind<SortCharactersUseCase>().AsCached();
            Container.Bind<CharacterSelectViewModelUseCase>().AsCached();
            Container.Bind<CharacterSelectRepository>().AsCached();
        }

        private void InstallCharacterDetail()
        {
            Container.Bind<CharacterDetailViewModelUseCase>().AsCached();
            Container.Bind<AnimationPlayBackUseCase>().AsCached();
        }

        private void InstallInventory()
        {
            Container.Bind<InventoryViewModelUseCase>().AsCached();
            Container.Bind<SkillDetailViewModelUseCase>().AsCached();
            Container.Bind<WeaponSortRepository>().AsCached();
            Container.Bind<SortWeaponUseCase>().AsCached();
        }

        private void InstallMain()
        {
            Container.Bind<UserInfoViewModelUseCase>().AsCached();
        }

        private void InstallTeamEdit()
        {
            Container.Bind<TeamEditViewModelUseCase>().AsCached();
            Container.Bind<TeamGridViewModelUseCase>().AsCached();
            Container.Bind<TeamStatusGridViewModelUseCase>().AsCached();
        }
    }
}