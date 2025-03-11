using System;
using Zenject;

namespace AttributeAttack.Sample
{
    public class Player : IDisposable
    {
        [Inject] private AttackFactory _attackFactory;

        public void Attack()
        {
            var attack = _attackFactory.Create(PlayerInstaller.AttackAttribute.Normal, null);
            attack.Attack();
            var attack2 = _attackFactory.Create(PlayerInstaller.AttackAttribute.Poison, attack);
            attack2.Attack();
            var attack3 = _attackFactory.Create(PlayerInstaller.AttackAttribute.Water, attack2);
            attack3.Attack();
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Player>
        {
        }
    }
}