using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Repository;
using UniRx;

namespace UI.Title
{
    public partial class TitleCore
    {
        public class InventoryState : StateMachine<TitleCore>.State
        {
            private InventoryView View => (InventoryView)Owner.GetView(State.Inventory);
            private InventoryViewModelUseCase InventoryViewModelUseCase => Owner.inventoryViewModelUseCase;
            private CharacterSelectRepository CharacterSelectRepository => Owner.characterSelectRepository;
            private UserDataRepository UserDataRepository => Owner.userDataRepository;
            private WeaponMasterDataRepository WeaponMasterDataRepository => Owner.weaponMasterDataRepository;

            private int selectedWeaponId;
            private CancellationTokenSource cts;
            private readonly Subject<int> onChangeSelectedWeaponSubject = new();

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                Cancel();
            }

            private void Initialize()
            {
                cts = new CancellationTokenSource();
                OnSubscribed();
                Owner.SwitchUiObject(State.Inventory, true).Forget();
            }

            private void OnSubscribed()
            {
                View.BackButton.OnClickAsObservable()
                    .Subscribe(_ => StateMachine.Dispatch((int)State.CharacterDetail))
                    .AddTo(cts.Token);

                onChangeSelectedWeaponSubject
                    .Select(weaponId => (selectedWeaponId: weaponId, viewModel: InventoryViewModelUseCase.InAsTask()))
                    .Subscribe(tuple =>
                    {
                        View.ApplyViewModel(tuple.viewModel, tuple.selectedWeaponId);
                        foreach (var gridView in View.WeaponGridViews)
                        {
                            gridView.OnClickObservable
                                .Subscribe(weaponId =>
                                {
                                    onChangeSelectedWeaponSubject.OnNext(weaponId);
                                    var selectedWeaponMasterData = WeaponMasterDataRepository.GetWeaponData(weaponId);
                                    View.ApplyWeaponDetailViewModel(selectedWeaponMasterData);
                                })
                                .AddTo(gridView.GetCancellationTokenOnDestroy());
                        }
                    })
                    .AddTo(cts.Token);

                var selectedCharacterId = CharacterSelectRepository.GetSelectedCharacterId();
                selectedWeaponId = UserDataRepository.GetEquippedWeaponId(selectedCharacterId);
                onChangeSelectedWeaponSubject.OnNext(selectedWeaponId);
            }


            private void Cancel()
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
    }
}