using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    /// <summary>
    /// This class is a very simple Tween-animation style animator for animating a subject's scale.
    /// However, I recommend getting a better Tween implementation such as DOTween, HOTween, LeanTween, iTween, etc.
    /// </summary>
    public class AnimateScale : MonoBehaviour
    {
        public Vector3 m_StartScale = new Vector3(0, 0, 0);
        public Vector3 m_EndScale = new Vector3(1, 1, 1);

        private float m_AnimationTime;
        private float m_LastKeyTime;

        [Header("Animation Curves")]
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
            transform.localScale = m_StartScale;

            m_AnimationTime = 0;

            Keyframe lastKey = m_ScaleCurve[m_ScaleCurve.length - 1];
            m_LastKeyTime = lastKey.time;
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
                transform.localScale = Vector3.Lerp(m_StartScale, m_EndScale, m_ScaleCurve.Evaluate(m_AnimationTime));
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
