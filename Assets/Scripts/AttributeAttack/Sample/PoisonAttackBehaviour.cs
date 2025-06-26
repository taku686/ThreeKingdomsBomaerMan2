using Common.Data;
using UnityEngine;
using Zenject;

namespace AttributeAttack.Sample
{
    public class PoisonAttackBehaviour : IAttackBehaviour
    {
        private readonly IAttackBehaviour _attackBehaviour;

        [Inject]
        public PoisonAttackBehaviour(IAttackBehaviour attackBehaviour)
        {
            _attackBehaviour = attackBehaviour;
        }

        public void Attack()
        {
            _attackBehaviour.Attack();
            Debug.Log("毒状態を付与した！");
        }

        public void Attack(AbnormalCondition attribute)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<IAttackBehaviour, PoisonAttackBehaviour>
        {
        }
    }
}