using System;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Common.ResourceManager
{
    public class PlayFabCatalogManager : IDisposable
    {
        [Inject] private readonly CatalogDataManager catalogDataManager;
        private readonly CancellationTokenSource cancellationTokenSource = new();
        private static readonly int ModifiedValue = 10;

        public async UniTask Initialize()
        {
            var catalogItems = await GetCatalogItems();
            foreach (var item in catalogItems)
            {
                if (item.ItemClass == GameCommonData.CharacterClassKey)
                {
                    SetCharacterData(item);
                }

                if (item.ItemClass == GameCommonData.ConsumableClassKey)
                {
                    SetAddVirtualCurrencyItemData(item);
                }

                if (item.ItemClass == GameCommonData.LoginBonusClassKey)
                {
                    SetLoginBonusItemData(item);
                }
            }
        }

        private async UniTask<List<CatalogItem>> GetCatalogItems()
        {
            var response = await PlayFabClientAPI.GetCatalogItemsAsync(new GetCatalogItemsRequest());
            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
                return null;
            }

            var catalogItemList = response.Result.Catalog;
            catalogDataManager.SetCatalogItemList(catalogItemList);
            return catalogItemList;
        }

        private void SetCharacterData(CatalogItem item)
        {
            var customData = JsonConvert.DeserializeObject<CharacterData>(item.CustomData);
            if (customData == null)
            {
                return;
            }

            var characterData = new CharacterData
            {
                CharaObj = customData.CharaObj,
                Team = customData.Team,
                Level = customData.Level,
                Name = customData.Name,
                Id = customData.Id,
                Speed = customData.Speed,
                BombLimit = customData.BombLimit / ModifiedValue,
                Attack = customData.Attack,
                FireRange = customData.FireRange / ModifiedValue,
                Hp = customData.Hp,
                CharaColor = customData.CharaColor
            };
            catalogDataManager.SetCharacter(customData.Id, characterData);
        }

        private void SetAddVirtualCurrencyItemData(CatalogItem item)
        {
            if (item.CustomData == null)
            {
                return;
            }

            var customData = JsonConvert.DeserializeObject<AddVirtualCurrencyItemData>(item.CustomData);
            if (customData == null)
            {
                return;
            }

            var addVirtualCurrencyItemData = new AddVirtualCurrencyItemData()
            {
                vc = customData.vc,
                price = customData.price,
                Name = item.ItemId
            };
            catalogDataManager.SetAddVirtualCurrencyData(addVirtualCurrencyItemData);
        }

        private void SetLoginBonusItemData(CatalogItem item)
        {
            if (item.CustomData == null)
            {
                return;
            }

            var customData = JsonConvert.DeserializeObject<AddVirtualCurrencyItemData>(item.CustomData);
            if (customData == null)
            {
                return;
            }

            var addVirtualCurrencyItemData = new AddVirtualCurrencyItemData()
            {
                vc = customData.vc,
                price = customData.price,
                Name = item.ItemId
            };
            catalogDataManager.SetLoginBonusItemData(addVirtualCurrencyItemData);
        }

        public void Dispose()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            catalogDataManager.Dispose();
        }
    }
}