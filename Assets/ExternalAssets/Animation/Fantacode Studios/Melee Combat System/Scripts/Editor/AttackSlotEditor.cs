using UnityEditor;
using UnityEngine;
namespace FS_CombatSystem
{
    [CustomPropertyDrawer(typeof(AttackSlot))]
    public class AttackSlotEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty canBeChargedProp = property.FindPropertyRelative("canBeCharged");
            SerializedProperty chargedAttackProp = property.FindPropertyRelative("chargedAttack");
            SerializedProperty attackProp = property.FindPropertyRelative("attack");

            string name = attackProp.objectReferenceValue != null ? attackProp.objectReferenceValue.name : label.ToString();
            property.isExpanded = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), property.isExpanded, name);
            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
                int i = 1;
                int j = 2;
                var attackPropRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);
                i++; j += 2;
                var canBeChargedPropRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);
                i++; j += 2;
                var chargedAttackPropRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);

                EditorGUI.PropertyField(attackPropRect, attackProp);
                EditorGUI.PropertyField(canBeChargedPropRect, canBeChargedProp);
                if (canBeChargedProp.boolValue)
                    EditorGUI.PropertyField(chargedAttackPropRect, chargedAttackProp);
                EditorGUI.indentLevel--;
            }
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty canBeChargedProp = property.FindPropertyRelative("canBeCharged");

            float height = EditorGUIUtility.singleLineHeight;
            if (property.isExpanded)
            {
                height += EditorGUIUtility.singleLineHeight * 2 + 6;
                if (canBeChargedProp.boolValue)
                    height += EditorGUIUtility.singleLineHeight + 2;
            }

            return height;
        }
    }
}