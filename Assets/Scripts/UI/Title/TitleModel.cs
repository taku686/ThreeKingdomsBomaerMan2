using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.ResourceManager;
using UnityEngine;
using Zenject;

namespace UI.Title
{
    public class TitleModel : ScriptableObject
    {
        [Inject] private ILoadResource _resourceManager;

        private readonly Dictionary<int, CharacterData> _characterDataList =
            new Dictionary<int, CharacterData>();

        private readonly Dictionary<int, Sprite> _characterSpriteList =
            new Dictionary<int, Sprite>();

        private readonly Dictionary<int, Sprite> _characterColorList =
            new Dictionary<int, Sprite>();

        private UserData _userData;

        public UserData UserData => _userData;

        public async UniTask Initialize(CancellationToken cancellationToken)
        {
            await InitializeCharacterData(cancellationToken);
            await InitializeCharacterSprite(cancellationToken);
            await InitializeUserData(cancellationToken);
            await InitializeCharacterColor(cancellationToken);
        }

        private async UniTask InitializeCharacterData(CancellationToken cancellationToken)
        {
            for (int i = 0; i < GetCharacterCount(); i++)
            {
                var characterData = await _resourceManager.LoadCharacterData(i, cancellationToken);
                _characterDataList.Add(i, characterData);
            }
        }

        private async UniTask InitializeCharacterSprite(CancellationToken cancellationToken)
        {
            for (int i = 0; i < GetCharacterCount(); i++)
            {
                var characterSprite = await _resourceManager.LoadCharacterSprite(i, cancellationToken);
                _characterSpriteList.Add(i, characterSprite);
            }
        }

        private async UniTask InitializeCharacterColor(CancellationToken cancellationToken)
        {
            for (int i = 0; i < GetCharacterColorCount(); i++)
            {
                var characterSprite = await _resourceManager.LoadCharacterColor(i, cancellationToken);
                _characterColorList.Add(i, characterSprite);
            }
        }

        private async UniTask InitializeUserData(CancellationToken cancellationToken)
        {
            _userData = await _resourceManager.LoadUserData(cancellationToken);
        }

        public CharacterData GetCharacterData(int id)
        {
            return _characterDataList[id];
        }

        public Sprite GetCharacterSprite(int id)
        {
            return _characterSpriteList[id];
        }

        public Sprite GetCharacterColor(int id)
        {
            return _characterColorList[id];
        }

        public int GetCharacterCount()
        {
            return Enum.GetValues(typeof(CharacterName)).Length;
        }

        private int GetCharacterColorCount()
        {
            return Enum.GetValues(typeof(CharacterColor)).Length;
        }
    }
}