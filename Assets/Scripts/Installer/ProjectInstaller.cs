using Assets.Scripts.Common.Data;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Manager;
using Manager.DataManager;
using Manager.NetworkManager;
using Repository;
using Skill;
using UI.Common;
using UI.Title;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class ProjectInstaller : MonoInstaller

    {
        [SerializeField] private GameObject _photonNetworkGameObject;
        [SerializeField] private GameObject _mainManagerGameObject;
        [SerializeField] private GameObject _characterTypeDataGameObject;
        [SerializeField] private GameObject _skillEffectRepositoryGameObject;
        [SerializeField] private GameObject _abnormalConditionSpriteRepositoryGameObject;
        [SerializeField] private GameObject _resourcesObjectRepositoryGameObject;

        public override void InstallBindings()
        {
            Container.Bind<RewardDataRepository>().AsCached();
            Container.Bind<CharacterMasterDataRepository>().AsSingle();
            Container.Bind<AbnormalConditionMasterDataRepository>().AsSingle();
            Container.Bind<CatalogDataRepository>().AsSingle();
            Container.Bind<LevelMasterDataRepository>().AsSingle();
            Container.Bind<EntitledMasterDataRepository>().AsSingle();
            Container.Bind<MissionMasterDataRepository>().AsCached();
            Container.Bind<UserDataRepository>().AsSingle();
            Container.Bind<MissionManager>().AsSingle();
            Container.Bind<PlayFabCatalogManager>().AsCached();
            Container.Bind<PlayFabUserDataManager>().AsCached();
            Container.Bind<SkillMasterDataRepository>().AsCached();
            Container.Bind<WeaponMasterDataRepository>().AsCached();
            Container.Bind<ApplyStatusSkillUseCase>().AsCached();
            Container.Bind<NormalSkillStatusChangeUseCase>().AsCached();
            Container.Bind<SkillActivationConditionsUseCase>().AsCached();
            Container.Bind<AbnormalConditionViewModelUseCase>().AsCached();
            Container.Bind<PhotonNetworkManager>().FromComponentInNewPrefab(_photonNetworkGameObject).AsSingle();
            Container.Bind<MainManager>().FromComponentsInNewPrefab(_mainManagerGameObject).AsSingle();
            Container.Bind<CharacterTypeSpriteRepository>().FromComponentInNewPrefab(_characterTypeDataGameObject).AsSingle();
            Container.Bind<AbnormalConditionSpriteRepository>().FromComponentInNewPrefab(_abnormalConditionSpriteRepositoryGameObject).AsSingle();
            Container.Bind<SkillEffectRepository>().FromComponentInNewPrefab(_skillEffectRepositoryGameObject).AsSingle();
            Container.Bind<ResourcesObjectRepository>().FromComponentInNewPrefab(_resourcesObjectRepositoryGameObject).AsSingle();
        }
    }
}