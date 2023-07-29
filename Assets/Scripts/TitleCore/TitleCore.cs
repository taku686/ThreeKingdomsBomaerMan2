using System;
using System.Collections;
using System.Threading;
using Assets.Scripts.Common.Data;
using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Manager;
using Manager.NetworkManager;
using Photon.Pun;
using UI.Common;
using UI.Title.ShopState;
using UnityEngine;
using Zenject;
using Manager.DataManager;
using UnityEngine.SceneManagement;


namespace UI.Title
{
    public partial class TitleCore : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private CharacterLevelDataManager _characterLevelDataManager;
        [Inject] private UserDataManager _userDataManager;
        [Inject] private MissionDataManager _missionDataManager;
        [Inject] private UIAnimation _uiAnimation;
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MainManager _mainManager;
        [Inject] private PlayFabLoginManager _playFabLoginManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private PlayFabShopManager _playFabShopManager;
        [Inject] private PlayFabAdsManager _playFabAdsManager;
        [Inject] private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
        [Inject] private CatalogDataManager _catalogDataManager;
        [Inject] private MissionManager _missionManager;
        [Inject] private ChatGPTManager _chatGptManager;
        [SerializeField] private Fade fade;
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
        [SerializeField] private MissionView missionView;
        [SerializeField] private CommonView commonView;
        private GameObject _character;
        private GameObject _weaponEffect;
        private StateMachine<TitleCore> _stateMachine;
        private CancellationToken _token;
        [SerializeField] private GameObject[] uiObjects;


        private enum TitleCoreEvent
        {
            Login,
            Main,
            CharacterSelect,
            CharacterDetail,
            Shop,
            ReadyBattle,
            SceneTransition,
            Setting,
            LoginBonus,
            Mission,
            SelectBattleMode,
        }


        private void Start()
        {
            _token = this.GetCancellationTokenOnDestroy();
            Initialize();
        }

        private void Update()
        {
            _stateMachine?.Update();
        }


        private void Initialize()
        {
            fade.InitializeInSceneTransition(1, ProjectCommonData.Instance.isSceneTransition);
            commonView.Initialize();
            InitializeState();
            InitializeButton();
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

            _stateMachine.AddAnyTransition<MainState>((int)TitleCoreEvent.Main);
            _stateMachine.AddAnyTransition<ShopState>((int)TitleCoreEvent.Shop);
            _stateMachine.AddTransition<MainState, CharacterSelectState>((int)TitleCoreEvent.CharacterSelect);
            _stateMachine.AddTransition<CharacterSelectState, CharacterDetailState>(
                (int)TitleCoreEvent.CharacterDetail);
            _stateMachine.AddTransition<CharacterDetailState, CharacterSelectState>(
                (int)TitleCoreEvent.CharacterSelect);
            _stateMachine.AddTransition<MainState, BattleReadyState>((int)TitleCoreEvent.ReadyBattle);
            _stateMachine.AddTransition<BattleReadyState, SceneTransitionState>((int)TitleCoreEvent.SceneTransition);
            _stateMachine.AddTransition<LoginState, MainState>((int)TitleCoreEvent.Main);
            _stateMachine.AddTransition<MainState, SettingState>((int)TitleCoreEvent.Setting);
            _stateMachine.AddTransition<MainState, LoginBonusState>((int)TitleCoreEvent.LoginBonus);
            _stateMachine.AddTransition<MainState, MissionState>((int)TitleCoreEvent.Mission);
        }

        private void InitializeButton()
        {
            var gemAddButton = commonView.virtualCurrencyView.gemAddButton;
            var coinAddButton = commonView.virtualCurrencyView.coinAddButton;
            var ticketAddButton = commonView.virtualCurrencyView.ticketAddButton;
            SetupRewardOkButton();
            gemAddButton.onClick.AddListener(() => { OnClickTransitionShopState(gemAddButton.gameObject); });
            coinAddButton.onClick.AddListener(() => { OnClickTransitionShopState(coinAddButton.gameObject); });
            ticketAddButton.onClick.AddListener(() => { OnClickTransitionShopState(ticketAddButton.gameObject); });
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
            mainView.LoginBonusGameObjet.SetActive(false);
            mainView.MissionGameObject.SetActive(false);
        }

        private bool CreateCharacter(int id)
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
                return false;
            }

            _character = Instantiate(createCharacterData.CharacterObject,
                characterCreatePosition.position,
                characterCreatePosition.rotation, characterCreatePosition);
            var currentCharacterLevel = _userDataManager.GetCurrentLevelData(id);
            if (currentCharacterLevel.Level < GameCommonData.MaxCharacterLevel)
            {
                return true;
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

            return true;
        }

        private void SwitchUiObject(TitleCoreEvent titleCoreEvent, bool isViewVirtualCurrencyUi)
        {
            TransitionAnimation(() =>
            {
                foreach (var ui in uiObjects)
                {
                    ui.SetActive(false);
                }

                //  SoundManager.Instance.PlaySingle(SoundManager.Se.SceneChange);
                commonView.virtualCurrencyView.gameObject.SetActive(isViewVirtualCurrencyUi);
                uiObjects[(int)titleCoreEvent].SetActive(true);
            });
        }

        private void TransitionAnimation(Action action)
        {
            fade.FadeIn(GameCommonData.FadeOutTime, () =>
            {
                action.Invoke();
                fade.FadeOut(GameCommonData.FadeOutTime, null);
            }, false);
        }

        private void SceneTransitionAnimation(int loadSceneIndex)
        {
            fade.FadeIn(GameCommonData.FadeOutTime,
                () => UniTask.Void(async () => { await SceneManager.LoadSceneAsync(loadSceneIndex); }), false);
        }

        private void TransitionState(TitleCoreEvent gameCoreEvent)
        {
            _stateMachine.Dispatch((int)gameCoreEvent);
        }

        private void CheckMission(int actionId)
        {
            switch (actionId)
            {
                case GameCommonData.LevelUpActionId:
                    _missionManager.CheckMission(GameCommonData.LevelUpActionId);
                    break;
                case GameCommonData.BattleCountActionId:
                    _missionManager.CheckMission(GameCommonData.BattleCountActionId);
                    break;
                case GameCommonData.CharacterBattleActionId:
                    var characterId = _userDataManager.GetEquippedCharacterData().Id;
                    _missionManager.CheckMission(GameCommonData.CharacterBattleActionId, characterId);
                    break;
            }
        }

        private async UniTask SetCoinText()
        {
            var coin = await _playFabVirtualCurrencyManager.GetCoin();
            commonView.virtualCurrencyView.coinText.text = coin.ToString("D");
        }

        private async UniTask SetGemText()
        {
            var gem = await _playFabVirtualCurrencyManager.GetGem();
            commonView.virtualCurrencyView.gemText.text = gem.ToString("D");
        }

        private async UniTask SetTicketText()
        {
            var ticket = await _playFabVirtualCurrencyManager.GetTicket();
            commonView.virtualCurrencyView.ticketText.text = ticket.ToString("D");
        }

        private void OnClickTransitionShopState(GameObject button)
        {
            _uiAnimation.ClickScale(button).OnComplete(() => { _stateMachine.Dispatch((int)TitleCoreEvent.Shop); })
                .SetLink(button);
        }

        private void SetupRewardOkButton()
        {
            commonView.rewardGetView.okButton.onClick.RemoveAllListeners();
            commonView.rewardGetView.okButton.onClick.AddListener(() => UniTask.Void(async () =>
            {
                await _uiAnimation.Close(commonView.rewardGetView.transform, GameCommonData.CloseDuration);
            }));
        }

        private async UniTask SetRewardUI(int value, Sprite rewardSprite)
        {
            var rewardView = commonView.rewardGetView;
            rewardView.rewardImage.sprite = rewardSprite;
            rewardView.rewardText.text = value == 1 ? "" : value.ToString("D");
            rewardView.transform.localScale = Vector3.zero;
            rewardView.gameObject.SetActive(true);
            await _uiAnimation.Open(rewardView.transform, GameCommonData.OpenDuration);
        }
    }
}