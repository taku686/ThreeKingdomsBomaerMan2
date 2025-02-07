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
            { SortType.Attribute, false },
            { SortType.Skill, false },
            { SortType.Slot, false },
            { SortType.Set, false },
            { SortType.Favorite, false },
            { SortType.BombCount, false },
            { SortType.Fire, false },
            { SortType.None, true },
        };

        private readonly Dictionary<WeaponType, bool> _weaponFilterTypeDictionary = new()
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
            { WeaponType.None, true },
        };

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
                var filterTypeDictionary = new Dictionary<WeaponType, bool>(_weaponFilterTypeDictionary);
                foreach (var filter in filterTypeDictionary)
                {
                    _weaponFilterTypeDictionary[filter.Key] = false;
                }

                _weaponFilterTypeDictionary[WeaponType.None] = true;
                return;
            }

            var isActive = _weaponFilterTypeDictionary[filterType];
            _weaponFilterTypeDictionary[filterType] = !isActive;
            _weaponFilterTypeDictionary[WeaponType.None] = false;

            if(_weaponFilterTypeDictionary.Values.All(value => !value))
            {
                _weaponFilterTypeDictionary[WeaponType.None] = true;
            }
        }

        public IReadOnlyDictionary<SortType, bool> GetSortTypeDictionary()
        {
            return _sortTypeDictionary;
        }

        public IReadOnlyDictionary<WeaponType, bool> GetFilterTypeDictionary()
        {
            return _weaponFilterTypeDictionary;
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
            Attribute,
            Skill,
            Slot,
            Set,
            Favorite,
            BombCount,
            Fire
        }

        public void Dispose()
        {
            _weaponFilterTypeDictionary.Clear();
            _sortTypeDictionary.Clear();
        }
    }
}