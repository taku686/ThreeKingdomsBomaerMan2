using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FS_CombatSystem
{
    public enum EnemySelectionType { TimeWaited, Distance, DistanceAndTimeWaited }

    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] Vector2 timeRangeBetweenAttacks = new Vector2(1, 4);
        [SerializeField] EnemySelectionType criteriaToSelectEnemyToAttack = EnemySelectionType.DistanceAndTimeWaited;

        public CombatController player;

        //[field: SerializeField] public LayerMask EnemyLayer { get; private set; }

        public static EnemyManager i { get; private set; }
        private void Awake()
        {
            i = this;
        }
        [HideInInspector]
        public List<EnemyController> enemiesInRange = new List<EnemyController>();
        float notAttackingTimer = 2;

        public void AddEnemyInRange(EnemyController enemy)
        {
            if (!enemiesInRange.Contains(enemy) && !enemy.IsInState(EnemyStates.Dead))
                enemiesInRange.Add(enemy);
        }

        public void RemoveEnemyInRange(EnemyController enemy)
        {
            enemiesInRange.Remove(enemy);

            if (player == null) return;

            if (enemy == player.TargetEnemy)
            {
                player.TargetEnemy = GetEnemyToTarget(player.GetTargetingDir());
            }
        }

        float timer = 0f;
        private void Update()
        {
            if (enemiesInRange.Count == 0) return;

            if (notAttackingTimer > 0)
                notAttackingTimer -= Time.deltaTime;

            if (!enemiesInRange.Any(e => e.IsInState(EnemyStates.Attack)))
            {
                if (notAttackingTimer <= 0)
                {
                    // Attack the player
                    var attackingEnemy = SelectEnemyForAttack();

                    if (attackingEnemy != null)
                    {
                        attackingEnemy.ChangeState(EnemyStates.Attack);
                        notAttackingTimer = Random.Range(timeRangeBetweenAttacks.x, timeRangeBetweenAttacks.y);
                    }
                }
            }

            if (timer >= 0.1f)
            {
                timer = 0f;
                var closestEnemy = GetEnemyToTarget(player.GetTargetingDir());
                if (closestEnemy != null && closestEnemy != player.TargetEnemy)
                {
                    player.TargetEnemy = closestEnemy;
                }
            }

            timer += Time.deltaTime;
        }

        EnemyController SelectEnemyForAttack()
        {
            var possibleEnemies = enemiesInRange.Where(e => e.Fighter.Target != null && e.IsInState(EnemyStates.CombatMovement) && e.DistanceToTarget <= e.Fighter.MaxAttackRange 
                && e.LineOfSightCheck(e.Fighter.Target) && !e.Fighter.Target.IsInSyncedAnimation).ToList();

            if (criteriaToSelectEnemyToAttack == EnemySelectionType.TimeWaited)
                return possibleEnemies.OrderByDescending(e => e.CombatMovementTimer).FirstOrDefault();
            else if (criteriaToSelectEnemyToAttack == EnemySelectionType.Distance)
                possibleEnemies.OrderBy(e => e.DistanceToTarget).FirstOrDefault();
            else if (criteriaToSelectEnemyToAttack == EnemySelectionType.DistanceAndTimeWaited)
                return possibleEnemies.Select(e => new
                {
                    Enemy = e,
                    Weight = (e.CombatMovementTimer * 5) / (e.DistanceToTarget * 10)
                }).OrderByDescending(e => e.Weight).FirstOrDefault()?.Enemy;

            return null;
        }

        public EnemyController GetAttackingEnemy()
        {
            return enemiesInRange.FirstOrDefault(e => e.IsInState(EnemyStates.Attack));
        }

        public EnemyController GetEnemyToTarget(Vector3 direction)
        {
            float minDistance = Mathf.Infinity;
            float minAngle = Mathf.Infinity;
            float minSum = Mathf.Infinity;
            EnemyController closestEnemy = null;

            foreach (var enemy in enemiesInRange)
            {
                var vecToEnemy = enemy.transform.position - player.transform.position;
                vecToEnemy.y = 0;

                if (player.TargetSelectionCriteria == TargetSelectionCriteria.Direction)
                {
                    float angle = Vector3.Angle(direction, vecToEnemy);
                    if (angle < minAngle)
                    {
                        minAngle = angle;
                        closestEnemy = enemy;
                    }
                }
                else if (player.TargetSelectionCriteria == TargetSelectionCriteria.Distance)
                {
                    float distance = enemy.DistanceToTarget;
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestEnemy = enemy;
                    }
                }
                else if (player.TargetSelectionCriteria == TargetSelectionCriteria.DirectionAndDistance)
                {
                    float weightedSum = enemy.DistanceToTarget + (Vector3.Angle(direction, vecToEnemy) * player.directionScaleFactor);
                    if (weightedSum < minSum)
                    {
                        minSum = weightedSum;
                        closestEnemy = enemy;
                    }
                }
            }

            return closestEnemy;
        }

        //private void OnGUI()
        //{
        //    var style = new GUIStyle();
        //    style.fontSize = 24;

        //    GUILayout.Space(30);
        //    GUILayout.Label("Not attacked timer " + notAttackingTimer, style);
        //}
    }
}
