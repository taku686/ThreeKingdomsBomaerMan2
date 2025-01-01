using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PUROPORO
{
    public class CardCounter : MonoBehaviour
    {
        [SerializeField] private Text m_CounterText;

        /// <summary>
        /// Updates the counter.
        /// </summary>
        /// <param name="i">The number displayed on the counter.</param>
        public void UpdateCounter(int i)
        {
            m_CounterText.text = i.ToString();
            GetComponent<AnimateScale>().StartAnimation(0);
        }
    }
}
