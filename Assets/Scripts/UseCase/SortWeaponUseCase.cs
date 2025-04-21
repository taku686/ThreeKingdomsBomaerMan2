using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Manager.DataManager;
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
            var sortType = _weaponSortRepository.GetSortTypeDictionary().Where(keyValue => keyValue.Value).Select(keyValue => keyValue.Key).First();
            var filter = _weaponSortRepository.GetFilterTypeDictionary();
            if (!filter[WeaponType.None])
            {
                possessedWeaponDatum = possessedWeaponDatum
                    .Where(weapon => filter[weapon.Key.WeaponType])
                    .ToDictionary(weapon => weapon.Key, weapon => weapon.Value);
            }

            var isAscending = _weaponSortRepository.GetAscendingSwitch();

            var sortDatum = possessedWeaponDatum
                .OrderBy(weapon => weapon.Key.WeaponType)
                .ThenBy(weapon => weapon.Key.Rare)
                .ThenBy(weapon => weapon.Key.Id);
            var result = isAscending
                ? sortDatum
                    .OrderBy(weapon => WhichSortType(sortType, weapon))
                    .ToDictionary(weapon => weapon.Key, weapon => weapon.Value)
                : sortDatum
                    .OrderByDescending(weapon => WhichSortType(sortType, weapon))
                    .ToDictionary(weapon => weapon.Key, weapon => weapon.Value);

            return result;
        }

        private static float WhichSortType(WeaponSortRepository.SortType sortType, KeyValuePair<WeaponMasterData, int> weapon)
        {
            return sortType switch
            {
                WeaponSortRepository.SortType.WeaponType => (int)weapon.Key.WeaponType,
                WeaponSortRepository.SortType.Rarity => weapon.Key.Rare,
                WeaponSortRepository.SortType.Possession => weapon.Value,
                WeaponSortRepository.SortType.Hp => GetStatus(weapon.Key.StatusSkillMasterDatum, StatusType.Hp),
                WeaponSortRepository.SortType.Attack => GetStatus(weapon.Key.StatusSkillMasterDatum, StatusType.Attack),
                WeaponSortRepository.SortType.Defense => GetStatus(weapon.Key.StatusSkillMasterDatum, StatusType.Defense),
                WeaponSortRepository.SortType.Speed => GetStatus(weapon.Key.StatusSkillMasterDatum, StatusType.Speed),
                WeaponSortRepository.SortType.Resistance => GetStatus(weapon.Key.StatusSkillMasterDatum, StatusType.Resistance),
                WeaponSortRepository.SortType.BombCount => GetStatus(weapon.Key.StatusSkillMasterDatum, StatusType.BombLimit),
                WeaponSortRepository.SortType.Fire => GetStatus(weapon.Key.StatusSkillMasterDatum, StatusType.FireRange),
                WeaponSortRepository.SortType.None => weapon.Key.Rare,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static float GetStatus(SkillMasterData[] skillMasterDatum, StatusType statusType)
        {
            if (skillMasterDatum == null || skillMasterDatum.Length == 0)
            {
                return GameCommonData.InvalidNumber;
            }

            foreach (var skillMasterData in skillMasterDatum)
            {
                var candidate = SkillMasterDataRepository.GetStatusSkillValue(skillMasterData);
                if (candidate.Item1 == statusType)
                {
                    return candidate.Item2;
                }
            }

            return GameCommonData.InvalidNumber;
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}