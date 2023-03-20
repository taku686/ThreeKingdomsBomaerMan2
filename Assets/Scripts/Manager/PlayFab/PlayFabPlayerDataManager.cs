using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PlayFabPlayerDataManager : IDisposable
    {
        [Inject] private UserManager _userManager;

        /// <summary>
        /// playerデータの更新
        /// </summary>
        public async UniTask<bool> TryUpdateUserDataAsync(string key, User value)
        {
            var userJson = JsonConvert.SerializeObject(value);
            var request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>
                {
                    {
                        key, userJson
                    }
                }
            };

            var response = await PlayFabClientAPI.UpdateUserDataAsync(request);

            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
                return false;
            }
            
            return true;
        }

        public async UniTask<User> GetPlayerData(string key)
        {
            var request = new GetUserDataRequest
            {
                PlayFabId = GameSettingData.TitleID,
                Keys = new List<string> { key }
            };

            var response = await PlayFabClientAPI.GetUserDataAsync(request);
            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
                return null;
            }
            else
            {
                var value = response.Result.Data[key].Value;
                var user = JsonConvert.DeserializeObject<User>(value);
                if (user == null)
                {
                    return null;
                }

                _userManager.SetUser(user);
                return user;
            }
        }

        public async UniTask DeletePlayerDataAsync()
        {
            var request = new UpdateUserDataRequest()
            {
                KeysToRemove = new List<string> { GameSettingData.UserKey }
            };

            var response = await PlayFabClientAPI.UpdateUserDataAsync(request);

            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
            }
        }

        public async UniTask UpdateUserDisplayName(string playerName)
        {
            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = playerName
            };

            var response = await PlayFabClientAPI.UpdateUserTitleDisplayNameAsync(request);
            if (response.Error != null)
            {
                switch (response.Error.Error)
                {
                    case PlayFabErrorCode.InvalidParams:
                        Debug.Log("名前は3~25文字以内で入力してください。");
                        break;
                    case PlayFabErrorCode.ProfaneDisplayName:
                        Debug.Log("この名前は使用できません。");
                        break;
                    default:
                        Debug.Log(response.Error.GenerateErrorReport());
                        break;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}