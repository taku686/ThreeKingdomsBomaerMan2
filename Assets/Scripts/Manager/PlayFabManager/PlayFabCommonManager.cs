using System;
using Common.Data;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PlayFabCommonManager : IDisposable
    {
        [Inject] private UserDataManager _userDataManager;
        
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
        
        public void Dispose()
        {
        }
    }
}