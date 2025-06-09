using UnityEngine;

namespace UI.BattleCore.InBattle
{
    public class ArrowSkillIndicatorView : SkillIndicatorViewBase
    {
        private const float ArrowWidthRate = 0.2f;
        private float _defaultOffsetY;

        public void Setup(float range)
        {
            if (_Material == null)
            {
                _Material = GetComponent<Renderer>().material;
                _defaultOffsetY = _Material.mainTextureOffset.y;
            }

            transform.localPosition = new Vector3(0, 0.2f, range * 0.5f);
            transform.localEulerAngles = new Vector3(90, 0, 0);
            transform.localScale = new Vector3(range * ArrowWidthRate, range, 1);
            NoHit();
        }

        public void UpdateArrowIndicator(Vector3 origin, float range, int layerMask, Vector3 direction)
        {
            if (Physics.Raycast(origin, direction, out var hitInfo, range, layerMask))
            {
                Hit();
                UpdateIndicatorLength(hitInfo.distance);
            }
            else
            {
                NoHit();
                UpdateIndicatorLength(range);
            }
        }

        private void UpdateIndicatorLength(float range)
        {
            if (_Material == null)
            {
                return;
            }

            var length = range * _defaultOffsetY / transform.localScale.y;
            _Material.mainTextureOffset = new Vector2(0, length);
        }
    }
}