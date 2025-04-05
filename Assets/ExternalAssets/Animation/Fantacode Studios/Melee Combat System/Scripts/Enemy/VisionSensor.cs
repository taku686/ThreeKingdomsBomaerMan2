using UnityEngine;
namespace FS_CombatSystem
{
    public class VisionSensor : MonoBehaviour
    {
        [SerializeField] EnemyController enemy;

        private void Awake()
        {
            enemy.VisionSensor = this;
        }

        private void OnTriggerEnter(Collider other)
        {
            var isTarget = other.gameObject.layer == LayerMask.NameToLayer("Player");
            if (isTarget)
            {
                var fighter = other.GetComponent<MeleeFighter>();
                enemy.TargetsInRange.Add(fighter);
                EnemyManager.i.AddEnemyInRange(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var isTarget = other.gameObject.layer == LayerMask.NameToLayer("Player");
            if (isTarget)
            {
                var fighter = other.GetComponent<MeleeFighter>();
                enemy.TargetsInRange.Remove(fighter);
                EnemyManager.i.RemoveEnemyInRange(enemy);
            }
        }
    }
}