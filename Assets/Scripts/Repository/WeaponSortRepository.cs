using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Repository
{
    public class WeaponSortRepository : IDisposable
    {
        private readonly Dictionary<SortType, bool> _sortTypeDictionary = new()
        {
            { SortType.WeaponType, false },
            { SortType.Rarity, false },
            { SortType.Possession, false },
            { SortType.Hp, false },
            { SortType.Attack, false },
            { SortType.Defense, false },
            { SortType.Speed, false },
            { SortType.Resistance, false },
            { SortType.Skill, false },
            { SortType.Slot, false },
            { SortType.Set, false },
            { SortType.Favorite, false },
            { SortType.BombCount, false },
            { SortType.Fire, false },
            { SortType.None, true },
        };

        private readonly Dictionary<WeaponType, bool> _filterTypeDictionary = new()
        {
            { WeaponType.Spear, false },
            { WeaponType.Hammer, false },
            { WeaponType.Sword, false },
            { WeaponType.Knife, false },
            { WeaponType.Fan, false },
            { WeaponType.Bow, false },
            { WeaponType.Shield, false },
            { WeaponType.Axe, false },
            { WeaponType.Staff, false },
            { WeaponType.Scythe, false },
            { WeaponType.BigSword, false },
            { WeaponType.Crow, false },
            { WeaponType.Katana, false },
            { WeaponType.Lance, false },
            { WeaponType.None, true }
        };

        private bool _isAscending = true;

        public void SetSortType(SortType sortType)
        {
            var sortTypeDictionary = new Dictionary<SortType, bool>(_sortTypeDictionary);
            foreach (var sort in sortTypeDictionary)
            {
                _sortTypeDictionary[sort.Key] = sort.Key == sortType;
            }
        }

        public void SetFilterType(WeaponType filterType)
        {
            if (filterType == WeaponType.None)
            {
                var filterTypeDictionary = new Dictionary<WeaponType, bool>(_filterTypeDictionary);
                foreach (var filter in filterTypeDictionary)
                {
                    _filterTypeDictionary[filter.Key] = false;
                }

                _filterTypeDictionary[WeaponType.None] = true;
                return;
            }

            var isActive = _filterTypeDictionary[filterType];
            _filterTypeDictionary[filterType] = !isActive;
            _filterTypeDictionary[WeaponType.None] = false;

            if (_filterTypeDictionary.Values.All(value => !value))
            {
                _filterTypeDictionary[WeaponType.None] = true;
            }
        }

        public void ChangeAscendingSwitch(bool isOn)
        {
            _isAscending = isOn;
        }

        public bool GetAscendingSwitch()
        {
            return _isAscending;
        }

        public IReadOnlyDictionary<SortType, bool> GetSortTypeDictionary()
        {
            return _sortTypeDictionary;
        }

        public IReadOnlyDictionary<WeaponType, bool> GetFilterTypeDictionary()
        {
            return _filterTypeDictionary;
        }

        public enum SortType
        {
            None,
            WeaponType,
            Rarity,
            Possession,
            Hp,
            Attack,
            Defense,
            Speed,
            Resistance,
            Skill,
            Slot,
            Set,
            Favorite,
            BombCount,
            Fire
        }

        public void Dispose()
        {
            _filterTypeDictionary.Clear();
            _sortTypeDictionary.Clear();
        }
    }
}