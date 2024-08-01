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
using UniRx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UI.Title
{
    public partial class TitleCore : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataManager characterDataManager;
        [Inject] private CharacterLevelDataManager characterLevelDataManager;
        [Inject] private UserDataManager userDataManager;
        [Inject] private MissionDataManager missionDataManager;
        [Inject] private UIAnimation uiAnimation;
        [Inject] private PhotonNetworkManager photonNetworkManager;
        [Inject] private MainManager mainManager;
        [Inject] private PlayFabLoginManager playFabLoginManager;
        [Inject] private PlayFabUserDataManager playFabUserDataManager;
        [Inject] private PlayFabShopManager playFabShopManager;
        [Inject] private PlayFabAdsManager playFabAdsManager;
        [Inject] private PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager;
        [Inject] private CatalogDataManager catalogDataManager;
        [Inject] private MissionManager missionManager;
        [Inject] private ChatGPTManager chatGptManager;
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
        private GameObject character;
        private GameObject weaponEffect;
        private StateMachine<TitleCore> stateMachine;
        private CancellationToken token;
        private CancellationTokenSource cts;
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
            token = this.GetCancellationTokenOnDestroy();
            Initialize();
        }

        private void OnDestroy()
        {
            Cancel(cts);
        }

        private void Update()
        {
            stateMachine?.Update();
        }


        private void Initialize()
        {
            cts = new CancellationTokenSource();
            fade.InitializeInSceneTransition(1, ProjectCommonData.Instance.isSceneTransition);
            commonView.Initialize();
            InitializeState();
            InitializeButton();
        }


        private void InitializeState()
        {
            stateMachine = new StateMachine<TitleCore>(this);
            if (mainManager.isInitialize)
            {
                stateMachine.Start<MainState>();
            }
            else
            {
                stateMachine.Start<LoginState>();
            }

            stateMachine.AddAnyTransition<MainState>((int)TitleCoreEvent.Main);
            stateMachine.AddAnyTransition<ShopState>((int)TitleCoreEvent.Shop);
            stateMachine.AddTransition<MainState, CharacterSelectState>((int)TitleCoreEvent.CharacterSelect);
            stateMachine.AddTransition<CharacterSelectState, CharacterDetailState>((int)TitleCoreEvent.CharacterDetail);
            stateMachine.AddTransition<CharacterDetailState, CharacterSelectState>((int)TitleCoreEvent.CharacterSelect);
            stateMachine.AddTransition<MainState, BattleReadyState>((int)TitleCoreEvent.ReadyBattle);
            stateMachine.AddTransition<BattleReadyState, SceneTransitionState>((int)TitleCoreEvent.SceneTransition);
            stateMachine.AddTransition<LoginState, MainState>((int)TitleCoreEvent.Main);
            stateMachine.AddTransition<MainState, SettingState>((int)TitleCoreEvent.Setting);
            stateMachine.AddTransition<MainState, LoginBonusState>((int)TitleCoreEvent.LoginBonus);
            stateMachine.AddTransition<MainState, MissionState>((int)TitleCoreEvent.Mission);
        }

        private void InitializeButton()
        {
            var gemAddButton = commonView.virtualCurrencyView.gemAddButton;
            var coinAddButton = commonView.virtualCurrencyView.coinAddButton;
            var ticketAddButton = commonView.virtualCurrencyView.ticketAddButton;
            SetupRewardOkButton();
            OnClickTransitionState(gemAddButton, TitleCoreEvent.Shop, cts.Token);
            OnClickTransitionState(coinAddButton, TitleCoreEvent.Shop, cts.Token);
            OnClickTransitionState(ticketAddButton, TitleCoreEvent.Shop, cts.Token);
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
            userDataManager.GetUserData().EquipCharacterId = id;
            var preCharacter = character;
            var preWeaponEffect = weaponEffect;
            Destroy(preCharacter);
            Destroy(preWeaponEffect);
            var createCharacterData = characterDataManager.GetCharacterData(id);
            if (createCharacterData.CharacterObject == null || createCharacterData.WeaponEffectObj == null)
            {
                Debug.LogError(id);
                return false;
            }

            character = Instantiate(createCharacterData.CharacterObject,
                characterCreatePosition.position,
                characterCreatePosition.rotation, characterCreatePosition);
            var currentCharacterLevel = userDataManager.GetCurrentLevelData(id);
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

        private void SwitchUiObject(TitleCoreEvent titleCoreEvent, bool isViewVirtualCurrencyUi, Action action = null)
        {
            TransitionAnimation(() =>
            {
                foreach (var ui in uiObjects)
                {
                    ui.SetActive(false);
                }

                action?.Invoke();
                commonView.virtualCurrencyView.gameObject.SetActive(isViewVirtualCurrencyUi);
                uiObjects[(int)titleCoreEvent].SetActive(true);
            });
        }

        private void TransitionAnimation(Action action)
        {
            fade.FadeIn(GameCommonData.FadeOutTime, () =>
            {
                action.Invoke();
                fade.FadeOut(GameCommonData.FadeOutTime);
            }, false);
        }

        private void SceneTransitionAnimation(int loadSceneIndex)
        {
            fade.FadeIn(GameCommonData.FadeOutTime,
                () => UniTask.Void(async () => { await SceneManager.LoadSceneAsync(loadSceneIndex); }), false);
        }

        private void TransitionState(TitleCoreEvent gameCoreEvent)
        {
            stateMachine.Dispatch((int)gameCoreEvent);
        }

        private void CheckMission(int actionId)
        {
            switch (actionId)
            {
                case GameCommonData.LevelUpActionId:
                    missionManager.CheckMission(GameCommonData.LevelUpActionId);
                    break;
                case GameCommonData.BattleCountActionId:
                    missionManager.CheckMission(GameCommonData.BattleCountActionId);
                    break;
                case GameCommonData.CharacterBattleActionId:
                    var characterId = userDataManager.GetEquippedCharacterData().Id;
                    missionManager.CheckMission(GameCommonData.CharacterBattleActionId, characterId);
                    break;
            }
        }

        private async UniTask SetCoinText()
        {
            var coin = await playFabVirtualCurrencyManager.GetCoin();
            commonView.virtualCurrencyView.coinText.text = coin.ToString("D");
        }

        private async UniTask SetGemText()
        {
            var gem = await playFabVirtualCurrencyManager.GetGem();
            commonView.virtualCurrencyView.gemText.text = gem.ToString("D");
        }

        private async UniTask SetTicketText()
        {
            var ticket = await playFabVirtualCurrencyManager.GetTicket();
            commonView.virtualCurrencyView.ticketText.text = ticket.ToString("D");
        }

        private void OnClickTransitionState(Button button, TitleCoreEvent titleCoreEvent, CancellationToken token)
        {
            if (button == null)
            {
                Debug.LogError("ボタンが設定されていません。");
                return;
            }

            button.OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                .Subscribe(_ =>
                {
                    uiAnimation.ClickScaleColor(button.gameObject)
                        .OnComplete(() => { stateMachine.Dispatch((int)titleCoreEvent); })
                        .SetLink(button.gameObject);
                }).AddTo(token);
        }

        private void SetupRewardOkButton()
        {
            commonView.rewardGetView.okButton.onClick.RemoveAllListeners();
            commonView.rewardGetView.okButton.onClick.AddListener(() => UniTask.Void(async () =>
            {
                await uiAnimation.Close(commonView.rewardGetView.transform, GameCommonData.CloseDuration);
            }));
        }

        private async UniTask SetRewardUI(int value, Sprite rewardSprite)
        {
            var rewardView = commonView.rewardGetView;
            rewardView.rewardImage.sprite = rewardSprite;
            rewardView.rewardText.text = value == 1 ? "" : value.ToString("D");
            rewardView.transform.localScale = Vector3.zero;
            rewardView.gameObject.SetActive(true);
            await uiAnimation.Open(rewardView.transform, GameCommonData.OpenDuration);
        }

        private void SetupButton(Button button, Action action, CancellationToken token)
        {
            if (button == null)
            {
                Debug.LogError("ボタンが設定されていません。");
                return;
            }

            button.OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                .Subscribe(_ =>
                {
                    uiAnimation.ClickScaleColor(button.gameObject)
                        .OnComplete(() => { action?.Invoke(); })
                        .SetLink(button.gameObject);
                }).AddTo(token);
        }

        private void SetupButtonAsync(Button button, Func<UniTask> asyncFunc, CancellationToken token)
        {
            if (button == null)
            {
                Debug.LogError("ボタンが設定されていません。");
                return;
            }

            button.OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(GameCommonData.ClickIntervalDuration))
                .Subscribe(_ =>
                {
                    uiAnimation.ClickScaleColor(button.gameObject)
                        .OnComplete(() => UniTask.Void(async () => { await asyncFunc?.Invoke(); }))
                        .SetLink(button.gameObject);
                }).AddTo(token);
        }

        private void Cancel(CancellationTokenSource cts)
        {
            if (cts == null)
            {
                return;
            }

            cts.Cancel();
            cts.Dispose();
        }
    }
}