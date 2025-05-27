using System;
using System.Collections.Generic;
using Common.Data;
using Repository;

namespace Data
{
    public class SortWeaponData : IDisposable
    {
        public Dictionary<WeaponSortRepository.SortType, bool> _SortTypeDictionary;

        public Dictionary<WeaponType, bool> _FilterTypeDictionary;

        public Dictionary<int, bool> _RarityFilterDictionary;

        public bool _IsAscending;

        public SortWeaponData
        (
            Dictionary<WeaponSortRepository.SortType, bool> sortTypeDictionary,
            Dictionary<WeaponType, bool> filterTypeDictionary,
            Dictionary<int, bool> rarityFilterDictionary,
            bool isAscending
        )
        {
            _SortTypeDictionary = sortTypeDictionary;
            _FilterTypeDictionary = filterTypeDictionary;
            _RarityFilterDictionary = rarityFilterDictionary;
            _IsAscending = isAscending;
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}