#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace FS_CombatSystem
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AttackData))]
    public class AttackDataEditor : AnimationPreviewHandler
    {
        public enum PreviewAnimation { Attack, Reaction, BlockedReaction }

        public SerializedProperty animationClipInfo;
        public SerializedProperty animationClip;
        public SerializedProperty animationSpeed;

        public SerializedProperty reactionClip;
        public SerializedProperty reactionClipInfo;
        public SerializedProperty hitDirection;
        public SerializedProperty isFinisher;
        public SerializedProperty canHitMultipleTargets;
        public SerializedProperty rotateToTarget;
        public SerializedProperty reactionTag;

        public SerializedProperty overrideReaction;
        public SerializedProperty reaction;
        public SerializedProperty isSyncedReaction;
        public SerializedProperty syncStartTime;
        public SerializedProperty rotateTarget;
        public SerializedProperty rotationOffset;
        public SerializedProperty willBeKnockedDown;
        public SerializedProperty getUpAnimation;

        public SerializedProperty overrideBlockedReaction;
        public SerializedProperty blockedReactionClipInfo;
        public SerializedProperty blockedReactionClip;
        public SerializedProperty isSyncedBlockedReaction;
        public SerializedProperty blockSyncStartTime;
        public SerializedProperty rotateTargetInBlocked;
        public SerializedProperty rotationInBlocked;

        public SerializedProperty canBeCountered;
        public SerializedProperty counterAttacks;


        public SerializedProperty hitboxToUse;
        public SerializedProperty damage;

        public SerializedProperty impactStartTime;
        public SerializedProperty impactEndTime;
        public SerializedProperty waitForNextAttack;
        public SerializedProperty waitForAttackTime;

        public SerializedProperty moveTotarget;
        public SerializedProperty distanceFromTarget;
        public SerializedProperty localPositionFromTarget;
        public SerializedProperty moveType;
        public SerializedProperty snapType;
        public SerializedProperty snapTarget;
        public SerializedProperty rootCurves;
        public SerializedProperty rootCurveX;
        public SerializedProperty rootCurveY;
        public SerializedProperty rootCurveZ;
        public SerializedProperty ignoreCollisions;
        public SerializedProperty moveStartTime;
        public SerializedProperty moveEndTime;
        public SerializedProperty isUnblockableAttack;

        public SerializedProperty hitSound;
        public SerializedProperty strikeSound;
        public SerializedProperty blockedHitSound;
        public SerializedProperty reactionSound;
        public SerializedProperty hitEffect;
        public SerializedProperty hittingTime;
        public SerializedProperty blockedHitEffect;
        public SerializedProperty blockedHittingTime;
        public SerializedProperty cameraShakeAmount;
        public SerializedProperty cameraShakeDuration;
        public SerializedProperty weightMask;

        static float startValueI;
        static float endValueI = 1;
        static float startValueM;
        static float endValueM = 1;


        PreviewAnimation previewAnimation;
        AttackData attackData;

        static bool effectsFoldout;
        static bool advancedFoldout;

        public override void OnEnable()
        {
            base.OnEnable();
            animationClipInfo = serializedObject.FindProperty("clipInfo");
            animationClip = animationClipInfo.FindPropertyRelative("clip");
            animationSpeed = serializedObject.FindProperty("animationSpeed");
            hitDirection = serializedObject.FindProperty("hitDirection");
            isFinisher = serializedObject.FindProperty("isFinisher");
            canHitMultipleTargets = serializedObject.FindProperty("canHitMultipleTargets");
            rotateToTarget = serializedObject.FindProperty("rotateToTarget");
            reactionTag = serializedObject.FindProperty("reactionTag");
            overrideReaction = serializedObject.FindProperty("overrideReaction");
            reaction = serializedObject.FindProperty("reaction");
            reactionClipInfo = reaction.FindPropertyRelative("animationClipInfo");
            reactionClip = reactionClipInfo.FindPropertyRelative("clip");
            willBeKnockedDown = reaction.FindPropertyRelative("willBeKnockedDown");
            getUpAnimation = reaction.FindPropertyRelative("getUpAnimation");
            isSyncedReaction = serializedObject.FindProperty("isSyncedReaction");
            syncStartTime = serializedObject.FindProperty("syncStartTime");
            rotateTarget = serializedObject.FindProperty("rotateTarget");
            rotationOffset = serializedObject.FindProperty("rotationOffset");

            overrideBlockedReaction = serializedObject.FindProperty("overrideBlockedReaction");
            blockedReactionClipInfo = serializedObject.FindProperty("blockedReaction").FindPropertyRelative("animationClipInfo");
            blockedReactionClip = blockedReactionClipInfo.FindPropertyRelative("clip");
            isSyncedBlockedReaction = serializedObject.FindProperty("isSyncedBlockedReaction");
            blockSyncStartTime = serializedObject.FindProperty("blockSyncStartTime");
            rotateTargetInBlocked = serializedObject.FindProperty("rotateTargetInBlocked");
            rotationInBlocked = serializedObject.FindProperty("rotationOffsetInBlocked");

            canBeCountered = serializedObject.FindProperty("canBeCountered");
            counterAttacks = serializedObject.FindProperty("counterAttacks");


            hitboxToUse = serializedObject.FindProperty("hitboxToUse");
            damage = serializedObject.FindProperty("damage");

            impactStartTime = serializedObject.FindProperty("impactStartTime");
            impactEndTime = serializedObject.FindProperty("impactEndTime");
            waitForAttackTime = serializedObject.FindProperty("waitForAttackTime");
            waitForNextAttack = serializedObject.FindProperty("waitForNextAttack");
            moveTotarget = serializedObject.FindProperty("moveToTarget");
            distanceFromTarget = serializedObject.FindProperty("distanceFromTarget");
            localPositionFromTarget = serializedObject.FindProperty("localPositionFromTarget");
            moveType = serializedObject.FindProperty("moveType");
            snapType = serializedObject.FindProperty("snapType");
            snapTarget = serializedObject.FindProperty("snapTarget");
            rootCurves = serializedObject.FindProperty("rootCurves");
            rootCurveX = rootCurves.FindPropertyRelative("CurveX");
            rootCurveY = rootCurves.FindPropertyRelative("CurveY");
            rootCurveZ = rootCurves.FindPropertyRelative("CurveZ");
            ignoreCollisions = serializedObject.FindProperty("ignoreCollisions");
            moveStartTime = serializedObject.FindProperty("moveStartTime");
            moveEndTime = serializedObject.FindProperty("moveEndTime");
            weightMask = serializedObject.FindProperty("weightMask");
            isUnblockableAttack = serializedObject.FindProperty("isUnblockableAttack");

            hitSound = serializedObject.FindProperty("hitSound");
            strikeSound = serializedObject.FindProperty("strikeSound");
            blockedHitSound = serializedObject.FindProperty("blockedHitSound");
            reactionSound = serializedObject.FindProperty("reactionSound");
            hitEffect = serializedObject.FindProperty("hitEffect");
            hittingTime = serializedObject.FindProperty("hittingTime");
            blockedHitEffect = serializedObject.FindProperty("blockedHitEffect");
            blockedHittingTime = serializedObject.FindProperty("blockedHittingTime");
            cameraShakeAmount = serializedObject.FindProperty("cameraShakeAmount");
            cameraShakeDuration = serializedObject.FindProperty("cameraShakeDuration");


            var attackData = target as AttackData;
            targetData = attackData;

            if (attackData.Clip.clip != null)
            {
                startValueI = attackData.ImpactStartTime;
                endValueI = attackData.ImpactEndTime;

                startValueM = attackData.MoveStartTime;
                endValueM = attackData.MoveEndTime;
            }
            else
            {
                startValueI = 0;
                endValueI = 1;
                startValueM = 0;
                endValueM = 1;
            }
            OnStart(attackData.Clip.clip);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            if (attackData == null)
                attackData = target as AttackData;

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(animationClipInfo, new GUIContent("Attack Clip"));
            if (EditorGUI.EndChangeCheck())
            {
                ChangeAnimationClip(PreviewAnimation.Attack);
                if (moveTotarget.boolValue && moveType.enumValueIndex == (int)TargetMatchType.ScaleRootMotion)
                    GenerateClipRootCurves();
            }
            


            GUILayout.Label("Impact Time");

            var si = startValueI;
            var ei = endValueI;

            GUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(impactStartTime, GUIContent.none, GUILayout.Width(40));
            if (EditorGUI.EndChangeCheck())
                impactStartTime.floatValue = Mathf.Clamp01(impactStartTime.floatValue);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.MinMaxSlider(ref startValueI, ref endValueI, 0, 1);
            if (EditorGUI.EndChangeCheck())
            {
                var time = -1f;
                if (si != startValueI)
                    time = startValueI;
                else if (ei != endValueI)
                    time = endValueI;
                if (time > 0)
                {
                    ChangeAnimationClip(PreviewAnimation.Attack);
                    if (clip != null)
                        previewTime = time * clip.length;
                    impactStartTime.floatValue = (float)Math.Round(startValueI, 2);
                    impactEndTime.floatValue = (float)Math.Round(endValueI, 2);
                    UpdatePreview();
                }
            }
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(impactEndTime, GUIContent.none, GUILayout.Width(40));
            if (EditorGUI.EndChangeCheck())
                impactEndTime.floatValue = Mathf.Clamp01(impactEndTime.floatValue);
            startValueI = impactStartTime.floatValue;
            endValueI = impactEndTime.floatValue;
            GUILayout.EndHorizontal();

            
            GUILayout.Space(10);

            EditorGUILayout.PropertyField(hitboxToUse);
            EditorGUILayout.PropertyField(canHitMultipleTargets);
            EditorGUILayout.PropertyField(isFinisher);
            EditorGUILayout.PropertyField(rotateToTarget);
            if (!isFinisher.boolValue)
                EditorGUILayout.PropertyField(damage);
            EditorGUILayout.PropertyField(hitDirection);
            EditorGUILayout.PropertyField(reactionTag);


            GUILayout.Space(15);
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(overrideReaction);
            if (EditorGUI.EndChangeCheck())
            {
                if (!overrideReaction.boolValue && !overrideBlockedReaction.boolValue)
                {
                    ChangeAnimationClip(PreviewAnimation.Attack);
                }
            }

            if (overrideReaction.boolValue)
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(reaction);
                if (EditorGUI.EndChangeCheck() && reactionClip.objectReferenceValue != null)
                    ChangeAnimationClip(PreviewAnimation.Reaction);

                EditorGUILayout.PropertyField(isSyncedReaction, new GUIContent("Is Synced"));
                if (isSyncedReaction.boolValue)
                {
                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.PropertyField(syncStartTime);

                    if (EditorGUI.EndChangeCheck())
                    {
                        ChangeAnimationClip(PreviewAnimation.Attack);
                        if (clip != null)
                            previewTime = syncStartTime.floatValue * clip.length;
                        UpdatePreview();
                    }

                }
                EditorGUILayout.PropertyField(rotateTarget, new GUIContent("Rotate To Attacker"));
                if (rotateTarget.boolValue)
                    EditorGUILayout.PropertyField(rotationOffset, new GUIContent("Rotation Offset (angles)"));

            }
            EditorGUILayout.EndVertical();

            GUILayout.Space(15);

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(overrideBlockedReaction);
            if (EditorGUI.EndChangeCheck())
            {
                if (!overrideBlockedReaction.boolValue && !overrideReaction.boolValue)
                {
                    ChangeAnimationClip(PreviewAnimation.Attack);
                }
            }

            if (overrideBlockedReaction.boolValue)
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(blockedReactionClipInfo, new GUIContent("Clip"));
                if (EditorGUI.EndChangeCheck() && blockedReactionClip.objectReferenceValue != null)
                    ChangeAnimationClip(PreviewAnimation.BlockedReaction);

                EditorGUILayout.PropertyField(isSyncedBlockedReaction, new GUIContent("Is Synced"));
                if (isSyncedBlockedReaction.boolValue)
                {
                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.PropertyField(blockSyncStartTime, new GUIContent("Sync Start Time"));
                    if (EditorGUI.EndChangeCheck())
                    {
                        ChangeAnimationClip(PreviewAnimation.Attack);
                        if (clip != null)
                            previewTime = blockSyncStartTime.floatValue * clip.length;
                        UpdatePreview();
                    }
                }
                EditorGUILayout.PropertyField(rotateTargetInBlocked, new GUIContent("Rotate To Attacker"));
                if (rotateTargetInBlocked.boolValue)
                    EditorGUILayout.PropertyField(rotationInBlocked, new GUIContent("Rotation Offset (angles)"));
            }
            EditorGUILayout.EndVertical();

            GUILayout.Space(15);

            // Counter Attack
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(canBeCountered);
            if (EditorGUI.EndChangeCheck())
            {
                if (canBeCountered.boolValue)
                {
                    if (counterAttacks.arraySize == 0)
                        counterAttacks.InsertArrayElementAtIndex(0);
                    counterAttacks.GetArrayElementAtIndex(0).FindPropertyRelative("foldOut").boolValue = true;
                }
            }
            if (canBeCountered.boolValue)
            {
                for (int i = 0; i < counterAttacks.arraySize; ++i)
                {
                    var counter = counterAttacks.GetArrayElementAtIndex(i);

                    if (buttonStyle == null)
                    {
                        buttonStyle = new GUIStyle(GUI.skin.button);
                        boxStyle = new GUIStyle(GUI.skin.box);
                        SetStyles();
                    }


                    SerializedProperty counterAttackProperty = counter.FindPropertyRelative("counterAttack");
                    var buttonLabel = counterAttackProperty.objectReferenceValue != null ? counterAttackProperty.objectReferenceValue.name : "Counter " + (i + 1);
                    var counterFoldOutProp = counter.FindPropertyRelative("foldOut");



                    var foldOut = counterFoldOutProp.boolValue;
                    if (foldOut)
                        EditorGUILayout.BeginVertical(boxStyle);

                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button(buttonLabel, buttonStyle))
                        counterFoldOutProp.boolValue = !counterFoldOutProp.boolValue;
                    if (counterAttacks.arraySize > 1 && GUILayout.Button(EditorGUIUtility.IconContent("Toolbar Minus"), GUILayout.Width(20)))
                    {
                        counterAttacks.DeleteArrayElementAtIndex(i);
                        break;
                    }
                    EditorGUILayout.EndHorizontal();

                    if (counterFoldOutProp.boolValue)
                    {
                        GUILayout.Space(10);
                        EditorGUILayout.PropertyField(counterAttackProperty);

                        var counterStartTime = counter.FindPropertyRelative("counterStartTime");
                        EditorGUILayout.BeginHorizontal();
                        EditorGUI.BeginChangeCheck();
                        float labelWidth = EditorGUIUtility.labelWidth;

                        // Calculate remaining width for the slider
                        float remainingWidth = EditorGUIUtility.currentViewWidth - labelWidth - 40;
                        EditorGUILayout.LabelField(new GUIContent("Counter Start Time"), GUILayout.Width(labelWidth));
                        var startTime = EditorGUILayout.Slider(counterStartTime.floatValue, 0, impactStartTime.floatValue, GUILayout.Width(remainingWidth));
                        if (EditorGUI.EndChangeCheck())
                        {
                            Undo.RecordObject(attackData, "Value Changed");
                            counterStartTime.floatValue = startTime;
                            ChangeAnimationClip(PreviewAnimation.Attack);
                            if (clip != null)
                                previewTime = counterStartTime.floatValue * clip.length;
                            UpdatePreview();
                        }
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.PropertyField(counter.FindPropertyRelative("maxDistanceForCounter"), new GUIContent("Max Distance"));
                        EditorGUILayout.PropertyField(counter.FindPropertyRelative("healthThresholdForCounter"), new GUIContent("Health Threshold"));
                    }
                    if (foldOut)
                        EditorGUILayout.EndVertical();
                }
                GUILayout.Space(5);
                //var rect = new Rect(GUILayoutUtility.GetLastRect().x + GUILayoutUtility.GetLastRect().width - 20, GUILayoutUtility.GetLastRect().y + 22, 20, 20);
                if (GUILayout.Button("Add Counter", GUILayout.Width(100)))
                    counterAttacks.InsertArrayElementAtIndex(0);
            }
            EditorGUILayout.EndVertical();

            GUILayout.Space(25);

            EditorGUILayout.BeginVertical(GUI.skin.box);

            EditorGUILayout.PropertyField(moveTotarget);
            if (moveTotarget.boolValue)
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(moveType);
                if (EditorGUI.EndChangeCheck() && moveType.enumValueIndex == (int)TargetMatchType.ScaleRootMotion)
                    GenerateClipRootCurves();

                if (moveType.enumValueIndex != (int)TargetMatchType.Snap)
                {

                    GUILayout.Label("Move Time");
                    var sm = startValueM;
                    var em = endValueM;
                    GUILayout.BeginHorizontal();
                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.PropertyField(moveStartTime, GUIContent.none, GUILayout.Width(40));
                    if (EditorGUI.EndChangeCheck())
                        moveStartTime.floatValue = Mathf.Clamp01(moveStartTime.floatValue);
                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.MinMaxSlider(ref startValueM, ref endValueM, 0, 1);
                    if (EditorGUI.EndChangeCheck())
                    {
                        var time = -1f;
                        if (sm != startValueM)
                            time = startValueM;
                        else if (em != endValueM)
                            time = endValueM;
                        if (time > 0)
                        {
                            Undo.RecordObject(this, "value changed");
                            if (clip != null)
                                previewTime = time * clip.length;
                            moveStartTime.floatValue = (float)Math.Round(startValueM, 2);
                            moveEndTime.floatValue = (float)Math.Round(endValueM, 2);
                            UpdatePreview();
                        }
                    }
                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.PropertyField(moveEndTime, GUIContent.none, GUILayout.Width(40));
                    if (EditorGUI.EndChangeCheck())
                        moveEndTime.floatValue = Mathf.Clamp01(moveEndTime.floatValue);
                    startValueM = moveStartTime.floatValue;
                    endValueM = moveEndTime.floatValue;

                    GUILayout.EndHorizontal();

                    EditorGUILayout.PropertyField(distanceFromTarget);
                }
                else
                {
                    EditorGUILayout.PropertyField(snapType);
                    if (snapType.enumValueIndex == (int)SnapType.LocalPosition)
                        EditorGUILayout.PropertyField(localPositionFromTarget);
                    else if (snapType.enumValueIndex == (int)SnapType.Distance)
                        EditorGUILayout.PropertyField(distanceFromTarget);

                    EditorGUILayout.PropertyField(snapTarget);
                }



                if (moveType.enumValueIndex == (int)TargetMatchType.Linear)
                {
                    EditorGUILayout.PropertyField(ignoreCollisions);
                }
                else if (moveType.enumValueIndex == (int)TargetMatchType.ScaleRootMotion)
                {
                    EditorGUILayout.PropertyField(ignoreCollisions);
                    EditorGUILayout.PropertyField(weightMask);
                    EditorGUILayout.PropertyField(rootCurves);
                    if (GUILayout.Button("Regenerate Root Motion Curves"))
                        GenerateClipRootCurves();
                }


            }

            EditorGUILayout.EndVertical();

            GUILayout.Space(10);

            advancedFoldout = EditorGUILayout.Foldout(advancedFoldout, "Advanced");
            if(advancedFoldout)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(animationSpeed, new GUIContent("Attack Clip Speed"));
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(waitForNextAttack);
                if (EditorGUI.EndChangeCheck())
                {
                    if (waitForNextAttack.boolValue)
                        waitForAttackTime.floatValue = impactEndTime.floatValue;
                }
                if (waitForNextAttack.boolValue)
                {

                    EditorGUI.BeginChangeCheck();
                    //EditorGUILayout.PropertyField(waitForAttackTime);
                    waitForAttackTime.floatValue = EditorGUILayout.Slider(waitForAttackTime.floatValue, impactEndTime.floatValue, 1);
                    if (EditorGUI.EndChangeCheck())
                    {
                        ChangeAnimationClip(PreviewAnimation.Attack);
                        if (clip != null)
                            previewTime = waitForAttackTime.floatValue * clip.length;
                        UpdatePreview();
                    }
                }
                EditorGUILayout.PropertyField(isUnblockableAttack);
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }

            

            GUILayout.Space(10);
            effectsFoldout = EditorGUILayout.Foldout(effectsFoldout, "Effects");
            if (effectsFoldout)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(strikeSound);
                EditorGUILayout.PropertyField(hitSound);
                EditorGUILayout.PropertyField(blockedHitSound);
                EditorGUILayout.PropertyField(reactionSound);
                EditorGUILayout.PropertyField(hitEffect);
                if (overrideReaction.boolValue && isSyncedReaction.boolValue)
                {
                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.PropertyField(hittingTime);
                    if (EditorGUI.EndChangeCheck())
                    {
                        ChangeAnimationClip(PreviewAnimation.Attack);
                        if (clip != null)
                            previewTime = hittingTime.floatValue * clip.length;
                        UpdatePreview();
                    }
                }
                EditorGUILayout.PropertyField(blockedHitEffect);
                if (overrideBlockedReaction.boolValue && isSyncedBlockedReaction.boolValue)
                {
                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.PropertyField(blockedHittingTime);
                    if (EditorGUI.EndChangeCheck())
                    {
                        ChangeAnimationClip(PreviewAnimation.Attack);
                        if (clip != null)
                            previewTime = blockedHittingTime.floatValue * clip.length;
                        UpdatePreview();
                    }
                }
                EditorGUILayout.PropertyField(cameraShakeAmount);
                EditorGUILayout.PropertyField(cameraShakeDuration);

                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }

            serializedObject.ApplyModifiedProperties();
        }

        public override void ChangeAnimationClip(object type = null)
        {
            base.ChangeAnimationClip(type);
            if (type != null)
                previewAnimation = (PreviewAnimation)type;
            switch (previewAnimation)
            {
                case PreviewAnimation.Attack:
                    clip = (AnimationClip)animationClip.objectReferenceValue;
                    break;
                case PreviewAnimation.Reaction:
                    clip = (AnimationClip)reactionClip.objectReferenceValue;
                    break;
                case PreviewAnimation.BlockedReaction:
                    clip = (AnimationClip)blockedReactionClip.objectReferenceValue;
                    break;
                default:
                    break;
            }
        }

        void GenerateClipRootCurves()
        {
            if (clip != null)
            {
                var bindings = AnimationUtility.GetCurveBindings(clip);

                rootCurveX.animationCurveValue = AnimationUtility.GetEditorCurve(clip, bindings[0]);
                rootCurveY.animationCurveValue = AnimationUtility.GetEditorCurve(clip, bindings[1]);
                rootCurveZ.animationCurveValue = AnimationUtility.GetEditorCurve(clip, bindings[2]);
            }
        }

        public override void HandleAnimationEnumPopup()
        {
            base.HandleAnimationEnumPopup();
            if ((overrideReaction.boolValue) || (overrideBlockedReaction.boolValue))
            {
                EditorGUI.BeginChangeCheck();
                previewAnimation = (PreviewAnimation)EditorGUILayout.EnumPopup(previewAnimation, GUILayout.Width(150));
                if (EditorGUI.EndChangeCheck())
                {
                    ChangeAnimationClip();
                    UpdatePreview();
                }
            }
        }
        GUIStyle buttonStyle;
        GUIStyle boxStyle;
        void SetStyles()
        {
            buttonStyle.normal.background = MakeTexture(1, 1, new Color(1f, 1f, 1f, 0.2f));
            buttonStyle.hover.background = MakeTexture(1, 1, new Color(0f, .5f, 1f, 0.2f));
            boxStyle.normal.background = MakeTexture(1, 1, new Color(1f, 1f, 1f, 0.1f));
            boxStyle.hover.background = MakeTexture(1, 1, new Color(1f, 1f, 1f, 0.1f));

        }
    }
}
#endif