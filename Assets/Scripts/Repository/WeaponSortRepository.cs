using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Data;
using UseCase;

namespace Repository
{
    public class WeaponSortRepository : IDisposable
    {
        private SortWeaponData _sortWeaponData;

        public void InitializeData()
        {
            if (!SaveLocalDataUseCase.ExitFile(GameCommonData._SortWeaponDataPath))
            {
                var sortTypeDictionary = new Dictionary<SortType, bool>
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
                    { SortType.Id, false },
                    { SortType.Name, false },
                    { SortType.None, true },
                };

                var filterTypeDictionary = new Dictionary<WeaponType, bool>
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

                var rarityFilterDictionary = new Dictionary<int, bool>
                {
                    { 1, false },
                    { 2, false },
                    { 3, false },
                    { 4, false },
                    { 5, false },
                    { GameCommonData.InvalidNumber, true }
                };

                const bool isAscending = true;

                var data = new SortWeaponData
                (
                    sortTypeDictionary,
                    filterTypeDictionary,
                    rarityFilterDictionary,
                    isAscending
                );

                SaveLocalDataUseCase.Save(data, GameCommonData._SortWeaponDataPath);
                _sortWeaponData = data;
            }

            _sortWeaponData = SaveLocalDataUseCase.Load<SortWeaponData>(GameCommonData._SortWeaponDataPath);
        }

        public void SetSortType(SortType sortType)
        {
            var sortTypeDictionary = _sortWeaponData._SortTypeDictionary;
            var sortTypeDictionaryClone = new Dictionary<SortType, bool>(sortTypeDictionary);
            foreach (var sort in sortTypeDictionaryClone)
            {
                sortTypeDictionary[sort.Key] = sort.Key == sortType;
            }

            SaveLocalData(_sortWeaponData);
        }

        public void SetFilterType(WeaponType filterType)
        {
            var filterTypeDictionary = _sortWeaponData._FilterTypeDictionary;
            if (filterType == WeaponType.None)
            {
                var filterTypeDictionaryClone = new Dictionary<WeaponType, bool>(filterTypeDictionary);
                foreach (var filter in filterTypeDictionaryClone)
                {
                    filterTypeDictionary[filter.Key] = false;
                }

                filterTypeDictionary[WeaponType.None] = true;
                SaveLocalData(_sortWeaponData);
                return;
            }

            var isActive = filterTypeDictionary[filterType];
            filterTypeDictionary[filterType] = !isActive;
            filterTypeDictionary[WeaponType.None] = false;

            if (filterTypeDictionary.Values.All(value => !value))
            {
                filterTypeDictionary[WeaponType.None] = true;
            }

            SaveLocalData(_sortWeaponData);
        }

        public void SetRarity(int rarity)
        {
            var rarityFilterDictionary = _sortWeaponData._RarityFilterDictionary;
            if (rarity == GameCommonData.InvalidNumber)
            {
                var rarityFilterDictionaryClone = new Dictionary<int, bool>(rarityFilterDictionary);
                foreach (var filter in rarityFilterDictionaryClone)
                {
                    rarityFilterDictionary[filter.Key] = false;
                }

                rarityFilterDictionary[GameCommonData.InvalidNumber] = true;
                SaveLocalData(_sortWeaponData);
                return;
            }

            var isActive = rarityFilterDictionary[rarity];
            rarityFilterDictionary[rarity] = !isActive;
            rarityFilterDictionary[GameCommonData.InvalidNumber] = false;

            if (rarityFilterDictionary.Values.All(value => !value))
            {
                rarityFilterDictionary[GameCommonData.InvalidNumber] = true;
            }

            SaveLocalData(_sortWeaponData);
        }

        public void SetAscending(bool isOn)
        {
            _sortWeaponData._IsAscending = isOn;
            SaveLocalDataUseCase.Save(_sortWeaponData, GameCommonData._SortWeaponDataPath);
        }

        private void SaveLocalData(SortWeaponData sortWeaponData)
        {
            SaveLocalDataUseCase.Save(sortWeaponData, GameCommonData._SortWeaponDataPath);
        }

        public bool GetAscendingSwitch()
        {
            return _sortWeaponData._IsAscending;
        }

        public IReadOnlyDictionary<SortType, bool> GetSortTypeDictionary()
        {
            return _sortWeaponData._SortTypeDictionary;
        }

        public IReadOnlyDictionary<WeaponType, bool> GetFilterTypeDictionary()
        {
            return _sortWeaponData._FilterTypeDictionary;
        }

        public IReadOnlyDictionary<int, bool> GetRarityFilterTypeDictionary()
        {
            return _sortWeaponData._RarityFilterDictionary;
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
            Fire,
            Name,
            Id
        }

        public void Dispose()
        {
        }
    }
}