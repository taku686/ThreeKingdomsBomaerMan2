#if UNITY_EDITOR
using FS_CombatSystem;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace FS_ThirdPerson
{
    public partial class FSSystemsSetup
    {
        static FSSystemInfo MeleeCombatSystemSetup = new FSSystemInfo
        (
            isSystemBase: true,
            enabled: false,
            name: "Melee Combat System",
            prefabName: "Combat Controller",
            welcomeEditorShowKey: "MeleeCombatSystem_WelcomeWindow_Opened",

            systemProjectSettings: new SystemProjectSettingsData
            (
                layers: new List<string> { "Enemy", "VisionSensor" },
                tags: new List<string>() { "Hitbox" }
            ),
            mobileControllerPrefabName: "Combat Mobile Controller",

            setupExtraActions: (GameObject obj, GameObject systemPrefabObj,GameObject systemControllerParentObj) => 
            { 
                SetColliders(obj.GetComponent<Animator>()); 
                SetCombatSettings(systemPrefabObj, systemControllerParentObj);
                SetEnemyManager(systemPrefabObj, systemControllerParentObj); 
            }
        );

        static string MeleeCombatSystemWelcomeEditorKey => MeleeCombatSystemSetup.welcomeEditorShowKey;


        [InitializeOnLoadMethod]
        public static void LoadMeleeCombatSystem()
        {
            if (!string.IsNullOrEmpty(MeleeCombatSystemWelcomeEditorKey) && !EditorPrefs.GetBool(MeleeCombatSystemWelcomeEditorKey, false))
            {
                SessionState.SetBool("FS_WelcomeWindow_Loaded", false);
                EditorPrefs.SetBool(MeleeCombatSystemWelcomeEditorKey, true);
                FSSystemsSetupEditorWindow.OnProjectLoad();
            }
        }

        static void SetCombatSettings(GameObject systemPrefabObj, GameObject systemControllerParentObj)
        {
            var sourceComp = systemPrefabObj.GetComponent<CombatSettings>();
            var targetComp = systemControllerParentObj.AddComponent<CombatSettings>();
            ComponentUtility.CopyComponent(sourceComp);
            ComponentUtility.PasteComponentValues(targetComp);
        }

        static void SetEnemyManager(GameObject systemPrefabObj, GameObject systemControllerParentObj)
        {
            var sourceComp = systemPrefabObj.GetComponentInChildren<EnemyManager>();
            var enemyManager = new GameObject("Enemy Manager");
            enemyManager.transform.SetParent(systemControllerParentObj.transform);

            var targetComp = enemyManager.AddComponent<EnemyManager>();
            ComponentUtility.CopyComponent(sourceComp);
            ComponentUtility.PasteComponentValues(targetComp);
            targetComp.player = systemControllerParentObj.GetComponentInChildren<CombatController>();

            
        }

        static void SetColliders(Animator modelAnimator)
        {
            AddColliderToBone(modelAnimator, HumanBodyBones.RightHand);
            AddColliderToBone(modelAnimator, HumanBodyBones.LeftHand);
            AddColliderToBone(modelAnimator, HumanBodyBones.RightFoot);
            AddColliderToBone(modelAnimator, HumanBodyBones.LeftFoot);

            AddColliderToBone(modelAnimator, HumanBodyBones.LeftLowerArm, "LeftElbowCollider");
            AddColliderToBone(modelAnimator, HumanBodyBones.RightLowerArm, "RightElbowCollider"); ;
            AddColliderToBone(modelAnimator, HumanBodyBones.LeftLowerLeg, "LeftKneeCollider");
            AddColliderToBone(modelAnimator, HumanBodyBones.RightLowerLeg, "RightKneeCollider");
            AddColliderToBone(modelAnimator, HumanBodyBones.Head, "HeadCollider");
        }
        static void AddColliderToBone(Animator animator, HumanBodyBones bone, string objName = "")
        {
            var handler = animator.GetBoneTransform(bone).transform;
            var prefabName = string.IsNullOrEmpty(objName) ? bone.ToString() + "Collider" : objName;
            var weaponHandler = (GameObject)Resources.Load(prefabName);
            var obj = PrefabUtility.InstantiatePrefab(weaponHandler, handler) as GameObject;
            obj.transform.localPosition = Vector3.zero;

        }

    }
}
#endif