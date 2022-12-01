using System;
using System.Collections.Generic;
using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Manager.NetworkManager
{
    public class PlayFabPlayerDataManager : IDisposable
    {
        /// <summary>
        /// playerデータの更新
        /// </summary>
        public async UniTask UpdateUserDataAsync(string key, User value)
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
            }
        }

        public async UniTask GetPlayerData(string key)
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
            }
            else
            {
                var value = response.Result.Data[key].Value;
                var user = JsonConvert.DeserializeObject<User>(value);
                if (user != null) Debug.Log(user.Level);
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