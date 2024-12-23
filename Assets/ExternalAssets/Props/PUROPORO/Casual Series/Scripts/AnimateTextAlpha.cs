using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace PUROPORO
{
    /// <summary>
    /// Automatically animate text alpha, looping animation (ping pong).
    /// </summary>
    public class AnimateTextAlpha : MonoBehaviour
    {
        [SerializeField] private Text m_text;

        private void LateUpdate()
        {
            m_text.color = new Color(1, 1, 1, Mathf.SmoothStep(0, 1.0f, Mathf.PingPong(Time.time, 1)));
        }
    }
}
