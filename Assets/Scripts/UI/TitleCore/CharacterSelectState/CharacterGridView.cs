using Common.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    public class CharacterGridView : MonoBehaviour
    {
        public Image characterImage;
        public Image backGroundImage;
        public TextMeshProUGUI nameText;
        public Button gridButton;
        [SerializeField] private Image _typeImage;
        [SerializeField] private Image _typeIcon;
        [SerializeField] private StatusGridView[] statusGridViews;

        public void ApplyStatusGridViews(TemporaryCharacterRepository.OrderType orderType, CharacterData fixedCharacterData, (Sprite, Color) typeData)
        {
            characterImage.sprite = fixedCharacterData.SelfPortraitSprite;
            backGroundImage.sprite = fixedCharacterData.ColorSprite;
            nameText.text = fixedCharacterData.Name;
            _typeImage.color = typeData.Item2;
            _typeIcon.sprite = typeData.Item1;
            foreach (var statusGridView in statusGridViews)
            {
                statusGridView.gameObject.SetActive(statusGridView.OrderType == orderType);
                if (statusGridView.OrderType != orderType)
                {
                    continue;
                }

                var value = GetStatusValue(fixedCharacterData, orderType);
                statusGridView.ApplyViewModel(orderType.ToString(), value);
            }
        }

        private string GetStatusValue(CharacterData characterData, TemporaryCharacterRepository.OrderType orderType)
        {
            return orderType switch
            {
                TemporaryCharacterRepository.OrderType.Id => characterData.Id.ToString(),
                TemporaryCharacterRepository.OrderType.Level => characterData.Level.ToString(),
                TemporaryCharacterRepository.OrderType.Hp => characterData.Hp.ToString(),
                TemporaryCharacterRepository.OrderType.Attack => characterData.Attack.ToString(),
                TemporaryCharacterRepository.OrderType.Speed => characterData.Speed.ToString(),
                TemporaryCharacterRepository.OrderType.Bomb => characterData.BombLimit.ToString(),
                TemporaryCharacterRepository.OrderType.Fire => characterData.FireRange.ToString(),
                _ => string.Empty
            };
        }
    }
}