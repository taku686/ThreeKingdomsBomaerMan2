using UnityEngine;

namespace UI.BattleCore.InBattle
{
    public class CircleSkillIndicatorView : SkillIndicatorViewBase
    {
        private static readonly int Angle = Shader.PropertyToID("_Angle");

        public void Setup(float range, float angle)
        {
            if (_Material == null)
            {
                _Material = GetComponent<Renderer>().material;
            }

            transform.localPosition = new Vector3(0, 0.2f, 0);
            transform.localEulerAngles = new Vector3(90, 90, 0);
            transform.localScale = new Vector3(range, range, 1);
            _Material.SetFloat(Angle, angle);
            NoHit();
        }

        public void UpdateCircleIndicator(Vector3 origin, float range, int layerMask)
        {
            var radius = range * 0.5f; // Adjust radius if needed
            if (Physics.CheckSphere(origin, radius, layerMask))
            {
                Hit();
            }
            else
            {
                NoHit();
            }
        }
    }
}