using System;
using System.Collections.Generic;

namespace Repository
{
    public class WeaponSortRepository : IDisposable
    {
        private readonly Dictionary<SortType, bool> _sortTypeDictionary = new()
        {
            { SortType.WeaponType, true },
            { SortType.Rarity, true },
            { SortType.Possession, true },
            { SortType.Hp, true },
            { SortType.Attack, true },
            { SortType.Defense, true },
            { SortType.Speed, true },
            { SortType.Resistance, true },
            { SortType.Element, true },
            { SortType.Skill, true },
            { SortType.Slot, true },
            { SortType.Set, true },
            { SortType.Favorite, true },
            { SortType.BombCount, true },
            { SortType.Fire, true },
            { SortType.None, false },
        };

        private readonly Dictionary<FilterType, bool> _filterTypeDictionary = new()
        {
            { FilterType.Spear, true },
            { FilterType.Hammer, true },
            { FilterType.Sword, true },
            { FilterType.Knife, true },
            { FilterType.Fan, true },
            { FilterType.Bow, true },
            { FilterType.Shield, true },
            { FilterType.Axe, true },
            { FilterType.Staff, true },
            { FilterType.Scythe, true },
            { FilterType.BigSword, true },
            { FilterType.None, false },
        };

        public void SetSortType(SortType sortType)
        {
            var sortTypeDictionary = new Dictionary<SortType, bool>(_sortTypeDictionary);
            foreach (var sort in sortTypeDictionary)
            {
                _sortTypeDictionary[sort.Key] = sort.Key != sortType;
            }
        }

        public void SetFilterType(FilterType filterType)
        {
            var isActive = _filterTypeDictionary[filterType];
            _filterTypeDictionary[filterType] = !isActive;
        }

        public IReadOnlyDictionary<SortType, bool> GetSortTypeDictionary()
        {
            return _sortTypeDictionary;
        }

        public IReadOnlyDictionary<FilterType, bool> GetFilterTypeDictionary()
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
            Element,
            Skill,
            Slot,
            Set,
            Favorite,
            BombCount,
            Fire
        }

        public enum FilterType
        {
            Spear = 0,
            Hammer = 1,
            Sword = 2,
            Knife = 3,
            Fan = 4,
            Bow = 5,
            Shield = 6,
            Axe = 7,
            Staff = 8,
            Scythe = 9,
            BigSword = 10,
            None = 999,
        }

        public void Dispose()
        {
            _filterTypeDictionary.Clear();
            _sortTypeDictionary.Clear();
        }
    }
}