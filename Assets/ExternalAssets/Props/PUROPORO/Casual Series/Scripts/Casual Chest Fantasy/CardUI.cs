using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PUROPORO
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] private Image m_CardFrame;
        [SerializeField] private Image m_CardImage;
        [SerializeField] private Text m_CardText;

        public void SetCard(Sprite frameSprite, Sprite tempSprite, string tempText)
        {
            m_CardFrame.sprite = frameSprite;
            m_CardImage.sprite = tempSprite;
            m_CardText.text = tempText;
        }
    }
}