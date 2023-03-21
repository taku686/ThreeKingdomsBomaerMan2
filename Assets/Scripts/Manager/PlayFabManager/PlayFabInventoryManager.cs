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
    public class PlayFabInventoryManager : IDisposable
    {
        [Inject] private UserDataManager _userDataManager;
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private PlayFabPlayerDataManager _playFabPlayerDataManager;

        public async UniTask SetVirtualCurrency()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return;
            }

            var user = _userDataManager.GetUser();
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

            _userDataManager.SetUser(user);
        }

        public async UniTask SetInventoryData()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return;
            }

            var user = _userDataManager.GetUser();
            foreach (var item in result.Result.Inventory)
            {
                if (item.ItemClass.Equals(GameCommonData.CharacterClassKey))
                {
                    var index = int.Parse(item.ItemId);
                    user.Characters.Add(_characterDataManager.GetCharacterData(index).ID);
                }
            }

            _userDataManager.SetUser(user);
            await _playFabPlayerDataManager.TryUpdateUserDataAsync(GameCommonData.UserKey, user);
        }

        public void Dispose()
        {
        }
    }
}