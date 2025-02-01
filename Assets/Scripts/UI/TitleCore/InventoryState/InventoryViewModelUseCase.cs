using System;
using System.Linq;
using Common.Data;
using Repository;
using UnityEngine;

namespace UI.Title
{
    public class InventoryViewModelUseCase : IDisposable
    {
        private readonly UserDataRepository _userDataRepository;
        private readonly WeaponMasterDataRepository _weaponMasterDataRepository;

        public InventoryViewModelUseCase
        (
            UserDataRepository userDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository
        )
        {
            _userDataRepository = userDataRepository;
            _weaponMasterDataRepository = weaponMasterDataRepository;
        }

        public InventoryView.ViewModel InAsTask(int selectedWeaponId)
        {
            var possessedWeaponDatum = _userDataRepository.GetAllPossessedWeaponDatum();
            var weaponMasterData = _weaponMasterDataRepository.GetWeaponData(selectedWeaponId);
            if (!possessedWeaponDatum.ContainsKey(weaponMasterData))
            {
                var candidate = possessedWeaponDatum
                    .OrderBy(weapon => weapon.Key.WeaponType)
                    .ThenBy(weapon => weapon.Key.Rare)
                    .ThenBy(weapon => weapon.Key.Id)
                    .First();
                weaponMasterData = _weaponMasterDataRepository.GetWeaponData(candidate.Key.Id);
            }

            return new InventoryView.ViewModel
            (
                possessedWeaponDatum,
                weaponMasterData
            );
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}