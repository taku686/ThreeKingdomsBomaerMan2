using FS_ThirdPerson;

namespace FS_CombatSystem
{

    public class IdleState : State<EnemyController>
    {
        EnemyController enemy;
        public override void Enter(EnemyController owner)
        {
            enemy = owner;

            enemy.Animator?.SetBool(AnimatorParameters.combatMode, false);
        }

        public override void Execute()
        {
            if (enemy.Fighter.CurrentWeapon == null) return;

            enemy.Fighter.Target = enemy.FindTarget();
            if (enemy.Fighter.Target != null)
            {
                enemy.AlertNearbyEnemies();
                enemy.ChangeState(EnemyStates.CombatMovement);
            }
        }

        public override void Exit()
        {

        }
    }
}
