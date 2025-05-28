using System;
using System.Linq;
using Common.Data;
using Repository;
using UnityEngine;
using UseCase;
using Zenject;

namespace UI.Title
{
    public class InventoryViewModelUseCase : IDisposable
    {
        private readonly UserDataRepository _userDataRepository;
        private readonly WeaponMasterDataRepository _weaponMasterDataRepository;
        private readonly SortWeaponUseCase _sortWeaponUseCase;
        private readonly WeaponCautionRepository _weaponCautionRepository;

        [Inject]
        public InventoryViewModelUseCase
        (
            UserDataRepository userDataRepository,
            WeaponMasterDataRepository weaponMasterDataRepository,
            SortWeaponUseCase sortWeaponUseCase,
            WeaponCautionRepository weaponCautionRepository
        )
        {
            _userDataRepository = userDataRepository;
            _weaponMasterDataRepository = weaponMasterDataRepository;
            _sortWeaponUseCase = sortWeaponUseCase;
            _weaponCautionRepository = weaponCautionRepository;
        }

        public InventoryView.ViewModel InAsTask(int selectedWeaponId)
        {
            var possessedWeaponDatum = _userDataRepository.GetAllPossessedWeaponDatum();
            var sortedWeaponDatum = _sortWeaponUseCase.InAsTask(possessedWeaponDatum);
            var weaponMasterData = _weaponMasterDataRepository.GetWeaponData(selectedWeaponId);
            var weaponCautionDictionary = _weaponCautionRepository.GetWeaponCaution();
            var isFocus = true;
            if (!sortedWeaponDatum.ContainsKey(weaponMasterData))
            {
                var candidate = sortedWeaponDatum.First();
                weaponMasterData = _weaponMasterDataRepository.GetWeaponData(candidate.Key.Id);
                isFocus = false;
            }

            return new InventoryView.ViewModel
            (
                sortedWeaponDatum,
                weaponMasterData,
                isFocus,
                weaponCautionDictionary
            );
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}