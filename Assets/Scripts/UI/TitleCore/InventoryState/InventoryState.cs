using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using UI.Common;
using UniRx;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class InventoryState : StateMachine<TitleCore>.State
        {
            private InventoryView _View => (InventoryView)Owner.GetView(State.Inventory);
            private InventoryViewModelUseCase _InventoryViewModelUseCase => Owner._inventoryViewModelUseCase;
            private CharacterSelectRepository _CharacterSelectRepository => Owner._characterSelectRepository;
            private UserDataRepository _UserDataRepository => Owner._userDataRepository;
            private SkillDetailViewModelUseCase _SkillDetailViewModelUseCase => Owner._skillDetailViewModelUseCase;
            private UIAnimation _UIAnimation => Owner._uiAnimation;

            private CancellationTokenSource _cts;
            private Subject<int> _onChangeSelectedWeaponSubject;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                _onChangeSelectedWeaponSubject.Dispose();
                Cancel();
            }

            private void Initialize()
            {
                _onChangeSelectedWeaponSubject = new Subject<int>();
                _cts = new CancellationTokenSource();
                Subscribe();
                Owner.SwitchUiObject(State.Inventory, true).Forget();
            }

            private void Subscribe()
            {
                _View._BackButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._BackButton).ToObservable())
                    .Subscribe(_ => StateMachine.Dispatch((int)State.CharacterDetail))
                    .AddTo(_cts.Token);

                _onChangeSelectedWeaponSubject
                    .Select(weaponId => _InventoryViewModelUseCase.InAsTask(weaponId))
                    .Subscribe(viewModel =>
                    {
                        _View.ApplyViewModel(viewModel, _UIAnimation, Owner.SetActiveBlockPanel);
                        foreach (var gridView in _View._WeaponGridViews)
                        {
                            gridView._OnClickObservable
                                .Subscribe(weaponId => { _onChangeSelectedWeaponSubject.OnNext(weaponId); })
                                .AddTo(_cts.Token);
                        }
                    })
                    .AddTo(_cts.Token);

                _View._EquipButton.OnClickAsObservable()
                    .SelectMany(_ => Owner.OnClickScaleColorAnimation(_View._EquipButton).ToObservable())
                    .WithLatestFrom(_onChangeSelectedWeaponSubject, (_, weaponId) => weaponId)
                    .Select(selectedWeaponId => (selectedWeaponId, selectedCharacterId: _CharacterSelectRepository.GetSelectedCharacterId()))
                    .SelectMany(tuple => _UserDataRepository.SetEquippedWeapon(tuple.selectedCharacterId, tuple.selectedWeaponId).ToObservable())
                    .Subscribe(_ => { stateMachine.Dispatch((int)State.CharacterDetail); })
                    .AddTo(_cts.Token);

                _View._OnClickStatusSkillDetailButtonAsObservable
                    .WithLatestFrom(_onChangeSelectedWeaponSubject, (_, weaponId) => weaponId)
                    .Select(weaponId => _SkillDetailViewModelUseCase.InAsTask(weaponId, SkillType.Status))
                    .Subscribe(viewModel =>
                    {
                        _View.ApplySkillDetailViewModel(viewModel);
                        Owner.SetActiveBlockPanel(false);
                    })
                    .AddTo(_cts.Token);

                _View._OnClickNormalSkillDetailButtonAsObservable
                    .WithLatestFrom(_onChangeSelectedWeaponSubject, (_, weaponId) => weaponId)
                    .Select(weaponId => _SkillDetailViewModelUseCase.InAsTask(weaponId, SkillType.Normal))
                    .Subscribe(viewModel =>
                    {
                        _View.ApplySkillDetailViewModel(viewModel);
                        Owner.SetActiveBlockPanel(false);
                    })
                    .AddTo(_cts.Token);

                _View._OnClickSpecialSkillDetailButtonAsObservable
                    .WithLatestFrom(_onChangeSelectedWeaponSubject, (_, weaponId) => weaponId)
                    .Select(weaponId => _SkillDetailViewModelUseCase.InAsTask(weaponId, SkillType.Special))
                    .Subscribe(viewModel =>
                    {
                        _View.ApplySkillDetailViewModel(viewModel);
                        Owner.SetActiveBlockPanel(false);
                    })
                    .AddTo(_cts.Token);

                _View._OnClickSkillDetailViewCloseButtonAsObservable
                    .Subscribe(_ =>
                    {
                        _View.CloseSkillDetailView();
                        Owner.SetActiveBlockPanel(false);
                    })
                    .AddTo(_cts.Token);

                var selectedCharacterId = _CharacterSelectRepository.GetSelectedCharacterId();
                var selectedWeaponId = _UserDataRepository.GetEquippedWeaponId(selectedCharacterId);
                _onChangeSelectedWeaponSubject.OnNext(selectedWeaponId);
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