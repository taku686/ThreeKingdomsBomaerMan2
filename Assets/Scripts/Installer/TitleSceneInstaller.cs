using Assets.Scripts.Common.PlayFab;
using AttributeAttack;
using Common.Data;
using DC.Scanner;
using Manager;
using Manager.NetworkManager;
using Manager.PlayFabManager;
using Manager.ResourceManager;
using Repository;
using Skill;
using Skill.Attack;
using Skill.Heal;
using UI.Common;
using UI.Title;
using UI.TitleCore.UserInfoState;
using UnityEngine;
using UseCase;
using UseCase.Battle;
using Zenject;

namespace Common.Installer
{
    public class TitleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private GameObject playFabManagerGameObject;
        [SerializeField] private Transform characterGenerateParent;
        [SerializeField] private GameObject _skyBoxManager;
        [SerializeField] private GameObject _statusSpriteManager;
        [SerializeField] private GameObject _animatorControllerRepositoryGameObject;

        public override void InstallBindings()
        {
            InstallCommon();
            InstallMain();
            InstallCharacterSelect();
            InstallInventory();
            InstallCharacterDetail();
            InstallTeamEdit();
            InstallSlashSKill();
            InstallBuffSkill();
            InstallHealSkill();
        }

        private void InstallCommon()
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
            Container.Bind<StatusSpriteManager>().FromComponentOn(_statusSpriteManager).AsCached();
            Container.Bind<ResourceManager>().AsCached();
            Container.Bind<MissionSpriteDataRepository>().AsCached();
            Container.Bind<AnimatorControllerRepository>().FromComponentInNewPrefab(_animatorControllerRepositoryGameObject).AsSingle();
            Container.Bind<SetupAnimatorUseCase>().AsCached();
            Container.Bind<ActiveSkillManager>().AsCached();
            Container.Bind<PassiveSkillManager>().AsCached();
            Container.Bind<SaveLocalDataUseCase>().AsCached();
            Container.Bind<GetRewardUseCase>().AsCached();
        }

        private void InstallCharacterSelect()
        {
            Container.Bind<SortCharactersUseCase>().AsCached();
            Container.Bind<CharacterSelectViewModelUseCase>().AsCached();
            Container.Bind<TemporaryCharacterRepository>().AsCached();
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
            Container.Bind<WeaponCautionRepository>().AsCached();
        }

        private void InstallMain()
        {
            Container.Bind<UserInfoViewModelUseCase>().AsCached();
            Container.Bind<MainViewModelUseCase>().AsCached();
        }

        private void InstallTeamEdit()
        {
            Container.Bind<TeamEditViewModelUseCase>().AsCached();
            Container.Bind<TeamGridViewModelUseCase>().AsCached();
            Container.Bind<TeamStatusGridViewModelUseCase>().AsCached();
        }

        private void InstallSlashSKill()
        {
            Container.BindFactory<int, TargetScanner, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeSlashFactory.SlashFactory>().FromFactory<AttributeSlashFactory>();
            Container.BindFactory<Animator, NormalSlash, NormalSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, PoisonSlash, PoisonSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, ParalysisSlash, ParalysisSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, FrozenSlash, FrozenSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, ConfusionSlash, ConfusionSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, NockBackSlash, NockBackSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, CharmSlash, CharmSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, MiasmaSlash, MiasmaSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, DarknessSlash, DarknessSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, SealedSlash, SealedSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, LifeStealSlash, LifeStealSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, CurseSlash, CurseSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, HellFireSlash, HellFireSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, FearSlash, FearSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, TimeStopSlash, TimeStopSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, ApraxiaSlash, ApraxiaSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, SoakingWetSlash, SoakingWetSlash.Factory>().AsCached();
            Container.BindFactory<int, TargetScanner, Animator, Transform, IAttackBehaviour, BurningSlash, BurningSlash.Factory>().AsCached();
        }

        private void InstallBuffSkill()
        {
            Container.Bind<BuffSkill>().AsCached();
        }

        private void InstallHealSkill()
        {
            Container.Bind<HealSkill>().AsCached();
        }
    }
}