using System;
using System.Collections.Generic;
using Common.Data;

namespace Manager.DataManager
{
    public class SkillMasterDataRepository : IDisposable
    {
        private readonly List<SkillMasterData> _skillDatum = new();

        public void AddSkillData(SkillMasterData masterData)
        {
            if (_skillDatum.Contains(masterData))
            {
                return;
            }

            _skillDatum.Add(masterData);
        }

        public SkillMasterData GetSkillData(int id)
        {
            return _skillDatum.Find(data => data.Id == id);
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}