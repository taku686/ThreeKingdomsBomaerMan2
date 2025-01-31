using System;
using Cysharp.Threading.Tasks;
using UniRx;
using Unity.Entities;
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
        private Func<UniTask> _onClickButtonAnimation;

        public IObservable<(int, Sprite)> _OnClickPurchaseButton =>
            purchaseButton
                .OnClickAsObservable()
                .SelectMany(_ => _onClickButtonAnimation().ToObservable())
                .Select(_ => (_characterId, _characterSprite));

        public void ApplyView(int characterId, Sprite characterSprite, Func<UniTask> function)
        {
            _characterId = characterId;
            _characterSprite = characterSprite;
            characterImage.sprite = characterSprite;
            _onClickButtonAnimation = function;
        }
    }
}