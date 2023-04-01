using System;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using Manager.NetworkManager;
using Manager.PlayFabManager;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Newtonsoft.Json;
using Photon.Pun;
using UI.Title.LoginState;
using Zenject;

namespace Assets.Scripts.Common.PlayFab
{
    public class PlayFabLoginManager : MonoBehaviour
    {
        private const int DefaultCharacterIndex = 0;
        private const int OneDay = 1;
        [Inject] private UserDataManager _userDataManager;
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private PlayFabCatalogManager _playFabCatalogManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private PlayFabShopManager _playFabShopManager;
        [Inject] private PlayFabTitleDataManager _playFabTitleDataManager;
        [Inject] private MissionManager _missionManager;
        private GetPlayerCombinedInfoRequestParams _info;
        private DisplayNameView _displayNameView;
        private GameObject _errorGameObject;
        private PlayFabResult<LoginResult> _loginResponse;
        public bool haveLoginBonus;


        public void Initialize(DisplayNameView displayNameView, GameObject errorGameObject)
        {
            _playFabTitleDataManager.Initialize();
            _displayNameView = displayNameView;
            _errorGameObject = errorGameObject;
            PlayFabSettings.staticSettings.TitleId = GameCommonData.TitleID;
            _info = new GetPlayerCombinedInfoRequestParams()
            {
                GetUserData = true,
                GetUserAccountInfo = true,
                GetTitleData = true,
                GetUserVirtualCurrency = true,
                GetUserInventory = true,
                GetPlayerProfile = true
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

            return await SetData(response).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
        }


        private async UniTask<bool> SetData(PlayFabResult<LoginResult> response)
        {
            await _playFabCatalogManager.Initialize();
            await _playFabShopManager.InitializePurchasing();
            await _playFabTitleDataManager.SetTitleData(response.Result.InfoResultPayload.TitleData);
            if (!response.Result.InfoResultPayload.UserData.TryGetValue(GameCommonData.UserKey,
                    out UserDataRecord userData))
            {
                _loginResponse = response;
                _displayNameView.gameObject.SetActive(true);
                return false;
            }

            var user = JsonConvert.DeserializeObject<UserData>(response.Result.InfoResultPayload
                .UserData[GameCommonData.UserKey].Value);
            var virtualCurrency = response.Result.InfoResultPayload.UserVirtualCurrency;


            if (user != null)
            {
                user.Coin = virtualCurrency[GameCommonData.CoinKey];
                user.Gem = virtualCurrency[GameCommonData.GemKey];
                await _userDataManager.Initialize(user);
                _missionManager.Initialize();
                if (response.Result.LastLoginTime != null)
                {
                    await SetLoginBonus(response.Result.LastLoginTime.Value);
                }

                return true;
            }

            return false;
        }

        public async UniTask<bool> CreateUserData()
        {
            var characterData = _characterDataManager.GetCharacterData(DefaultCharacterIndex);
            var userData = new UserData().Create(characterData);
            var virtualCurrency = _loginResponse.Result.InfoResultPayload.UserVirtualCurrency;
            userData.Coin = virtualCurrency[GameCommonData.CoinKey];
            userData.Gem = virtualCurrency[GameCommonData.GemKey];
            var isSuccess = await _playFabUserDataManager.TryUpdateUserDataAsync(userData)
                .AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            if (!isSuccess)
            {
                Debug.LogError("ユーザーデータの更新に失敗しました");
                return false;
            }

            return await Login().AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
        }

        private async UniTask SetLoginBonus(DateTime lastLoginDate)
        {
            var daySubtraction = DateTime.Today - lastLoginDate.Date;
            var dayOfWeek = DateTime.Today.DayOfWeek;
            haveLoginBonus = daySubtraction.Days >= OneDay;
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                await _userDataManager.ResetLoginBonus();
            }

            if (!haveLoginBonus)
            {
                return;
            }

            await _userDataManager.SetLoginBonus((int)dayOfWeek, LoginBonusStatus.CanReceive);
        }
    }
}