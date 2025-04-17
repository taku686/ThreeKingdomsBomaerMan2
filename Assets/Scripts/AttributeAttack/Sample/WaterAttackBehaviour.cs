using AttributeAttack;
using UnityEngine;
using Zenject;

public class WaterAttackBehaviour : IAttackBehaviour
{
    private readonly IAttackBehaviour _attackBehaviour;

    [Inject]
    public WaterAttackBehaviour(IAttackBehaviour attackBehaviour)
    {
        _attackBehaviour = attackBehaviour;
    }

    public void Attack()
    {
        _attackBehaviour.Attack();
        Debug.Log("水属性攻撃！");
    }

    public void Dispose()
    {
    }

    public class Factory : PlaceholderFactory<IAttackBehaviour, WaterAttackBehaviour>
    {
    }
}