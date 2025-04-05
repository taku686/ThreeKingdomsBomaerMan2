using FS_ThirdPerson;
using System.Collections.Generic;
using UnityEngine;
namespace FS_CombatSystem
{
    [CustomIcon(FolderPath.CombatIcons + "Reaction Icon.png")]
    [CreateAssetMenu(menuName = "Combat System/Create Reactions")]
    public class ReactionsData : ScriptableObject
    {
        [Tooltip("List of reactions for handling different reactions.")]
        public List<ReactionContainer> reactions = new List<ReactionContainer>();

        [Tooltip("Indicates if the target should rotate towards the attacker during the attack.")]
        public bool rotateToAttacker = true;

        private void OnValidate()
        {
            foreach (var item in reactions)
            {
                if(item.reaction.animationClip != null && item.reaction.animationClipInfo.clip == null)
                item.reaction.animationClipInfo.clip = item.reaction.animationClip;
            }
        }
    }

    [System.Serializable]
    public class ReactionContainer
    {
        [HideInInspector]
        public string name;

        [Tooltip("Direction of the hit")]
        [HideInInspectorEnum(1)]
        public HitDirections direction;

        [Tooltip("If true, reaction will only be played when attacked from behind")]
        public bool attackedFromBehind = false;

        [Tooltip("You can specify tags like Powerful or Weak for reactions and play them based on the tag provied in the attack")]
        public string tag;

        public Reaction reaction;

        public ReactionContainer()
        {
            name = "Direction - " + direction.ToString();
            if (!string.IsNullOrWhiteSpace(tag))
                name += ", Tag - " + tag;
        }
    }

    [System.Serializable]
    public class Reaction
    {
        [Tooltip("The animation clip associated with this reaction.")]
        [HideInInspector]
        public AnimationClip animationClip;

        [Tooltip("The animation clip associated with this reaction.")]
        public AnimGraphClipInfo animationClipInfo;

        [Tooltip("Indicates if the character will be knocked down as part of this reaction.")]
        public bool willBeKnockedDown;

        [Tooltip("The direction in which the character will be knocked down.")]
        public KnockDownDirection knockDownDirection;

        [Tooltip("The range of time (in seconds) for how long the character will stay lying down.")]
        public Vector2 lyingDownTimeRange = new Vector2(1, 3);

        [Tooltip("Indicates if the lying down animation should be overridden.")]
        public bool overrideLyingDownAnimation;

        [Tooltip("The animation clip to use for the lying down phase.")]
        public AnimationClip lyingDownAnimation;

        [Tooltip("The animation clip to use for the character getting up.")]
        public AnimationClip getUpAnimation;
    }

    public enum KnockDownDirection { LyingOnBack, LyingOnFront }

    public enum HitDirections
    {
        Any,
        FromCollision,
        Top,
        Bottom,
        Right,
        Left
    }
}
