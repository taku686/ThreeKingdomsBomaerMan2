using System.Threading;
using Assets.Scripts.Common.PlayFab;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager;
using Repository;
using UI.TitleCore.UserInfoState;
using UniRx;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class MainState : StateMachine<TitleCore>.State
        {
            private StateMachine<TitleCore> _StateMachine => Owner._stateMachine;
            private MainView _View => (MainView)Owner.GetView(State.Main);
            private CharacterCreateUseCase _CharacterCreateUseCase => Owner._characterCreateUseCase;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private EntitledMasterDataRepository _EntitledMasterDataRepository => Owner._entitledMasterDataRepository;
            private SkyBoxManager _SkyBoxManager => Owner._skyBoxManager;
            private PopupGenerateUseCase _PopupGenerateUseCase => Owner._popupGenerateUseCase;
            private UserInfoViewModelUseCase _UserInfoViewModelUseCase => Owner._userInfoViewModelUseCase;
            private MainViewModelUseCase _MainViewModelUseCase => Owner._mainViewModelUseCase;
            private TemporaryCharacterRepository _TemporaryCharacterRepository => Owner._temporaryCharacterRepository;

            private CancellationTokenSource _cts;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize().Forget();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
                _View.SetBackgroundEffect(false);
            }

            private async UniTaskVoid Initialize()
            {
                _cts = new CancellationTokenSource();
                Owner.SwitchUiObject(State.Main, true, () =>
                {
                    Subscribe();
                    _SkyBoxManager.ChangeSkyBox();
                    ApplySimpleUserInfoView();
                    ApplyMainViewModel();
                    _View.SetBackgroundEffect(true);
                    GenerateTeamMembers();
                }).Forget();
                await InitializeText();
            }

            private void ApplyMainViewModel()
            {
                var viewModel = _MainViewModelUseCase.InAsTask();
                _View.ApplyViewModel(viewModel);
            }

            private void GenerateTeamMembers()
            {
                var teamMembers = _UserDataRepository.GetTeamMembers();
                foreach (var (index, characterId) in teamMembers)
                {
                    if (characterId == GameCommonData.InvalidNumber)
                    {
                        continue;
                    }

                    var createParent = Owner.GetGenerateCharacterCreateParent(index);
                    _CharacterCreateUseCase.CreateTeam(characterId, index, createParent);
                }
            }

            private void ApplySimpleUserInfoView()
            {
                var userData = _UserDataRepository.GetUserData();
                var userName = userData.Name;
                var userIcon = _UserDataRepository.GetUserIconSprite();
                var entitled = _EntitledMasterDataRepository.GetEntitledMasterData(userData.EntitledId).Entitled;
                var viewModel = new SimpleUserInfoView.ViewModel
                (
                    userIcon,
                    userName,
                    entitled
                );
                _View.ApplySimpleUserInfoView(viewModel);
            }


            private void Subscribe()
            {
                _View._MissionButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._MissionButton).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Mission); })
                    .AddTo(_cts.Token);

                _View._ShopButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._ShopButton).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Shop); })
                    .AddTo(_cts.Token);

                _View._SettingButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._SettingButton).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.Setting); })
                    .AddTo(_cts.Token);

                _View._BattleReadyButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._BattleReadyButton).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.BattleReady); })
                    .AddTo(_cts.Token);

                _View._CharacterSelectButton
                    .OnClickAsObservable()
                    .Take(1)
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._CharacterSelectButton).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.CharacterSelect); })
                    .AddTo(_cts.Token);

                _View._UserInfoButton
                    .OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._UserInfoButton).ToObservable())
                    .Select(_ => _UserInfoViewModelUseCase.InAsTask())
                    .SelectMany(viewModel => _PopupGenerateUseCase.GenerateUserInfoPopup(viewModel))
                    .Subscribe(_ => Owner.SetActiveBlockPanel(false))
                    .AddTo(_cts.Token);

                _View._TeamEditButton
                    .OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._TeamEditButton).ToObservable())
                    .Subscribe(_ => { _StateMachine.Dispatch((int)State.TeamEdit); })
                    .AddTo(_cts.Token);

                _View._InventoryButton
                    .OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._InventoryButton).ToObservable())
                    .Subscribe(_ =>
                    {
                        var characterId = _UserDataRepository.GetTeamMember(0);
                        _TemporaryCharacterRepository.SetSelectedCharacterId(characterId);
                        _StateMachine.Dispatch((int)State.Inventory, (int)State.Main);
                    })
                    .AddTo(_cts.Token);
            }

            private async UniTask InitializeText()
            {
                await Owner.SetCoinText();
                await Owner.SetGemText();
                await Owner.SetTicketText();
                Owner._commonView.virtualCurrencyView.gameObject.SetActive(true);
            }

            private void Cancel()
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }
    }
}