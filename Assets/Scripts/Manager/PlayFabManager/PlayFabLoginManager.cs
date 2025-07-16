using System;
using System.Threading;
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
using Repository;
using UI.TitleCore.LoginBonusState;
using Zenject;

namespace Assets.Scripts.Common.PlayFab
{
    public class PlayFabLoginManager : IDisposable
    {
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private PlayFabCatalogManager _playFabCatalogManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private PlayFabShopManager _playFabShopManager;
        [Inject] private PlayFabTitleDataManager _playFabTitleDataManager;
        [Inject] private MissionManager _missionManager;
        [Inject] private Manager.ResourceManager.ResourceManager _resourceManager;
        [Inject] private MissionSpriteDataRepository _missionSpriteDataRepository;
        [Inject] private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
        [Inject] private LoginBonusFacade _loginBonusFacade;

        private CancellationTokenSource _cts;
        private GetPlayerCombinedInfoRequestParams _info;
        private bool _haveLoginBonus;

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
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

        public async UniTask<(PlayFabResult<LoginResult>, string)> Login(string userName = "")
        {
            var request = new LoginWithAndroidDeviceIDRequest
            {
                CreateAccount = true,
                InfoRequestParameters = _info,
                AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            };
            return (await PlayFabClientAPI.LoginWithAndroidDeviceIDAsync(request), userName);
        }
        
        public async UniTask<bool> InitializeGameData(PlayFabResult<LoginResult> response)
        {
            await _playFabTitleDataManager.SetTitleData(response.Result.InfoResultPayload.TitleData);
            await _playFabCatalogManager.Initialize();
            await _userDataRepository.AddMissionData();
            if (!response.Result.InfoResultPayload.UserData.TryGetValue(GameCommonData.UserKey, value: out var value))
            {
                return false;
            }

            var user = JsonConvert.DeserializeObject<UserData>(value.Value);
            if (user == null) return false;
            var userName = response.Result.InfoResultPayload.AccountInfo.TitleInfo.DisplayName;
            var userIcon = await _resourceManager.LoadUserIconSprite(user.UserIconFileName);
            await _playFabUserDataManager.TryUpdateUserDataAsync(user);
            _userDataRepository.Initialize(user, userName, userIcon);
            _loginBonusFacade.LoadState();
            _missionManager.Initialize();
            await _userDataRepository.AddMissionData();
            return true;
        }

        public async UniTask<PlayFabResult<LoginResult>> CreateUserData((PlayFabResult<LoginResult>, string) tuple)
        {
            var userData = new UserData().Create();
            var userName = tuple.Item2;
            var userIcon = await _resourceManager.LoadUserIconSprite(userData.UserIconFileName);
            _userDataRepository.Initialize(userData, userName, userIcon);
            _loginBonusFacade.LoadState();
            await _playFabVirtualCurrencyManager.GetCoin();
            await _playFabVirtualCurrencyManager.GetGem();
            await _playFabUserDataManager.TryUpdateUserDataAsync(userData).AttachExternalCancellation(_cts.Token);
            return tuple.Item1;
        }

        public void Dispose()
        {
            _userDataRepository?.Dispose();
            _characterMasterDataRepository?.Dispose();
            _playFabCatalogManager?.Dispose();
            _playFabUserDataManager?.Dispose();
            _playFabShopManager?.Dispose();
            _playFabTitleDataManager?.Dispose();
            _missionManager?.Dispose();
            _resourceManager?.Dispose();
            _missionSpriteDataRepository?.Dispose();
            _playFabVirtualCurrencyManager?.Dispose();
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}