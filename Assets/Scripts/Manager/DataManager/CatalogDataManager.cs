using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PlayFab.ClientModels;

namespace Assets.Scripts.Common.Data
{
    public class CatalogDataManager : IDisposable
    {
        private readonly Dictionary<int, CharacterData> characters = new();
        private readonly List<AddVirtualCurrencyItemData> addVirtualCurrencyItemDatum = new();
        private readonly List<AddVirtualCurrencyItemData> loginBonusItemDatum = new();
        private List<CatalogItem> catalogItemList;

        public void SetCharacter(int index, CharacterData data)
        {
            characters[index] = data;
        }

        public void SetAddVirtualCurrencyData(AddVirtualCurrencyItemData data)
        {
            addVirtualCurrencyItemDatum.Add(data);
        }

        public void SetLoginBonusItemData(AddVirtualCurrencyItemData data)
        {
            loginBonusItemDatum.Add(data);
        }

        public void SetCatalogItemList(List<CatalogItem> itemList)
        {
            catalogItemList = itemList;
        }

        public List<CatalogItem> GetCatalogItems()
        {
            return catalogItemList;
        }

        public List<AddVirtualCurrencyItemData> GetAddVirtualCurrencyItemDatum()
        {
            return addVirtualCurrencyItemDatum;
        }
        
        public AddVirtualCurrencyItemData GetAddVirtualCurrencyItemData(string itemId)
        {
            return loginBonusItemDatum.FirstOrDefault(x => x.Name == itemId);
        }

        public void Dispose()
        {
            characters.Clear();
        }
    }
}