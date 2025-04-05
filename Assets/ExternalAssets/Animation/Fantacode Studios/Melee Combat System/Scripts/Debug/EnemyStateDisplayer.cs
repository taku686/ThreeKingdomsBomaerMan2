using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FS_CombatSystem
{
    public class EnemyStateDisplayer : MonoBehaviour
    {
        EnemyController enemy;
        private void Start()
        {
            enemy = GetComponent<EnemyController>();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (enemy == null) return;

            var style = new GUIStyle() { fontSize = 20 };
            Handles.Label(transform.position + Vector3.up * 2, enemy.currState.ToString(), style);
        }
#endif
    }
}
