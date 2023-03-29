using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PlayFabVirtualCurrencyManager : IDisposable
    {
        [Inject] private UserDataManager _userDataManager;
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;

        public async UniTask SetVirtualCurrency()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return;
            }

            var user = _userDataManager.GetUserData();
            foreach (var item in result.Result.VirtualCurrency)
            {
                if (item.Key.Equals(GameCommonData.CoinKey))
                {
                    user.Coin = item.Value;
                }

                if (item.Key.Equals(GameCommonData.GemKey))
                {
                    user.Gem = item.Value;
                }
            }

            _userDataManager.SetUserData(user);
        }

        public async UniTask<bool> AddVirtualCurrency(string virtualCurrencyKey, int amount)
        {
            var request = new AddUserVirtualCurrencyRequest
            {
                Amount = amount,
                VirtualCurrency = virtualCurrencyKey
            };
            var result = await PlayFabClientAPI.AddUserVirtualCurrencyAsync(request);

            if (result.Error != null)
            {
                return false;
            }

            await SetVirtualCurrency();
            return true;
        }

        public async UniTask SetInventoryData()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return;
            }

            var user = _userDataManager.GetUserData();
            foreach (var item in result.Result.Inventory)
            {
                if (item.ItemClass.Equals(GameCommonData.CharacterClassKey))
                {
                    var index = int.Parse(item.ItemId);
                    user.Characters.Add(_characterDataManager.GetCharacterData(index).Id);
                }
            }

            _userDataManager.SetUserData(user);
            await _playFabUserDataManager.TryUpdateUserDataAsync(user);
        }

        public void Dispose()
        {
        }
    }
}