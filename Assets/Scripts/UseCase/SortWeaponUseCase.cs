using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Common.Data;
using Repository;
using Zenject;

namespace UseCase
{
    public class SortWeaponUseCase : IDisposable
    {
        private readonly WeaponSortRepository _weaponSortRepository;

        [Inject]
        public SortWeaponUseCase
        (
            WeaponSortRepository weaponSortRepository
        )
        {
            _weaponSortRepository = weaponSortRepository;
        }

        public IReadOnlyDictionary<WeaponMasterData, int> InAsTask(IReadOnlyDictionary<WeaponMasterData, int> possessedWeaponDatum)
        {
            var sortType = _weaponSortRepository.GetSortTypeDictionary().Where(keyValue => !keyValue.Value).Select(keyValue => keyValue.Key).First();
            var filter = _weaponSortRepository.GetFilterTypeDictionary();
            if (!filter[WeaponType.None])
            {
                possessedWeaponDatum = possessedWeaponDatum
                    .Where(weapon => filter[weapon.Key.WeaponType])
                    .ToDictionary(weapon => weapon.Key, weapon => weapon.Value);
            }

            var sortDatum = possessedWeaponDatum
                .OrderBy(weapon => TranslateSortType(sortType, weapon))
                .ThenBy(weapon => weapon.Key.WeaponType)
                .ThenBy(weapon => weapon.Key.Rare)
                .ThenBy(weapon => weapon.Key.Id)
                .ToDictionary(weapon => weapon.Key, weapon => weapon.Value);
            return sortDatum;
        }

        private static int TranslateSortType(WeaponSortRepository.SortType sortType, KeyValuePair<WeaponMasterData, int> weapon)
        {
            return sortType switch
            {
                WeaponSortRepository.SortType.WeaponType => (int)weapon.Key.WeaponType,
                WeaponSortRepository.SortType.Rarity => weapon.Key.Rare,
                WeaponSortRepository.SortType.Possession => weapon.Value,
                WeaponSortRepository.SortType.Hp => weapon.Key.Rare,
                WeaponSortRepository.SortType.Attack => weapon.Key.Rare,
                WeaponSortRepository.SortType.Defense => weapon.Key.Rare,
                WeaponSortRepository.SortType.Speed => weapon.Key.Rare,
                WeaponSortRepository.SortType.Resistance => weapon.Key.Rare,
                WeaponSortRepository.SortType.Attribute => (int)weapon.Key.AttributeType,
                WeaponSortRepository.SortType.Skill => weapon.Key.Rare,
                WeaponSortRepository.SortType.Slot => weapon.Key.Rare,
                WeaponSortRepository.SortType.Set => weapon.Key.Rare,
                WeaponSortRepository.SortType.Favorite => weapon.Key.Rare,
                WeaponSortRepository.SortType.BombCount => weapon.Key.Rare,
                WeaponSortRepository.SortType.Fire => weapon.Key.Rare,
                WeaponSortRepository.SortType.None => weapon.Key.Rare,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}