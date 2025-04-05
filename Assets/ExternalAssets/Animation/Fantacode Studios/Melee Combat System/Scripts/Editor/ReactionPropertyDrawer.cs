using UnityEditor;
using UnityEngine;

namespace FS_CombatSystem
{
    [CustomPropertyDrawer(typeof(Reaction), true)]
    public class ReactionPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            float lineHeight = EditorGUIUtility.singleLineHeight;
            float padding = 4;
            float yOffset = position.y + padding;

            var animationClip = property.FindPropertyRelative("animationClipInfo");
            var willBeKnockedDown = property.FindPropertyRelative("willBeKnockedDown");
            var knockDownDirection = property.FindPropertyRelative("knockDownDirection");
            var lyingDownTimeRange = property.FindPropertyRelative("lyingDownTimeRange");
            var overrideLyingDownAnimation = property.FindPropertyRelative("overrideLyingDownAnimation");
            var lyingDownAnimation = property.FindPropertyRelative("lyingDownAnimation");
            var getUpAnimation = property.FindPropertyRelative("getUpAnimation");

            Rect DrawNextRect() => new Rect(position.x, yOffset, position.width, lineHeight);

            EditorGUI.PropertyField(DrawNextRect(), animationClip);
            yOffset += EditorGUI.GetPropertyHeight(animationClip, true) + padding;

            EditorGUI.PropertyField(DrawNextRect(), willBeKnockedDown);
            yOffset += lineHeight + padding;

            if (willBeKnockedDown.boolValue)
            {
                EditorGUI.PropertyField(DrawNextRect(), knockDownDirection);
                yOffset += lineHeight + padding;

                EditorGUI.PropertyField(DrawNextRect(), lyingDownTimeRange);
                yOffset += lineHeight + padding;

                EditorGUI.PropertyField(DrawNextRect(), overrideLyingDownAnimation);
                yOffset += lineHeight + padding;

                if (overrideLyingDownAnimation.boolValue)
                {
                    EditorGUI.PropertyField(DrawNextRect(), lyingDownAnimation);
                    yOffset += lineHeight + padding;

                    EditorGUI.PropertyField(DrawNextRect(), getUpAnimation);
                    yOffset += lineHeight + padding;
                }
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float lineHeight = EditorGUIUtility.singleLineHeight;
            float padding = 4;

            float height = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("animationClipInfo"), true) + padding;

            SerializedProperty willBeKnockedDown = property.FindPropertyRelative("willBeKnockedDown");
            SerializedProperty overrideLyingAnim = property.FindPropertyRelative("overrideLyingDownAnimation");

            height += lineHeight + padding;

            if (willBeKnockedDown.boolValue)
            {
                height += lineHeight * 3 + padding * 3;
                if (overrideLyingAnim.boolValue)
                {
                    height += lineHeight * 2 + padding * 2;
                }
            }

            return height;
        }
    }
}
