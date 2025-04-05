using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace FS_CombatSystem
{
    [CustomEditor(typeof(ReactionsData))]
    public class ReactionDataEditor : AnimationPreviewHandler
    {
        ReactionsData reactionsData;
        public int currentAnimation;

        public List<string> reactionsNameList = new List<string>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            reactionsNameList.Clear();
            foreach (var d in reactionsData.reactions)
            {
                d.name = "Direction - " + d.direction.ToString();
                if (!string.IsNullOrWhiteSpace(d.tag))
                {
                    d.name += ", Tag - " + d.tag;
                }
                if (!reactionsNameList.Contains(d.name))
                    reactionsNameList.Add(d.name);
            }
        }
        public override void OnEnable()
        {
            base.OnEnable();
            reactionsData = target as ReactionsData;
            targetData = reactionsData;
            OnStart();
        }

        public override void HandleAnimationEnumPopup()
        {
            base.HandleAnimationEnumPopup();
            if (reactionsData.reactions.Count > 0)
            {
                currentAnimation = (int)EditorGUILayout.Popup(currentAnimation, reactionsNameList.ToArray(), GUILayout.Width(150));
                if (currentAnimation < reactionsNameList.Count)
                    clip = reactionsData.reactions.FirstOrDefault(r => r.name == reactionsNameList[currentAnimation]).reaction.animationClip;
                else
                    currentAnimation = 0;
            }

        }
    }
}
