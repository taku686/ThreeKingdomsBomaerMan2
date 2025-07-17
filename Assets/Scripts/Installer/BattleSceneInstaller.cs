using AttributeAttack;
using Bomb;
using Character;
using Common.Data;
using Enemy;
using Facade.Skill;
using Manager.BattleManager;
using Player.Common;
using Repository;
using Skill;
using Skill.Attack;
using Skill.Attack.FlyingSlash;
using Skill.ChangeBomb;
using Skill.CrushImpact;
using Skill.DashAttack;
using Skill.Heal;
using Skill.ImpactRock;
using Skill.MagicShot;
using Skill.RainArrow;
using Skill.SlashSpin;
using UI.Common;
using UnityEngine;
using UseCase;
using UseCase.Battle;
using Zenject;

namespace Common.Installer
{
    public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private GameObject playerManagerGameObject;
        [SerializeField] private GameObject bombProviderGameObject;
        [SerializeField] private GameObject buttonsGameObject;
        [SerializeField] private GameObject _animatorControllerRepositoryGameObject;
        [SerializeField] private GameObject _skillEffectActivateGameObject;

        public override void InstallBindings()
        {
            var dummyTransform = transform;
            Container.Bind<CharacterCreateUseCase>().AsCached().WithArguments(dummyTransform);
            Container.Bind<PlayerGeneratorUseCase>().FromComponentOn(playerManagerGameObject).AsCached();
            Container.Bind<BombProvider>().FromComponentOn(bombProviderGameObject).AsCached();
            Container.Bind<InputView>().FromComponentOn(buttonsGameObject).AsCached();
            Container.Bind<StatusInBattleViewModelUseCase>().AsCached();
            Container.Bind<InputViewModelUseCase>().AsCached();
            Container.Bind<BattleResultDataRepository>().AsCached();
            Container.Bind<CharacterObjectRepository>().AsCached();
            Container.Bind<SetupAnimatorUseCase>().AsCached();
            Container.Bind<AbnormalConditionEffectUseCase>().AsCached();
            Container.BindFactory<CharacterData, WeaponMasterData, LevelMasterData, TranslateStatusInBattleUseCase, TranslateStatusInBattleUseCase.Factory>().AsCached();
            Container.Bind<AnimatorControllerRepository>().FromComponentInNewPrefab(_animatorControllerRepositoryGameObject).AsSingle();
            Container.Bind<SkillEffectActivateUseCase>().FromComponentOn(_skillEffectActivateGameObject).AsCached();

            InstallEnemyCore();
            InstallSkill();
            InstallSlashSKill();
            InstallFlyingSlashSkill();
            InstallBuffSkill();
            InstallHealSkill();
            InstallDashAttack();
            InstallCrushImpact();
            InstallSlashSpin();
            InstallMagicShot();
            InstallRainArrowSKill();
            InstallImpactRock();
            InstallChangeBomb();
        }

        private void InstallEnemyCore()
        {
            Container.BindFactory<GameObject, EnemySearchPlayer, EnemySearchPlayer.Factory>().AsCached();
            Container.BindFactory<EnemySkillTimer, EnemySkillTimer.Factory>().AsCached();
            Container.Bind<HpCalculateUseCase>().AsCached();
        }

        private void InstallSkill()
        {
            Container.Bind<ActiveSkillManager>().AsCached();
            Container.Bind<PassiveSkillManager>().AsCached();
            Container.Bind<SkillAnimationFacade>().AsCached();
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

        private void InstallRainArrowSKill()
        {
            Container.BindFactory<int, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeRainArrowFactory.Factory>().FromFactory<AttributeRainArrowFactory>();
            Container.BindFactory<NormalRainArrow, NormalRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, PoisonRainArrow, PoisonRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, FrozenRainArrow, FrozenRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ConfusionRainArrow, ConfusionRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, CharmRainArrow, CharmRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, MiasmaRainArrow, MiasmaRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, DarknessRainArrow, DarknessRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, LifeStealRainArrow, LifeStealRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, HellFireRainArrow, HellFireRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, StigmataRainArrow, StigmataRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, SoakingWetRainArrow, SoakingWetRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, BurningRainArrow, BurningRainArrow.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ParalysisRainArrow, ParalysisRainArrow.Factory>().AsCached();
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

        private void InstallImpactRock()
        {
            Container.BindFactory<int, Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeImpactRockFactory.Factory>().FromFactory<AttributeImpactRockFactory>();
            Container.BindFactory<NormalImpactRock, NormalImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, PoisonImpactRock, PoisonImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ParalysisImpactRock, ParalysisImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, FrozenImpactRock, FrozenImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, ConfusionImpactRock, ConfusionImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, CharmImpactRock, CharmImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, MiasmaImpactRock, MiasmaImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, DarknessImpactRock, DarknessImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, HellFireImpactRock, HellFireImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, StigmataImpactRock, StigmataImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, SoakingWetImpactRock, SoakingWetImpactRock.Factory>().AsCached();
            Container.BindFactory<int, Transform, IAttackBehaviour, BurningImpactRock, BurningImpactRock.Factory>().AsCached();
        }

        private void InstallChangeBomb()
        {
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeChangeBombFactory.Factory>().FromFactory<AttributeChangeBombFactory>();
            Container.BindFactory<NormalChangeBomb, NormalChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, ParalysisChangeBomb, ParalysisChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, HellFireChangeBomb, HellFireChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, DarknessChangeBomb, DarknessChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, LifeStealChangeBomb, LifeStealChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, MiasmaChangeBomb, MiasmaChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, SoakingWetChangeBomb, SoakingWetChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, StigmataChangeBomb, StigmataChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, CharmChangeBomb, CharmChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, BurningChangeBomb, BurningChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, ConfusionChangeBomb, ConfusionChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, FrozenChangeBomb, FrozenChangeBomb.Factory>().AsCached();
            Container.BindFactory<int, PutBomb, PlayerStatusInfo, IAttackBehaviour, PoisonChangeBomb, PoisonChangeBomb.Factory>().AsCached();
        }

        private void InstallBuffSkill()
        {
            Container.Bind<BuffSkill>().AsCached();
        }

        private void InstallHealSkill()
        {
            Container.Bind<Heal>().AsCached();
        }
    }
}