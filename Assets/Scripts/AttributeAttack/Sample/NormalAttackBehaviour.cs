using Common.Data;
using UnityEngine;
using Zenject;

namespace AttributeAttack.Sample
{
    public class NormalAttackBehaviour : IAttackBehaviour
    {
        public void Attack()
        {
            Debug.Log("通常攻撃した！");
        }

        public void Attack(AbnormalCondition attribute)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }

        public class Factory : PlaceholderFactory<NormalAttackBehaviour>
        {
        }
    }
}