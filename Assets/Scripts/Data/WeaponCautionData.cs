using System;
using System.Collections.Generic;

namespace Data
{
    public class WeaponCautionData : IDisposable
    {
        public Dictionary<int, bool> _CautionDictionary;

        public WeaponCautionData(Dictionary<int, bool> cautionDictionary)
        {
            _CautionDictionary = cautionDictionary;
        }

        public void Dispose()
        {
            _CautionDictionary.Clear();
        }
    }
}