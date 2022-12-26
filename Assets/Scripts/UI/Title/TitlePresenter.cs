using System.Threading;
using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.NetworkManager;
using Photon.Pun;
using UI.Common;
using UI.Title.ShopState;
using UnityEngine;
using Zenject;
using GoogleMobileAds.Api;

namespace UI.Title
{
    public partial class TitlePresenter : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private UIAnimation _uiAnimation;
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MainManager _mainManager;
        [Inject] private PlayFabLoginManager _playFabLoginManager;
        [Inject] private UserManager _userManager;
        [Inject] private PlayFabPlayerDataManager _playFabPlayerDataManager;
        [Inject] private PlayFabShopManager _playFabShopManager;
        [Inject] private PlayFabAdsManager _playFabAdsManager;
        [SerializeField] private Transform characterCreatePosition;
        [SerializeField] private MainView mainView;
        [SerializeField] private CharacterSelectView characterSelectView;
        [SerializeField] private CharacterDetailView characterDetailView;
        [SerializeField] private BattleReadyView battleReadyView;
        [SerializeField] private SceneTransitionView sceneTransitionView;
        [SerializeField] private LoginView loginView;
        [SerializeField] private SettingView settingView;
        [SerializeField] private ShopView shopView;

        private GameObject _character;
        private StateMachine<TitlePresenter> _stateMachine;
        private CancellationToken _token;
        private int _currentCharacterId;
        private RewardedAd _rewardAd;

        private enum Event
        {
            Login,
            Main,
            CharacterSelect,
            CharacterSelectBack,
            CharacterDetail,
            Shop,
            ReadyBattle,
            SelectBattleMode,
            SceneTransition,
            Setting
        }


        private void Start()
        {
            _token = this.GetCancellationTokenOnDestroy();
            Initialize();
        }


        private void Initialize()
        {
            InitializeState();
            InitializeAds();
        }


        private void InitializeAds()
        {
            _rewardAd = new RewardedAd(GameSettingData.RewardAdsKey);
            AdRequest request = new AdRequest.Builder().Build();
            _rewardAd.LoadAd(request);
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<Title.TitlePresenter>(this);
            if (_mainManager.isInitialize)
            {
                _stateMachine.Start<MainState>();
            }
            else
            {
                _stateMachine.Start<LoginState>();
            }

            _stateMachine.AddAnyTransition<MainState>((int)Event.Main);
            _stateMachine.AddTransition<MainState, CharacterSelectState>((int)Event.CharacterSelect);
            _stateMachine.AddTransition<CharacterSelectState, CharacterDetailState>((int)Event.CharacterDetail);
            _stateMachine.AddTransition<CharacterDetailState, CharacterSelectState>((int)Event.CharacterSelectBack);
            _stateMachine.AddTransition<MainState, BattleReadyState>((int)Event.ReadyBattle);
            _stateMachine.AddTransition<BattleReadyState, SceneTransitionState>((int)Event.SceneTransition);
            _stateMachine.AddTransition<LoginState, MainState>((int)Event.Login);
            _stateMachine.AddTransition<MainState, SettingState>((int)Event.Setting);
            _stateMachine.AddTransition<MainState, ShopState>((int)Event.Shop);
            _stateMachine.AddTransition<CharacterSelectState, ShopState>((int)Event.Shop);
        }


        private void DisableTitleGameObject()
        {
            mainView.MainGameObject.SetActive(false);
            mainView.CharacterListGameObject.SetActive(false);
            mainView.CharacterDetailGameObject.SetActive(false);
            mainView.BattleReadyGameObject.SetActive(false);
            mainView.SceneTransitionGameObject.SetActive(false);
            mainView.LoginGameObject.SetActive(false);
            mainView.SettingGameObject.SetActive(false);
            mainView.ShopGameObject.SetActive(false);
        }

        private void CreateCharacter(int id)
        {
            _userManager.equipCharacterId.Value = id;
            var preCharacter = _character;
            Destroy(preCharacter);
            if (_characterDataManager.GetCharacterGameObject(id) == null)
            {
                Debug.Log(id);
            }

            _character = Instantiate(_characterDataManager.GetCharacterGameObject(id),
                characterCreatePosition.position,
                characterCreatePosition.rotation, characterCreatePosition);
        }
    }
}