using UnityEngine;
using UnityEngine.UI;

namespace PUROPORO
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] private Image m_CardFrame;
        [SerializeField] private Image m_CardImage;
        [SerializeField] private Text m_CardText;

        /// <summary>
        /// Setups the card informations.
        /// </summary>
        /// <param name="tempColor">The color of rarity.</param>
        /// <param name="tempSprite">Card's icon or image.</param>
        /// <param name="tempText">Card's name.</param>
        public void SetCard(Color tempColor, Sprite tempSprite, string tempText)
        {
            m_CardFrame.color = tempColor;
            m_CardImage.sprite = tempSprite;
            m_CardText.text = tempText;
        }
    }
}
