#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
namespace FS_CombatSystem
{

    [CustomEditor(typeof(WeaponData))]
    public class WeaponDataEditor : AnimationPreviewHandler
    {
        public enum Animations { Equip, UnEquip, Block }

        public SerializedProperty spawnWeapon;
        public SerializedProperty weaponHolder;
        public SerializedProperty localPosition;
        public SerializedProperty localRotation;
        public SerializedProperty weaponModel;
        public SerializedProperty attacks;
        public SerializedProperty heavyAttacks;
        public SerializedProperty specialAttacks;
        public SerializedProperty reactionData;

        public SerializedProperty weaponEquipAnimation;
        public SerializedProperty weaponActivationTime;
        public SerializedProperty weaponEquipSound;

        public SerializedProperty weaponUnEquipAnimation;
        public SerializedProperty weaponDeactivationTime;
        public SerializedProperty weaponUnEquipSound;

        public SerializedProperty canBlock;
        public SerializedProperty blocking;
        public SerializedProperty blockedDamage;
        public SerializedProperty blockReactionData;
        public SerializedProperty blockMask;
        public SerializedProperty canCounter;
        public SerializedProperty playActionIfCounterMisused;
        public SerializedProperty counterMisusedAction;

        public SerializedProperty overrideController;
        public SerializedProperty useRootmotion;
        public SerializedProperty overrideMoveSpeed;
        public SerializedProperty walkSpeed;
        public SerializedProperty runSpeed;
        public SerializedProperty sprintSpeed;
        public SerializedProperty combatMoveSpeed;
        public SerializedProperty weaponHoldingClip;
        public SerializedProperty weaponHolderMask;
        public SerializedProperty minAttackDistance;

        public SerializedProperty overrideDodge;
        public SerializedProperty dodgeData;
        public SerializedProperty overrideRoll;
        public SerializedProperty rollData;


        WeaponData weaponData;

        static bool equipFoldout;
        static bool unEquipFoldout;

        static bool advancedFoldOut;

        static Animations currentClipType = Animations.Equip;

        public override void OnEnable()
        {
            base.OnEnable();
            spawnWeapon = serializedObject.FindProperty("spawnWeapon");
            weaponHolder = serializedObject.FindProperty("weaponHolder");
            localPosition = serializedObject.FindProperty("localPosition");
            localRotation = serializedObject.FindProperty("localRotation");
            weaponModel = serializedObject.FindProperty("weaponModel");

            attacks = serializedObject.FindProperty("attacks");
            heavyAttacks = serializedObject.FindProperty("heavyAttacks");
            specialAttacks = serializedObject.FindProperty("specialAttacks");
            reactionData = serializedObject.FindProperty("reactionData");

            weaponEquipAnimation = serializedObject.FindProperty("weaponEquipAnimation");
            weaponActivationTime = serializedObject.FindProperty("weaponActivationTime");
            weaponEquipSound = serializedObject.FindProperty("weaponEquipSound");
            weaponUnEquipAnimation = serializedObject.FindProperty("weaponUnEquipAnimation");
            weaponDeactivationTime = serializedObject.FindProperty("weaponDeactivationTime");
            weaponUnEquipSound = serializedObject.FindProperty("weaponUnEquipSound");

            canBlock = serializedObject.FindProperty("canBlock");
            blocking = serializedObject.FindProperty("blocking");
            blockedDamage = serializedObject.FindProperty("blockedDamage");
            blockReactionData = serializedObject.FindProperty("blockReactionData");
            blockMask = serializedObject.FindProperty("blockMask");

            canCounter = serializedObject.FindProperty("canCounter");
            playActionIfCounterMisused = serializedObject.FindProperty("playActionIfCounterMisused");
            counterMisusedAction = serializedObject.FindProperty("counterMisusedAction");

            overrideController = serializedObject.FindProperty("overrideController");
            useRootmotion = serializedObject.FindProperty("useRootmotion");
            overrideMoveSpeed = serializedObject.FindProperty("overrideMoveSpeed");
            walkSpeed = serializedObject.FindProperty("walkSpeed");
            runSpeed = serializedObject.FindProperty("runSpeed");
            sprintSpeed = serializedObject.FindProperty("sprintSpeed");
            combatMoveSpeed = serializedObject.FindProperty("combatMoveSpeed");
            weaponHoldingClip = serializedObject.FindProperty("weaponHoldingClip");
            weaponHolderMask = serializedObject.FindProperty("weaponHolderMask");
            minAttackDistance = serializedObject.FindProperty("minAttackDistance");

            overrideDodge = serializedObject.FindProperty("overrideDodge");
            dodgeData = serializedObject.FindProperty("dodgeData");
            overrideRoll = serializedObject.FindProperty("overrideRoll");
            rollData = serializedObject.FindProperty("rollData");

            weaponData = target as WeaponData;
            targetData = weaponData;

            OnStart(weaponData.WeaponEquipAnimation);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(spawnWeapon);

            if (spawnWeapon.boolValue)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(weaponModel, new GUIContent("Model"));
                EditorGUILayout.PropertyField(weaponHolder, new GUIContent("Holder"));
                EditorGUILayout.PropertyField(localPosition);
                EditorGUILayout.PropertyField(localRotation);
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            
            GUILayout.Space(5);

            EditorGUILayout.PropertyField(attacks);
            EditorGUILayout.PropertyField(heavyAttacks);
            EditorGUILayout.PropertyField(specialAttacks);
            EditorGUILayout.PropertyField(reactionData);


            EditorGUILayout.PropertyField(canBlock);
            if (canBlock.boolValue)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUI.indentLevel++;
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(blocking, new GUIContent("Animation"));
                if (EditorGUI.EndChangeCheck() && blocking.objectReferenceValue != null)
                    ChangeAnimationClip(Animations.Block);
                EditorGUILayout.PropertyField(blockedDamage, new GUIContent("Blocked Damage(%)"));
                EditorGUILayout.PropertyField(blockReactionData, new GUIContent("Reaction Data"));
                EditorGUILayout.PropertyField(blockMask);
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.PropertyField(canCounter);
            if (canCounter.boolValue)
            {
                EditorGUILayout.PropertyField(playActionIfCounterMisused);
                if (playActionIfCounterMisused.boolValue)
                    EditorGUILayout.PropertyField(counterMisusedAction);
            }

            equipFoldout = EditorGUILayout.Foldout(equipFoldout, "Equip");

            if (equipFoldout)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUI.indentLevel++;

                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(weaponEquipAnimation, new GUIContent("Animation"));
                var anim = ((AnimationClip)weaponEquipAnimation.objectReferenceValue);
                if (EditorGUI.EndChangeCheck() && anim != null)
                    ChangeAnimationClip(Animations.Equip);
                if (anim != null)
                {
                    EditorGUI.BeginChangeCheck();
                    weaponActivationTime.floatValue = EditorGUILayout.Slider(new GUIContent("Activation Time", "The time taken to activate the weapon."), weaponActivationTime.floatValue, 0, anim.length);
                    if (EditorGUI.EndChangeCheck())
                    {
                        ChangeAnimationClip(Animations.Equip);
                        clip = anim;
                        previewTime = weaponActivationTime.floatValue;
                        UpdatePreview();
                    }
                }
                EditorGUILayout.PropertyField(weaponEquipSound, new GUIContent("Equip Sound"));

                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }

            unEquipFoldout = EditorGUILayout.Foldout(unEquipFoldout, "UnEquip");

            if (unEquipFoldout)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUI.indentLevel++;

                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(weaponUnEquipAnimation, new GUIContent("Animation"));
                var anim = ((AnimationClip)weaponUnEquipAnimation.objectReferenceValue);
                if (EditorGUI.EndChangeCheck() && anim != null)
                    ChangeAnimationClip(Animations.UnEquip);
                if (anim != null)
                {
                    EditorGUI.BeginChangeCheck();
                    weaponDeactivationTime.floatValue = EditorGUILayout.Slider(new GUIContent("Deactivation Time", "The time taken to deactivate the weapon."), weaponDeactivationTime.floatValue, 0, anim.length);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(this, "value changed");
                        ChangeAnimationClip(Animations.UnEquip);
                        clip = anim;
                        previewTime = weaponDeactivationTime.floatValue;
                        UpdatePreview();
                    }
                }
                EditorGUILayout.PropertyField(weaponUnEquipSound, new GUIContent("UnEquip Sound"));

                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }

            advancedFoldOut = EditorGUILayout.Foldout(advancedFoldOut, "Advanced");
            if (advancedFoldOut)
            {
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(overrideController);
                EditorGUILayout.PropertyField(useRootmotion);
                EditorGUILayout.PropertyField(overrideMoveSpeed);
                if (overrideMoveSpeed.boolValue)
                {
                    EditorGUILayout.PropertyField(walkSpeed);
                    EditorGUILayout.PropertyField(runSpeed);
                    EditorGUILayout.PropertyField(sprintSpeed);
                    EditorGUILayout.PropertyField(combatMoveSpeed);
                }
                EditorGUILayout.PropertyField(weaponHoldingClip);
                EditorGUILayout.PropertyField(weaponHolderMask);

                EditorGUILayout.PropertyField(minAttackDistance, new GUIContent("Min Attack Distance To Target"));

                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.PropertyField(overrideDodge);
                if(overrideDodge.boolValue)
                    EditorGUILayout.PropertyField(dodgeData);
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.PropertyField(overrideRoll);
                if (overrideRoll.boolValue)
                    EditorGUILayout.PropertyField(rollData);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
            }

            serializedObject.ApplyModifiedProperties();
        }

        public override void ChangeAnimationClip(object type = null)
        {
            base.ChangeAnimationClip(type);
            if (type != null)
                currentClipType = (Animations)type;
            switch (currentClipType)
            {
                case Animations.Equip:
                    clip = (AnimationClip)weaponEquipAnimation.objectReferenceValue;
                    break;
                case Animations.UnEquip:
                    clip = (AnimationClip)weaponUnEquipAnimation.objectReferenceValue;
                    break;
                case Animations.Block:
                    clip = (AnimationClip)blocking.objectReferenceValue;
                    break;
                default:
                    break;
            }
        }

        public override void HandleAnimationEnumPopup()
        {
            base.HandleAnimationEnumPopup();
            EditorGUI.BeginChangeCheck();
            currentClipType = (Animations)EditorGUILayout.EnumPopup(currentClipType, GUILayout.Width(150));
            if (EditorGUI.EndChangeCheck())
            {
                ChangeAnimationClip();
                UpdatePreview();
            }
        }
    }
}
#endif

