using AttributeAttack;
using Bomb;
using Common.Data;
using Manager.BattleManager;
using Repository;
using Skill;
using Skill.Attack;
using Skill.Heal;
using UI.Common;
using UnityEngine;
using Zenject;
using TargetScanner = DC.Scanner.TargetScanner;

namespace Common.Installer
{
    public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private GameObject playerManagerGameObject;
        [SerializeField] private GameObject bombProviderGameObject;
        [SerializeField] private GameObject buttonsGameObject;

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

            SkillInstaller();
            SlashSKillInstaller();
            BuffSkillInstaller();
            HealSkillInstaller();
        }

        private void SkillInstaller()
        {
            Container.Bind<ActiveSkillManager>().AsCached();
            Container.Bind<PassiveSkillManager>().AsCached();
        }

        private void SlashSKillInstaller()
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

        private void BuffSkillInstaller()
        {
            Container.Bind<BuffSkill>().AsCached();
        }

        private void HealSkillInstaller()
        {
            Container.Bind<HealSkill>().AsCached();
        }
    }
}