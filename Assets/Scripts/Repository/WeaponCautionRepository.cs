using System;
using System.Collections.Generic;
using Common.Data;
using Data;
using UseCase;

namespace Repository
{
    public class WeaponCautionRepository : IDisposable
    {
        private WeaponCautionData _weaponCautionData;

        public void InitializeData()
        {
            if (!SaveLocalDataUseCase.ExitFile(GameCommonData._WeaponCautionDataPath))
            {
                _weaponCautionData = new WeaponCautionData(new Dictionary<int, bool>());
                SaveLocalDataUseCase.Save(_weaponCautionData, GameCommonData._WeaponCautionDataPath);
            }
            else
            {
                _weaponCautionData = SaveLocalDataUseCase.Load<WeaponCautionData>(GameCommonData._WeaponCautionDataPath);
            }
        }

        public void AddWeaponCautionData(int[] weaponIds)
        {
            foreach (var weaponId in weaponIds)
            {
                SetWeaponCautionData(weaponId, true);
            }
        }

        public void SetWeaponCautionData(int weaponId, bool isCaution)
        {
            _weaponCautionData._CautionDictionary[weaponId] = isCaution;
            SaveCautionData();
        }

        private void SaveCautionData()
        {
            SaveLocalDataUseCase.Save(_weaponCautionData, GameCommonData._WeaponCautionDataPath);
        }

        public Dictionary<int, bool> GetWeaponCaution()
        {
            return _weaponCautionData._CautionDictionary;
        }

        public bool HaveCaution()
        {
            return _weaponCautionData._CautionDictionary.ContainsValue(true);
        }

        public void Dispose()
        {
            // TODO マネージリソースをここで解放します
        }
    }
}