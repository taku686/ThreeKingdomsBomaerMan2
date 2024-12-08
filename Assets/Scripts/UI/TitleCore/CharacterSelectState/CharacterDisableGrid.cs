using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;


namespace UI.Title
{
    public class CharacterDisableGrid : MonoBehaviour
    {
        public Button purchaseButton;
        public Image characterImage;
        private int _characterId;
        private Sprite _characterSprite;

        public IObservable<(int, Sprite)> _OnClickPurchaseButton =>
            purchaseButton.OnClickAsObservable().Select(_ => (_characterId, _characterSprite));

        public void ApplyView(int characterId, Sprite characterSprite)
        {
            _characterId = characterId;
            _characterSprite = characterSprite;
            characterImage.sprite = characterSprite;
        }
    }
}