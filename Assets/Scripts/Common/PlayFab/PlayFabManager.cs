using System.Collections.Generic;
using Assets.Scripts.Common.Data;
using Common;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UpdateUserDataRequest = PlayFab.ClientModels.UpdateUserDataRequest;
using Newtonsoft.Json;
using Zenject;

namespace Assets.Scripts.Common.PlayFab
{
    public class PlayFabManager : MonoBehaviour
    {
        private readonly Catalog _catalog = new();
        private const string Email = "test9@gmail.com";
        private const string Password = "Passw0rd";

        private async UniTaskVoid Start()
        {
            var token = this.GetCancellationTokenOnDestroy();
            Initialize();
            Debug.Log(PlayerPrefsManager.IsLoginEmailAddress);
            if (PlayerPrefsManager.IsLoginEmailAddress)
            {
                await LoginWithEmail(Email, Password).AttachExternalCancellation(token);
            }
            else
            {
                await LoginWithCustomId().AttachExternalCancellation(token);
                await SetEmailAndPassword(Email, Password).AttachExternalCancellation(token);
            }

            await UpdateUserDisplayName("Alan");
            await UpdateUserDataAsync(nameof(User), User.Create()).AttachExternalCancellation(token);
            await GetUserData(nameof(User)).AttachExternalCancellation(token);
            await GetCatalogItems().AttachExternalCancellation(token);
        }

        public void Initialize()
        {
            PlayFabSettings.staticSettings.TitleId = "92AF5";
        }

        public async UniTask LoginWithCustomId()
        {
            var request = new LoginWithCustomIDRequest
            {
                CustomId = PlayerPrefsManager.UserID,
                CreateAccount = true
            };

            var response = await PlayFabClientAPI.LoginWithCustomIDAsync(request);
            var message = response.Error != null
                ? response.Error.GenerateErrorReport()
                : $"Login success!! my PlayFabID is {response.Result.PlayFabId}";
            Debug.Log(message);
        }

        public async UniTask SetEmailAndPassword(string email, string password)
        {
            var request = new AddUsernamePasswordRequest
            {
                Username = PlayerPrefsManager.UserID,
                Email = email,
                Password = password
            };

            var response = await PlayFabClientAPI.AddUsernamePasswordAsync(request);

            if (response.Error != null)
            {
                switch (response.Error.Error)
                {
                    case PlayFabErrorCode.InvalidParams:
                        Debug.Log("有効なメールアドレスと6~100文字以内のパスワードを入力してください。");
                        break;
                    case PlayFabErrorCode.InvalidEmailAddress:
                        Debug.Log("このメールアドレスは使用できません。");
                        break;
                    case PlayFabErrorCode.InvalidPassword:
                        Debug.Log("このパスワードは使用できません。");
                        break;
                    default:
                        Debug.Log(response.Error.GenerateErrorReport());
                        break;
                }
            }
            else
            {
                Debug.Log("登録完了!!");
                PlayerPrefsManager.IsLoginEmailAddress = true;
            }
        }

        public async UniTask LoginWithEmail(string email, string password)
        {
            var request = new LoginWithEmailAddressRequest
            {
                Email = email,
                Password = password,
                InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
                {
                    GetUserAccountInfo = true,
                    GetUserInventory = true
                }
            };
            var response = await PlayFabClientAPI.LoginWithEmailAddressAsync(request);

            if (response.Error != null)
            {
                switch (response.Error.Error)
                {
                    case PlayFabErrorCode.InvalidParams:
                        break;
                    case PlayFabErrorCode.InvalidEmailOrPassword:
                        break;
                    case PlayFabErrorCode.AccountNotFound:
                        Debug.Log("メールアドレスかパスワードが正しくありません。");
                        break;
                    case PlayFabErrorCode.Success:
                        Debug.Log("登録完了!!");
                        break;
                    default:
                        Debug.Log(response.Error.GenerateErrorReport());
                        break;
                }
            }
            else
            {
                Debug.Log($"Login success!! my PlayFabID is {response.Result.PlayFabId}");
                SetupInventory(response.Result.InfoResultPayload.UserInventory);
                if (PlayerPrefsManager.IsLoginEmailAddress)
                {
                    PlayerPrefsManager.UserID = response.Result.InfoResultPayload.AccountInfo.CustomIdInfo.CustomId;
                }
            }
        }

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

        public async UniTask DeletePlayerDataAsync()
        {
            var request = new UpdateUserDataRequest()
            {
                KeysToRemove = new List<string> { "User" }
            };

            var response = await PlayFabClientAPI.UpdateUserDataAsync(request);

            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
            }
        }

        public async UniTask GetUserData(string key)
        {
            var request = new global::PlayFab.ClientModels.GetUserDataRequest
            {
                PlayFabId = PlayFabSettings.staticPlayer.PlayFabId,
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

        public async UniTask GetCatalogItems()
        {
            var response = await PlayFabClientAPI.GetCatalogItemsAsync(new GetCatalogItemsRequest());
            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
            }
            else
            {
                foreach (var item in response.Result.Catalog)
                {
                    _catalog.Characters[int.Parse(item.ItemId)] = item;
                    Debug.Log($"{_catalog.Characters[int.Parse(item.ItemId)].DisplayName}");
                }
            }
        }

        private void SetupInventory(List<ItemInstance> items)
        {
            foreach (var item in items)
            {
                Debug.Log(item.ItemClass);
                if (item.ItemClass == "Character")
                {
                }
            }
        }
    }
}