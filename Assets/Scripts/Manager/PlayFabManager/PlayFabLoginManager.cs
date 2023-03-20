using System;
using System.Runtime.Remoting.Messaging;
using Assets.Scripts.Common.ResourceManager;
using Common;
using Common.Data;
using Cysharp.Threading.Tasks;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Manager.NetworkManager;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Newtonsoft.Json;
using UI.Title;
using UI.Title.LoginState;
using WebSocketSharp;
using Zenject;

namespace Assets.Scripts.Common.PlayFab
{
    public class PlayFabLoginManager : MonoBehaviour
    {
        [Inject] private UserDataManager _userDataManager;
        [Inject] private PlayFabCatalogManager _playFabCatalogManager;
        [Inject] private PlayFabPlayerDataManager _playFabPlayerDataManager;
        [Inject] private PlayFabShopManager _playFabShopManager;
        private GetPlayerCombinedInfoRequestParams _info;
        private DisplayNameView _displayNameView;
        private GameObject _errorGameObject;
        private PlayFabResult<LoginResult> _loginResponse;

        public void Initialize(DisplayNameView displayNameView, GameObject errorGameObject)
        {
            _displayNameView = displayNameView;
            _errorGameObject = errorGameObject;
            PlayFabSettings.staticSettings.TitleId = GameCommonData.TitleID;
            _info = new GetPlayerCombinedInfoRequestParams()
            {
                GetUserData = true,
                GetUserAccountInfo = true,
                GetTitleData = true,
                GetUserVirtualCurrency = true,
                GetUserInventory = true
            };
        }

        public async UniTask<bool> Login()
        {
            var request = new LoginWithAndroidDeviceIDRequest()
            {
                CreateAccount = true,
                InfoRequestParameters = _info,
                AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            };
            var response = await PlayFabClientAPI.LoginWithAndroidDeviceIDAsync(request);

            if (response.Error != null)
            {
                Debug.LogError(response.Error.GenerateErrorReport());
                _errorGameObject.SetActive(true);
                return false;
            }

            return await LoginSuccess(response).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
        }


        private async UniTask<bool> LoginSuccess(PlayFabResult<LoginResult> response)
        {
            return await SetData(response).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
        }

        private async UniTask<bool> SetData(PlayFabResult<LoginResult> response)
        {
            var catalogList = await _playFabCatalogManager.GetCatalogItems()
                .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            await _playFabCatalogManager.Initialize(catalogList);
            await _playFabShopManager.InitializePurchasing();
            if (!response.Result.InfoResultPayload.UserData.TryGetValue(GameCommonData.UserKey,
                    out UserDataRecord userData))
            {
                _loginResponse = response;
                _displayNameView.gameObject.SetActive(true);
                return false;
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(response.Result.InfoResultPayload
                    .UserData[GameCommonData.UserKey].Value);
                var virtualCurrency = response.Result.InfoResultPayload.UserVirtualCurrency;

                if (user != null)
                {
                    user.Coin = virtualCurrency[GameCommonData.CoinKey];
                    user.Gem = virtualCurrency[GameCommonData.GemKey];
                    _userDataManager.Initialize(user);
                    return true;
                }

                return false;
            }
        }

        public async UniTask<bool> CreateUserData()
        {
            var characterData = _playFabCatalogManager.GetCharacterData(0);
            var user = new User().Create(characterData);
            var virtualCurrency = _loginResponse.Result.InfoResultPayload.UserVirtualCurrency;
            user.Coin = virtualCurrency[GameCommonData.CoinKey];
            user.Gem = virtualCurrency[GameCommonData.GemKey];
            var isSuccess = await _playFabPlayerDataManager.TryUpdateUserDataAsync(GameCommonData.UserKey, user)
                .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            if (!isSuccess)
            {
                Debug.LogError("ユーザーデータの更新に失敗しました");
                return false;
            }

            return await Login().AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
        }

        public async UniTask<bool> SetDisplayName(string displayName)
        {
            if (displayName.IsNullOrEmpty())
            {
                return false;
            }

            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = displayName
            };
            var response = await PlayFabClientAPI.UpdateUserTitleDisplayNameAsync(request);
            if (response.Error != null)
            {
                switch (response.Error.Error)
                {
                    case PlayFabErrorCode.InvalidParams:
                        Debug.Log("名前の文字数制限エラーです");
                        _displayNameView.ErrorText.text = "名前は3~15文字以内で入力して下さい。";
                        return false;
                    case PlayFabErrorCode.ProfaneDisplayName:
                        Debug.Log("この名前は使用できません");
                        _displayNameView.ErrorText.text = "この名前は使用できません。";
                        return false;
                    default:
                        _displayNameView.ErrorText.text = "この名前は使用できません。";
                        Debug.Log(response.Error.GenerateErrorReport());
                        return false;
                }
            }

            return true;
        }
    }
}