using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FS_CombatSystem
{
    public class AttachedWeapon : MonoBehaviour
    {
        public WeaponData weapon;
        public GameObject trail;
        [HideInInspector]
        public GameObject unEquipedWeaponModel;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AttachedWeapon))]
    public class AttachedWeaponEditor : Editor
    {
        SerializedProperty unEquipedWeapon;
        bool foldOutExpanded = false;

        private void OnEnable()
        {
            unEquipedWeapon = serializedObject.FindProperty("unEquipedWeaponModel");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            foldOutExpanded = EditorGUILayout.Foldout(foldOutExpanded, "Advanced");
            if (foldOutExpanded)
            {
                EditorGUILayout.PropertyField(unEquipedWeapon);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
