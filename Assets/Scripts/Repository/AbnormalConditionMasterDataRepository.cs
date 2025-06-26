using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;

namespace Repository
{
    public class AbnormalConditionMasterDataRepository : IDisposable
    {
        private readonly List<AbnormalConditionMasterData> _abnormalConditionMasterDatum = new();

        public void AddAbnormalConditionMasterData(AbnormalConditionMasterData abnormalConditionMasterData)
        {
            if (_abnormalConditionMasterDatum.Contains(abnormalConditionMasterData))
            {
                return;
            }

            _abnormalConditionMasterDatum.Add(abnormalConditionMasterData);
        }

        public AbnormalConditionMasterData GetAbnormalConditionMasterData(AbnormalCondition abnormalCondition)
        {
            return _abnormalConditionMasterDatum.FirstOrDefault(x => x.Id == (int)abnormalCondition);
        }

        public void Dispose()
        {
            _abnormalConditionMasterDatum.Clear();
        }
    }
}