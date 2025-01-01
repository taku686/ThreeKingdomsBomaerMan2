using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    /// <summary>
    /// This class is a very simple Tween-animation style animator for animating a subject from point a to point b in UI.
    /// However, I recommend getting a better Tween implementation such as DOTween, HOTween, LeanTween, iTween, etc.
    /// </summary>
    public class AnimateAToBUi : MonoBehaviour
    {
        public RectTransform m_Subject;
        public RectTransform m_PointA;
        public RectTransform m_PointB;

        private float m_AnimationTime;
        private float m_LastKeyTime;

        [Header("Animation Curves")]
        [SerializeField] private AnimationCurve m_MoveCurve;
        [SerializeField] private AnimationCurve m_RotationCurve;
        [SerializeField] private AnimationCurve m_ScaleCurve;

        private void Start()
        {
            ResetAnimation();
        }

        /// <summary>
        /// Reset the animation.
        /// </summary>
        public void ResetAnimation()
        {
            m_Subject.position = m_PointA.position;
            m_Subject.rotation = m_PointA.rotation;
            m_Subject.localScale = m_PointA.localScale;

            m_AnimationTime = 0;

            Keyframe lastKey = m_MoveCurve[m_MoveCurve.length - 1];
            Keyframe tempKey = m_RotationCurve[m_RotationCurve.length - 1];

            if (lastKey.time < tempKey.time)
                lastKey = tempKey;

            tempKey = m_ScaleCurve[m_ScaleCurve.length - 1];

            if (lastKey.time < tempKey.time)
                lastKey = tempKey;

            m_LastKeyTime = lastKey.time;

            StopAllCoroutines();
        }

        /// <summary>
        /// Starts the animation (Coroutine).
        /// </summary>
        /// <param name="delay">The start delay of the animation.</param>
        public void StartAnimation(float delay)
        {
            ResetAnimation();
            StartCoroutine(Animate(delay));
        }

        private IEnumerator Animate(float delay)
        {
            yield return new WaitForSeconds(delay);

            while (m_AnimationTime < m_LastKeyTime)
            {
                m_AnimationTime += Time.deltaTime;
                m_Subject.position = Vector3.Lerp(m_PointA.position, m_PointB.position, m_MoveCurve.Evaluate(m_AnimationTime));
                m_Subject.rotation = Quaternion.Lerp(m_PointA.rotation, m_PointB.rotation, m_RotationCurve.Evaluate(m_AnimationTime));
                m_Subject.localScale = Vector3.Lerp(m_PointA.localScale, m_PointB.localScale, m_ScaleCurve.Evaluate(m_AnimationTime));
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
