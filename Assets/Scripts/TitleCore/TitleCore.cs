using System;
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
using UnityEngine.UI;
using UseCase;


namespace UI.Title
{
    public partial class TitleCore : MonoBehaviourPunCallbacks
    {
        [Inject] private CharacterDataManager characterDataManager;
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
        [Inject] private CharacterSelectViewModelUseCase characterSelectViewModelUseCase;
        [Inject] private CharacterSelectRepository characterSelectRepository;
        [Inject] private SortCharactersUseCase sortCharactersUseCase;
        [SerializeField] private Fade fade;
        [SerializeField] private Transform characterCreatePosition;
        [SerializeField] private MainView mainView;
        [SerializeField] private CharacterSelectView characterSelectView;
        [SerializeField] private CharacterDetailView characterDetailView;
        [SerializeField] private BattleReadyView battleReadyView;
        [SerializeField] private LoginView loginView;
        [SerializeField] private SettingView settingView;
        [SerializeField] private ShopView shopView;
        [SerializeField] private LoginBonusView loginBonusView;
        [SerializeField] private MissionView missionView;
        [SerializeField] private CommonView commonView;
        private GameObject equippedCharacter;
        private GameObject weaponEffect;
        private StateMachine<TitleCore> stateMachine;
        private CancellationToken token;
        private CancellationTokenSource cts;
        [SerializeField] private GameObject[] uiObjects;


        private enum State
        {
            Login,
            Main,
            CharacterSelect,
            CharacterDetail,
            Shop,
            ReadyBattle,
            Setting,
            LoginBonus,
            Mission,
            SelectBattleMode,
        }


        private void Start()
        {
            token = this.GetCancellationTokenOnDestroy();
            Application.targetFrameRate = 60;
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
            mainView.SetBackgroundEffect(false);
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

            stateMachine.AddAnyTransition<MainState>((int)State.Main);
            stateMachine.AddAnyTransition<ShopState>((int)State.Shop);
            stateMachine.AddTransition<MainState, CharacterSelectState>((int)State.CharacterSelect);
            stateMachine.AddTransition<CharacterSelectState, CharacterDetailState>((int)State.CharacterDetail);
            stateMachine.AddTransition<CharacterDetailState, CharacterSelectState>((int)State.CharacterSelect);
            stateMachine.AddTransition<MainState, BattleReadyState>((int)State.ReadyBattle);
            stateMachine.AddTransition<LoginState, MainState>((int)State.Main);
            stateMachine.AddTransition<MainState, SettingState>((int)State.Setting);
            stateMachine.AddTransition<MainState, LoginBonusState>((int)State.LoginBonus);
            stateMachine.AddTransition<MainState, MissionState>((int)State.Mission);
        }

        private void InitializeButton()
        {
            var gemAddButton = commonView.virtualCurrencyView.gemAddButton;
            var coinAddButton = commonView.virtualCurrencyView.coinAddButton;
            var ticketAddButton = commonView.virtualCurrencyView.ticketAddButton;
            SetupRewardOkButton();
            OnClickTransitionState(gemAddButton, State.Shop, cts.Token);
            OnClickTransitionState(coinAddButton, State.Shop, cts.Token);
            OnClickTransitionState(ticketAddButton, State.Shop, cts.Token);
        }

        private void CreateCharacter(int id)
        {
            var preCharacter = equippedCharacter;
            var preWeaponEffect = weaponEffect;
            Destroy(preCharacter);
            Destroy(preWeaponEffect);
            var createCharacterData = characterDataManager.GetCharacterData(id);
            if (createCharacterData.CharacterObject == null || createCharacterData.WeaponEffectObj == null)
            {
                Debug.LogError(id);
            }

            equippedCharacter = Instantiate(createCharacterData.CharacterObject,
                characterCreatePosition.position,
                characterCreatePosition.rotation, characterCreatePosition);
            var currentCharacterLevel = userDataManager.GetCurrentLevelData(id);
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

        private async UniTask SwitchUiObject(State state, bool isViewVirtualCurrencyUi, Action action = null)
        {
            await TransitionAnimation(() =>
            {
                foreach (var ui in uiObjects)
                {
                    ui.SetActive(false);
                }

                action?.Invoke();
                commonView.virtualCurrencyView.gameObject.SetActive(isViewVirtualCurrencyUi);
                uiObjects[(int)state].SetActive(true);
            });
        }

        private async UniTask TransitionAnimation(Action action)
        {
            await fade.FadeIn(GameCommonData.FadeOutTime, null, false);
            action.Invoke();
            await fade.FadeOut(GameCommonData.FadeOutTime);
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
                    var characterId = userDataManager.GetEquippedCharacterId();
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

        private void OnClickTransitionState(Button button, State state, CancellationToken token)
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
                        .OnComplete(() => { stateMachine.Dispatch((int)state); })
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

        private async UniTask OnClickButtonAnimation(Button button)
        {
            await uiAnimation.ClickScaleColor(button.gameObject).ToUniTask(cancellationToken: token);
        }

        private void Cancel(CancellationTokenSource cancellationTokenSource)
        {
            if (cancellationTokenSource == null)
            {
                return;
            }

            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
    }
}