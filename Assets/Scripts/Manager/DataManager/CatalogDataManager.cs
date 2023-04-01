using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PlayFab.ClientModels;

namespace Assets.Scripts.Common.Data
{
    public class CatalogDataManager : IDisposable
    {
        private readonly Dictionary<int, CharacterData> _characters = new();
        private readonly List<AddVirtualCurrencyItemData> _addVirtualCurrencyItemDatum = new();
        private readonly List<AddVirtualCurrencyItemData> _loginBonusItemDatum = new();
        private List<CatalogItem> _catalogItemList;

        public void SetCharacter(int index, CharacterData data)
        {
            _characters[index] = data;
        }

        public void SetAddVirtualCurrencyData(AddVirtualCurrencyItemData data)
        {
            _addVirtualCurrencyItemDatum.Add(data);
        }

        public void SetLoginBonusItemData(AddVirtualCurrencyItemData data)
        {
            _loginBonusItemDatum.Add(data);
        }

        public void SetCatalogItemList(List<CatalogItem> itemList)
        {
            _catalogItemList = itemList;
        }

        public List<CatalogItem> GetCatalogItems()
        {
            return _catalogItemList;
        }

        public CatalogItem GetCatalogItem(string itemId)
        {
            return _catalogItemList.FirstOrDefault(x => x.ItemId == itemId);
        }

        public List<AddVirtualCurrencyItemData> GetAddVirtualCurrencyItemDatum()
        {
            return _addVirtualCurrencyItemDatum;
        }

        public CharacterData GetCharacterData(int index)
        {
            return _characters[index];
        }

        public AddVirtualCurrencyItemData GetAddVirtualCurrencyItemData(string itemId)
        {
            return _loginBonusItemDatum.FirstOrDefault(x => x.Name == itemId);
        }

        public void Dispose()
        {
            _characters.Clear();
        }
    }
}