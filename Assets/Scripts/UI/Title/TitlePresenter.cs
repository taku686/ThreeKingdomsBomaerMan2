using System.Threading;
using Assets.Scripts.Common.PlayFab;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Manager.NetworkManager;
using Photon.Pun;
using UI.Common;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Title
{
    public partial class TitlePresenter : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataModel _characterDataModel;
        [Inject] private UIAnimation _uiAnimation;
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MainManager _mainManager;
        [Inject] private PlayFabManager _playFabManager;
        [Inject] private UserManager _userManager;
        [SerializeField] private Transform characterCreatePosition;
        [SerializeField] private MainView mainView;
        [SerializeField] private CharacterSelectView characterSelectView;
        [SerializeField] private CharacterDetailView characterDetailView;
        [SerializeField] private BattleReadyView battleReadyView;
        [SerializeField] private SceneTransitionView sceneTransitionView;
        [SerializeField] private LoginView loginView;
        [SerializeField] private SettingView settingView;

        private GameObject _character;
        private StateMachine<Title.TitlePresenter> _stateMachine;
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


        private async void Start()
        {
            _token = this.GetCancellationTokenOnDestroy();
            await Initialize(_token).AttachExternalCancellation(_token);
        }


        private async UniTask Initialize(CancellationToken token)
        {
            InitializeState();
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
        }

        private void CreateCharacter(int id)
        {
            _userManager.equipCharacterId.Value = id;
            var preCharacter = _character;
            Destroy(preCharacter);
            _character = Instantiate(_characterDataModel.GetCharacterGameObject(id),
                characterCreatePosition.position,
                characterCreatePosition.rotation, characterCreatePosition);
        }
    }
}