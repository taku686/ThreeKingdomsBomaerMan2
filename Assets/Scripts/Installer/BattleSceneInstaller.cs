using AttributeAttack;
using Bomb;
using Common.Data;
using Manager.BattleManager;
using Player.Common;
using Repository;
using Skill;
using Skill.Attack;
using Skill.Attack.FlyingSlash;
using Skill.CrushImpact;
using Skill.DashAttack;
using Skill.Heal;
using UI.Common;
using UnityEngine;
using UseCase.Battle;
using Zenject;
using TargetScanner = DC.Scanner.TargetScanner;

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
            Container.Bind<PlayerGeneratorUseCase>().FromComponentOn(playerManagerGameObject).AsCached();
            Container.Bind<BombProvider>().FromComponentOn(bombProviderGameObject).AsCached();
            Container.Bind<InputView>().FromComponentOn(buttonsGameObject).AsCached();
            Container.Bind<StatusInBattleViewModelUseCase>().AsCached();
            Container.Bind<InputViewModelUseCase>().AsCached();
            Container.Bind<BattleResultDataRepository>().AsCached();
            var dummyTransform = transform;
            Container.Bind<CharacterCreateUseCase>().AsCached().WithArguments(dummyTransform);
            Container.Bind<CharacterObjectRepository>().AsCached();
            Container.Bind<SetupAnimatorUseCase>().AsCached();
            Container.BindFactory<CharacterData, WeaponMasterData, LevelMasterData, TranslateStatusInBattleUseCase, TranslateStatusInBattleUseCase.Factory>().AsCached();
            Container.Bind<AnimatorControllerRepository>().FromComponentInNewPrefab(_animatorControllerRepositoryGameObject).AsSingle();
            Container.Bind<SkillEffectActivateUseCase>().FromComponentOn(_skillEffectActivateGameObject).AsCached();

            InstallSkill();
            InstallSlashSKill();
            InstallFlyingSlashSkill();
            InstallBuffSkill();
            InstallHealSkill();
            InstallDashAttack();
            InstallCrushImpact();
        }

        private void InstallSkill()
        {
            Container.Bind<ActiveSkillManager>().AsCached();
            Container.Bind<PassiveSkillManager>().AsCached();
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
            Container.BindFactory<Animator, NormalCrushImpact, NormalCrushImpact.Factory>().AsCached();
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