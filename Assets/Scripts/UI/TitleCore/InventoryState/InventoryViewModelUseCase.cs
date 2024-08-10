using System;
using Common.Data;

namespace UI.Title
{
    public class InventoryViewModelUseCase : IDisposable
    {
        private readonly UserDataRepository userDataRepository;

        public InventoryViewModelUseCase
        (
            UserDataRepository userDataRepository
        )
        {
            this.userDataRepository = userDataRepository;
        }

        public InventoryView.ViewModel InAsTask()
        {
            var weaponDatum = userDataRepository.GetAllPossessedWeaponDatum();
            var equippedCharacterId = userDataRepository.GetEquippedCharacterId();
            var equippedWeaponData = userDataRepository.GetEquippedWeaponData(equippedCharacterId);
            return new InventoryView.ViewModel
            (
                weaponDatum,
                equippedWeaponData
            );
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}