using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FS_CombatSystem
{
    public class AnimationPreviewHandler : Editor
    {
        public virtual void HandleAnimationEnumPopup() { }
        public virtual void ChangeAnimationClip(object type = null) { }

        public virtual void OnEnable()
        {
            previewTime = 0;
        }


        #region Preview handler


        #region variables

        protected UnityEngine.Object targetData;

        protected static float previewTime;
        protected static Editor editor;


        protected static bool isPlaying;
        protected static float playbackSpeed = 1;
        protected static float frameCount;

        protected static GameObject previewObject;
        protected string previewObjectPath;

        protected AnimationClip clip;

        GUIStyle sliderStyle = new GUIStyle();
        GUIStyle thumbStyle = new GUIStyle();
        GUIStyle blackStyle = new GUIStyle();
        GUIStyle backgroundStyle = new GUIStyle();


        PreviewSceneStage previewSceneStage;
        bool scenePreviewOpened;
        const string scenePreviewStatusKey = "ScenePreviewStatus";

        float lastFrameTime = 0.0f;

        #endregion

        protected void OnStart(AnimationClip animationClip = null)
        {
            scenePreviewOpened = EditorPrefs.GetBool(scenePreviewStatusKey);
            SetStyles();
            clip = animationClip;
            ChangeAnimationClip();


            previewObject = Resources.Load<GameObject>("Preview Object");
            previewObjectPath = AssetDatabase.GetAssetPath(previewObject);

            if (previewObject != null && scenePreviewOpened)
            {
                FocusPreviewObjectOnScene();
                OpenScenePreview();
            }

            DestroyImmediate(editor);


            PreviewStage.OnCloseAction -= OnCloseStage;
            PreviewStage.OnCloseAction += OnCloseStage;
        }

        private void OnDisable()
        {
            PreviewStage.OnCloseAction -= OnCloseStage;
            var closeScene = (Selection.activeObject == null || Selection.activeObject.GetType() != targetData.GetType());
            if (closeScene)
            {
                isPlaying = false;
                if (scenePreviewOpened)
                    CloseScenePreview();
            }

        }

        public override bool HasPreviewGUI()
        {
            return true;
        }

        public override void OnPreviewSettings()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 50;
            var guiContent = new GUIContent(!scenePreviewOpened ? "Open" : "Close", !scenePreviewOpened ? "Open Scene Preview" : "Close Scene Preview");
            if (GUILayout.Button(guiContent))
            {
                scenePreviewOpened = !scenePreviewOpened;
                EditorPrefs.SetBool(scenePreviewStatusKey, scenePreviewOpened);
                HandlePreviewScene();
            }

            EditorGUI.BeginChangeCheck();
            previewObject = (GameObject)EditorGUILayout.ObjectField(previewObject, typeof(GameObject), true, GUILayout.Width(150));
            if (EditorGUI.EndChangeCheck())
            {
                if (previewObject != null && previewObject.GetComponent<Animator>() != null)
                {
                    var prefab = PrefabUtility.SaveAsPrefabAsset(previewObject, previewObjectPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    prefab.name = "Preview Object";
                    previewObject = Resources.Load<GameObject>("Preview Object");
                    var animator = previewObject.GetComponent<Animator>();
                    if (animator != null)
                        animator.applyRootMotion = false;
                    if (scenePreviewOpened)
                        OpenScenePreview();
                }
                UpdatePreview();
            }

            HandleAnimationEnumPopup();

            EditorGUILayout.EndHorizontal();
        }

        (bool, string) CanPreview()
        {
            var text = "";
            bool canPreview = true;
            if (clip == null)
            {
                text = "Clip is not assigned";
                canPreview = false;
            }
            else if (previewObject == null)
            {
                text = "Preview Object is not assigned";
                canPreview = false;
            }
            return (targetData != null && canPreview, text);
        }

        void HandlePreviewScene()
        {
            if (scenePreviewOpened)
                OpenScenePreview();
            else
                CloseScenePreview();
        }

        void OpenScenePreview()
        {
            AddPreviewObjectToPreviewScene();
            EditorApplication.delayCall += () =>
            {
                Selection.activeObject = targetData;
            };
        }

        private void AddPreviewObjectToPreviewScene()
        {
            GameObject duplicatedObject = Instantiate(previewObject);
            duplicatedObject.name = previewObject.name;
            if (previewSceneStage == null)
            {
                previewSceneStage = CreateInstance<PreviewStage>();
                StageUtility.GoToStage(previewSceneStage, true);
                SceneView.lastActiveSceneView.showGrid = true;
            }
            else
            {
                foreach (var obj in previewSceneStage.scene.GetRootGameObjects())
                    DestroyImmediate(obj);
            }
            Scene previewScene = previewSceneStage.scene;
            SceneManager.MoveGameObjectToScene(duplicatedObject, previewScene);
            duplicatedObject.hideFlags = HideFlags.HideInHierarchy;
            SceneManager.MoveGameObjectToScene(CreateDirectionalLight(new Vector3(50, -90, 0)), previewScene);
            SceneManager.MoveGameObjectToScene(CreateDirectionalLight(new Vector3(50, 90, 0)), previewScene);
            SceneManager.MoveGameObjectToScene(CreateDirectionalLight(new Vector3(90, 0, 0)), previewScene);
            previewObject = duplicatedObject;
        }

        GameObject CreateDirectionalLight(Vector3 rot)
        {
            GameObject lightGameObject = new GameObject("Preview Light");
            Light lightComp = lightGameObject.AddComponent<Light>();
            lightComp.type = LightType.Directional;
            lightGameObject.transform.eulerAngles = rot;
            lightGameObject.hideFlags = HideFlags.HideInHierarchy;
            return lightGameObject;
        }

        void CloseScenePreview()
        {
            StageUtility.GoToMainStage();
        }

        void OnCloseStage()
        {
            Selection.activeObject = targetData;
            previewObject = Resources.Load<GameObject>("Preview Object");
            scenePreviewOpened = false;
            EditorPrefs.SetBool(scenePreviewStatusKey, scenePreviewOpened);
        }

        public void SampleAnimationPreviewOnScene()
        {
            if (CanPreview().Item1)
                clip.SampleAnimation(previewObject, previewTime);
        }

        public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
        {
            (bool canPreview, string text) = CanPreview();
            if (canPreview)
            {
                if (thumbStyle.normal.background == null)
                    SetStyles();
                var backgroundPos = new Rect(r.x, r.y, r.width, 20);
                var buttonPos = new Rect(r.x, r.y, r.width * .07f, 20);
                var previewTimePose = new Rect(buttonPos.x + buttonPos.width, r.y, r.width * .6f, 20);
                var speedPos = new Rect(previewTimePose.x + previewTimePose.width, r.y, r.width * .28f, 20);
                var speedTimeLabelPos = new Rect(speedPos.x + speedPos.width, r.y, r.width * .05f, 20);

                GUI.Box(backgroundPos, "", backgroundStyle);

                GUIContent playIcon = EditorGUIUtility.IconContent("PlayButton");
                GUIContent pauseIcon = EditorGUIUtility.IconContent("PauseButton");
                if (GUI.Button(buttonPos, isPlaying ? pauseIcon : playIcon))
                {
                    isPlaying = !isPlaying;
                    if (isPlaying && scenePreviewOpened)
                        FocusPreviewObjectOnScene();
                }
                if (isPlaying)
                {
                    SampleAnimationPreviewOnScene();
                }

                EditorGUI.BeginChangeCheck();
                previewTime = GUI.HorizontalSlider(previewTimePose, previewTime, 0, clip.length, sliderStyle, thumbStyle);
                if (EditorGUI.EndChangeCheck())
                    UpdatePreview();

                playbackSpeed = GUI.HorizontalSlider(speedPos, playbackSpeed, 0.1f, 2);
                GUI.Box(new Rect(buttonPos.width, r.y, 2, 20), "", blackStyle);
                GUI.Box(new Rect(previewTimePose.x + previewTimePose.width, r.y, 2, 20), "", blackStyle);
                playbackSpeed = EditorGUI.FloatField(speedTimeLabelPos, (float)Math.Round(playbackSpeed, 2));
                playbackSpeed = Mathf.Clamp(playbackSpeed, 0.1f, 2);




                r = new Rect(r.x, r.y + 20, r.width, r.height);
                base.OnInteractivePreviewGUI(r, background);
                SampleAnimationPreview(r);

                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                var normalizeTime = Math.Round(((previewTime / clip.length) * 100), 2) + " %";
                var previewT = (float)Math.Round(previewTime, 2);
                var fCount = (int)frameCount;
                string label = previewT + " ( " + normalizeTime + " ) Frame: " + fCount;
                GUILayout.Label(label);
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                GUIContent labelContent = EditorGUIUtility.IconContent("console.warnicon.sml");
                labelContent.text = text;
                Vector2 labelSize = EditorStyles.label.CalcSize(labelContent);
                Rect labelRect = new Rect(r.center - labelSize / 2f, labelSize);
                GUI.Label(labelRect, labelContent, EditorStyles.label);
            }

        }

        protected void UpdatePreview()
        {
            if (editor == null || clip == null) return;
            DestroyImmediate(editor);
            frameCount = previewTime * clip.frameRate;
        }

        void SampleAnimationPreview(Rect r)
        {
            if (isPlaying)
            {
                DestroyImmediate(editor);
                float deltaTime = Time.realtimeSinceStartup - lastFrameTime;
                previewTime += Mathf.Clamp(deltaTime * playbackSpeed, 0, clip.length);
                if (previewTime > clip.length)
                    previewTime = 0;
                frameCount = previewTime * clip.frameRate;
            }
            if (editor == null)
                editor = Editor.CreateEditor(previewObject);

            lastFrameTime = Time.realtimeSinceStartup;

            editor.OnInteractivePreviewGUI(r, "window");
            clip.SampleAnimation(previewObject, previewTime);
            editor.Repaint();
        }

        void FocusPreviewObjectOnScene()
        {
            SceneView sceneView = SceneView.lastActiveSceneView;
            if (previewObject != null)
                sceneView?.LookAt(previewObject.transform.position + Vector3.up);
        }

        void SetStyles()
        {
            sliderStyle.normal.background = MakeTexture(1, 1, new Color(0f, 0f, .19f, 0f));
            sliderStyle.fixedHeight = 20f;
            thumbStyle.normal.background = MakeTexture(1, 1, new Color(1f, 1f, 1f, .61f));
            thumbStyle.fixedWidth = 3f;
            thumbStyle.fixedHeight = 20f;
            blackStyle.normal.background = MakeTexture(1, 1, Color.black);
            backgroundStyle.normal.background = MakeTexture(1, 1, new Color(0f, 0f, .3f, 0f));
        }

        public Texture2D MakeTexture(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; ++i)
            {
                pix[i] = color;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }

        #endregion
    }
    public class PreviewStage : PreviewSceneStage
    {
        public static event Action OnCloseAction;
        protected override GUIContent CreateHeaderContent()
        {
            var title = EditorGUIUtility.IconContent("AnimationClip Icon");
            title.text = "Animation Preview";
            return title;
        }

        protected override void OnCloseStage()
        {
            base.OnCloseStage();
            OnCloseAction?.Invoke();
        }
    }
}