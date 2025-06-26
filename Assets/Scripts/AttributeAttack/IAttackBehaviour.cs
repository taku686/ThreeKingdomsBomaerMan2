using System;

namespace AttributeAttack
{
    public interface IAttackBehaviour : IDisposable
    {
         void Attack();
    }
}