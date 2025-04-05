using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FS_CombatSystem
{
    public class FighterStateDisplayer : MonoBehaviour
    {
        MeleeFighter fighter;
        private void Start()
        {
            fighter = GetComponent<MeleeFighter>();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (fighter == null) return;

            var style = new GUIStyle() { fontSize = 20 };
            Handles.Label(transform.position + Vector3.up * 2, fighter.State.ToString(), style);
        }
#endif
    }
}
