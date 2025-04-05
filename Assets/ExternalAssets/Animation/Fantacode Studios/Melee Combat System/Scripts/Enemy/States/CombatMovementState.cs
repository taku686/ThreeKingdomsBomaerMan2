using FS_ThirdPerson;
using UnityEngine;
namespace FS_CombatSystem
{
    public enum AICombatStates { Idle, Chase, Circling }

    public class CombatMovementState : State<EnemyController>
    {

        [SerializeField] float adjustDistanceThreshold = 1f;
        [SerializeField] Vector2 idleTimeRange = new Vector2(2, 5);
        [SerializeField] Vector2 circlingTimeRange = new Vector2(3, 6);
        [SerializeField] float rotateTowardsTargetSpeed = 150f;

        float circlingDistThreshold = 1.5f;

        float timer = 0f;

        int circlingDir = 1;
        bool slowChase = true;

        AICombatStates state;

        EnemyController enemy;
        public override void Enter(EnemyController owner)
        {
            enemy = owner;

            enemy.NavAgent.stoppingDistance = enemy.Fighter.PreferredFightingRange;
            enemy.CombatMovementTimer = 0f;

            enemy.Animator.SetBool(AnimatorParameters.combatMode, true);

            state = AICombatStates.Idle;
        }

        public override void Execute()
        {
            if (enemy.Fighter.CurrentWeapon == null) return;
            if (enemy.Fighter.Target == null || enemy.Fighter.Target.CurrentHealth <= 0)
            {
                enemy.Fighter.Target = null;
                enemy.ChangeState(EnemyStates.Idle);
                return;
            }

            enemy.CalculateDistanceToTarget();

            if ((enemy.DistanceToTarget > enemy.Fighter.MaxAttackRange || enemy.NavAgent.Raycast(enemy.Fighter.Target.transform.position, out _)) && state != AICombatStates.Chase)
                StartChase();

            if (state == AICombatStates.Idle)
            {
                if (timer <= 0)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        StartIdle();
                    }
                    else
                    {
                        StartCircling();
                    }
                }
                if (enemy.Fighter.Target != null)
                {
                    var vecToTarget = (enemy.transform.position - enemy.Fighter.Target.transform.position);
                    vecToTarget.y = 0f;
                    vecToTarget.Normalize();
                    var targetRot = Quaternion.LookRotation(-vecToTarget);

                    if (Vector3.Angle(enemy.transform.forward, -vecToTarget) > rotateTowardsTargetSpeed  * Time.deltaTime)
                        enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, targetRot, rotateTowardsTargetSpeed * Time.deltaTime);
                    else
                        enemy.transform.rotation = targetRot;
                }

            }
            else if (state == AICombatStates.Chase)
            {
                if (enemy.DistanceToTarget <= enemy.Fighter.PreferredFightingRange + 0.03f)
                {
                    StartIdle();
                    return;
                }

                // If the target is too far, then run and chase fast
                if (slowChase)
                {
                    if (enemy.DistanceToTarget >= enemy.Fighter.MaxAttackRange + 5)
                    {
                        slowChase = false;
                        enemy.NavAgent.speed = enemy.RunSpeed;
                        enemy.Animator.SetBool(AnimatorParameters.combatMode, false);
                    }
                }

                enemy.NavAgent.SetDestination(enemy.Fighter.Target.transform.position);
            }
            else if (state == AICombatStates.Circling)
            {
                if (timer <= 0 || enemy.DistanceToTarget < circlingDistThreshold)
                {
                    StartIdle();
                    return;
                }

                var vecToTarget = enemy.transform.position - enemy.Fighter.Target.transform.position;
                var rotatedPos = Quaternion.Euler(0, enemy.CombatModeSpeed * circlingDir * Time.deltaTime, 0) * vecToTarget;

                enemy.NavAgent.Move((rotatedPos - vecToTarget).normalized * enemy.CombatModeSpeed * Time.deltaTime);
                var rotatedPosXZ = rotatedPos;
                rotatedPosXZ.y = 0;
                enemy.transform.rotation = Quaternion.LookRotation(-rotatedPosXZ);
            }

            if (timer > 0)
                timer -= Time.deltaTime;

            enemy.CombatMovementTimer += Time.deltaTime;
        }

        void StartChase()
        {
            state = AICombatStates.Chase;
            slowChase = true;
            enemy.NavAgent.speed = enemy.CombatModeSpeed;
        }

        void StartIdle()
        {
            enemy.Animator.SetBool(AnimatorParameters.combatMode, true);

            state = AICombatStates.Idle;
            timer = Random.Range(idleTimeRange.x, idleTimeRange.y);
        }

        void StartCircling()
        {
            enemy.Animator.SetBool(AnimatorParameters.combatMode, true);

            state = AICombatStates.Circling;
            timer = Random.Range(circlingTimeRange.x, circlingTimeRange.y);

            circlingDir = Random.Range(0, 2) == 0 ? 1 : -1;
        }

        public override void Exit()
        {
            enemy.CombatMovementTimer = 0f;
            enemy.NavAgent?.ResetPath();
        }

        //private void OnGUI()
        //{
        //    var style = new GUIStyle();
        //    style.fontSize = 24;

        //    GUILayout.Label(state.ToString(), style);
        //}
    }
}