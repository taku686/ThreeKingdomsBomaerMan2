using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Repository
{
    public class WeaponMasterDataRepository : IDisposable
    {
        private readonly List<WeaponMasterData> _weaponDataList = new();

        public void AddWeaponData(WeaponMasterData weaponMasterData)
        {
            var ids = _weaponDataList.Select(data => data.Id).ToArray();
            if (ids.Contains(weaponMasterData.Id))
            {
                return;
            }

            _weaponDataList.Add(weaponMasterData);
        }

        public IReadOnlyCollection<WeaponMasterData> GetAllWeaponData()
        {
            var result = _weaponDataList
                .OrderBy(data => data.WeaponType)
                .ThenBy(data => data.Id)
                .ToArray();
            return result;
        }

        public int GetWeaponRandomWeaponId()
        {
            var keys = _weaponDataList.Select(data => data.Id).ToArray();
            var index = Random.Range(0, keys.Length);
            return keys[index];
        }

        public WeaponMasterData GetWeaponData(int weaponId)
        {
            return _weaponDataList.Find(data => data.Id == weaponId);
        }

        public int GetRandomWeaponId()
        {
            var index = Random.Range(0, _weaponDataList.Count);
            return _weaponDataList[index].Id;
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}