using Assets.Scripts.Common.PlayFab;
using AttributeAttack;
using Common.Data;
using Manager;
using Manager.NetworkManager;
using Manager.PlayFabManager;
using Manager.ResourceManager;
using Player.Common;
using Repository;
using Skill;
using Skill.Attack;
using Skill.Attack.FlyingSlash;
using Skill.CrushImpact;
using Skill.DashAttack;
using Skill.Heal;
using UI.Common;
using UI.Title;
using UI.TitleCore.UserInfoState;
using UnityEngine;
using UseCase;
using UseCase.Battle;
using Zenject;
using TargetScanner = DC.Scanner.TargetScanner;

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
            InstallFlyingSlashSkill();
            InstallDashAttack();
            InstallBuffSkill();
            InstallHealSkill();
            InstallShop();
            InstallSetting();
            InstallCrushImpact();
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
            Container.BindFactory<int, TargetScanner, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeSlashFactory.Factory>().FromFactory<AttributeSlashFactory>();
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

        private void InstallFlyingSlashSkill()
        {
            Container.BindFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeFlyingSlashFactory.Factory>().FromFactory<AttributeFlyingSlashFactory>();
            Container.BindFactory<Animator, NormalFlyingSlash, NormalFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, PoisonFlyingSlash, PoisonFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ParalysisFlyingSlash, ParalysisFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, FrozenFlyingSlash, FrozenFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ConfusionFlyingSlash, ConfusionFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, CharmFlyingSlash, CharmFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, MiasmaFlyingSlash, MiasmaFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, DarknessFlyingSlash, DarknessFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, LifeStealFlyingSlash, LifeStealFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, HellFireFlyingSlash, HellFireFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, StigmataFlyingSlash, StigmataFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, SoakingWetFlyingSlash, SoakingWetFlyingSlash.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, BurningFlyingSlash, BurningFlyingSlash.Factory>().AsCached();
        }

        private void InstallDashAttack()
        {
            Container.BindFactory<int, Animator, PlayerDash, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeDashAttackFactory.Factory>().FromFactory<AttributeDashAttackFactory>();
            Container.BindFactory<Animator, PlayerDash, NormalDashAttack, NormalDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, PoisonDashAttack, PoisonDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ParalysisDashAttack, ParalysisDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, FrozenDashAttack, FrozenDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ConfusionDashAttack, ConfusionDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, CharmDashAttack, CharmDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, MiasmaDashAttack, MiasmaDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, DarknessDashAttack, DarknessDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, LifeStealDashAttack, LifeStealDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, HellFireDashAttack, HellFireDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, StigmataDashAttack, StigmataDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, SoakingWetDashAttack, SoakingWetDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, BurningDashAttack, BurningDashAttack.Factory>().AsCached();
        }

        private void InstallCrushImpact()
        {
            Container.BindFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeCrushImpactFactory.Factory>().FromFactory<AttributeCrushImpactFactory>();
            Container.BindFactory<Animator, Transform, NormalCrushImpact, NormalCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, PoisonCrushImpact, PoisonCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ParalysisCrushImpact, ParalysisCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, FrozenCrushImpact, FrozenCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ConfusionCrushImpact, ConfusionCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, CharmCrushImpact, CharmCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, MiasmaCrushImpact, MiasmaCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, DarknessCrushImpact, DarknessCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, LifeStealCrushImpact, LifeStealCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, HellFireCrushImpact, HellFireCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, StigmataCrushImpact, StigmataCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, SoakingWetCrushImpact, SoakingWetCrushImpact.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, BurningCrushImpact, BurningCrushImpact.Factory>().AsCached();
        }

        private void InstallBuffSkill()
        {
            Container.Bind<BuffSkill>().AsCached();
        }

        private void InstallHealSkill()
        {
            Container.Bind<HealSkill>().AsCached();
        }

        private void InstallShop()
        {
            Container.Bind<PlayStoreShopManager>().AsCached();
            Container.Bind<AdMobManager>().AsCached();
        }

        private void InstallSetting()
        {
            Container.Bind<SettingViewModelUseCase>().AsCached();
        }
    }
}