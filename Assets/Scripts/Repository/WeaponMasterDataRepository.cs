using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Repository
{
    public class WeaponMasterDataRepository : IDisposable
    {
        private readonly List<WeaponMasterData> _weaponDataList = new();

        public void AddWeaponData(WeaponMasterData weaponMasterData)
        {
            if (_weaponDataList.Contains(weaponMasterData))
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

        public WeaponMasterData GetWeaponData(int weaponId)
        {
            return _weaponDataList.Find(data => data.Id == weaponId);
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}