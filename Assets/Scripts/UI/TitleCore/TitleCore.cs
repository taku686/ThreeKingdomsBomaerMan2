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
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private MissionDataRepository _missionDataRepository;
        [Inject] private CatalogDataRepository _catalogDataRepository;
        [Inject] private CharacterSelectRepository _characterSelectRepository;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;
        [Inject] private CharacterObjectRepository _characterObjectRepository;
        [Inject] private RewardDataRepository _rewardDataRepository;

        //UseCase
        [Inject] private CharacterSelectViewModelUseCase _characterSelectViewModelUseCase;
        [Inject] private SortCharactersUseCase _sortCharactersUseCase;
        [Inject] private InventoryViewModelUseCase _inventoryViewModelUseCase;
        [Inject] private CharacterCreateUseCase _characterCreateUseCase;
        [Inject] private AnimationPlayBackUseCase _animationPlayBackUseCase;
        [Inject] private CharacterDetailViewModelUseCase _characterDetailViewModelUseCase;
        [Inject] private SkillDetailViewModelUseCase _skillDetailViewModelUseCase;
        [Inject] private PopupGenerateUseCase _popupGenerateUseCase;
        [Inject] private RewardDataUseCase _rewardDataUseCase;

        //Manager
        [Inject] private PhotonNetworkManager _photonNetworkManager;
        [Inject] private MainManager _mainManager;
        [Inject] private PlayFabLoginManager _playFabLoginManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private PlayFabShopManager _playFabShopManager;
        [Inject] private PlayFabAdsManager _playFabAdsManager;
        [Inject] private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
        [Inject] private MissionManager _missionManager;
        [Inject] private ChatGPTManager _chatGptManager;
        [Inject] private CharacterTypeManager _characterTypeManager;

        //UI
        [Inject] private UIAnimation _uiAnimation;

        [SerializeField] private Fade _fade;
        [SerializeField] private Transform _characterCreatePosition;
        [SerializeField] private CommonView _commonView;
        [SerializeField] private ViewBase[] _views;


        private StateMachine<TitleCore> _stateMachine;
        private CancellationTokenSource _cts;


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
            Inventory,
            Reward
        }


        private void Start()
        {
            Application.targetFrameRate = 60;
            Initialize();
        }

        private void OnDestroy()
        {
            Cancel(_cts);
        }

        private void Update()
        {
            _stateMachine?.Update();
        }


        private void Initialize()
        {
            _cts = new CancellationTokenSource();
            _fade.InitializeInSceneTransition(1, ProjectCommonData.Instance.isSceneTransition);
            var view = (MainView)GetView(State.Main);
            view.SetBackgroundEffect(false);
            _commonView.Initialize();
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

            _stateMachine.AddAnyTransition<MainState>((int)State.Main);
            _stateMachine.AddAnyTransition<ShopState>((int)State.Shop);
            _stateMachine.AddTransition<MainState, CharacterSelectState>((int)State.CharacterSelect);
            _stateMachine.AddTransition<CharacterSelectState, CharacterDetailState>((int)State.CharacterDetail);
            _stateMachine.AddTransition<CharacterDetailState, CharacterSelectState>((int)State.CharacterSelect);
            _stateMachine.AddTransition<CharacterDetailState, InventoryState>((int)State.Inventory);
            _stateMachine.AddTransition<InventoryState, CharacterDetailState>((int)State.CharacterDetail);
            _stateMachine.AddTransition<MainState, BattleReadyState>((int)State.BattleReady);
            _stateMachine.AddTransition<LoginState, MainState>((int)State.Main);
            _stateMachine.AddTransition<MainState, SettingState>((int)State.Setting);
            _stateMachine.AddTransition<MainState, LoginBonusState>((int)State.LoginBonus);
            _stateMachine.AddTransition<MainState, MissionState>((int)State.Mission);
            _stateMachine.AddTransition<CharacterSelectState, RewardState>((int)State.Reward);
            _stateMachine.AddTransition<ShopState, RewardState>((int)State.Reward);
            _stateMachine.AddTransition<RewardState, CharacterSelectState>((int)State.CharacterSelect);
        }

        private void InitializeButton()
        {
            var gemAddButton = _commonView.virtualCurrencyView.gemAddButton;
            var coinAddButton = _commonView.virtualCurrencyView.coinAddButton;
            var ticketAddButton = _commonView.virtualCurrencyView.ticketAddButton;
            SetupRewardOkButton();
            OnClickTransitionState(gemAddButton, State.Shop, _cts.Token);
            OnClickTransitionState(coinAddButton, State.Shop, _cts.Token);
            OnClickTransitionState(ticketAddButton, State.Shop, _cts.Token);
        }

        private ViewBase GetView(State state)
        {
            foreach (var view in _views)
            {
                if (view._State == state)
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
                foreach (var view in _views)
                {
                    view.gameObject.SetActive(view._State == state);
                }

                _commonView.SetCharacterStageActive(state != State.Reward);
                _commonView.SetGachaStageActive(state == State.Reward);
                action?.Invoke();
                _commonView.virtualCurrencyView.gameObject.SetActive(isViewVirtualCurrencyUi);
            });
        }

        private async UniTask TransitionUiAnimation(Action action)
        {
            await _fade.FadeIn(GameCommonData.FadeOutTime, null, false);
            action.Invoke();
            await _fade.FadeOut(GameCommonData.FadeOutTime);
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
                    var characterId = _userDataRepository.GetEquippedCharacterId();
                    _missionManager.CheckMission(GameCommonData.CharacterBattleActionId, characterId);
                    break;
            }
        }

        private async UniTask SetCoinText()
        {
            var coin = await _playFabVirtualCurrencyManager.GetCoin();
            _commonView.virtualCurrencyView.coinText.text = coin.ToString("D");
        }

        private async UniTask SetGemText()
        {
            var gem = await _playFabVirtualCurrencyManager.GetGem();
            _commonView.virtualCurrencyView.gemText.text = gem.ToString("D");
        }

        private async UniTask SetTicketText()
        {
            var ticket = await _playFabVirtualCurrencyManager.GetTicket();
            _commonView.virtualCurrencyView.ticketText.text = ticket.ToString("D");
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
                    _uiAnimation.ClickScaleColor(button.gameObject)
                        .OnComplete(() =>
                        {
                            _stateMachine.Dispatch((int)state);
                            button.interactable = true;
                        })
                        .SetLink(button.gameObject);
                })
                .AddTo(cancellationToken);
        }

        private void SetupRewardOkButton()
        {
            _commonView.rewardGetView.okButton.onClick.RemoveAllListeners();
            _commonView.rewardGetView.okButton.onClick.AddListener(() => UniTask.Void(async () =>
            {
                await _uiAnimation.Close(_commonView.rewardGetView.transform, GameCommonData.CloseDuration);
            }));
        }

        private async UniTask SetRewardUI(int value, Sprite rewardSprite)
        {
            var rewardView = _commonView.rewardGetView;
            rewardView.rewardImage.sprite = rewardSprite;
            rewardView.rewardText.text = value == 1 ? "" : value.ToString("D");
            rewardView.transform.localScale = Vector3.zero;
            rewardView.gameObject.SetActive(true);
            await _uiAnimation.Open(rewardView.transform, GameCommonData.OpenDuration);
        }

        private async UniTask OnClickButtonAnimation(Button button)
        {
            await _uiAnimation.ClickScaleColor(button.gameObject).ToUniTask();
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