using System;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace UI.Title
{
    public class CharacterDataManager : IDisposable
    {
        [Inject] private MainManager _mainManager;
        [Inject] private PlayFabCatalogManager _playFabCatalogManager;
        private UserManager _userManager;

        private static readonly Dictionary<int, CharacterData> CharacterDataDictionary = new();

        private readonly Dictionary<int, Sprite> _characterSpriteDictionary = new();

        private readonly Dictionary<int, Sprite> _characterColorDictionary = new();

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
            await InitializeCharacterColor(cancellationToken);
        }


        private void InitializeCharacterData()
        {
            for (int i = 0; i < GetCharacterCount(); i++)
            {
                var characterData = _playFabCatalogManager.GetCharacterData(i);
                
                CharacterDataDictionary[i] = characterData;
            }
        }

        private async UniTask InitializeCharacterSprite(CancellationToken cancellationToken)
        {
            for (int i = 0; i < GetCharacterCount(); i++)
            {
                var characterSprite = await _playFabCatalogManager.LoadCharacterSprite(i, cancellationToken);
                _characterSpriteDictionary[i] = characterSprite;
            }
        }

        private async UniTask InitializeCharacterColor(CancellationToken cancellationToken)
        {
            for (int i = 0; i < GetCharacterColorCount(); i++)
            {
                var characterSprite = await _playFabCatalogManager.LoadCharacterColor(i, cancellationToken);
                _characterColorDictionary[i] = characterSprite;
            }
        }

        public CharacterData GetCharacterData(int id)
        {
            return CharacterDataDictionary[id];
        }

        public Sprite GetCharacterSprite(int id)
        {
            return _characterSpriteDictionary[id];
        }

        public Sprite GetCharacterColor(int id)
        {
            return _characterColorDictionary[id];
        }

        public GameObject GetCharacterGameObject(int id)
        {
            return _playFabCatalogManager.CharacterGameObjects[id];
        }

        public int GetCharacterCount()
        {
            return _playFabCatalogManager.CharacterGameObjects.Count;
        }

        public CharacterData GetUserEquipCharacterData()
        {
            return GetCharacterData(_userManager.equipCharacterId.Value);
        }

        private int GetCharacterColorCount()
        {
            return Enum.GetValues(typeof(CharacterColor)).Length;
        }


        public void Dispose()
        {
        }
    }
}