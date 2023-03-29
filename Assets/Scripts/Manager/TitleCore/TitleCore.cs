using System;
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
using Manager.DataManager;


namespace UI.Title
{
    public partial class TitleCore : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private CharacterLevelDataManager _characterLevelDataManager;
        [Inject] private UserDataManager _userDataManager;
        [Inject] private UIAnimation _uiAnimation;
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MainManager _mainManager;
        [Inject] private PlayFabLoginManager _playFabLoginManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
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
        [SerializeField] private LoginBonusView loginBonusView;
        private GameObject _character;
        private GameObject _weaponEffect;
        private StateMachine<TitleCore> _stateMachine;
        private CancellationToken _token;


        private enum Event
        {
            Login,
            Main,
            CharacterSelect,
            CharacterDetail,
            Shop,
            ReadyBattle,
            SelectBattleMode,
            SceneTransition,
            Setting,
            LoginBonus
        }


        private void Start()
        {
            _token = this.GetCancellationTokenOnDestroy();
            Initialize();
        }

        private void Update()
        {
            _stateMachine.Update();
        }


        private void Initialize()
        {
            InitializeState();
        }


        private void InitializeState()
        {
            _stateMachine = new StateMachine<TitleCore>(this);
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
            _stateMachine.AddTransition<CharacterDetailState, CharacterSelectState>((int)Event.CharacterSelect);
            _stateMachine.AddTransition<MainState, BattleReadyState>((int)Event.ReadyBattle);
            _stateMachine.AddTransition<BattleReadyState, SceneTransitionState>((int)Event.SceneTransition);
            _stateMachine.AddTransition<LoginState, MainState>((int)Event.Main);
            _stateMachine.AddTransition<MainState, SettingState>((int)Event.Setting);
            _stateMachine.AddTransition<MainState, ShopState>((int)Event.Shop);
            _stateMachine.AddTransition<CharacterDetailState, ShopState>((int)Event.Shop);
            _stateMachine.AddTransition<CharacterSelectState, ShopState>((int)Event.Shop);
            _stateMachine.AddTransition<MainState, LoginBonusState>((int)Event.LoginBonus);
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
            mainView.LoginBonusObjet.SetActive(false);
        }

        private void CreateCharacter(int id)
        {
            _userDataManager.GetUserData().EquipCharacterId = id;
            var preCharacter = _character;
            var preWeaponEffect = _weaponEffect;
            Destroy(preCharacter);
            Destroy(preWeaponEffect);
            var createCharacterData = _characterDataManager.GetCharacterData(id);
            if (createCharacterData.CharacterObject == null || createCharacterData.WeaponEffectObj == null)
            {
                Debug.LogError(id);
            }

            _character = Instantiate(createCharacterData.CharacterObject,
                characterCreatePosition.position,
                characterCreatePosition.rotation, characterCreatePosition);
            var currentCharacterLevel = _userDataManager.GetCurrentLevelData(id);
            if (currentCharacterLevel.Level < GameCommonData.MaxCharacterLevel)
            {
                return;
            }

            var weapons = GameObject.FindGameObjectsWithTag(GameCommonData.WeaponTag);
            foreach (var weapon in weapons)
            {
                var effectObj = Instantiate(createCharacterData.WeaponEffectObj, weapon.transform);
                var particleSystems = effectObj.GetComponentsInChildren<ParticleSystem>();
                foreach (var system in particleSystems)
                {
                    var main = system.main;
                    main.startColor = GameCommonData.GetWeaponColor(id);
                }

                var effect = effectObj.GetComponentInChildren<PSMeshRendererUpdater>();
                effect.Color = GameCommonData.GetWeaponColor(id);
                effect.UpdateMeshEffect(weapon);
            }
        }
    }
}