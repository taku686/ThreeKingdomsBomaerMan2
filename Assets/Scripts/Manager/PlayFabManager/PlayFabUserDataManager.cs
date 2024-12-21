using System;
using System.Collections.Generic;
using Common.Data;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

namespace Manager.NetworkManager
{
    public class PlayFabUserDataManager : IDisposable
    {
        [Inject] private UserDataRepository _userDataRepository;

        /// <summary>
        /// playerデータの更新
        /// </summary>
        public async UniTask<bool> TryUpdateUserDataAsync(UserData value)
        {
            var userJson = JsonConvert.SerializeObject(value);
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    {
                        GameCommonData.UserKey, userJson
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

        public async UniTask<UserData> GetPlayerData(string key)
        {
            var request = new GetUserDataRequest
            {
                PlayFabId = GameCommonData.TitleID,
                Keys = new List<string> { key }
            };

            var response = await PlayFabClientAPI.GetUserDataAsync(request);
            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
                return null;
            }

            var value = response.Result.Data[key].Value;
            var user = JsonConvert.DeserializeObject<UserData>(value);
            if (user == null)
            {
                return null;
            }

            _userDataRepository.SetUserData(user);
            return user;
        }

        public async UniTask DeletePlayerDataAsync()
        {
            var request = new UpdateUserDataRequest()
            {
                KeysToRemove = new List<string> { GameCommonData.UserKey }
            };

            var response = await PlayFabClientAPI.UpdateUserDataAsync(request);

            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
            }
        }

        public async UniTask<(bool, string)> UpdateUserDisplayNameAsync(string playerName)
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
                        return (false, "名前は3~15文字以内で入力して下さい。");
                    case PlayFabErrorCode.ProfaneDisplayName:
                        return (false, "この名前は使用できません。");
                    default:
                        return (false, "この名前は使用できません。");
                }
            }

            return (true, string.Empty);
        }

        public void Dispose()
        {
        }
    }
}