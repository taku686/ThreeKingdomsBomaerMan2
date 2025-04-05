using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace FS_CombatSystem
{
    [CustomEditor(typeof(CombatController))]
    public class CombatControllerEditor : Editor
    {
        public SerializedProperty targetSelectionCriteria;
        public SerializedProperty directionScaleFactor;

        private void OnEnable()
        {
            targetSelectionCriteria = serializedObject.FindProperty("targetSelectionCriteria");
            directionScaleFactor = serializedObject.FindProperty("directionScaleFactor");
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            if (targetSelectionCriteria.enumValueIndex == (int)TargetSelectionCriteria.DirectionAndDistance)
                EditorGUILayout.PropertyField(directionScaleFactor);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
