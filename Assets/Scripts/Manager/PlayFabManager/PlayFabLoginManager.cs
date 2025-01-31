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
using UniRx;
using Zenject;

namespace Assets.Scripts.Common.PlayFab
{
    public class PlayFabLoginManager : MonoBehaviour
    {
        private const int OneDay = 1;
        private const int TimeDifference = 9;
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private PlayFabCatalogManager _playFabCatalogManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private PlayFabShopManager _playFabShopManager;
        [Inject] private PlayFabTitleDataManager _playFabTitleDataManager;
        [Inject] private MissionManager _missionManager;

        private GetPlayerCombinedInfoRequestParams _info;
        public bool _haveLoginBonus;


        public void Initialize()
        {
            _playFabTitleDataManager.Initialize();
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

        public async UniTask<PlayFabResult<LoginResult>> Login()
        {
            var request = new LoginWithAndroidDeviceIDRequest
            {
                CreateAccount = true,
                InfoRequestParameters = _info,
                AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            };
            return await PlayFabClientAPI.LoginWithAndroidDeviceIDAsync(request);
        }


        public async UniTask<bool> InitializeGameData(PlayFabResult<LoginResult> response)
        {
            await _playFabCatalogManager.Initialize();
            await _playFabShopManager.InitializePurchasing();
            await _playFabTitleDataManager.SetTitleData(response.Result.InfoResultPayload.TitleData);
            if (!response.Result.InfoResultPayload.UserData.TryGetValue(GameCommonData.UserKey, value: out var value))
            {
                return false;
            }

            var user = JsonConvert.DeserializeObject<UserData>(value.Value);
            if (user == null) return false;
            await _playFabUserDataManager.TryUpdateUserDataAsync(user);
            await _userDataRepository.Initialize(user);
            _missionManager.Initialize();
            return true;
        }

        public async UniTask<PlayFabResult<LoginResult>> CreateUserData(PlayFabResult<LoginResult> loginResult)
        {
            var userData = new UserData().Create();
            _userDataRepository.SetUserData(userData);
            await _playFabUserDataManager.TryUpdateUserDataAsync(userData).AttachExternalCancellation(this.GetCancellationTokenOnDestroy());
            return loginResult;
        }

        private async UniTask SetLoginBonus(DateTime lastLoginDate)
        {
            var daySubtraction = DateTime.Today - lastLoginDate.Date;
            var dayOfWeek = DateTime.Today.DayOfWeek;
            _haveLoginBonus = daySubtraction.Days >= OneDay;
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                await _userDataRepository.ResetLoginBonus();
            }

            if (!_haveLoginBonus)
            {
                return;
            }

            await _userDataRepository.SetLoginBonus((int)dayOfWeek, LoginBonusStatus.CanReceive);
        }

        private async UniTask<bool> HaveLoginBonus(LoginResult loginResult)
        {
            var loginDateTime = loginResult.InfoResultPayload.AccountInfo.TitleInfo.LastLogin;
            var lastLoginDateTime = loginResult.LastLoginTime;
            if (loginDateTime == null || lastLoginDateTime == null)
            {
                return false;
            }

            var loginDate = (loginDateTime + TimeSpan.FromHours(TimeDifference))?.Date;
            var lastLoginDate = (lastLoginDateTime + TimeSpan.FromHours(TimeDifference))?.Date;
            if (loginDate == lastLoginDate) return true;
            var result = await _playFabShopManager.TryPurchaseItem(GameCommonData.LoginBonusNotificationItemKey,
                GameCommonData.CoinKey, 0, null);
            return result;
        }
    }
}