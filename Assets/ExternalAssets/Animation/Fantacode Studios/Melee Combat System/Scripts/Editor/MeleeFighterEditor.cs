#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace FS_CombatSystem
{

    [CanEditMultipleObjects]
    [CustomEditor(typeof(MeleeFighter))]
    public class MeleeFighterEditor : Editor
    {
        public SerializedProperty onAttackEvent;
        public SerializedProperty onGotHitEvent;
        public SerializedProperty OnWeaponEquipEvent;
        public SerializedProperty OnWeaponUnEquipEvent;
        public SerializedProperty OnCounterMisusedEvent;
        public SerializedProperty OnKnockDownEvent;
        public SerializedProperty OnGettingUpEvent;
        public SerializedProperty OnDeathEvent;

        public SerializedProperty CanDodge;
        public SerializedProperty dodgeData;
        public SerializedProperty OnlyDodgeInCombatMode;

        public SerializedProperty CanRoll;
        public SerializedProperty rollData;
        public SerializedProperty OnlyRollInCombatMode;

        bool eventFoldOut;

        private void OnEnable()
        {
            onAttackEvent = serializedObject.FindProperty("OnAttackEvent");
            onGotHitEvent = serializedObject.FindProperty("OnGotHitEvent");
            OnWeaponEquipEvent = serializedObject.FindProperty("OnWeaponEquipEvent");
            OnWeaponUnEquipEvent = serializedObject.FindProperty("OnWeaponUnEquipEvent");
            OnCounterMisusedEvent = serializedObject.FindProperty("OnCounterMisusedEvent");
            OnGettingUpEvent = serializedObject.FindProperty("OnGettingUpEvent");
            OnDeathEvent = serializedObject.FindProperty("OnDeathEvent");
            OnKnockDownEvent = serializedObject.FindProperty("OnKnockDownEvent");

            CanDodge = serializedObject.FindProperty("CanDodge");
            dodgeData = serializedObject.FindProperty("dodgeData");
            OnlyDodgeInCombatMode = serializedObject.FindProperty("OnlyDodgeInCombatMode");
            CanRoll = serializedObject.FindProperty("CanRoll");
            rollData = serializedObject.FindProperty("rollData");
            OnlyRollInCombatMode = serializedObject.FindProperty("OnlyRollInCombatMode");
        }


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(5f);

            serializedObject.Update();
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.PropertyField(CanDodge);
            if (CanDodge.boolValue)
            {
                EditorGUILayout.PropertyField(dodgeData);
                EditorGUILayout.PropertyField(OnlyRollInCombatMode);
            }
            EditorGUILayout.EndVertical();
            GUILayout.Space(5f);
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.PropertyField(CanRoll);
            if (CanRoll.boolValue)
            {
                EditorGUILayout.PropertyField(rollData);
                EditorGUILayout.PropertyField(OnlyRollInCombatMode);
            }
            EditorGUILayout.EndVertical();

            eventFoldOut = EditorGUILayout.Foldout(eventFoldOut, "Events");
            if (eventFoldOut)
            {
                EditorGUILayout.PropertyField(onAttackEvent);
                EditorGUILayout.PropertyField(onGotHitEvent);
                EditorGUILayout.PropertyField(OnWeaponEquipEvent);
                EditorGUILayout.PropertyField(OnWeaponUnEquipEvent);
                EditorGUILayout.PropertyField(OnCounterMisusedEvent);
                EditorGUILayout.PropertyField(OnKnockDownEvent);
                EditorGUILayout.PropertyField(OnGettingUpEvent);
                EditorGUILayout.PropertyField(OnDeathEvent);
            }

            serializedObject.ApplyModifiedProperties();
        }

    }
}
#endif