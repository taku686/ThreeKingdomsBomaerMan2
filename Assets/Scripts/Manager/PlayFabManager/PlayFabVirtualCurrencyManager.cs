using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.PlayFabManager;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;
using JsonObject = PlayFab.Json.JsonObject;

namespace Manager.NetworkManager
{
    public class PlayFabVirtualCurrencyManager : IDisposable
    {
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;

        public async UniTask SetVirtualCurrency()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.LogError(result.Error.GenerateErrorReport());
            }

            var user = _userDataRepository.GetUserData();
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

            _userDataRepository.SetUserData(user);
        }

        public async UniTask<int> GetCoin()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return GameCommonData.NetworkErrorCode;
            }

            foreach (var item in result.Result.VirtualCurrency)
            {
                if (item.Key.Equals(GameCommonData.CoinKey))
                {
                    _userDataRepository.SetCoin(item.Value);
                    return item.Value;
                }
            }

            return GameCommonData.NetworkErrorCode;
        }

        public async UniTask<int> GetGem()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return GameCommonData.NetworkErrorCode;
            }

            foreach (var item in result.Result.VirtualCurrency)
            {
                if (item.Key.Equals(GameCommonData.GemKey))
                {
                    _userDataRepository.SetGem(item.Value);
                    return item.Value;
                }
            }

            return GameCommonData.NetworkErrorCode;
        }

        public async UniTask<int> GetTicket()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return GameCommonData.NetworkErrorCode;
            }

            foreach (var item in result.Result.VirtualCurrency)
            {
                if (item.Key.Equals(GameCommonData.TicketKey))
                {
                    return item.Value;
                }
            }

            return GameCommonData.NetworkErrorCode;
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

        public async UniTask<bool> SubtractVirtualCurrency(string virtualCurrencyKey, int amount)
        {
            var request = new SubtractUserVirtualCurrencyRequest
            {
                Amount = amount,
                VirtualCurrency = virtualCurrencyKey
            };
            var result = await PlayFabClientAPI.SubtractUserVirtualCurrencyAsync(request);

            if (result.Error != null)
            {
                return false;
            }

            await SetVirtualCurrency();
            return true;
        }

        public async UniTask Add1000CoinAsync()
        {
            await PlayFabBaseManager.AzureFunctionAsync("Add1000Coin");
        }

        public async UniTask SetInventoryData()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return;
            }

            var user = _userDataRepository.GetUserData();
            foreach (var item in result.Result.Inventory)
            {
                if (item.ItemClass.Equals(GameCommonData.CharacterClassKey))
                {
                    var index = int.Parse(item.ItemId);
                    user.Characters.Add(_characterMasterDataRepository.GetCharacterData(index).Id);
                }
            }

            _userDataRepository.SetUserData(user);
            await _playFabUserDataManager.TryUpdateUserDataAsync(user);
        }

        public void Dispose()
        {
        }
    }
}