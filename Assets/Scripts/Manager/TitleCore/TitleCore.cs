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
using Manager.DataManager;

namespace UI.Title
{
    public partial class TitleBase : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private UIAnimation _uiAnimation;
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MainManager _mainManager;
        [Inject] private PlayFabLoginManager _playFabLoginManager;
        [Inject] private UserDataManager _userDataManager;
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
        private StateMachine<TitleBase> _stateMachine;
        private CancellationToken _token;
        private int _currentCharacterId;
      

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
         
        }

        private void InitializeState()
        {
            _stateMachine = new StateMachine<Title.TitleBase>(this);
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
            _userDataManager.equipCharacterId.Value = id;
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