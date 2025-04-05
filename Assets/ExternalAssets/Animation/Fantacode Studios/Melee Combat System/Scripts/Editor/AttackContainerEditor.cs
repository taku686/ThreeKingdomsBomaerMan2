using System;
using UnityEditor;
using UnityEngine;

namespace FS_CombatSystem
{
    [CustomPropertyDrawer(typeof(AttackContainer))]
    public class AttackContainerEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            //SerializedProperty isComboProp = property.FindPropertyRelative("isCombo");
            //SerializedProperty undetectedProp = property.FindPropertyRelative("isStealthAttack");
            //SerializedProperty isCounterProp = property.FindPropertyRelative("isCounterAttack");
            SerializedProperty attackTypeProp = property.FindPropertyRelative("attackType");
            SerializedProperty attacksProp = property.FindPropertyRelative("attacks");
            SerializedProperty attackProp = property.FindPropertyRelative("attack");


            var name = (attackTypeProp.enumValueIndex == (int)AttackType.Combo) && attacksProp.arraySize > 0 && attacksProp.GetArrayElementAtIndex(0).FindPropertyRelative("attack").objectReferenceValue != null ?
                attacksProp.GetArrayElementAtIndex(0).FindPropertyRelative("attack").objectReferenceValue?.name :
                (attackProp.FindPropertyRelative("attack").objectReferenceValue == null ? label.ToString() : attackProp.FindPropertyRelative("attack").objectReferenceValue.name);

            property.isExpanded = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), property.isExpanded, name);
            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
                int i = 1;
                int j = 2;
                var attackPropRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);
                i++; j += 2;
                var conditionRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width * .75f, EditorGUIUtility.singleLineHeight);
                i++; j += 2;
                var minDistanceRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width * .5f, EditorGUIUtility.singleLineHeight);

                var boxRect = new Rect(position.x + position.width * .52f, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width * .48f, EditorGUIUtility.singleLineHeight * 2);
                var buttonReact = new Rect(position.x + position.width * .525f, position.y + EditorGUIUtility.singleLineHeight * (i + .1f) + j, position.width * .365f, EditorGUIUtility.singleLineHeight * 1.8f);
                var labelRect = new Rect(position.x + position.width * .89f, position.y + EditorGUIUtility.singleLineHeight * (i + .5f) + j, position.width * .11f, EditorGUIUtility.singleLineHeight);

                i++; j += 2;
                var maxDistanceRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width * .5f, EditorGUIUtility.singleLineHeight);


                i++; j += 2;
                var minHealthRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);
                //i++; j += 2;
                //var undetectedRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);
                //i++; j += 2;
                //var isCounterRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);
                //i++; j += 2;
                //var useComboRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);
                i++; j += 2;
                var attackHeaderRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);
                i++; j += 2;
                var attackRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight * i + j, position.width, EditorGUIUtility.singleLineHeight);

                EditorGUI.PropertyField(attackPropRect, attackTypeProp);

                GUIStyle style = new GUIStyle(GUI.skin.label);
                style.fontStyle = FontStyle.Bold;
                GUI.Label(conditionRect, "Conditions", style);

                EditorGUI.PropertyField(minDistanceRect, property.FindPropertyRelative("minDistance"), new GUIContent("Min Distance"));
                EditorGUI.PropertyField(maxDistanceRect, property.FindPropertyRelative("maxDistance"), new GUIContent("Max Distance"));

                GUI.Box(boxRect, "");
                if (GUI.Button(buttonReact, new GUIContent("Rootmotion Distance", "Animation Rootmotion Distance")))
                {
                    property.FindPropertyRelative("animationDistance").floatValue = GetAnimationDistance(attacksProp);
                }
                var dist = property.FindPropertyRelative("animationDistance").floatValue;
                GUIContent content = new GUIContent(Math.Round(dist, 2).ToString());
                Vector2 contentSize = style.CalcSize(content);
                float x = labelRect.x + (labelRect.width - contentSize.x) / 2;
                float y = labelRect.y + (labelRect.height - contentSize.y) / 2;
                labelRect = new Rect(x, y, contentSize.x, contentSize.y);
                GUI.Label(labelRect, content);

                EditorGUI.PropertyField(minHealthRect, property.FindPropertyRelative("healthThreshold"), new GUIContent("Health Threshold (%)"));

                //EditorGUI.PropertyField(isCounterRect, isCounterProp, new GUIContent("Is Counter Attack"));
                //EditorGUI.PropertyField(undetectedRect, undetectedProp, new GUIContent("Is Stealth Attack"));
                //EditorGUI.PropertyField(useComboRect, isComboProp, new GUIContent("Is Combo"));



                if (attackTypeProp.enumValueIndex == (int)AttackType.Combo)
                {
                    GUI.Label(attackHeaderRect, "Attacks data", style);
                    EditorGUI.PropertyField(attackRect, attacksProp, new GUIContent("Attacks"), true);
                }
                else
                {
                    GUI.Label(attackHeaderRect, "Attack data", style);
                    EditorGUI.BeginChangeCheck();
                    EditorGUI.PropertyField(attackRect, attackProp, new GUIContent("Attack"), true);
                    if (EditorGUI.EndChangeCheck())
                    {
                        attacksProp.ClearArray();
                        attacksProp.arraySize++;
                        attacksProp.GetArrayElementAtIndex(0).FindPropertyRelative("attack").objectReferenceValue = attackProp.FindPropertyRelative("attack").objectReferenceValue;
                    }
                }

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();

            float GetAnimationDistance(SerializedProperty attacksProp)
            {
                float dist = 0;
                if (attacksProp.arraySize > 0 && attacksProp.GetArrayElementAtIndex(0).FindPropertyRelative("attack").objectReferenceValue != null)
                {
                    var attackData = attacksProp.GetArrayElementAtIndex(0).FindPropertyRelative("attack").objectReferenceValue as AttackData;
                    if (attackData != null)
                    {
                        dist = GetAnimationMoveDistance(attackData.Clip);
                    }
                }
                return dist;
            }

            float GetAnimationMoveDistance(AnimationClip clip)
            {
                if (clip != null)
                {
                    var bindings = AnimationUtility.GetCurveBindings(clip);

                    var curveX = AnimationUtility.GetEditorCurve(clip, bindings[0]);
                    var curveY = AnimationUtility.GetEditorCurve(clip, bindings[1]);
                    var curveZ = AnimationUtility.GetEditorCurve(clip, bindings[2]);
                    var curve = new Vector3(curveX.Evaluate(clip.length),
                    curveY.Evaluate(clip.length),
                    curveZ.Evaluate(clip.length));
                    return curve.magnitude;
                }
                return 0;
            }

        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //SerializedProperty useComboProp = property.FindPropertyRelative("isCombo");
            SerializedProperty attackTypeProp = property.FindPropertyRelative("attackType");
            SerializedProperty attacksProp = property.FindPropertyRelative("attacks");
            SerializedProperty attackProp = property.FindPropertyRelative("attack");

            float height = EditorGUIUtility.singleLineHeight * 7;
            if (!property.isExpanded)
                height = EditorGUIUtility.singleLineHeight;
            else if (attackTypeProp.enumValueIndex == (int)AttackType.Combo)
                height += EditorGUI.GetPropertyHeight(attacksProp, true) + EditorGUIUtility.singleLineHeight;
            else if (attackTypeProp.enumValueIndex != (int)AttackType.Combo)
                height += EditorGUI.GetPropertyHeight(attackProp, true) + EditorGUIUtility.singleLineHeight;

            return height;
        }
    }
}