#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace FS_CombatSystem
{

    public class TargetDistanceVisualizer : MonoBehaviour
    {
        EnemyController enemy;
        private void Awake()
        {
            enemy = GetComponent<EnemyController>();
        }
        private void Update()
        {

        }
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Handles.color = Color.black;
            if (enemy?.Fighter?.Target != null)
            {
                Gizmos.DrawLine(enemy.transform.position, enemy.Fighter.Target.transform.position); 

                var disp = enemy.Fighter.Target.transform.position - enemy.transform.position;
                Handles.Label(enemy.transform.position + disp / 2, "" + disp.magnitude);
            }
        }
#endif
    }
}