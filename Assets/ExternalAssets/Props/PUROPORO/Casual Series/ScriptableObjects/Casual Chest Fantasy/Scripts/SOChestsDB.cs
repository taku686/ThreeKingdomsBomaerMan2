using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    [CreateAssetMenu(fileName = "Chests Database", menuName = "PUROPORO/Casual/Chest Database")]
    [System.Serializable]
    public class SOChestsDB : ScriptableObject
    {
        public SOChest[] m_Chests;

        public int GetCount()
        {
            return m_Chests.Length;
        }

        public SOChest GetChest(int i)
        {
            if (i == -1)
                return m_Chests[Random.Range(0, m_Chests.Length)];

            return m_Chests[i];
        }
    }
}
