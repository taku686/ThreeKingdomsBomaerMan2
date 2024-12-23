using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    /// <summary>
    /// This class is used to control the background of the Reward Room.
    /// </summary>
    public class RewardRoomDemo : MonoBehaviour
    {
        [SerializeField] private Texture[] m_Wallpapers;
        private int m_Counter = 0;

        public void ChangeBGColor()
        {
            m_Counter++;

            if (m_Counter >= m_Wallpapers.Length)
                m_Counter = 0;

            GetComponent<MeshRenderer>().material.mainTexture = m_Wallpapers[m_Counter];
        }
    }
}
