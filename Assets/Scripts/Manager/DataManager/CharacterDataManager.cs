using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using PlayFab.ClientModels;
using Zenject;

namespace Manager.DataManager
{
    public class CharacterDataManager : IDisposable
    {
        [Inject] private MainManager _mainManager;
        private UserDataManager _userDataManager;

        private static readonly Dictionary<int, CharacterData> CharacterDatum = new();

        private CatalogItem _catalogItem;

        public CatalogItem CatalogItem => _catalogItem;

        public void Initialize(UserDataManager userDataManager, CancellationToken cancellationToken)
        {
            if (_mainManager.isInitialize)
            {
                return;
            }

            _userDataManager = userDataManager;
        }


        public void SetCharacterData(CharacterData characterData)
        {
            CharacterDatum[characterData.ID] = characterData;
        }

        public CharacterData GetCharacterData(int id)
        {
            return CharacterDatum[id];
        }

        public int GetCharacterCount()
        {
            return CharacterDatum.Count;
        }

        public CharacterData GetUserEquipCharacterData()
        {
            return GetCharacterData(_userDataManager.GetUserData().EquipCharacterId);
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