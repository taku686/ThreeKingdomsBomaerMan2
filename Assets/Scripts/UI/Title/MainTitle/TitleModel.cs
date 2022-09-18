using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Manager.ResourceManager;
using UnityEngine;
using Zenject;

namespace UI.Title.MainTitle
{
    public class TitleModel
    {
        [Inject] private ILoadResource _resourceManager;
        [Inject] private DiContainer _container;
        
        private readonly Dictionary<int, CharacterData> _characterDataList =
            new Dictionary<int, CharacterData>();

        private readonly Dictionary<int, Sprite> _characterSpriteList =
            new Dictionary<int, Sprite>();

        private UserData _userData;

        public UserData UserData => _userData;

        public Dictionary<int, Sprite> CharacterSpriteList => _characterSpriteList;

        public Dictionary<int, CharacterData> CharacterDataList => _characterDataList;

        public void Initialize(CancellationToken cancellationToken)
        {
            _container.Bind<ILoadResource>.()
            InitializeCharacterData(cancellationToken);
            InitializeCharacterSprite(cancellationToken);
            InitializeUserData(cancellationToken);
        }

        private async void InitializeCharacterData(CancellationToken cancellationToken)
        {
            for (int i = 0; i < Enum.GetValues(typeof(CharacterName)).Length; i++)
            {
                var characterData = await _resourceManager.LoadCharacterData(i, cancellationToken);
                _characterDataList.Add(i, characterData);
            }
        }

        private async void InitializeCharacterSprite(CancellationToken cancellationToken)
        {
            for (int i = 0; i < Enum.GetValues(typeof(CharacterName)).Length; i++)
            {
                var characterSprite = await _resourceManager.LoadCharacterSprite(i, cancellationToken);
                _characterSpriteList.Add(i, characterSprite);
            }
        }

        private async void InitializeUserData(CancellationToken cancellationToken)
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
    }
}