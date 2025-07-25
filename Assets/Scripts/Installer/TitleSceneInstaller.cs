﻿using AttributeAttack;
using Common.Data;
using Manager;
using Manager.NetworkManager;
using Repository;
using Skill;
using Skill.Attack;
using Skill.Attack.FlyingSlash;
using Skill.CrushImpact;
using Skill.DashAttack;
using Skill.Heal;
using Skill.MagicShot;
using Skill.SlashSpin;
using UI.Common;
using UI.Title;
using UI.TitleCore.LoginBonusState;
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
            InstallLoginBonus();

            InstallSlashSKill();
            InstallSlashSpin();
            InstallFlyingSlashSkill();
            InstallDashAttack();
            InstallBuffSkill();
            InstallHealSkill();
            InstallShop();
            InstallSetting();
            InstallCrushImpact();
            InstallMagicShot();
        }

        private void InstallCommon()
        {
            Container.Bind<PlayFabShopManager>().AsCached();
            Container.Bind<SkyBoxManager>().FromComponentOn(_skyBoxManager).AsCached();
            Container.Bind<UIAnimation>().AsCached();
            Container.Bind<UserData>().AsCached();
            Container.Bind<PlayFabAdsManager>().AsCached();
            Container.Bind<ChatGPTManager>().AsCached();
            Container.Bind<CharacterCreateUseCase>().AsCached().WithArguments(characterGenerateParent);
            Container.Bind<CharacterObjectRepository>().AsCached();
            Container.Bind<RewardDataUseCase>().AsCached();
            Container.Bind<StatusSpriteManager>().FromComponentOn(_statusSpriteManager).AsCached();
            Container.Bind<AnimatorControllerRepository>().FromComponentInNewPrefab(_animatorControllerRepositoryGameObject).AsSingle();
            Container.Bind<SetupAnimatorUseCase>().AsCached();
            Container.Bind<ActiveSkillManager>().AsCached();
            Container.Bind<PassiveSkillManager>().AsCached();
            Container.Bind<SaveLocalDataUseCase>().AsCached();
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

        private void InstallLoginBonus()
        {
            Container.Bind<LoginBonusViewModelUseCase>().AsCached();
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
            Container.BindFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeSlashFactory.Factory>().FromFactory<AttributeSlashFactory>();
            Container.BindFactory<Animator, NormalSlash, NormalSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, PoisonSlash, PoisonSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ParalysisSlash, ParalysisSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, FrozenSlash, FrozenSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ConfusionSlash, ConfusionSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, NockBackSlash, NockBackSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, CharmSlash, CharmSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, MiasmaSlash, MiasmaSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, DarknessSlash, DarknessSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, SealedSlash, SealedSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, LifeStealSlash, LifeStealSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, CurseSlash, CurseSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, HellFireSlash, HellFireSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, FearSlash, FearSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, TimeStopSlash, TimeStopSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ApraxiaSlash, ApraxiaSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, SoakingWetSlash, SoakingWetSlash.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, BurningSlash, BurningSlash.Factory>().AsCached();
        }

        private void InstallSlashSpin()
        {
            Container.BindFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeSlashSpinFactory.Factory>().FromFactory<AttributeSlashSpinFactory>();
            Container.BindFactory<Animator, NormalSlashSpin, NormalSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, PoisonSlashSpin, PoisonSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ParalysisSlashSpin, ParalysisSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, FrozenSlashSpin, FrozenSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ConfusionSlashSpin, ConfusionSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, CharmSlashSpin, CharmSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, MiasmaSlashSpin, MiasmaSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, DarknessSlashSpin, DarknessSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, LifeStealSlashSpin, LifeStealSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, HellFireSlashSpin, HellFireSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, StigmataSlashSpin, StigmataSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, SoakingWetSlashSpin, SoakingWetSlashSpin.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, BurningSlashSpin, BurningSlashSpin.Factory>().AsCached();
        }

        private void InstallMagicShot()
        {
            Container.BindFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeMagicShotFactory.Factory>().FromFactory<AttributeMagicShotFactory>();
            Container.BindFactory<Animator, NormalMagicShot, NormalMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, PoisonMagicShot, PoisonMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ParalysisMagicShot, ParalysisMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, FrozenMagicShot, FrozenMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, ConfusionMagicShot, ConfusionMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, CharmMagicShot, CharmMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, MiasmaMagicShot, MiasmaMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, DarknessMagicShot, DarknessMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, LifeStealMagicShot, LifeStealMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, HellFireMagicShot, HellFireMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, StigmataMagicShot, StigmataMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, SoakingWetMagicShot, SoakingWetMagicShot.Factory>().AsCached();
            Container.BindFactory<int, Animator, Transform, IAttackBehaviour, BurningMagicShot, BurningMagicShot.Factory>().AsCached();
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
            Container.BindFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeDashAttackFactory.Factory>().FromFactory<AttributeDashAttackFactory>();
            Container.BindFactory<Animator, NormalDashAttack, NormalDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, PoisonDashAttack, PoisonDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ParalysisDashAttack, ParalysisDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, FrozenDashAttack, FrozenDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ConfusionDashAttack, ConfusionDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, CharmDashAttack, CharmDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, MiasmaDashAttack, MiasmaDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, DarknessDashAttack, DarknessDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, LifeStealDashAttack, LifeStealDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, HellFireDashAttack, HellFireDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, StigmataDashAttack, StigmataDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, SoakingWetDashAttack, SoakingWetDashAttack.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, BurningDashAttack, BurningDashAttack.Factory>().AsCached();
        }

        private void InstallCrushImpact()
        {
            Container.BindFactory<int, Animator, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeCrushImpactFactory.Factory>().FromFactory<AttributeCrushImpactFactory>();
            Container.BindFactory<Transform, NormalCrushImpact, NormalCrushImpact.Factory>().AsCached();
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
            Container.Bind<Heal>().AsCached();
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