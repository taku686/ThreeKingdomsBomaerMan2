using System;
using Common.Data;
using Repository;

namespace UI.Title
{
    public class InventoryViewModelUseCase : IDisposable
    {
        private readonly UserDataRepository userDataRepository;
        private readonly WeaponMasterDataRepository weaponMasterDataRepository;

        public InventoryViewModelUseCase
        (
            UserDataRepository userDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository
        )
        {
            this.userDataRepository = userDataRepository;
            this.weaponMasterDataRepository = weaponMasterDataRepository;
        }

        public InventoryView.ViewModel InAsTask(int selectedWeaponId)
        {
            var weaponDatum = userDataRepository.GetAllPossessedWeaponDatum();
            var weaponMasterData = weaponMasterDataRepository.GetWeaponData(selectedWeaponId);
            return new InventoryView.ViewModel
            (
                weaponDatum,
                weaponMasterData
            );
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}