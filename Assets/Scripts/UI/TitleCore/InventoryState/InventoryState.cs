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
            private readonly Subject<Unit> onChangeSubject = new();

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
                var selectedCharacterId = CharacterSelectRepository.GetSelectedCharacterId();
                selectedWeaponId = UserDataRepository.GetEquippedWeaponId(selectedCharacterId);
                OnSubscribed();
                Owner.SwitchUiObject(State.Inventory, true).Forget();
            }

            private void OnSubscribed()
            {
                View.BackButton.OnClickAsObservable()
                    .Subscribe(_ => StateMachine.Dispatch((int)State.CharacterDetail))
                    .AddTo(cts.Token);

                onChangeSubject
                    .Select(_ => InventoryViewModelUseCase.InAsTask())
                    .Subscribe(viewModel =>
                    {
                        View.ApplyViewModel(viewModel);
                    })
                    .AddTo(cts.Token);

                onChangeSubject.OnNext(Unit.Default);
                
                foreach (var gridView in View.WeaponGridViews)
                {
                    gridView.OnClickObservable
                        .Subscribe(weaponId =>
                        {
                            selectedWeaponId = weaponId;
                            var selectedWeaponMasterData = WeaponMasterDataRepository.GetWeaponData(weaponId);
                            View.ApplyWeaponDetailViewModel(selectedWeaponMasterData);
                        })
                        .AddTo(cts.Token);
                }
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