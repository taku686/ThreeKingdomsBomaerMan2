using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    [CreateAssetMenu(fileName = "Card", menuName = "PUROPORO/Casual/Card")]
    [System.Serializable]
    public class SOCard : ScriptableObject
    {
        [SerializeField] private Rarity m_CardRarity;
        [SerializeField] private string m_CardName;
        [SerializeField] private Sprite m_CardImage;

        public Rarity GetRarity()
        {
            return m_CardRarity;
        }

        public string GetName()
        {
            return m_CardName;
        }

        public Sprite GetImage()
        {
            return m_CardImage;
        }
    }
}
