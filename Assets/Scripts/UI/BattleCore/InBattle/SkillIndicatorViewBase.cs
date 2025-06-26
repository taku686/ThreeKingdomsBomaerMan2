using Common.Data;
using UnityEngine;

namespace UI.BattleCore.InBattle
{
    public class SkillIndicatorViewBase : MonoBehaviour
    {
        protected Material _Material;

        public void NoHit()
        {
            SetColor(Color.red);
        }

        public void Hit()
        {
            SetColor(Color.green);
        }

        private void SetColor(Color color)
        {
            if (_Material != null)
            {
                _Material.color = color;
            }
        }

        private void OnDestroy()
        {
            if (_Material != null)
            {
                Destroy(_Material);
            }
        }

        public class SkillIndicatorInfo
        {
            public float _Range { get; }
            public float _Angle { get; }
            public bool _IsTouch { get; }
            public bool _IsInteractable { get; }
            public SkillDirection _SkillDirection { get; }

            public SkillIndicatorInfo
            (
                float range,
                float angle,
                bool isTouch,
                bool isInteractable,
                SkillDirection skillDirection
            )
            {
                _Range = range;
                _Angle = angle;
                _IsTouch = isTouch;
                _IsInteractable = isInteractable;
                _SkillDirection = skillDirection;
            }
        }
    }
}