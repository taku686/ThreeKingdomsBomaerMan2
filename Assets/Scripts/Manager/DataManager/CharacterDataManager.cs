using System;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Cysharp.Threading.Tasks;
using PlayFab.ClientModels;
using Zenject;

namespace Manager.DataManager
{
    public class CharacterDataManager : IDisposable
    {
        [Inject] private MainManager _mainManager;
        [Inject] private PlayFabCatalogManager _playFabCatalogManager;
        private UserDataManager _userDataManager;

        private static readonly Dictionary<int, CharacterData> CharacterDatum = new();

        /*private readonly Dictionary<int, Sprite> _characterSpriteDictionary = new();

        private readonly Dictionary<int, Sprite> _characterColorDictionary = new();*/

        private CatalogItem _catalogItem;

        public CatalogItem CatalogItem => _catalogItem;

        public async UniTask Initialize(UserDataManager userDataManager, CancellationToken cancellationToken)
        {
            if (_mainManager.isInitialize)
            {
                return;
            }

            _userDataManager = userDataManager;
            // InitializeCharacterData();
            /*await InitializeCharacterSprite(cancellationToken);
            await InitializeCharacterColor(cancellationToken);*/
        }


        /*private void InitializeCharacterData()
        {
            for (int i = 0; i < GetCharacterCount(); i++)
            {
                var characterData = _playFabCatalogManager.GetCharacterData(i);

                CharacterDatum[i] = characterData;
            }
        }*/

        /*private async UniTask InitializeCharacterSprite(CancellationToken cancellationToken)
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
        }*/

        public void SetCharacterData(CharacterData characterData)
        {
            CharacterDatum[characterData.ID] = characterData;
        }

        public CharacterData GetCharacterData(int id)
        {
            return CharacterDatum[id];
        }

        /*public Sprite GetCharacterSprite(int id)
        {
            return _characterSpriteDictionary[id];
        }

        public Sprite GetCharacterColor(int id)
        {
            return _characterColorDictionary[id];
        }*/

        public int GetCharacterCount()
        {
            return CharacterDatum.Count;
        }

        public CharacterData GetUserEquipCharacterData()
        {
            return GetCharacterData(_userDataManager.equipCharacterId.Value);
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