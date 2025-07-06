using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TitleCore.LoginBonusState
{
    public class LoginBonusGridView : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private TextMeshProUGUI _itemAmountText;

        public void ApplyView(Sprite itemSprite, int itemAmount)
        {
            if (_itemImage != null)
            {
                _itemImage.sprite = itemSprite;
            }

            if (_itemAmountText != null)
            {
                _itemAmountText.text = itemAmount.ToString();
            }
        }
    }
}