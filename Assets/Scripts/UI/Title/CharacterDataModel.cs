using System;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.BattleManager;
using Manager.ResourceManager;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace UI.Title
{
    public class CharacterDataModel
    {
        [Inject] private CatalogManager _resourceManager;
        [Inject] private MainManager _mainManager;
        [Inject] private CatalogManager _catalogManager;
        private UserManager _userManager;

        private static readonly Dictionary<int, CharacterData> CharacterDataList =
            new Dictionary<int, CharacterData>();

        private readonly Dictionary<int, Sprite> _characterSpriteList =
            new Dictionary<int, Sprite>();

        private readonly Dictionary<int, Sprite> _characterColorList =
            new Dictionary<int, Sprite>();

        private CatalogItem _catalogItem;

        public CatalogItem CatalogItem => _catalogItem;

        public async UniTask Initialize(UserManager userManager, CancellationToken cancellationToken)
        {
            if (_mainManager.isInitialize)
            {
                return;
            }

            _userManager = userManager;
            InitializeCharacterData();
            await InitializeCharacterSprite(cancellationToken);
            InitializeUserData(cancellationToken);
            await InitializeCharacterColor(cancellationToken);
        }


        private void InitializeCharacterData()
        {
            for (int i = 0; i < GetCharacterCount(); i++)
            {
                var characterData = _resourceManager.LoadCharacterData(i);
                CharacterDataList[i] = characterData;
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

        private void InitializeUserData(CancellationToken cancellationToken)
        {
        }

        public CharacterData GetCharacterData(int id)
        {
            return CharacterDataList[id];
        }

        public Sprite GetCharacterSprite(int id)
        {
            return _characterSpriteList[id];
        }

        public Sprite GetCharacterColor(int id)
        {
            return _characterColorList[id];
        }

        public GameObject GetCharacterGameObject(int id)
        {
            return _catalogManager.CharacterGameObjects[id];
        }

        public int GetCharacterCount()
        {
            return Enum.GetValues(typeof(CharacterName)).Length;
        }

        public CharacterData GetUserEquipCharacterData()
        {
            return GetCharacterData(_userManager.equipCharacterId.Value);
        }

        private int GetCharacterColorCount()
        {
            return Enum.GetValues(typeof(CharacterColor)).Length;
        }
    }
}