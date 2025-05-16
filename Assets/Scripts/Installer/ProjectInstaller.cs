using Assets.Scripts.Common.Data;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Manager;
using Manager.DataManager;
using Manager.NetworkManager;
using Repository;
using Skill;
using UI.Common;
using UnityEngine;
using Zenject;

namespace Common.Installer
{
    public class ProjectInstaller : MonoInstaller

    {
        [SerializeField] private GameObject _photonNetworkGameObject;
        [SerializeField] private GameObject _mainManagerGameObject;
        [SerializeField] private GameObject _characterTypeDataGameObject;
        [SerializeField] private GameObject _animatorControllerRepositoryGameObject;
        [SerializeField] private GameObject _skillEffectRepositoryGameObject;

        public override void InstallBindings()
        {
            Container.Bind<CharacterMasterDataRepository>().AsSingle();
            Container.Bind<CatalogDataRepository>().AsSingle();
            Container.Bind<LevelMasterDataRepository>().AsSingle();
            Container.Bind<EntitledMasterDataRepository>().AsSingle();
            Container.Bind<MissionMasterDataRepository>().AsCached();
            Container.Bind<PhotonNetworkManager>().FromComponentInNewPrefab(_photonNetworkGameObject).AsSingle();
            Container.Bind<MainManager>().FromComponentsInNewPrefab(_mainManagerGameObject).AsSingle();
            Container.Bind<CharacterTypeSpriteManager>().FromComponentInNewPrefab(_characterTypeDataGameObject).AsSingle();
            Container.Bind<UserDataRepository>().AsSingle();
            Container.Bind<MissionManager>().AsSingle();
            Container.Bind<PlayFabCatalogManager>().AsCached();
            Container.Bind<PlayFabUserDataManager>().AsCached();
            Container.Bind<SkillMasterDataRepository>().AsCached();
            Container.Bind<WeaponMasterDataRepository>().AsCached();
            Container.Bind<ApplyStatusSkillUseCase>().AsCached();
            Container.Bind<NormalSkillStatusChangeUseCase>().AsCached();
            Container.Bind<AnimatorControllerRepository>().FromComponentInNewPrefab(_animatorControllerRepositoryGameObject).AsSingle();
            Container.Bind<SkillEffectRepository>().FromComponentInNewPrefab(_skillEffectRepositoryGameObject).AsSingle();
            Container.Bind<SkillActivationConditionsUseCase>().AsCached();
        }
    }
}