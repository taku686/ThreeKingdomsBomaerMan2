using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Common.Data;
using Assets.Scripts.Common.ResourceManager;
using Common;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.NetworkManager;
using Manager.ResourceManager;
using ModestTree;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UpdateUserDataRequest = PlayFab.ClientModels.UpdateUserDataRequest;
using Newtonsoft.Json;
using UI.Title;
using Zenject;
using Currency = Common.Data.Currency;

namespace Assets.Scripts.Common.PlayFab
{
    public class PlayFabLoginManager : MonoBehaviour
    {
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private UserManager _userManager;
        [Inject] private PlayFabCatalogManager _playFabCatalogManager;
        [Inject] private PlayFabPlayerDataManager _playFabPlayerDataManager;
        private const string Email = "test9@gmail.com";
        private const string Password = "Passw0rd";
        private GetPlayerCombinedInfoRequestParams _info;

        public void Initialize()
        {
            PlayFabSettings.staticSettings.TitleId = GameSettingData.TitleID;
            _info = new GetPlayerCombinedInfoRequestParams()
            {
                GetUserData = true,
                GetUserAccountInfo = true,
                GetTitleData = true,
                GetUserVirtualCurrency = true,
                GetUserInventory = true
            };
        }

        public async UniTask<bool> LoginWithCustomId()
        {
            var request = new LoginWithCustomIDRequest
            {
                CustomId = PlayerPrefsManager.UserID,
                InfoRequestParameters = _info,
                CreateAccount = true
            };

            var response = await PlayFabClientAPI.LoginWithCustomIDAsync(request);
            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
                return false;
            }

            await LoginSuccess(response).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            return true;
        }

        public async UniTask<bool> LoginWithEmail(string email, string password)
        {
            var request = new LoginWithEmailAddressRequest
            {
                Email = email,
                Password = password,
                InfoRequestParameters = _info
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
                await LoginSuccess(response).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
                if (PlayerPrefsManager.IsLoginEmailAddress)
                {
                    PlayerPrefsManager.UserID = response.Result.InfoResultPayload.AccountInfo.CustomIdInfo.CustomId;
                }
            }

            return response.Error == null;
        }


        private async UniTask LoginSuccess(PlayFabResult<LoginResult> response)
        {
            await SetData(response).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
        }

        private async UniTask SetData(PlayFabResult<LoginResult> response)
        {
            await GetCatalogItems().AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            if (!response.Result.InfoResultPayload.UserData.TryGetValue(GameSettingData.UserKey,
                    out UserDataRecord userData))
            {
                var characterData = _playFabCatalogManager.GetCharacterData(0);
                var user = new User().Create(characterData);
                var virtualCurrency = response.Result.InfoResultPayload.UserVirtualCurrency;
                user.Coin = virtualCurrency[GameSettingData.CoinKey];
                user.Gem = virtualCurrency[GameSettingData.GemKey];
                var isSuccess = await _playFabPlayerDataManager.TryUpdateUserDataAsync(GameSettingData.UserKey, user)
                    .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
                if (!isSuccess)
                {
                    Debug.LogError("ユーザーデータの更新に失敗しました");
                }

                //再度ユーザーデータ取得
                if (!PlayerPrefsManager.IsLoginEmailAddress)
                {
                    await LoginWithCustomId().AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
                }
                else
                {
                    await LoginWithEmail(Email, Password)
                        .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
                }
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(response.Result.InfoResultPayload
                    .UserData[GameSettingData.UserKey].Value);
                var virtualCurrency = response.Result.InfoResultPayload.UserVirtualCurrency;

                if (user != null)
                {
                    user.Coin = virtualCurrency[GameSettingData.CoinKey];
                    user.Gem = virtualCurrency[GameSettingData.GemKey];
                    _userManager.Initialize(user);
                }
            }
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


        private async UniTask GetCatalogItems()
        {
            var response = await PlayFabClientAPI.GetCatalogItemsAsync(new GetCatalogItemsRequest());
            if (response.Error != null)
            {
                Debug.Log(response.Error.GenerateErrorReport());
            }
            else
            {
                await _playFabCatalogManager.Initialize(response.Result.Catalog)
                    .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            }
        }
    }
}