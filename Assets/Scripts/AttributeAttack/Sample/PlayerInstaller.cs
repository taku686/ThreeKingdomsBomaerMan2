using Zenject;

namespace AttributeAttack.Sample
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Initializer>().AsSingle();
            Container.BindFactory<NormalAttackBehaviour, NormalAttackBehaviour.Factory>().AsCached();
            Container.BindFactory<IAttackBehaviour, PoisonAttackBehaviour, PoisonAttackBehaviour.Factory>().AsCached();
            Container.BindFactory<IAttackBehaviour, WaterAttackBehaviour, WaterAttackBehaviour.Factory>().AsCached();
            Container.BindFactory<AttackAttribute, IAttackBehaviour, IAttackBehaviour, AttackFactory>().FromFactory<AttributeAttackFactory>();
            Container.BindFactory<Player, Player.Factory>().AsCached();
        }

        public enum AttackAttribute
        {
            Normal,
            Poison,
            Water
        }
    }
}