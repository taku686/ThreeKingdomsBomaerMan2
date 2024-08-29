using System.Threading;
using Common.Data;
using Cysharp.Threading.Tasks;
using Repository;
using UniRx;
using UnityEngine;

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

            private CancellationTokenSource cts;
            private Subject<int> onChangeSelectedWeaponSubject;

            protected override void OnEnter(StateMachine<TitleCore>.State prevState)
            {
                Initialize();
            }

            protected override void OnExit(StateMachine<TitleCore>.State nextState)
            {
                onChangeSelectedWeaponSubject.Dispose();
                Cancel();
            }

            private void Initialize()
            {
                onChangeSelectedWeaponSubject = new Subject<int>();
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
                    .Select(weaponId => InventoryViewModelUseCase.InAsTask(weaponId))
                    .Subscribe(viewModel =>
                    {
                        View.ApplyViewModel(viewModel);
                        foreach (var gridView in View.WeaponGridViews)
                        {
                            gridView.OnClickObservable
                                .Subscribe(weaponId => onChangeSelectedWeaponSubject.OnNext(weaponId))
                                .AddTo(gridView.GetCancellationTokenOnDestroy());
                        }
                    })
                    .AddTo(cts.Token);

                View.EquipButton.OnClickAsObservable()
                    .WithLatestFrom(onChangeSelectedWeaponSubject, (_, weaponId) => weaponId)
                    .Select(selectedWeaponId => (selectedWeaponId, selectedCharacterId: CharacterSelectRepository.GetSelectedCharacterId()))
                    .SelectMany(tuple => UserDataRepository.SetEquippedWeapon(tuple.selectedCharacterId, tuple.selectedWeaponId).ToObservable())
                    .Subscribe(_ => { stateMachine.Dispatch((int)State.CharacterDetail); })
                    .AddTo(cts.Token);

                var selectedCharacterId = CharacterSelectRepository.GetSelectedCharacterId();
                var selectedWeaponId = UserDataRepository.GetEquippedWeaponId(selectedCharacterId);
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