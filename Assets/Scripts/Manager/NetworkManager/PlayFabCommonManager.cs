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
        [Inject] private UserManager _userManager;
        
        public async UniTask SetVirtualCurrency()
        {
            var result = await PlayFabClientAPI.GetUserInventoryAsync(new GetUserInventoryRequest());
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return;
            }

            var user = _userManager.GetUser();
            foreach (var item in result.Result.VirtualCurrency)
            {
                if (item.Key.Equals(GameSettingData.CoinKey))
                {
                    user.Coin = item.Value;
                }

                if (item.Key.Equals(GameSettingData.GemKey))
                {
                    user.Gem = item.Value;
                }
            }

            _userManager.SetUser(user);
        }
        
        public void Dispose()
        {
        }
    }
}