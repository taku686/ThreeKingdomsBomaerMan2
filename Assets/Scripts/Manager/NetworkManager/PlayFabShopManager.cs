using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Manager.NetworkManager
{
    public class PlayFabShopManager : IDisposable
    {
        public async UniTask<bool> TryPurchaseItem(string itemName, string virtualCurrencyKey, int price)
        {
            var request = new PurchaseItemRequest()
            {
                ItemId = itemName,
                VirtualCurrency = virtualCurrencyKey,
                Price = price
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return false;
            }

            return true;
        }


        public void Dispose()
        {
        }
    }
}