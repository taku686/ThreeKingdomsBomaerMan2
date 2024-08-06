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
        [SerializeField] private StatusGridView[] statusGridViews;

        public void ApplyStatusGridViews(CharacterSelectRepository.OrderType orderType,
            CharacterData fixedCharacterData)
        {
            characterImage.sprite = fixedCharacterData.SelfPortraitSprite;
            backGroundImage.sprite = fixedCharacterData.ColorSprite;
            nameText.text = fixedCharacterData.Name;
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

        private string GetStatusValue(CharacterData characterData, CharacterSelectRepository.OrderType orderType)
        {
            return orderType switch
            {
                CharacterSelectRepository.OrderType.Id => characterData.Id.ToString(),
                CharacterSelectRepository.OrderType.Level => characterData.Level.ToString(),
                CharacterSelectRepository.OrderType.Hp => characterData.Hp.ToString(),
                CharacterSelectRepository.OrderType.Attack => characterData.Attack.ToString(),
                CharacterSelectRepository.OrderType.Speed => characterData.Speed.ToString(),
                CharacterSelectRepository.OrderType.Bomb => characterData.BombLimit.ToString(),
                CharacterSelectRepository.OrderType.Fire => characterData.FireRange.ToString(),
                _ => string.Empty
            };
        }
    }
}