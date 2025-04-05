using System.Collections;
using UnityEngine;
namespace FS_CombatSystem
{
    public class GettingHitState : State<EnemyController>
    {
        [SerializeField] float stunnTime = 1f;

        EnemyController enemy;
        public override void Enter(EnemyController owner)
        {
            StopAllCoroutines();

            enemy = owner;
            enemy.Fighter.OnHitComplete += () => StartCoroutine(GoToCombatMovement());
        }

        IEnumerator GoToCombatMovement()
        {
            yield return new WaitForSeconds(stunnTime);

            if (!enemy.IsInState(EnemyStates.Dead))
                enemy.ChangeState(EnemyStates.CombatMovement);
        }
    }
}