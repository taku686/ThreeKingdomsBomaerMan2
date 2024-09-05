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
using UnityEngine;
using Zenject;
using Manager.DataManager;
using Repository;
using UniRx;
using UnityEngine.UI;
using UseCase;


namespace UI.Title
{
    public partial class TitleCore : MonoBehaviourPunCallbacks
    {
        //Repository
        [Inject] private CharacterMasterDataRepository characterMasterDataRepository;
        [Inject] private UserDataRepository userDataRepository;
        [Inject] private MissionDataRepository missionDataRepository;
        [Inject] private CatalogDataRepository catalogDataRepository;
        [Inject] private CharacterSelectRepository characterSelectRepository;
        [Inject] private WeaponMasterDataRepository weaponMasterDataRepository;
        [Inject] private CharacterObjectRepository characterObjectRepository;

        //UseCase
        [Inject] private CharacterSelectViewModelUseCase characterSelectViewModelUseCase;
        [Inject] private SortCharactersUseCase sortCharactersUseCase;
        [Inject] private InventoryViewModelUseCase inventoryViewModelUseCase;
        [Inject] private CharacterCreateUseCase characterCreateUseCase;
        [Inject] private AnimationPlayBackUseCase animationPlayBackUseCase;

        //Manager
        [Inject] private PhotonNetworkManager photonNetworkManager;
        [Inject] private MainManager mainManager;
        [Inject] private PlayFabLoginManager playFabLoginManager;
        [Inject] private PlayFabUserDataManager playFabUserDataManager;
        [Inject] private PlayFabShopManager playFabShopManager;
        [Inject] private PlayFabAdsManager playFabAdsManager;
        [Inject] private PlayFabVirtualCurrencyManager playFabVirtualCurrencyManager;
        [Inject] private MissionManager missionManager;
        [Inject] private ChatGPTManager chatGptManager;

        //UI
        [Inject] private UIAnimation uiAnimation;

        [SerializeField] private Fade fade;
        [SerializeField] private Transform characterCreatePosition;
        [SerializeField] private ViewBase[] views;
        [SerializeField] private CommonView commonView;

        private StateMachine<TitleCore> stateMachine;
        private CancellationTokenSource cts;


        public enum State
        {
            Login,
            Main,
            CharacterSelect,
            CharacterDetail,
            Shop,
            BattleReady,
            Setting,
            LoginBonus,
            Mission,
            SelectBattleMode,
            Inventory
        }


        private void Start()
        {
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
            var view = (MainView)GetView(State.Main);
            view.SetBackgroundEffect(false);
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
            stateMachine.AddTransition<CharacterDetailState, InventoryState>((int)State.Inventory);
            stateMachine.AddTransition<InventoryState, CharacterDetailState>((int)State.CharacterDetail);
            stateMachine.AddTransition<MainState, BattleReadyState>((int)State.BattleReady);
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

        private ViewBase GetView(State state)
        {
            foreach (var view in views)
            {
                if (view.State == state)
                {
                    return view;
                }
            }

            return null;
        }

        private async UniTask SwitchUiObject(State state, bool isViewVirtualCurrencyUi, Action action = null)
        {
            await TransitionUiAnimation(() =>
            {
                foreach (var view in views)
                {
                    view.gameObject.SetActive(view.State == state);
                }

                action?.Invoke();
                commonView.virtualCurrencyView.gameObject.SetActive(isViewVirtualCurrencyUi);
            });
        }

        private async UniTask TransitionUiAnimation(Action action)
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
                    var characterId = userDataRepository.GetEquippedCharacterId();
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

        private void OnClickTransitionState(Button button, State state, CancellationToken cancellationToken)
        {
            if (button == null)
            {
                Debug.LogError("ボタンが設定されていません。");
                return;
            }

            button.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    button.interactable = false;
                    uiAnimation.ClickScaleColor(button.gameObject)
                        .OnComplete(() =>
                        {
                            stateMachine.Dispatch((int)state);
                            button.interactable = true;
                        })
                        .SetLink(button.gameObject);
                })
                .AddTo(cancellationToken);
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
            await uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
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