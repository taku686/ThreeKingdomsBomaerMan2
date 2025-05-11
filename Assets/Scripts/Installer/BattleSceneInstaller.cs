using AttributeAttack;
using AttributeAttack.Sample;
using Bomb;
using Common.Data;
using Manager.BattleManager;
using Repository;
using Skill;
using Skill.Attack;
using UI.Common;
using UnityEngine;
using Zenject;

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

            SlashSKillInstaller();
        }

        private void SlashSKillInstaller()
        {
            Container.Bind<SkillManager>().AsCached();
            Container.BindFactory<Transform, AbnormalCondition, IAttackBehaviour, IAttackBehaviour, AttributeSlashFactory.SlashFactory>().FromFactory<AttributeSlashFactory>();
            Container.BindFactory<NormalSlash, NormalSlash.Factory>().AsCached();
            Container.BindFactory<IAttackBehaviour, PoisonSlash, PoisonSlash.Factory>().AsCached();
            Container.BindFactory<IAttackBehaviour, ParalysisSlash, ParalysisSlash.Factory>().AsCached();
        }
    }
}