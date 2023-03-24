using System;
using System.Collections.Generic;
using Common.Data;
using PlayFab.ClientModels;

namespace Assets.Scripts.Common.Data
{
    public class CatalogDataManager : IDisposable
    {
        private readonly Dictionary<int, CharacterData> _characters = new();
        private readonly List<AddVirtualCurrencyItemData> _addVirtualCurrencyItemDatum = new();
        private List<CatalogItem> _catalogItemList;

        public void SetCharacter(int index, CharacterData data)
        {
            _characters[index] = data;
        }

        public void SetAddVirtualCurrencyData(AddVirtualCurrencyItemData data)
        {
            _addVirtualCurrencyItemDatum.Add(data);
        }

        public void SetCatalogItemList(List<CatalogItem> itemList)
        {
            _catalogItemList = itemList;
        }

        public List<CatalogItem> GetCatalogItems()
        {
            return _catalogItemList;
        }

        public List<AddVirtualCurrencyItemData> GetAddVirtualCurrencyItemDatum()
        {
            return _addVirtualCurrencyItemDatum;
        }

        public CharacterData GetCharacterData(int index)
        {
            return _characters[index];
        }

        public void Dispose()
        {
            _characters.Clear();
        }
    }
}