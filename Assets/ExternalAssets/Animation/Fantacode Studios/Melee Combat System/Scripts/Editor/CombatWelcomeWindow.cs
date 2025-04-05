#if UNITY_EDITOR
using FS_ThirdPerson;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
namespace FS_CombatSystem
{

    public class CombatWelcomeWindow : EditorWindow
    {
        public static CombatWelcomeWindow combatCombatWelcomeWindow;
        public const string inputsystem = "inputsystem";
        public static string windowOpenKey = "combat-window-not-opened";

        static string[] newLayers = { "Player", "Enemy", "VisionSensor" };
        static List<string> newTags = new List<string>() { "Hitbox" };


        [MenuItem("Tools/Combat System/Support/Discord")]
        public static void InitDiscord()
        {
            Application.OpenURL("https://discord.gg/QNe4AMYT");
        }
        [MenuItem("Tools/Combat System/Support/Youtube")]
        public static void InitYoutude()
        {
            Application.OpenURL("https://youtube.com/playlist?list=PLnbdyws4rcAuJ6g8xrL9r2K3vv2SwL1na&si=ZEldtXG4X6XTpAsY");
        }


        [InitializeOnLoadMethod]
        public static void ShowWindow()
        {
            if (PlayerPrefs.GetString(windowOpenKey) != "combat-window-opened")
            {
                AddNewLayers();
                InitEditorWindow();
                PlayerPrefs.SetString(windowOpenKey, "combat-window-opened");
            }
        }
        [MenuItem("Tools/Combat System/Welcome Window")]
        public static void InitEditorWindow()
        {
            if (HasOpenInstances<CombatWelcomeWindow>())
                return;
            combatCombatWelcomeWindow = (CombatWelcomeWindow)EditorWindow.GetWindow<CombatWelcomeWindow>();
            GUIContent titleContent = new GUIContent("Welcome");
            combatCombatWelcomeWindow.titleContent = titleContent;
            combatCombatWelcomeWindow.minSize = new Vector2(450, 242);
            combatCombatWelcomeWindow.maxSize = new Vector2(450, 242);

        }
        private void OnGUI()
        {
            if (combatCombatWelcomeWindow == null)
                combatCombatWelcomeWindow = (CombatWelcomeWindow)EditorWindow.GetWindow<CombatWelcomeWindow>();
            GUILayout.Space(10);

            EditorGUI.HelpBox(new Rect(5, 10, position.width - 10, 80), "Looking to add dynamic and immersive melee combat to your game, similar to what you see in titles like Assassin's Creed, Batman Arkham, etc.? Then this is the perfect asset for you. With this asset, you can create a free-flow combat system with features like combos, takedowns/finishers, counterattacks, block/parry systems, free-flow enemy AI, motion warping, etc.", MessageType.None);


            if (GUI.Button(new Rect(55, 100, 110, 35), "QuickStart"))
                Application.OpenURL("https://fantacode.gitbook.io/melee-combat-system/quick-start");
            if (GUI.Button(new Rect(170, 100, 110, 35), "Documentation"))
                Application.OpenURL("https://fantacode.gitbook.io/melee-combat-system");
            if (GUI.Button(new Rect(285, 100, 110, 35), "Videos"))
                Application.OpenURL("https://youtube.com/playlist?list=PLnbdyws4rcAuJ6g8xrL9r2K3vv2SwL1na&si=ZEldtXG4X6XTpAsY");

            GUILayout.Space(130);
            AddOnModules();

            GUI.Box(new Rect(0, 182, position.width, 2), "");

            if (GUI.Button(new Rect(155, 195, 150, 35), "Create Character"))
                CreateCombatCharacterEditorWindow.InitPlayerSetupWindow();

        }
        private void AddOnModules()
        {
            var _inputsystem = false;

            var sybmols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(';');
            for (int i = 0; i < sybmols.Length; i++)
            {
                if (string.Equals(inputsystem, sybmols[i].Trim()))
                    _inputsystem = true;
            }

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.LabelField(new GUIContent("Addon Module :"), EditorStyles.boldLabel);
            GUILayout.Space(4);

            GUILayout.BeginHorizontal();
            var _input = EditorGUILayout.Toggle("", _inputsystem, GUILayout.Width(17), GUILayout.Height(17));
            EditorGUILayout.LabelField(new GUIContent("New Input System", "Enabling this feature allows support for the New Input System. Ensure that you have installed the New InputSystem package before enabling this feature"), GUILayout.Width(110));
            GUILayout.EndHorizontal();

            var sybmolValueChanged = EditorGUI.EndChangeCheck();

            if (_input != _inputsystem)
            {
                if (_input)
                {
                    if (EditorUtility.DisplayDialog("New Input System", "Enabling this feature allows support for the New Input System. Ensure that you have installed the New InputSystem package before enabling this feature", "OK", "Cancel"))
                    {
                        ScriptingDefineSymbolController.ToggleScriptingDefineSymbol(inputsystem, _input);
                    }
                    else
                        sybmolValueChanged = false;
                }
                else
                    ScriptingDefineSymbolController.ToggleScriptingDefineSymbol(inputsystem, _input);
            }


            if (sybmolValueChanged)
                ScriptingDefineSymbolController.ReimportScripts();

        }
        [MenuItem("Tools/Combat System/Import Tag Manager", false, 600, priority = 4)]
        public static void AddTagsAndlayers()
        {
            EditorUtility.DisplayDialog("Tag Manager", "Tags and layers imported successfully", "ok");
            AddNewLayers();
        }
        public static void AddNewLayers()
        {
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            SerializedProperty layersProp = tagManager.FindProperty("layers");

            for (int i = 0; i < newLayers.Length; i++)
            {
                string layerName = newLayers[i];

                if (!string.IsNullOrEmpty(layerName))
                {
                    bool layerExists = false;
                    for (int j = 0; j < layersProp.arraySize; j++)
                    {
                        SerializedProperty layerProp = layersProp.GetArrayElementAtIndex(j);
                        if (layerProp.stringValue == layerName)
                        {
                            layerExists = true;
                            break;
                        }
                    }

                    if (!layerExists)
                    {
                        for (int j = 8; j < layersProp.arraySize; j++)
                        {
                            SerializedProperty layerProp = layersProp.GetArrayElementAtIndex(j);
                            if (string.IsNullOrEmpty(layerProp.stringValue))
                            {
                                layerProp.stringValue = layerName;
                                break;
                            }
                        }
                    }
                }
            }
            tagManager.ApplyModifiedProperties();

            foreach (var tag in newTags)
            {
                if (!InternalEditorUtility.tags.ToList().Contains(tag))
                    InternalEditorUtility.AddTag(tag);
            }
        }
    }
}
#endif
