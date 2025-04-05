using System.Collections;
using UnityEngine;
namespace FS_CombatSystem
{

    public class AttackState : State<EnemyController>
    {
        bool isAttacking;

        EnemyController enemy;
        public override void Enter(EnemyController owner)
        {
            enemy = owner;
        }

        public override void Execute()
        {
            if (isAttacking || enemy.Fighter.CurrentWeapon == null) return;

            if (enemy.Fighter.IsBlocking)
                enemy.Fighter.IsBlocking = false;

            StartCoroutine(Attack());
        }

        IEnumerator Attack()
        {
            isAttacking = true;

            enemy.Fighter.TryToAttack(enemy.Fighter.Target);
            int comboCount = enemy.Fighter.CurrAttacksList.Count;
            for (int i = 1; i < comboCount; i++)
            {
                while (enemy.Fighter.State == FighterState.Attacking && !enemy.Fighter.IsInCounterWindow()) yield return null;
                if (enemy.Fighter.State != FighterState.Attacking)
                    break;

                enemy.Fighter.TryToAttack(enemy.Fighter.Target);
                yield return null;
            }

            yield return new WaitUntil(() => enemy.Fighter.AttackState == AttackStates.Idle);

            isAttacking = false;

            if (enemy.IsInState(EnemyStates.Attack))
                enemy.ChangeState(EnemyStates.CombatMovement);
        }

        public override void Exit()
        {
            //enemy.NavAgent.ResetPath();
        }
    }
}