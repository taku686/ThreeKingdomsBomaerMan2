using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    [CreateAssetMenu(fileName = "Cards Database", menuName = "PUROPORO/Casual/Cards Database")]
    [System.Serializable]
    public class SOCardsDB : ScriptableObject
    {
        public SOCard[] m_Cards;

        public int GetCount()
        {
            return m_Cards.Length;
        }

        public SOCard GetCard(int i)
        {
            if (i == -1)
                return m_Cards[Random.Range(0, m_Cards.Length)];

            return m_Cards[i];
        }
    }
}
